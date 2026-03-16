namespace ProfitCalculatorApp
{
    public partial class EditTransactionsForm : Form
    {
        public EditTransactionsForm(DateTime date, string clientName, decimal revenue, decimal cost)
        {
            InitializeComponent();

            dtpEditDate.Value = date;
            txtEditClientName.Text = clientName;
            txtEditRevenue.Text = revenue.ToString();
            txtEditCost.Text = cost.ToString();
        }


        public DateTime EditedDate { get; private set; }
        public string EditedClientName { get; private set; }
        public decimal EditedRevenue { get; private set; }
        public decimal EditedCost { get; private set; }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EditTransactionsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
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

            EditedDate = dtpEditDate.Value.Date;
            EditedClientName = clientName;
            EditedRevenue = revenue;
            EditedCost = cost;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
