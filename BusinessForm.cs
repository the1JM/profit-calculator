using System.ComponentModel;
using System.Data;

namespace ProfitCalculatorApp
{
    public partial class BusinessForm : Form
    {
        // A reference back to HomeForm lets this screen trigger saves
        // and business-level actions such as deleting the current business.
        private HomeForm? _homeForm;

        // This is the specific business the user is currently working with.
        private Business? _business;



        private void UpdateTransactionInputVisibility()
        {
            if (_business == null)
            {
                return;
            }

            // Sales and service businesses gather transaction data differently,
            // so only the relevant input group should be enabled.
            if (_business.Type == "Sales")
            {
                grpSalesFields.Enabled = true;
                grpServiceFields.Enabled = false;
            }
            else
            {
                grpSalesFields.Enabled = false;
                grpServiceFields.Enabled = true;
            }
        }



        public BusinessForm(HomeForm homeForm, Business business)
        {
            InitializeComponent();
            _homeForm = homeForm;
            _business = business;

            if (_business != null)
            {
                // Putting the business name in the title bar makes multiple open windows easier to identify.
                this.Text = $"Business - {_business.Name}";
            }
        }


        private void RefreshTransactionGrid()
        {
            // Rebuild the grid from scratch so it always reflects the current transaction list.
            dgvTransactions.Rows.Clear();

            if (_business == null)
            {
                return;
            }

            var sortedTransactions = _business.Transactions
                .OrderByDescending(t => t.Date)
                .ToList();

            foreach (Transaction t in sortedTransactions)
            {
                // Currency formatting makes the transaction history read more like a financial summary.
                int rowIndex = dgvTransactions.Rows.Add(
                    t.Date.ToShortDateString(),
                    t.ClientName,
                    t.Revenue.ToString("C2"),
                    t.Tax.ToString("C2"),
                    t.Profit.ToString("C2")
                );

                // Store the original transaction object on the row so edit/delete actions
                // can find the exact record the user clicked.
                dgvTransactions.Rows[rowIndex].Tag = t;
            }


            // Every grid refresh also updates the running totals shown below it.
            UpdateTransactionTotals();
        }






        private void UpdateTransactionTotals()
        {
            if (_business == null)
            {
                return;
            }

            // These totals summarize the entire transaction history for the selected business.
            decimal totalRevenue = 0;
            decimal totalProfit = 0;

            foreach (Transaction t in _business.Transactions)
            {
                totalRevenue += t.Revenue;
                totalProfit += t.Profit;
            }

            lblTotalRevenueValue.Text = totalRevenue.ToString("C2");
            lblTotalProfitValue.Text = totalProfit.ToString("C2");
        }

        private void UpdateReportControls()
        {
            // Only the input control for the currently selected report mode should be active.
            bool isWeek = rdoWeek.Checked;
            bool isMonth = rdoMonth.Checked;
            bool isYear = rdoYear.Checked;

            dtpWeekDate.Enabled = isWeek;
            dtpMonth.Enabled = isMonth;
            numYear.Enabled = isYear;
        }


        private void BusinessForm_Load(object sender, EventArgs e)
        {
            if (_business == null)
            {
                MessageBox.Show("Business is null in Load");
                return;
            }


            // Copy the business profile into the header labels when the form opens.
            lblBusinessName.Text = "Name: " + _business.Name;
            lblBusinessType.Text = "Type: " + _business.Type;
            lblBusinessState.Text = "State: " + _business.State;
            lblBusinessTaxRate.Text = "Tax Rate: " + _business.TaxRate;

            UpdateTransactionInputVisibility();

            // Load the business history into the grid immediately.
            RefreshTransactionGrid();


        }



        private void label1_Click(object sender, EventArgs e)
        {
            // This label does not need click behavior.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // This generated handler is currently unused.
        }

        private void btnDeleteBusiness_Click(object sender, EventArgs e)
        {
            if (_homeForm == null || _business == null)
            {
                return;
            }

            // Ask for confirmation because deleting a business also updates the saved file.
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this business?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                _homeForm.DeleteBusiness(_business);
                this.Close();
            }
        }

        private void BusinessForm_Click(object sender, EventArgs e)
        {
            // Clicking the form background has no custom behavior.
        }

