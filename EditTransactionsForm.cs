namespace ProfitCalculatorApp
{
    public partial class EditTransactionsForm : Form
    {
        public EditTransactionsForm(DateTime date, string clientName, decimal revenue, decimal cost)
        {
            InitializeComponent();

            // Pre-fill the editor so the user can adjust the existing values instead of retyping them.
            dtpEditDate.Value = date;
            txtEditClientName.Text = clientName;
            txtEditRevenue.Text = revenue.ToString();
            txtEditCost.Text = cost.ToString();
        }


        // These properties carry the approved edits back to BusinessForm after the dialog closes.
        public DateTime EditedDate { get; private set; }
        public string EditedClientName { get; private set; }
        public decimal EditedRevenue { get; private set; }
        public decimal EditedCost { get; private set; }



        private void label1_Click(object sender, EventArgs e)
        {
            // The label is informational only.
        }

        private void EditTransactionsForm_Load(object sender, EventArgs e)
        {
            // No additional setup is needed beyond the constructor values.
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Trim the name so accidental spaces do not become part of the saved client value.
            string clientName = txtEditClientName.Text.Trim();

            if (clientName == "")
            {
                MessageBox.Show("Please enter a client name.");
                return;
            }

            decimal revenue = 0;
            decimal cost = 0;

            try
            {
                // Revenue is required, while cost can be left blank and treated as zero.
                revenue = decimal.Parse(txtEditRevenue.Text);

                if (txtEditCost.Text.Trim() != "")
                {
                    cost = decimal.Parse(txtEditCost.Text);
                }
                else
                {
                    cost = 0;
                }
            }
            catch
            {
                MessageBox.Show("Please enter valid numbers for revenue and cost.");
                return;
            }

            // Store the validated edits so the calling form can read them after this dialog closes.
            EditedDate = dtpEditDate.Value.Date;
            EditedClientName = clientName;
            EditedRevenue = revenue;
            EditedCost = cost;

            // OK tells the calling form that validation passed and the edited values are ready to use.
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Cancel closes the dialog without changing the original transaction.
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
