
namespace View
{
    partial class SearchDiscountForm
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
            this.DiscountSearchGroupBox = new System.Windows.Forms.GroupBox();
            this.ShopComboBox = new System.Windows.Forms.ComboBox();
            this.DiscountValueTextBox = new System.Windows.Forms.TextBox();
            this.ShopCheckBox = new System.Windows.Forms.CheckBox();
            this.ValueCheckBox = new System.Windows.Forms.CheckBox();
            this.SertificateDiscountNoPeriodСheckBox = new System.Windows.Forms.CheckBox();
            this.ProcentDiscountWithPeriodСheckBox = new System.Windows.Forms.CheckBox();
            this.SertificateDiscountWithPeriodСheckBox = new System.Windows.Forms.CheckBox();
            this.ProcentDiscountNoPeriodСheckBox = new System.Windows.Forms.CheckBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.DiscountSearchGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // DiscountSearchGroupBox
            // 
            this.DiscountSearchGroupBox.Controls.Add(this.ShopComboBox);
            this.DiscountSearchGroupBox.Controls.Add(this.DiscountValueTextBox);
            this.DiscountSearchGroupBox.Controls.Add(this.ShopCheckBox);
            this.DiscountSearchGroupBox.Controls.Add(this.ValueCheckBox);
            this.DiscountSearchGroupBox.Controls.Add(this.SertificateDiscountNoPeriodСheckBox);
            this.DiscountSearchGroupBox.Controls.Add(this.ProcentDiscountWithPeriodСheckBox);
            this.DiscountSearchGroupBox.Controls.Add(this.SertificateDiscountWithPeriodСheckBox);
            this.DiscountSearchGroupBox.Controls.Add(this.ProcentDiscountNoPeriodСheckBox);
            this.DiscountSearchGroupBox.Location = new System.Drawing.Point(12, 12);
            this.DiscountSearchGroupBox.Name = "DiscountSearchGroupBox";
            this.DiscountSearchGroupBox.Size = new System.Drawing.Size(252, 176);
            this.DiscountSearchGroupBox.TabIndex = 0;
            this.DiscountSearchGroupBox.TabStop = false;
            this.DiscountSearchGroupBox.Text = "Найти скидку";
            // 
            // ShopComboBox
            // 
            this.ShopComboBox.FormattingEnabled = true;
            this.ShopComboBox.Location = new System.Drawing.Point(82, 142);
            this.ShopComboBox.Name = "ShopComboBox";
            this.ShopComboBox.Size = new System.Drawing.Size(163, 21);
            this.ShopComboBox.TabIndex = 1;
            // 
            // DiscountValueTextBox
            // 
            this.DiscountValueTextBox.Location = new System.Drawing.Point(164, 119);
            this.DiscountValueTextBox.Name = "DiscountValueTextBox";
            this.DiscountValueTextBox.Size = new System.Drawing.Size(81, 20);
            this.DiscountValueTextBox.TabIndex = 1;
            this.DiscountValueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DiscountValueTextBox_KeyPress);
            // 
            // ShopCheckBox
            // 
            this.ShopCheckBox.AutoSize = true;
            this.ShopCheckBox.Location = new System.Drawing.Point(6, 144);
            this.ShopCheckBox.Name = "ShopCheckBox";
            this.ShopCheckBox.Size = new System.Drawing.Size(70, 17);
            this.ShopCheckBox.TabIndex = 1;
            this.ShopCheckBox.Text = "Магазин";
            this.ShopCheckBox.UseVisualStyleBackColor = true;
            this.ShopCheckBox.CheckedChanged += new System.EventHandler(this.ShopCheckBox_CheckedChanged);
            // 
            // ValueCheckBox
            // 
            this.ValueCheckBox.AutoSize = true;
            this.ValueCheckBox.Location = new System.Drawing.Point(6, 121);
            this.ValueCheckBox.Name = "ValueCheckBox";
            this.ValueCheckBox.Size = new System.Drawing.Size(113, 17);
            this.ValueCheckBox.TabIndex = 4;
            this.ValueCheckBox.Text = "Величина скидки";
            this.ValueCheckBox.UseVisualStyleBackColor = true;
            this.ValueCheckBox.CheckedChanged += new System.EventHandler(this.ValueCheckBox_CheckedChanged);
            // 
            // SertificateDiscountNoPeriodСheckBox
            // 
            this.SertificateDiscountNoPeriodСheckBox.AutoSize = true;
            this.SertificateDiscountNoPeriodСheckBox.Location = new System.Drawing.Point(6, 29);
            this.SertificateDiscountNoPeriodСheckBox.Name = "SertificateDiscountNoPeriodСheckBox";
            this.SertificateDiscountNoPeriodСheckBox.Size = new System.Drawing.Size(202, 17);
            this.SertificateDiscountNoPeriodСheckBox.TabIndex = 1;
            this.SertificateDiscountNoPeriodСheckBox.Text = "Бесрочная скидка по сертификату";
            this.SertificateDiscountNoPeriodСheckBox.UseVisualStyleBackColor = true;
            // 
            // ProcentDiscountWithPeriodСheckBox
            // 
            this.ProcentDiscountWithPeriodСheckBox.AutoSize = true;
            this.ProcentDiscountWithPeriodСheckBox.Location = new System.Drawing.Point(6, 98);
            this.ProcentDiscountWithPeriodСheckBox.Name = "ProcentDiscountWithPeriodСheckBox";
            this.ProcentDiscountWithPeriodСheckBox.Size = new System.Drawing.Size(184, 17);
            this.ProcentDiscountWithPeriodСheckBox.TabIndex = 3;
            this.ProcentDiscountWithPeriodСheckBox.Text = "Временная процентная скидка";
            this.ProcentDiscountWithPeriodСheckBox.UseVisualStyleBackColor = true;
            // 
            // SertificateDiscountWithPeriodСheckBox
            // 
            this.SertificateDiscountWithPeriodСheckBox.AutoSize = true;
            this.SertificateDiscountWithPeriodСheckBox.Location = new System.Drawing.Point(6, 52);
            this.SertificateDiscountWithPeriodСheckBox.Name = "SertificateDiscountWithPeriodСheckBox";
            this.SertificateDiscountWithPeriodСheckBox.Size = new System.Drawing.Size(205, 17);
            this.SertificateDiscountWithPeriodСheckBox.TabIndex = 1;
            this.SertificateDiscountWithPeriodСheckBox.Text = "Временная скидка по сертификату";
            this.SertificateDiscountWithPeriodСheckBox.UseVisualStyleBackColor = true;
            // 
            // ProcentDiscountNoPeriodСheckBox
            // 
            this.ProcentDiscountNoPeriodСheckBox.AutoSize = true;
            this.ProcentDiscountNoPeriodСheckBox.Location = new System.Drawing.Point(6, 75);
            this.ProcentDiscountNoPeriodСheckBox.Name = "ProcentDiscountNoPeriodСheckBox";
            this.ProcentDiscountNoPeriodСheckBox.Size = new System.Drawing.Size(187, 17);
            this.ProcentDiscountNoPeriodСheckBox.TabIndex = 2;
            this.ProcentDiscountNoPeriodСheckBox.Text = "Бессрочная процентная скидка";
            this.ProcentDiscountNoPeriodСheckBox.UseVisualStyleBackColor = true;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(18, 195);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(239, 23);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.Text = "Искать";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchDiscountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 230);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.DiscountSearchGroupBox);
            this.MaximumSize = new System.Drawing.Size(297, 269);
            this.MinimumSize = new System.Drawing.Size(297, 269);
            this.Name = "SearchDiscountForm";
            this.Text = "Поиск";
            this.Load += new System.EventHandler(this.SearchDiscountForm_Load);
            this.DiscountSearchGroupBox.ResumeLayout(false);
            this.DiscountSearchGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox DiscountSearchGroupBox;
        private System.Windows.Forms.CheckBox ShopCheckBox;
        private System.Windows.Forms.CheckBox ValueCheckBox;
        private System.Windows.Forms.CheckBox SertificateDiscountNoPeriodСheckBox;
        private System.Windows.Forms.CheckBox ProcentDiscountWithPeriodСheckBox;
        private System.Windows.Forms.CheckBox SertificateDiscountWithPeriodСheckBox;
        private System.Windows.Forms.CheckBox ProcentDiscountNoPeriodСheckBox;
        private System.Windows.Forms.TextBox DiscountValueTextBox;
        private System.Windows.Forms.ComboBox ShopComboBox;
        private System.Windows.Forms.Button SearchButton;
    }
}