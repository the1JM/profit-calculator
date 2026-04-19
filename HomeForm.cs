namespace ProfitCalculatorApp
{
    public partial class HomeForm : Form
    {
        // This keeps track of how many add-business windows are currently open
        // so the user does not accidentally stack too many entry forms at once.
        private static int openAddBusinessWindows = 0;

        // HomeForm owns the main in-memory business list for the application session.
        private readonly List<Business> _businesses = new List<Business>();


        public HomeForm()
        {
            InitializeComponent();

            // Businesses must be loaded first because transactions are attached to businesses by name.
            LoadBusinessesFromFile();

            // Once the business list exists in memory, transactions can be restored into each one.
            LoadTransactionsFromFile();
        }


        private void AddBusinessFormClosed(object sender, FormClosedEventArgs e)
        {
            // When an add-business window closes, release one slot from the open-window counter.
            openAddBusinessWindows--;

        }


        public void AddBusiness(Business business)
        {
            // This guard keeps the method safe even if it is called defensively.
            if (business == null)
            {
                return;
            }

            // Add the new business to the main collection, then redraw the visible list.
            _businesses.Add(business);
            RefreshBusinessList();
        }


        public void DeleteBusiness(Business business)
        {
            // If nothing valid was supplied, there is nothing to remove.
            if (business == null)
            {
                return;
            }

            // Find the exact business object in the collection before removing it.
            int index = _businesses.IndexOf(business);
            if (index < 0)
            {
                return;
            }

            _businesses.RemoveAt(index);

            // After a deletion, update both the on-screen list and the saved file.
            RefreshBusinessList();
            SaveBusinessesToFile();
        }



        public void RefreshBusinessList()
        {
            // Rebuild the list box from scratch so it always mirrors the current collection.
            lstBusinesses.Items.Clear();

            foreach (var business in _businesses)
            {
                // Only the business name is shown on the home screen.
                lstBusinesses.Items.Add(business.Name);
            }
        }




        public void SaveBusinessesToFile()
        {
            // The app stores data in a simple text file next to the executable
            // so it can persist data without a database.
            string filePath = Path.Combine(Application.StartupPath, "businesses.txt");

            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (var business in _businesses)
                {
                    // A pipe-delimited format keeps the file simple enough to inspect manually.
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

            // Start clean so repeated loads do not duplicate businesses in memory.
            _businesses.Clear();
            lstBusinesses.Items.Clear();

            // A missing file simply means the user has not saved any businesses yet.
            if (!File.Exists(filePath))
            {
                return;
            }

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                // Ignore blank rows so minor formatting issues do not crash the loader.
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split('|');

                // A valid business record should contain five saved values.
                if (parts.Length < 5)
                {
                    continue;
                }

                string name = parts[0];
                string type = parts[1];
                string state = parts[2];

                decimal taxRate = 0;
                decimal.TryParse(parts[3], out taxRate);

                // Grey market is saved as 1 for true and 0 for false.
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
            }

            // Refresh once at the end instead of repeatedly during the load loop.
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
                        // The business name is written first so the transaction can
                        // be matched back to the correct business on startup.
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

            // Clear any existing transactions so loading is repeatable and does not duplicate data.
            foreach (Business b in _businesses)
            {
                b.Transactions.Clear();
            }

            // No file means there simply are no saved transactions yet.
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

                // A valid saved transaction contains the business name plus five transaction values.
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

                // Find the business that this transaction belongs to by matching the saved name.
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
                    // If the business no longer exists, skip the orphaned transaction.
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

                // Once reconstructed, the transaction is returned to its business in memory.
                foundBusiness.Transactions.Add(t);
            }
        }





        private void HomeForm_Load(object sender, EventArgs e)
        {
            // This handler is available if startup-specific UI behavior is needed later.
        }




        private void HomeForm_Click(object sender, EventArgs e)
        {
            // Clicking the form background does not trigger any custom action.
        }

        private void btnAddBusiness_Click(object sender, EventArgs e)
        {
            // Limit how many add-business windows can be open so the user does not lose track of them.
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

            // Create the entry form and track it until the user closes it.
            AddBusinessForm addForm = new AddBusinessForm(this);
            openAddBusinessWindows++;

            addForm.FormClosed += AddBusinessFormClosed;

            // Show the form as a child of HomeForm so it stays anchored to the main workflow.
            addForm.Show(this);
        }





        private void lstBusinesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Selection changes alone do not do anything; the user opens a business by double-clicking.
        }

        private void lstBusinesses_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // This duplicate generated handler is not being used for extra behavior.
        }

        private void lstBusinesses_DoubleClick_1(object sender, EventArgs e)
        {
            // Double-click opens the selected business in its own detail window.
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
