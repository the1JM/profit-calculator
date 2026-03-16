namespace ProfitCalculatorApp
{
    partial class BusinessForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblBusinessName = new Label();
            lblBusinessType = new Label();
            lblBusinessState = new Label();
            lblBusinessTaxRate = new Label();
            tabBusiness = new TabControl();
            Transactions = new TabPage();
            btnAddTransaction = new Button();
            grpServiceFields = new GroupBox();
            txtServiceCost = new TextBox();
            lblServiceCost = new Label();
            txtHourlyRate = new TextBox();
            lblHourlyRate = new Label();
            txtHoursWorked = new TextBox();
            lblHoursWorked = new Label();
            grpSalesFields = new GroupBox();
            txtSalesCost = new TextBox();
            lblSalesCost = new Label();
            txtSaleAmount = new TextBox();
            lblSaleAmount = new Label();
            txtClientName = new TextBox();
            lblClientName = new Label();
            dtpTransactionDate = new DateTimePicker();
            lblTransactionDate = new Label();
            lblAddTransactionHeader = new Label();
            Reports = new TabPage();
            lblReportTotalProfitValue = new Label();
            lblReportTotalProfitLabel = new Label();
            lblReportTotalTaxValue = new Label();
            lblReportTotalTaxLabel = new Label();
            lblReportTotalRevenueValue = new Label();
            lblReportTotalRevenueLabel = new Label();
            btnCalculateReport = new Button();
            numYear = new NumericUpDown();
            lblYear = new Label();
            dtpMonth = new DateTimePicker();
            lblMonthYear = new Label();
            dtpWeekDate = new DateTimePicker();
            lblWeekDate = new Label();
            grpReportPeriod = new GroupBox();
            rdoYear = new RadioButton();
            rdoMonth = new RadioButton();
            rdoWeek = new RadioButton();
            lblReportsHeader = new Label();
            btnEditBusiness = new Button();
            btnDeleteBusiness = new Button();
            dgvTransactions = new DataGridView();
            colDate = new DataGridViewTextBoxColumn();
            colClient = new DataGridViewTextBoxColumn();
            colRevenue = new DataGridViewTextBoxColumn();
            colTax = new DataGridViewTextBoxColumn();
            colProfit = new DataGridViewTextBoxColumn();
            ctxTransactions = new ContextMenuStrip(components);
            editTransactionToolStripMenuItem = new ToolStripMenuItem();
            deleteTransactionToolStripMenuItem = new ToolStripMenuItem();
            lblTotalRevenue = new Label();
            lblTotalRevenueValue = new Label();
            lblTotalProfit = new Label();
            lblTotalProfitValue = new Label();
            lblTransactionsTitle = new Label();
            tabBusiness.SuspendLayout();
            Transactions.SuspendLayout();
            grpServiceFields.SuspendLayout();
            grpSalesFields.SuspendLayout();
            Reports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numYear).BeginInit();
            grpReportPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            ctxTransactions.SuspendLayout();
            SuspendLayout();
            // 
            // lblBusinessName
            // 
            lblBusinessName.AutoSize = true;
            lblBusinessName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBusinessName.Location = new Point(12, 68);
            lblBusinessName.Name = "lblBusinessName";
            lblBusinessName.Size = new Size(88, 32);
            lblBusinessName.TabIndex = 0;
            lblBusinessName.Text = "Name:";
            lblBusinessName.Click += label1_Click;
            // 
            // lblBusinessType
            // 
            lblBusinessType.AutoSize = true;
            lblBusinessType.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBusinessType.Location = new Point(12, 162);
            lblBusinessType.Name = "lblBusinessType";
            lblBusinessType.Size = new Size(75, 32);
            lblBusinessType.TabIndex = 1;
            lblBusinessType.Text = "Type:";
            // 
            // lblBusinessState
            // 
            lblBusinessState.AutoSize = true;
            lblBusinessState.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBusinessState.Location = new Point(12, 267);
            lblBusinessState.Name = "lblBusinessState";
            lblBusinessState.Size = new Size(77, 32);
            lblBusinessState.TabIndex = 2;
            lblBusinessState.Text = "State:";
            // 
            // lblBusinessTaxRate
            // 
            lblBusinessTaxRate.AutoSize = true;
            lblBusinessTaxRate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBusinessTaxRate.Location = new Point(12, 367);
            lblBusinessTaxRate.Name = "lblBusinessTaxRate";
            lblBusinessTaxRate.Size = new Size(117, 32);
            lblBusinessTaxRate.TabIndex = 3;
            lblBusinessTaxRate.Text = "Tax Rate:";
            // 
            // tabBusiness
            // 
            tabBusiness.Controls.Add(Transactions);
            tabBusiness.Controls.Add(Reports);
            tabBusiness.Location = new Point(690, 12);
            tabBusiness.Name = "tabBusiness";
            tabBusiness.SelectedIndex = 0;
            tabBusiness.Size = new Size(669, 560);
            tabBusiness.TabIndex = 4;
            // 
            // Transactions
            // 
            Transactions.Controls.Add(btnAddTransaction);
            Transactions.Controls.Add(grpServiceFields);
            Transactions.Controls.Add(grpSalesFields);
            Transactions.Controls.Add(txtClientName);
            Transactions.Controls.Add(lblClientName);
            Transactions.Controls.Add(dtpTransactionDate);
            Transactions.Controls.Add(lblTransactionDate);
            Transactions.Controls.Add(lblAddTransactionHeader);
            Transactions.Location = new Point(8, 46);
            Transactions.Name = "Transactions";
            Transactions.Padding = new Padding(3);
            Transactions.Size = new Size(653, 506);
            Transactions.TabIndex = 0;
            Transactions.Text = "Transactions";
            Transactions.UseVisualStyleBackColor = true;
            // 
            // btnAddTransaction
            // 
            btnAddTransaction.BackColor = Color.AliceBlue;
            btnAddTransaction.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddTransaction.Location = new Point(207, 455);
            btnAddTransaction.Name = "btnAddTransaction";
            btnAddTransaction.Size = new Size(239, 39);
            btnAddTransaction.TabIndex = 7;
            btnAddTransaction.Text = "Add Transaction";
            btnAddTransaction.UseVisualStyleBackColor = false;
            btnAddTransaction.Click += btnAddTransaction_Click;
            // 
            // grpServiceFields
            // 
            grpServiceFields.Controls.Add(txtServiceCost);
            grpServiceFields.Controls.Add(lblServiceCost);
            grpServiceFields.Controls.Add(txtHourlyRate);
            grpServiceFields.Controls.Add(lblHourlyRate);
            grpServiceFields.Controls.Add(txtHoursWorked);
            grpServiceFields.Controls.Add(lblHoursWorked);
            grpServiceFields.Location = new Point(379, 160);
            grpServiceFields.Name = "grpServiceFields";
            grpServiceFields.Size = new Size(271, 284);
            grpServiceFields.TabIndex = 6;
            grpServiceFields.TabStop = false;
            grpServiceFields.Text = "Service Transaction";
            // 
            // txtServiceCost
            // 
            txtServiceCost.Location = new Point(36, 237);
            txtServiceCost.Name = "txtServiceCost";
            txtServiceCost.Size = new Size(165, 39);
            txtServiceCost.TabIndex = 5;
            // 
            // lblServiceCost
            // 
            lblServiceCost.AutoSize = true;
            lblServiceCost.Location = new Point(6, 202);
            lblServiceCost.Name = "lblServiceCost";
            lblServiceCost.Size = new Size(61, 32);
            lblServiceCost.TabIndex = 4;
            lblServiceCost.Text = "Cost";
            // 
            // txtHourlyRate
            // 
            txtHourlyRate.Location = new Point(36, 160);
            txtHourlyRate.Name = "txtHourlyRate";
            txtHourlyRate.Size = new Size(165, 39);
            txtHourlyRate.TabIndex = 3;
            // 
            // lblHourlyRate
            // 
            lblHourlyRate.AutoSize = true;
            lblHourlyRate.Location = new Point(6, 127);
            lblHourlyRate.Name = "lblHourlyRate";
            lblHourlyRate.Size = new Size(139, 32);
            lblHourlyRate.TabIndex = 2;
            lblHourlyRate.Text = "Hourly Rate";
            // 
            // txtHoursWorked
            // 
            txtHoursWorked.Location = new Point(36, 83);
            txtHoursWorked.Name = "txtHoursWorked";
            txtHoursWorked.Size = new Size(165, 39);
            txtHoursWorked.TabIndex = 1;
            // 
            // lblHoursWorked
            // 
            lblHoursWorked.AutoSize = true;
            lblHoursWorked.Location = new Point(6, 50);
            lblHoursWorked.Name = "lblHoursWorked";
            lblHoursWorked.Size = new Size(166, 32);
            lblHoursWorked.TabIndex = 0;
            lblHoursWorked.Text = "Hours Worked";
            // 
            // grpSalesFields
            // 
            grpSalesFields.Controls.Add(txtSalesCost);
            grpSalesFields.Controls.Add(lblSalesCost);
            grpSalesFields.Controls.Add(txtSaleAmount);
            grpSalesFields.Controls.Add(lblSaleAmount);
            grpSalesFields.Location = new Point(6, 160);
            grpSalesFields.Name = "grpSalesFields";
            grpSalesFields.Size = new Size(272, 283);
            grpSalesFields.TabIndex = 5;
            grpSalesFields.TabStop = false;
            grpSalesFields.Text = "Sales Transaction";
            grpSalesFields.Enter += grpSalesFields_Enter;
            // 
            // txtSalesCost
            // 
            txtSalesCost.Location = new Point(29, 162);
            txtSalesCost.Name = "txtSalesCost";
            txtSalesCost.Size = new Size(160, 39);
            txtSalesCost.TabIndex = 3;
            // 
            // lblSalesCost
            // 
            lblSalesCost.AutoSize = true;
            lblSalesCost.Location = new Point(6, 127);
            lblSalesCost.Name = "lblSalesCost";
            lblSalesCost.Size = new Size(61, 32);
            lblSalesCost.TabIndex = 2;
            lblSalesCost.Text = "Cost";
            // 
            // txtSaleAmount
            // 
            txtSaleAmount.Location = new Point(29, 85);
            txtSaleAmount.Name = "txtSaleAmount";
            txtSaleAmount.Size = new Size(160, 39);
            txtSaleAmount.TabIndex = 1;
            // 
            // lblSaleAmount
            // 
            lblSaleAmount.AutoSize = true;
            lblSaleAmount.Location = new Point(6, 50);
            lblSaleAmount.Name = "lblSaleAmount";
            lblSaleAmount.Size = new Size(151, 32);
            lblSaleAmount.TabIndex = 0;
            lblSaleAmount.Text = "Sale Amount";
            // 
            // txtClientName
            // 
            txtClientName.Location = new Point(26, 82);
            txtClientName.Name = "txtClientName";
            txtClientName.Size = new Size(225, 39);
            txtClientName.TabIndex = 4;
            // 
            // lblClientName
            // 
            lblClientName.AutoSize = true;
            lblClientName.Location = new Point(6, 47);
            lblClientName.Name = "lblClientName";
            lblClientName.Size = new Size(147, 32);
            lblClientName.TabIndex = 3;
            lblClientName.Text = "Client Name";
            // 
            // dtpTransactionDate
            // 
            dtpTransactionDate.CalendarFont = new Font("Segoe UI", 8F);
            dtpTransactionDate.Font = new Font("Segoe UI", 8F);
            dtpTransactionDate.Location = new Point(275, 82);
            dtpTransactionDate.Name = "dtpTransactionDate";
            dtpTransactionDate.Size = new Size(372, 36);
            dtpTransactionDate.TabIndex = 2;
            // 
            // lblTransactionDate
            // 
            lblTransactionDate.AutoSize = true;
            lblTransactionDate.Location = new Point(292, 47);
            lblTransactionDate.Name = "lblTransactionDate";
            lblTransactionDate.Size = new Size(64, 32);
            lblTransactionDate.TabIndex = 1;
            lblTransactionDate.Text = "Date";
            // 
            // lblAddTransactionHeader
            // 
            lblAddTransactionHeader.AutoSize = true;
            lblAddTransactionHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddTransactionHeader.Location = new Point(204, 10);
            lblAddTransactionHeader.Name = "lblAddTransactionHeader";
            lblAddTransactionHeader.Size = new Size(258, 32);
            lblAddTransactionHeader.TabIndex = 0;
            lblAddTransactionHeader.Text = "Add New Transaction";
            // 
            // Reports
            // 
            Reports.Controls.Add(lblReportTotalProfitValue);
            Reports.Controls.Add(lblReportTotalProfitLabel);
            Reports.Controls.Add(lblReportTotalTaxValue);
            Reports.Controls.Add(lblReportTotalTaxLabel);
            Reports.Controls.Add(lblReportTotalRevenueValue);
            Reports.Controls.Add(lblReportTotalRevenueLabel);
            Reports.Controls.Add(btnCalculateReport);
            Reports.Controls.Add(numYear);
            Reports.Controls.Add(lblYear);
            Reports.Controls.Add(dtpMonth);
            Reports.Controls.Add(lblMonthYear);
            Reports.Controls.Add(dtpWeekDate);
            Reports.Controls.Add(lblWeekDate);
            Reports.Controls.Add(grpReportPeriod);
            Reports.Controls.Add(lblReportsHeader);
            Reports.Location = new Point(8, 46);
            Reports.Name = "Reports";
            Reports.Padding = new Padding(3);
            Reports.Size = new Size(653, 506);
            Reports.TabIndex = 1;
            Reports.Text = "Reports";
            Reports.UseVisualStyleBackColor = true;
            // 
            // lblReportTotalProfitValue
            // 
            lblReportTotalProfitValue.AutoSize = true;
            lblReportTotalProfitValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblReportTotalProfitValue.Location = new Point(193, 455);
            lblReportTotalProfitValue.Name = "lblReportTotalProfitValue";
            lblReportTotalProfitValue.Size = new Size(28, 32);
            lblReportTotalProfitValue.TabIndex = 14;
            lblReportTotalProfitValue.Text = "0";
            // 
            // lblReportTotalProfitLabel
            // 
            lblReportTotalProfitLabel.AutoSize = true;
            lblReportTotalProfitLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblReportTotalProfitLabel.Location = new Point(6, 455);
            lblReportTotalProfitLabel.Name = "lblReportTotalProfitLabel";
            lblReportTotalProfitLabel.Size = new Size(149, 32);
            lblReportTotalProfitLabel.TabIndex = 13;
            lblReportTotalProfitLabel.Text = "Total Profit:";
            // 
            // lblReportTotalTaxValue
            // 
            lblReportTotalTaxValue.AutoSize = true;
            lblReportTotalTaxValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblReportTotalTaxValue.Location = new Point(193, 413);
            lblReportTotalTaxValue.Name = "lblReportTotalTaxValue";
            lblReportTotalTaxValue.Size = new Size(28, 32);
            lblReportTotalTaxValue.TabIndex = 12;
            lblReportTotalTaxValue.Text = "0";
            // 
            // lblReportTotalTaxLabel
            // 
            lblReportTotalTaxLabel.AutoSize = true;
            lblReportTotalTaxLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblReportTotalTaxLabel.Location = new Point(6, 413);
            lblReportTotalTaxLabel.Name = "lblReportTotalTaxLabel";
            lblReportTotalTaxLabel.Size = new Size(122, 32);
            lblReportTotalTaxLabel.TabIndex = 11;
            lblReportTotalTaxLabel.Text = "Total Tax:";
            // 
            // lblReportTotalRevenueValue
            // 
            lblReportTotalRevenueValue.AutoSize = true;
            lblReportTotalRevenueValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblReportTotalRevenueValue.Location = new Point(193, 369);
            lblReportTotalRevenueValue.Name = "lblReportTotalRevenueValue";
            lblReportTotalRevenueValue.Size = new Size(28, 32);
            lblReportTotalRevenueValue.TabIndex = 10;
            lblReportTotalRevenueValue.Text = "0";
            // 
            // lblReportTotalRevenueLabel
            // 
            lblReportTotalRevenueLabel.AutoSize = true;
            lblReportTotalRevenueLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblReportTotalRevenueLabel.Location = new Point(6, 369);
            lblReportTotalRevenueLabel.Name = "lblReportTotalRevenueLabel";
            lblReportTotalRevenueLabel.Size = new Size(181, 32);
            lblReportTotalRevenueLabel.TabIndex = 9;
            lblReportTotalRevenueLabel.Text = "Total Revenue:";
            // 
            // btnCalculateReport
            // 
            btnCalculateReport.Location = new Point(484, 319);
            btnCalculateReport.Name = "btnCalculateReport";
            btnCalculateReport.Size = new Size(150, 46);
            btnCalculateReport.TabIndex = 8;
            btnCalculateReport.Text = "Calculate";
            btnCalculateReport.UseVisualStyleBackColor = true;
            btnCalculateReport.Click += btnCalculateReport_Click;
            // 
            // numYear
            // 
            numYear.Location = new Point(70, 299);
            numYear.Maximum = new decimal(new int[] { 2200, 0, 0, 0 });
            numYear.Minimum = new decimal(new int[] { 2025, 0, 0, 0 });
            numYear.Name = "numYear";
            numYear.Size = new Size(116, 39);
            numYear.TabIndex = 7;
            numYear.Value = new decimal(new int[] { 2025, 0, 0, 0 });
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(6, 301);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(58, 32);
            lblYear.TabIndex = 6;
            lblYear.Text = "Year";
            // 
            // dtpMonth
            // 
            dtpMonth.CustomFormat = "MMMM yyyy";
            dtpMonth.Format = DateTimePickerFormat.Custom;
            dtpMonth.Location = new Point(165, 240);
            dtpMonth.Name = "dtpMonth";
            dtpMonth.Size = new Size(258, 39);
            dtpMonth.TabIndex = 5;
            dtpMonth.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // lblMonthYear
            // 
            lblMonthYear.AutoSize = true;
            lblMonthYear.Location = new Point(6, 245);
            lblMonthYear.Name = "lblMonthYear";
            lblMonthYear.Size = new Size(153, 32);
            lblMonthYear.TabIndex = 4;
            lblMonthYear.Text = "Month / Year";
            // 
            // dtpWeekDate
            // 
            dtpWeekDate.Format = DateTimePickerFormat.Short;
            dtpWeekDate.Location = new Point(139, 185);
            dtpWeekDate.Name = "dtpWeekDate";
            dtpWeekDate.Size = new Size(157, 39);
            dtpWeekDate.TabIndex = 3;
            // 
            // lblWeekDate
            // 
            lblWeekDate.AutoSize = true;
            lblWeekDate.Location = new Point(6, 190);
            lblWeekDate.Name = "lblWeekDate";
            lblWeekDate.Size = new Size(127, 32);
            lblWeekDate.TabIndex = 2;
            lblWeekDate.Text = "Week date";
            // 
            // grpReportPeriod
            // 
            grpReportPeriod.Controls.Add(rdoYear);
            grpReportPeriod.Controls.Add(rdoMonth);
            grpReportPeriod.Controls.Add(rdoWeek);
            grpReportPeriod.Location = new Point(149, 44);
            grpReportPeriod.Name = "grpReportPeriod";
            grpReportPeriod.Size = new Size(389, 124);
            grpReportPeriod.TabIndex = 1;
            grpReportPeriod.TabStop = false;
            grpReportPeriod.Text = "Period";
            // 
            // rdoYear
            // 
            rdoYear.AutoSize = true;
            rdoYear.Location = new Point(283, 61);
            rdoYear.Name = "rdoYear";
            rdoYear.Size = new Size(89, 36);
            rdoYear.TabIndex = 2;
            rdoYear.TabStop = true;
            rdoYear.Text = "Year";
            rdoYear.UseVisualStyleBackColor = true;
            rdoYear.CheckedChanged += rdoYear_CheckedChanged;
            // 
            // rdoMonth
            // 
            rdoMonth.AutoSize = true;
            rdoMonth.Location = new Point(138, 61);
            rdoMonth.Name = "rdoMonth";
            rdoMonth.Size = new Size(117, 36);
            rdoMonth.TabIndex = 1;
            rdoMonth.TabStop = true;
            rdoMonth.Text = "Month";
            rdoMonth.UseVisualStyleBackColor = true;
            rdoMonth.CheckedChanged += rdoMonth_CheckedChanged;
            // 
            // rdoWeek
            // 
            rdoWeek.AutoSize = true;
            rdoWeek.Location = new Point(16, 61);
            rdoWeek.Name = "rdoWeek";
            rdoWeek.Size = new Size(104, 36);
            rdoWeek.TabIndex = 0;
            rdoWeek.TabStop = true;
            rdoWeek.Text = "Week";
            rdoWeek.UseVisualStyleBackColor = true;
            rdoWeek.CheckedChanged += rdoWeek_CheckedChanged;
            // 
            // lblReportsHeader
            // 
            lblReportsHeader.AutoSize = true;
            lblReportsHeader.Location = new Point(6, 3);
            lblReportsHeader.Name = "lblReportsHeader";
            lblReportsHeader.Size = new Size(94, 32);
            lblReportsHeader.TabIndex = 0;
            lblReportsHeader.Text = "Reports";
            // 
            // btnEditBusiness
            // 
            btnEditBusiness.BackColor = Color.AliceBlue;
            btnEditBusiness.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditBusiness.Location = new Point(163, 977);
            btnEditBusiness.Name = "btnEditBusiness";
            btnEditBusiness.Size = new Size(150, 46);
            btnEditBusiness.TabIndex = 5;
            btnEditBusiness.Text = "Edit";
            btnEditBusiness.UseVisualStyleBackColor = false;
            btnEditBusiness.Click += btnEditBusiness_Click;
            // 
            // btnDeleteBusiness
            // 
            btnDeleteBusiness.BackColor = Color.AliceBlue;
            btnDeleteBusiness.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteBusiness.ForeColor = Color.IndianRed;
            btnDeleteBusiness.Location = new Point(1099, 977);
            btnDeleteBusiness.Name = "btnDeleteBusiness";
            btnDeleteBusiness.Size = new Size(150, 46);
            btnDeleteBusiness.TabIndex = 6;
            btnDeleteBusiness.Text = "Delete";
            btnDeleteBusiness.UseVisualStyleBackColor = false;
            btnDeleteBusiness.Click += btnDeleteBusiness_Click;
            // 
            // dgvTransactions
            // 
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.AllowUserToDeleteRows = false;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.Columns.AddRange(new DataGridViewColumn[] { colDate, colClient, colRevenue, colTax, colProfit });
            dgvTransactions.ContextMenuStrip = ctxTransactions;
            dgvTransactions.Location = new Point(164, 621);
            dgvTransactions.MultiSelect = false;
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.ReadOnly = true;
            dgvTransactions.RowHeadersWidth = 82;
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactions.Size = new Size(1085, 251);
            dgvTransactions.TabIndex = 7;
            dgvTransactions.AutoSizeColumnModeChanged += Fill;
            dgvTransactions.CellContentClick += dgvTransactions_CellContentClick;
            dgvTransactions.MouseDown += dgvTransactions_MouseDown;
            // 
            // colDate
            // 
            colDate.HeaderText = "Date";
            colDate.MinimumWidth = 10;
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            colDate.Width = 200;
            // 
            // colClient
            // 
            colClient.HeaderText = "Client";
            colClient.MinimumWidth = 10;
            colClient.Name = "colClient";
            colClient.ReadOnly = true;
            colClient.Width = 200;
            // 
            // colRevenue
            // 
            colRevenue.HeaderText = "Revenue";
            colRevenue.MinimumWidth = 10;
            colRevenue.Name = "colRevenue";
            colRevenue.ReadOnly = true;
            colRevenue.Width = 200;
            // 
            // colTax
            // 
            colTax.HeaderText = "Tax";
            colTax.MinimumWidth = 10;
            colTax.Name = "colTax";
            colTax.ReadOnly = true;
            colTax.Width = 200;
            // 
            // colProfit
            // 
            colProfit.HeaderText = "Profit";
            colProfit.MinimumWidth = 10;
            colProfit.Name = "colProfit";
            colProfit.ReadOnly = true;
            colProfit.Width = 200;
            // 
            // ctxTransactions
            // 
            ctxTransactions.ImageScalingSize = new Size(32, 32);
            ctxTransactions.Items.AddRange(new ToolStripItem[] { editTransactionToolStripMenuItem, deleteTransactionToolStripMenuItem });
            ctxTransactions.Name = "ctxTransactions";
            ctxTransactions.Size = new Size(286, 80);
            ctxTransactions.Opening += contextMenuStrip1_Opening;
            // 
            // editTransactionToolStripMenuItem
            // 
            editTransactionToolStripMenuItem.Name = "editTransactionToolStripMenuItem";
            editTransactionToolStripMenuItem.Size = new Size(285, 38);
            editTransactionToolStripMenuItem.Text = "Edit Transaction";
            editTransactionToolStripMenuItem.Click += editTransactionToolStripMenuItem_Click;
            // 
            // deleteTransactionToolStripMenuItem
            // 
            deleteTransactionToolStripMenuItem.Name = "deleteTransactionToolStripMenuItem";
            deleteTransactionToolStripMenuItem.Size = new Size(285, 38);
            deleteTransactionToolStripMenuItem.Text = "Delete Transaction";
            deleteTransactionToolStripMenuItem.Click += deleteTransactionToolStripMenuItem_Click;
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalRevenue.Location = new Point(164, 893);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(181, 32);
            lblTotalRevenue.TabIndex = 8;
            lblTotalRevenue.Text = "Total Revenue:";
            // 
            // lblTotalRevenueValue
            // 
            lblTotalRevenueValue.AutoSize = true;
            lblTotalRevenueValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalRevenueValue.Location = new Point(354, 893);
            lblTotalRevenueValue.Name = "lblTotalRevenueValue";
            lblTotalRevenueValue.Size = new Size(28, 32);
            lblTotalRevenueValue.TabIndex = 9;
            lblTotalRevenueValue.Text = "0";
            // 
            // lblTotalProfit
            // 
            lblTotalProfit.AutoSize = true;
            lblTotalProfit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalProfit.Location = new Point(164, 937);
            lblTotalProfit.Name = "lblTotalProfit";
            lblTotalProfit.Size = new Size(149, 32);
            lblTotalProfit.TabIndex = 10;
            lblTotalProfit.Text = "Total Profit:";
            // 
            // lblTotalProfitValue
            // 
            lblTotalProfitValue.AutoSize = true;
            lblTotalProfitValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalProfitValue.Location = new Point(354, 937);
            lblTotalProfitValue.Name = "lblTotalProfitValue";
            lblTotalProfitValue.Size = new Size(28, 32);
            lblTotalProfitValue.TabIndex = 11;
            lblTotalProfitValue.Text = "0";
            // 
            // lblTransactionsTitle
            // 
            lblTransactionsTitle.AutoSize = true;
            lblTransactionsTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTransactionsTitle.Location = new Point(164, 586);
            lblTransactionsTitle.Name = "lblTransactionsTitle";
            lblTransactionsTitle.Size = new Size(157, 32);
            lblTransactionsTitle.TabIndex = 12;
            lblTransactionsTitle.Text = "Transactions";
            // 
            // BusinessForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 1035);
            Controls.Add(lblTransactionsTitle);
            Controls.Add(lblTotalProfitValue);
            Controls.Add(lblTotalProfit);
            Controls.Add(lblTotalRevenueValue);
            Controls.Add(lblTotalRevenue);
            Controls.Add(dgvTransactions);
            Controls.Add(btnDeleteBusiness);
            Controls.Add(btnEditBusiness);
            Controls.Add(tabBusiness);
            Controls.Add(lblBusinessTaxRate);
            Controls.Add(lblBusinessState);
            Controls.Add(lblBusinessType);
            Controls.Add(lblBusinessName);
            Name = "BusinessForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Business Details";
            Load += BusinessForm_Load;
            Click += BusinessForm_Click;
            tabBusiness.ResumeLayout(false);
            Transactions.ResumeLayout(false);
            Transactions.PerformLayout();
            grpServiceFields.ResumeLayout(false);
            grpServiceFields.PerformLayout();
            grpSalesFields.ResumeLayout(false);
            grpSalesFields.PerformLayout();
            Reports.ResumeLayout(false);
            Reports.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numYear).EndInit();
            grpReportPeriod.ResumeLayout(false);
            grpReportPeriod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ctxTransactions.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBusinessName;
        private Label lblBusinessType;
        private Label lblBusinessState;
        private Label lblBusinessTaxRate;
        private TabControl tabBusiness;
        private TabPage Transactions;
        private TabPage Reports;
        private Button btnEditBusiness;
        private Button btnDeleteBusiness;
        private DateTimePicker dtpTransactionDate;
        private Label lblTransactionDate;
        private Label lblAddTransactionHeader;
        private TextBox txtClientName;
        private Label lblClientName;
        private GroupBox grpSalesFields;
        private Label lblSaleAmount;
        private TextBox txtSalesCost;
        private Label lblSalesCost;
        private TextBox txtSaleAmount;
        private GroupBox grpServiceFields;
        private TextBox txtHoursWorked;
        private Label lblHoursWorked;
        private Label lblHourlyRate;
        private TextBox txtServiceCost;
        private Label lblServiceCost;
        private TextBox txtHourlyRate;
        private Button btnAddTransaction;
        private DataGridView dgvTransactions;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colClient;
        private DataGridViewTextBoxColumn colRevenue;
        private DataGridViewTextBoxColumn colTax;
        private DataGridViewTextBoxColumn colProfit;
        private Label lblTotalRevenue;
        private Label lblTotalRevenueValue;
        private Label lblTotalProfit;
        private Label lblTotalProfitValue;
        private ContextMenuStrip ctxTransactions;
        private ToolStripMenuItem editTransactionToolStripMenuItem;
        private ToolStripMenuItem deleteTransactionToolStripMenuItem;
        private Label lblReportsHeader;
        private GroupBox grpReportPeriod;
        private DateTimePicker dtpWeekDate;
        private Label lblWeekDate;
        private RadioButton rdoYear;
        private RadioButton rdoMonth;
        private RadioButton rdoWeek;
        private DateTimePicker dtpMonth;
        private Label lblMonthYear;
        private NumericUpDown numYear;
        private Label lblYear;
        private Label lblReportTotalRevenueLabel;
        private Button btnCalculateReport;
        private Label lblReportTotalProfitLabel;
        private Label lblReportTotalTaxValue;
        private Label lblReportTotalTaxLabel;
        private Label lblReportTotalRevenueValue;
        private Label lblReportTotalProfitValue;
        private Label lblTransactionsTitle;
    }
}