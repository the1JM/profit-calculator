namespace ProfitCalculatorApp
{
    partial class EditTransactionsForm
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
            lblEditDate = new Label();
            dtpEditDate = new DateTimePicker();
            lblEditClient = new Label();
            txtEditClientName = new TextBox();
            lblEditRevenue = new Label();
            lblEditCost = new Label();
            txtEditRevenue = new TextBox();
            txtEditCost = new TextBox();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblEditDate
            // 
            lblEditDate.AutoSize = true;
            lblEditDate.Location = new Point(12, 132);
            lblEditDate.Name = "lblEditDate";
            lblEditDate.Size = new Size(69, 32);
            lblEditDate.TabIndex = 0;
            lblEditDate.Text = "Date:";
            // 
            // dtpEditDate
            // 
            dtpEditDate.Format = DateTimePickerFormat.Short;
            dtpEditDate.Location = new Point(30, 167);
            dtpEditDate.Name = "dtpEditDate";
            dtpEditDate.Size = new Size(223, 39);
            dtpEditDate.TabIndex = 1;
            // 
            // lblEditClient
            // 
            lblEditClient.AutoSize = true;
            lblEditClient.Location = new Point(12, 40);
            lblEditClient.Name = "lblEditClient";
            lblEditClient.Size = new Size(152, 32);
            lblEditClient.TabIndex = 2;
            lblEditClient.Text = "Client Name:";
            lblEditClient.Click += label1_Click;
            // 
            // txtEditClientName
            // 
            txtEditClientName.Location = new Point(30, 75);
            txtEditClientName.Name = "txtEditClientName";
            txtEditClientName.Size = new Size(223, 39);
            txtEditClientName.TabIndex = 3;
            // 
            // lblEditRevenue
            // 
            lblEditRevenue.AutoSize = true;
            lblEditRevenue.Location = new Point(12, 228);
            lblEditRevenue.Name = "lblEditRevenue";
            lblEditRevenue.Size = new Size(111, 32);
            lblEditRevenue.TabIndex = 4;
            lblEditRevenue.Text = "Revenue:";
            // 
            // lblEditCost
            // 
            lblEditCost.AutoSize = true;
            lblEditCost.Location = new Point(12, 331);
            lblEditCost.Name = "lblEditCost";
            lblEditCost.Size = new Size(66, 32);
            lblEditCost.TabIndex = 5;
            lblEditCost.Text = "Cost:";
            // 
            // txtEditRevenue
            // 
            txtEditRevenue.Location = new Point(30, 263);
            txtEditRevenue.Name = "txtEditRevenue";
            txtEditRevenue.Size = new Size(223, 39);
            txtEditRevenue.TabIndex = 6;
            // 
            // txtEditCost
            // 
            txtEditCost.Location = new Point(30, 363);
            txtEditCost.Name = "txtEditCost";
            txtEditCost.Size = new Size(223, 39);
            txtEditCost.TabIndex = 7;
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.AliceBlue;
            btnOk.Location = new Point(555, 378);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(85, 46);
            btnOk.TabIndex = 8;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.WhiteSmoke;
            btnCancel.Location = new Point(449, 378);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 46);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // EditTransactionsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(652, 436);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(txtEditCost);
            Controls.Add(txtEditRevenue);
            Controls.Add(lblEditCost);
            Controls.Add(lblEditRevenue);
            Controls.Add(txtEditClientName);
            Controls.Add(lblEditClient);
            Controls.Add(dtpEditDate);
            Controls.Add(lblEditDate);
            Name = "EditTransactionsForm";
            Text = "Edit Transaction";
            Load += EditTransactionsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEditDate;
        private DateTimePicker dtpEditDate;
        private Label lblEditClient;
        private TextBox txtEditClientName;
        private Label lblEditRevenue;
        private Label lblEditCost;
        private TextBox txtEditRevenue;
        private TextBox txtEditCost;
        private Button btnOk;
        private Button btnCancel;
    }
}