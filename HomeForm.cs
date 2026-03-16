namespace ProfitCalculatorApp
{


    public partial class HomeForm : Form
    {
        private static int openAddBusinessWindows = 0;

        private readonly List<Business> _businesses = new List<Business>();


        public HomeForm()
        {
            InitializeComponent();
            LoadBusinessesFromFile();
            LoadTransactionsFromFile();
        }


        private void AddBusinessFormClosed(object sender, FormClosedEventArgs e)
        {
            openAddBusinessWindows--;

        }


        public void AddBusiness(Business business)
        {
            if (business == null)
            {
                return;
            }

            _businesses.Add(business);
            RefreshBusinessList();
        }


        public void DeleteBusiness(Business business)
        {
            if (business == null)
            {
                return;
            }

            int index = _businesses.IndexOf(business);
            if (index < 0)
            {
                return;
            }

            _businesses.RemoveAt(index);

            RefreshBusinessList();
            SaveBusinessesToFile();
        }



        public void RefreshBusinessList()
        {
            lstBusinesses.Items.Clear();

            foreach (var business in _businesses)
            {
                lstBusinesses.Items.Add(business.Name);
            }
        }




        public void SaveBusinessesToFile()
        {
            string filePath = Path.Combine(Application.StartupPath, "businesses.txt");

            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (var business in _businesses)
                {
                    string line = string.Join("|",
                        business.Name ?? "",
                        business.Type ?? "",
                        business.State ?? "",
                        business.TaxRate.ToString(),
                        business.IsGreyMarket ? "1" : "0");

                    writer.WriteLine(line);
                }
            }
        }

        public void LoadBusinessesFromFile()
        {
            string filePath = Path.Combine(Application.StartupPath, "businesses.txt");

            _businesses.Clear();
            lstBusinesses.Items.Clear();

            if (!File.Exists(filePath))
            {
                return;
            }

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split('|');
                if (parts.Length < 5)
                {
                    continue;
                }

                string name = parts[0];
                string type = parts[1];
                string state = parts[2];

                decimal taxRate = 0;
                decimal.TryParse(parts[3], out taxRate);

                bool isGreyMarket = parts[4] == "1";

                Business business = new Business
                {
                    Name = name,
                    Type = type,
                    State = state,
                    TaxRate = taxRate,
                    IsGreyMarket = isGreyMarket
                };

                _businesses.Add(business);
                //lstBusinesses.Items.Add(business.Name);
             

            }

            RefreshBusinessList();

        }


        public void SaveTransactionsToFile()
        {
            string filePath = Path.Combine(Application.StartupPath, "transactions.txt");

            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (Business business in _businesses)
                {
                    foreach (Transaction t in business.Transactions)
                    {
                        string line = business.Name + "|" +
                                      t.Date.ToString("yyyy-MM-dd") + "|" +
                                      t.ClientName + "|" +
                                      t.Revenue.ToString() + "|" +
                                      t.Tax.ToString() + "|" +
                                      t.Profit.ToString();

                        writer.WriteLine(line);
                    }
                }
            }
        }




        public void LoadTransactionsFromFile()
        {
            string filePath = Path.Combine(Application.StartupPath, "transactions.txt");

            // Clear existing transactions in memory
            foreach (Business b in _businesses)
            {
                b.Transactions.Clear();
            }

            if (!File.Exists(filePath))
            {
                return;
            }

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split('|');
                if (parts.Length < 6)
                {
                    continue;
                }

                string businessName = parts[0];
                string dateText = parts[1];
                string clientName = parts[2];
                string revenueText = parts[3];
                string taxText = parts[4];
                string profitText = parts[5];

                // Find the matching business by name
                Business? foundBusiness = null;

                foreach (Business b in _businesses)
                {
                    if (b.Name == businessName)
                    {
                        foundBusiness = b;
                        break;
                    }
                }

                if (foundBusiness == null)
                {
                    continue;
                }

                DateTime date;
                decimal revenue;
                decimal tax;
                decimal profit;

                if (!DateTime.TryParse(dateText, out date))
                {
                    continue;
                }

                if (!decimal.TryParse(revenueText, out revenue))
                {
                    continue;
                }

                if (!decimal.TryParse(taxText, out tax))
                {
                    continue;
                }

                if (!decimal.TryParse(profitText, out profit))
                {
                    continue;
                }

                Transaction t = new Transaction();
                t.Date = date;
                t.ClientName = clientName;
                t.Revenue = revenue;
                t.Tax = tax;
                t.Profit = profit;

                foundBusiness.Transactions.Add(t);
            }
        }





        private void HomeForm_Load(object sender, EventArgs e)
        {
      
        }




        private void HomeForm_Click(object sender, EventArgs e)
        {

        }

        private void btnAddBusiness_Click(object sender, EventArgs e)
        {
            if (openAddBusinessWindows >= 4)
            {
                MessageBox.Show(
                    this,
                    "5 Businesses? Calm down!",
                    "Business Limit Reached",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            AddBusinessForm addForm = new AddBusinessForm(this);
            openAddBusinessWindows++;

            addForm.FormClosed += AddBusinessFormClosed;

            addForm.Show(this);
        }





        private void lstBusinesses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstBusinesses_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void lstBusinesses_DoubleClick_1(object sender, EventArgs e)
        {
            int index = lstBusinesses.SelectedIndex;
            if (index < 0)
            {
                return;
            }

            Business selectedBusiness = _businesses[index];

            BusinessForm businessForm = new BusinessForm(this, selectedBusiness);
            businessForm.TopMost = true;
            businessForm.Show();
        }
    }
}
