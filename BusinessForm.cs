using System.ComponentModel;
using System.Data;

namespace ProfitCalculatorApp
{
    public partial class BusinessForm : Form
    {

        private HomeForm? _homeForm;

        private Business? _business;



        private void UpdateTransactionInputVisibility()
        {
            if (_business == null)
            {
                return;
            }

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
                this.Text = $"Business - {_business.Name}";
            }
        }


        private void RefreshTransactionGrid()
        {
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
                int rowIndex = dgvTransactions.Rows.Add(
                    t.Date.ToShortDateString(),
                    t.ClientName,
                    t.Revenue.ToString("C2"),
                    t.Tax.ToString("C2"),
                    t.Profit.ToString("C2")
                );

                dgvTransactions.Rows[rowIndex].Tag = t;
            }


            UpdateTransactionTotals();
        }






        private void UpdateTransactionTotals()
        {
            if (_business == null)
            {
                return;
            }

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


            lblBusinessName.Text = "Name: " + _business.Name;
            lblBusinessType.Text = "Type: " + _business.Type;
            lblBusinessState.Text = "State: " + _business.State;
            lblBusinessTaxRate.Text = "Tax Rate: " + _business.TaxRate;

            UpdateTransactionInputVisibility();

            RefreshTransactionGrid();


        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteBusiness_Click(object sender, EventArgs e)
        {
            if (_homeForm == null || _business == null)
            {
                return;
            }

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

        }

        private void btnEditBusiness_Click(object sender, EventArgs e)
        {
            if (_homeForm == null || _business == null)
            {
                return;
            }

            AddBusinessForm editForm = new AddBusinessForm(_homeForm, _business);

            editForm.TopMost = true;

            editForm.ShowDialog(this);

            // After the edit window closes, _business has been updated.
            // Now refresh the UI to match the new values.
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

        }

        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            if (_business == null)
            {
                return;
            }

            // Common fields
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
                    decimal saleAmount = decimal.Parse(txtSaleAmount.Text);
                    revenue = saleAmount;

                    if (txtSalesCost.Text != "")
                    {
                        cost = decimal.Parse(txtSalesCost.Text);
                    }
                }
                else // Service
                {
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
                MessageBox.Show("Please enter valid numbers.");
                return;
            }

            // Tax
            decimal tax = 0;

            if (_business.IsGreyMarket == false)
            {
                tax = revenue * (_business.TaxRate / 100);
            }

            // Profit
            decimal profit = revenue - cost - tax;

            // Create transaction object
            Transaction transaction = new Transaction();
            transaction.Date = date;
            transaction.ClientName = clientName;
            transaction.Revenue = revenue;
            transaction.Tax = tax;
            transaction.Profit = profit;


            // Clear inputs
            txtClientName.Clear();
            txtSaleAmount.Clear();
            txtSalesCost.Clear();
            txtHoursWorked.Clear();
            txtHourlyRate.Clear();
            txtServiceCost.Clear();

            _business.Transactions.Add(transaction);

            MessageBox.Show("Transaction added.");

            RefreshTransactionGrid();

            if (_homeForm != null)
            {
                _homeForm.SaveTransactionsToFile();
            }


            // Clear inputs
            txtClientName.Clear();



        }

        private void dgvTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }



        private void dgvTransactions_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dgvTransactions.HitTest(e.X, e.Y);

                if (hit.RowIndex >= 0)
                {
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

            // Rebuild cost from existing values
            decimal cost = t.Revenue - t.Tax - t.Profit;
            if (cost < 0)
            {
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

            _business.Transactions.Remove(t);

            RefreshTransactionGrid();

            if (_homeForm != null)
            {
                _homeForm.SaveTransactionsToFile();
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void rdoWeek_CheckedChanged(object sender, EventArgs e)
        {
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

            if (!rdoWeek.Checked && !rdoMonth.Checked && !rdoYear.Checked)
            {
                MessageBox.Show("Please select Week, Month, or Year.");
                return;
            }

            DateTime startDate;
            DateTime endDate;

            if (rdoWeek.Checked)
            {
                // Treat week as Monday to Sunday
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
                DateTime chosen = dtpMonth.Value;
                int year = chosen.Year;
                int month = chosen.Month;

                startDate = new DateTime(year, month, 1);
                endDate = startDate.AddMonths(1).AddDays(-1);
            }
            else // Year
            {
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
                    totalRevenue += t.Revenue;
                    totalTax += t.Tax;
                    totalProfit += t.Profit;
                }
            }

            lblReportTotalRevenueValue.Text = totalRevenue.ToString("C2");
            lblReportTotalTaxValue.Text = totalTax.ToString("C2");
            lblReportTotalProfitValue.Text = totalProfit.ToString("C2");
        }

        private void Fill(object sender, DataGridViewAutoSizeColumnModeEventArgs e)
        {

        }
    }
}
