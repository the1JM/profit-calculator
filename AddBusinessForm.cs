namespace ProfitCalculatorApp
{
    public partial class AddBusinessForm : Form
    {



        private HomeForm _homeForm;

        private Business? _editingBusiness;
        private bool _isEditMode = false;


        public AddBusinessForm(HomeForm homeForm)
        {


            InitializeComponent();
            _homeForm = homeForm;

        }

        public AddBusinessForm(HomeForm homeForm, Business businessToEdit)
        {
            InitializeComponent();
            _homeForm = homeForm;
            _editingBusiness = businessToEdit;
            _isEditMode = true;
        }


        private void AddBusinessForm_Load(object sender, EventArgs e)
        {

            // Business types
            cboBusinessType.Items.Clear();
            cboBusinessType.Items.Add("Sales");
            cboBusinessType.Items.Add("Service");

            if (cboBusinessType.Items.Count > 0)
            {
                cboBusinessType.SelectedIndex = 0;
            }

            // States list
            cboState.Items.Clear();
            cboState.Items.AddRange(new string[]
            {
                 "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE",
                 "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS",
                 "KY", "LA", "ME", "MD", "MA", "MI", "MN", "MS",
                 "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY",
                 "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC",
                 "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV",
                 "WI", "WY", "DC"
            });

            if (cboState.Items.Count > 0)
            {
                cboState.SelectedIndex = 0;
            }

            if (_isEditMode && _editingBusiness != null)
            {
                txtBusinessName.Text = _editingBusiness.Name;
                cboBusinessType.SelectedItem = _editingBusiness.Type;
                cboState.SelectedItem = _editingBusiness.State;
                txtTaxRate.Text = _editingBusiness.TaxRate.ToString();

                chkIsGreyMarket.Checked = _editingBusiness.IsGreyMarket;
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cboState_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!chkIsGreyMarket.Checked)
            {
                txtTaxRate.Enabled = true;
            }

        }

        private void chkIsGreyMarket_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsGreyMarket.Checked)
            {
                txtTaxRate.Text = "0";
                txtTaxRate.Enabled = false;
            }
            else
            {
                txtTaxRate.Enabled = true;
            }
        }

        private void btnSaveBusiness_Click(object sender, EventArgs e)
        {
            string name = txtBusinessName.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a business name.");
                return;
            }

            if (cboBusinessType.SelectedItem == null)
            {
                MessageBox.Show("Please select a business type.");
                return;
            }

            if (cboState.SelectedItem == null)
            {
                MessageBox.Show("Please select a state.");
                return;
            }

            if (!decimal.TryParse(txtTaxRate.Text.Trim(), out decimal taxRate) || taxRate < 0)
            {
                MessageBox.Show("Please enter a valid tax rate.");
                return;
            }

            Business business;

            if (_isEditMode && _editingBusiness != null)
            {
                business = _editingBusiness;
                business.Name = name;
                business.Type = cboBusinessType.SelectedItem.ToString();
                business.State = cboState.SelectedItem.ToString();
                business.TaxRate = taxRate;
                business.IsGreyMarket = chkIsGreyMarket.Checked;

                _homeForm.RefreshBusinessList();
                _homeForm.SaveBusinessesToFile();
            }
            else
            {
                // Add new business
                business = new Business
                {
                    Name = name,
                    Type = cboBusinessType.SelectedItem.ToString(),
                    State = cboState.SelectedItem.ToString(),
                    TaxRate = taxRate,
                    IsGreyMarket = chkIsGreyMarket.Checked
                };

                _homeForm.AddBusiness(business);
                _homeForm.SaveBusinessesToFile();
            }

            this.Close();

        }

    }
}
