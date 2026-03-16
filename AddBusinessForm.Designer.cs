namespace ProfitCalculatorApp
{
    partial class AddBusinessForm
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
            lblBusinessName = new Label();
            txtBusinessName = new TextBox();
            lblBusinessType = new Label();
            cboBusinessType = new ComboBox();
            lblState = new Label();
            cboState = new ComboBox();
            chkIsGreyMarket = new CheckBox();
            lblTaxRate = new Label();
            txtTaxRate = new TextBox();
            btnSaveBusiness = new Button();
            SuspendLayout();
            // 
            // lblBusinessName
            // 
            lblBusinessName.AutoSize = true;
            lblBusinessName.Font = new Font("Segoe UI", 9F);
            lblBusinessName.Location = new Point(12, 51);
            lblBusinessName.Name = "lblBusinessName";
            lblBusinessName.Size = new Size(181, 32);
            lblBusinessName.TabIndex = 0;
            lblBusinessName.Text = "Business Name:";
            // 
            // txtBusinessName
            // 
            txtBusinessName.Location = new Point(199, 48);
            txtBusinessName.Name = "txtBusinessName";
            txtBusinessName.Size = new Size(345, 39);
            txtBusinessName.TabIndex = 1;
            // 
            // lblBusinessType
            // 
            lblBusinessType.AutoSize = true;
            lblBusinessType.Location = new Point(12, 138);
            lblBusinessType.Name = "lblBusinessType";
            lblBusinessType.Size = new Size(168, 32);
            lblBusinessType.TabIndex = 2;
            lblBusinessType.Text = "Business Type:";
            // 
            // cboBusinessType
            // 
            cboBusinessType.FormattingEnabled = true;
            cboBusinessType.Location = new Point(186, 135);
            cboBusinessType.Name = "cboBusinessType";
            cboBusinessType.Size = new Size(213, 40);
            cboBusinessType.TabIndex = 3;
            // 
            // lblState
            // 
            lblState.AutoSize = true;
            lblState.Location = new Point(12, 223);
            lblState.Name = "lblState";
            lblState.Size = new Size(72, 32);
            lblState.TabIndex = 4;
            lblState.Text = "State:";
            // 
            // cboState
            // 
            cboState.FormattingEnabled = true;
            cboState.Location = new Point(90, 220);
            cboState.Name = "cboState";
            cboState.Size = new Size(90, 40);
            cboState.TabIndex = 5;
            cboState.SelectedIndexChanged += cboState_SelectedIndexChanged;
            // 
            // chkIsGreyMarket
            // 
            chkIsGreyMarket.AutoSize = true;
            chkIsGreyMarket.Location = new Point(12, 295);
            chkIsGreyMarket.Name = "chkIsGreyMarket";
            chkIsGreyMarket.Size = new Size(215, 36);
            chkIsGreyMarket.TabIndex = 6;
            chkIsGreyMarket.Text = "Grey? (Untaxed)";
            chkIsGreyMarket.UseVisualStyleBackColor = true;
            chkIsGreyMarket.CheckedChanged += chkIsGreyMarket_CheckedChanged;
            // 
            // lblTaxRate
            // 
            lblTaxRate.AutoSize = true;
            lblTaxRate.Location = new Point(382, 296);
            lblTaxRate.Name = "lblTaxRate";
            lblTaxRate.Size = new Size(106, 32);
            lblTaxRate.TabIndex = 7;
            lblTaxRate.Text = "Tax Rate:";
            lblTaxRate.Click += label1_Click;
            // 
            // txtTaxRate
            // 
            txtTaxRate.Location = new Point(494, 292);
            txtTaxRate.Name = "txtTaxRate";
            txtTaxRate.Size = new Size(72, 39);
            txtTaxRate.TabIndex = 8;
            txtTaxRate.Text = "0";
            // 
            // btnSaveBusiness
            // 
            btnSaveBusiness.BackColor = Color.AliceBlue;
            btnSaveBusiness.Location = new Point(223, 386);
            btnSaveBusiness.Name = "btnSaveBusiness";
            btnSaveBusiness.Size = new Size(118, 46);
            btnSaveBusiness.TabIndex = 9;
            btnSaveBusiness.Text = "Save";
            btnSaveBusiness.UseVisualStyleBackColor = false;
            btnSaveBusiness.Click += btnSaveBusiness_Click;
            // 
            // AddBusinessForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 444);
            Controls.Add(btnSaveBusiness);
            Controls.Add(txtTaxRate);
            Controls.Add(lblTaxRate);
            Controls.Add(chkIsGreyMarket);
            Controls.Add(cboState);
            Controls.Add(lblState);
            Controls.Add(cboBusinessType);
            Controls.Add(lblBusinessType);
            Controls.Add(txtBusinessName);
            Controls.Add(lblBusinessName);
            Name = "AddBusinessForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Business";
            Load += AddBusinessForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBusinessName;
        private TextBox txtBusinessName;
        private Label lblBusinessType;
        private ComboBox cboBusinessType;
        private Label lblState;
        private ComboBox cboState;
        private CheckBox chkIsGreyMarket;
        private Label lblTaxRate;
        private TextBox txtTaxRate;
        private Button btnSaveBusiness;
    }
}