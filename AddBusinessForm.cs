namespace ProfitCalculatorApp
{
    public partial class AddBusinessForm : Form
    {
        // HomeForm is passed in so this dialog can push changes back to the main list.
        private HomeForm _homeForm;

        // These fields let one form handle both creating a new business
        // and editing an existing one.
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

            // If a business was supplied, Save should update that object instead of creating a new one.
            _isEditMode = true;
        }


        private void AddBusinessForm_Load(object sender, EventArgs e)
        {
            // Populate the business type choices each time the form opens.
            cboBusinessType.Items.Clear();
            cboBusinessType.Items.Add("Sales");
            cboBusinessType.Items.Add("Service");

            if (cboBusinessType.Items.Count > 0)
            {
                cboBusinessType.SelectedIndex = 0;
            }

            // Populate the list of supported state abbreviations.
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
                // In edit mode, preload the current values so the user can revise them.
                txtBusinessName.Text = _editingBusiness.Name;
                cboBusinessType.SelectedItem = _editingBusiness.Type;
                cboState.SelectedItem = _editingBusiness.State;
                txtTaxRate.Text = _editingBusiness.TaxRate.ToString();

                chkIsGreyMarket.Checked = _editingBusiness.IsGreyMarket;
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {
            // The label is informational only and does not need click behavior.
        }

        private void cboState_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If grey market is not checked, the tax field should remain editable
            // regardless of which state is selected.
            if (!chkIsGreyMarket.Checked)
            {
                txtTaxRate.Enabled = true;
            }

        }

        private void chkIsGreyMarket_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsGreyMarket.Checked)
            {
                // Grey market businesses are treated as untaxed, so the visible rate is forced to zero.
                txtTaxRate.Text = "0";
                txtTaxRate.Enabled = false;
            }
            else
            {
                // Re-enable manual tax entry when the business is not grey market.
                txtTaxRate.Enabled = true;
            }
        }

        private void btnSaveBusiness_Click(object sender, EventArgs e)
        {
            // Trim the name so accidental spaces do not become part of the saved value.
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
                // Edit mode updates the same object instance so any open forms still point to the correct business.
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
                // Create a brand-new business record for the home screen list.
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

            // Close the dialog after the business has been saved.
            this.Close();

        }

    }
}