        private void btnEditBusiness_Click(object sender, EventArgs e)
        {
            if (_homeForm == null || _business == null)
            {
                return;
            }

            // Reuse AddBusinessForm in edit mode so business details are maintained in one place.
            AddBusinessForm editForm = new AddBusinessForm(_homeForm, _business);

            editForm.TopMost = true;

            editForm.ShowDialog(this);

            // After the dialog closes, the same business object may now contain new values,
            // so refresh the title and header labels to match it.
            this.Text = $"Business - {_business.Name}";
            lblBusinessName.Text = $"Name: {_business.Name}";
            lblBusinessType.Text = $"Type: {_business.Type}";
            lblBusinessState.Text = $"State: {_business.State}";
            lblBusinessTaxRate.Text = $"Tax Rate: {_business.TaxRate}";

            UpdateTransactionInputVisibility();
            this.Refresh();

            
        }


        private void grpSalesFields_Enter(object sender, EventArgs e)
        {
            // No extra behavior is needed when the sales group gains focus.
        }

        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            if (_business == null)
            {
                return;
            }

            // These fields are shared by both sales and service transactions.
            DateTime date = dtpTransactionDate.Value.Date;
            string clientName = txtClientName.Text.Trim();

            if (clientName == "")
            {
                MessageBox.Show("Please enter a client name.");
                return;
            }

            decimal revenue = 0;
            decimal cost = 0;

            try
            {
                if (_business.Type == "Sales")
                {
                    // Sales businesses enter revenue directly as a sale amount.
                    decimal saleAmount = decimal.Parse(txtSaleAmount.Text);
                    revenue = saleAmount;

                    if (txtSalesCost.Text != "")
                    {
                        // Cost is optional, but if entered it reduces the final profit.
                        cost = decimal.Parse(txtSalesCost.Text);
                    }
                }
                else // Service
                {
                    // Service revenue is calculated from hours worked multiplied by hourly rate.
                    decimal hoursWorked = decimal.Parse(txtHoursWorked.Text);
                    decimal hourlyRate = decimal.Parse(txtHourlyRate.Text);

                    revenue = hoursWorked * hourlyRate;

                    if (txtServiceCost.Text != "")
                    {
                        cost = decimal.Parse(txtServiceCost.Text);
                    }
                }
            }
            catch
            {
                // Any parse failure means one of the numeric entry fields was not valid.
                MessageBox.Show("Please enter valid numbers.");
                return;
            }

            // Tax is only applied when the business is not marked as grey market.
            decimal tax = 0;

            if (_business.IsGreyMarket == false)
            {
                tax = revenue * (_business.TaxRate / 100);
            }

            // Profit is what remains after subtracting cost and tax from revenue.
            decimal profit = revenue - cost - tax;

            // Package the finished values into a transaction record for storage.
            Transaction transaction = new Transaction();
            transaction.Date = date;
            transaction.ClientName = clientName;
            transaction.Revenue = revenue;
            transaction.Tax = tax;
            transaction.Profit = profit;


            // Clear the entry fields so the user can immediately add another transaction.
            txtClientName.Clear();
            txtSaleAmount.Clear();
            txtSalesCost.Clear();
            txtHoursWorked.Clear();
            txtHourlyRate.Clear();
            txtServiceCost.Clear();

            _business.Transactions.Add(transaction);

            MessageBox.Show("Transaction added.");

            // Redraw the grid and totals now that the business history changed.
            RefreshTransactionGrid();

            if (_homeForm != null)
            {
                // Save after each successful add so the new transaction survives the next restart.
                _homeForm.SaveTransactionsToFile();
            }


