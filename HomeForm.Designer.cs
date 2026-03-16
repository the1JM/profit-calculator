namespace ProfitCalculatorApp
{
    partial class HomeForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            btnAddBusiness = new Button();
            lstBusinesses = new ListBox();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(373, 53);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(266, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Profit Calculator";
            // 
            // btnAddBusiness
            // 
            btnAddBusiness.BackColor = Color.AliceBlue;
            btnAddBusiness.Location = new Point(410, 617);
            btnAddBusiness.Name = "btnAddBusiness";
            btnAddBusiness.Size = new Size(195, 46);
            btnAddBusiness.TabIndex = 2;
            btnAddBusiness.Text = "Add Business";
            btnAddBusiness.UseVisualStyleBackColor = false;
            btnAddBusiness.Click += btnAddBusiness_Click;
            // 
            // lstBusinesses
            // 
            lstBusinesses.FormattingEnabled = true;
            lstBusinesses.Location = new Point(204, 138);
            lstBusinesses.Name = "lstBusinesses";
            lstBusinesses.Size = new Size(597, 420);
            lstBusinesses.TabIndex = 3;
            lstBusinesses.SelectedIndexChanged += lstBusinesses_SelectedIndexChanged_1;
            lstBusinesses.DoubleClick += lstBusinesses_DoubleClick_1;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 737);
            Controls.Add(lstBusinesses);
            Controls.Add(btnAddBusiness);
            Controls.Add(lblTitle);
            Name = "HomeForm";
            Text = "Profit Calculator";
            Load += HomeForm_Load;
            Click += HomeForm_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnAddBusiness;
        private ListBox lstBusinesses;
    }
}