            // This second clear is redundant in practice, but it guarantees the client box stays empty.
            txtClientName.Clear();



        }

        private void dgvTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Cell clicks rely on the grid's normal behavior only.
        }



        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            // The context menu uses its default opening behavior.
        }



        private void dgvTransactions_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dgvTransactions.HitTest(e.X, e.Y);

                if (hit.RowIndex >= 0)
                {
                    // Right-click also selects the row under the cursor so edit/delete acts on the intended item.
                    dgvTransactions.ClearSelection();
                    dgvTransactions.Rows[hit.RowIndex].Selected = true;
                    dgvTransactions.CurrentCell = dgvTransactions.Rows[hit.RowIndex].Cells[0];
                }
            }
        }

        private void editTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_business == null)
            {
                return;
            }

            if (dgvTransactions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transaction to edit.");
                return;
            }

            DataGridViewRow row = dgvTransactions.SelectedRows[0];

            Transaction t = row.Tag as Transaction;
            if (t == null)
            {
                MessageBox.Show("Could not find the selected transaction.");
                return;
            }

            // Cost is not stored directly, so it is reconstructed from the saved transaction math.
            decimal cost = t.Revenue - t.Tax - t.Profit;
            if (cost < 0)
            {
                // A negative reconstructed cost would not make practical sense, so clamp it to zero.
                cost = 0;
            }

            EditTransactionsForm editForm = new EditTransactionsForm(
                t.Date,
                t.ClientName,
                t.Revenue,
                cost
            );

            editForm.TopMost = true;
            DialogResult result = editForm.ShowDialog(this);

            if (result != DialogResult.OK)
            {
                return;
            }

            t.Date = editForm.EditedDate;
            t.ClientName = editForm.EditedClientName;
            t.Revenue = editForm.EditedRevenue;

            decimal editedCost = editForm.EditedCost;

            // Recalculate tax and profit from the edited values so the transaction stays consistent.
            decimal taxRateToUse = 0;
            if (_business.IsGreyMarket == false)
            {
                taxRateToUse = _business.TaxRate;
            }

            t.Tax = t.Revenue * (taxRateToUse / 100);
            t.Profit = t.Revenue - editedCost - t.Tax;

            RefreshTransactionGrid();

            if (_homeForm != null)
            {
                // Save immediately so edits are not lost if the app closes next.
                _homeForm.SaveTransactionsToFile();
            }
        }


        private void deleteTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_business == null)
            {
                return;
            }

            if (dgvTransactions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transaction to delete.");
                return;
            }

            DataGridViewRow row = dgvTransactions.SelectedRows[0];

            Transaction t = row.Tag as Transaction;
            if (t == null)
            {
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to delete this transaction?",
                "Confirm Delete",
                MessageBoxButtons.YesNo
            );

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            // Remove the chosen transaction, then refresh and persist the updated history.
            _business.Transactions.Remove(t);

            RefreshTransactionGrid();

            if (_homeForm != null)
            {
                _homeForm.SaveTransactionsToFile();
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // The chosen date is read when a transaction or report is submitted.
        }

        private void rdoWeek_CheckedChanged(object sender, EventArgs e)
        {
            // Switching report modes changes which date input control should be enabled.
            UpdateReportControls();
        }

        private void rdoMonth_CheckedChanged(object sender, EventArgs e)
        {
            UpdateReportControls();
        }

        private void rdoYear_CheckedChanged(object sender, EventArgs e)
        {
            UpdateReportControls();
        }

        private void btnCalculateReport_Click(object sender, EventArgs e)
        {
            if (_business == null)
            {
                return;
            }

            // The user must choose whether the report should cover a week, month, or year.
            if (!rdoWeek.Checked && !rdoMonth.Checked && !rdoYear.Checked)
            {
                MessageBox.Show("Please select Week, Month, or Year.");
                return;
            }

            DateTime startDate;
            DateTime endDate;

            if (rdoWeek.Checked)
            {
                // This project treats a week as Monday through Sunday.
                DateTime chosen = dtpWeekDate.Value.Date;
                int diff = (int)chosen.DayOfWeek - (int)DayOfWeek.Monday;
                if (diff < 0)
                {
                    diff += 7;
                }

                startDate = chosen.AddDays(-diff);
                endDate = startDate.AddDays(6);
            }
            else if (rdoMonth.Checked)
            {
                // A month report covers the full selected month from the first day to the last.
                DateTime chosen = dtpMonth.Value;
                int year = chosen.Year;
                int month = chosen.Month;

                startDate = new DateTime(year, month, 1);
                endDate = startDate.AddMonths(1).AddDays(-1);
            }
            else // Year
            {
                // A year report covers January 1 through December 31 of the chosen year.
                int year = (int)numYear.Value;

                startDate = new DateTime(year, 1, 1);
                endDate = new DateTime(year, 12, 31);
            }

            decimal totalRevenue = 0;
            decimal totalTax = 0;
            decimal totalProfit = 0;

            foreach (Transaction t in _business.Transactions)
            {
                DateTime d = t.Date.Date;

                if (d >= startDate && d <= endDate)
                {
                    // Only transactions inside the selected time window count toward the report.
                    totalRevenue += t.Revenue;
                    totalTax += t.Tax;
                    totalProfit += t.Profit;
                }
            }

            // Show the completed totals in the report section of the form.
            lblReportTotalRevenueValue.Text = totalRevenue.ToString("C2");
            lblReportTotalTaxValue.Text = totalTax.ToString("C2");
            lblReportTotalProfitValue.Text = totalProfit.ToString("C2");
        }

        private void Fill(object sender, DataGridViewAutoSizeColumnModeEventArgs e)
        {
            // No custom column auto-size behavior is needed here.
        }
    }
}
