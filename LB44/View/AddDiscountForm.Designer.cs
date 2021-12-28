
namespace View
{
    partial class AddDiscountForm
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
            this.components = new System.ComponentModel.Container();
            this.DiscountChoiceСomboBox = new System.Windows.Forms.ComboBox();
            this.DiscountChoiseGroupBox = new System.Windows.Forms.GroupBox();
            this.OkAddDiscountButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ShopTextBox = new System.Windows.Forms.TextBox();
            this.ValueTextBox = new System.Windows.Forms.TextBox();
            this.ParametrsGroupBox = new System.Windows.Forms.GroupBox();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.ShopLabel = new System.Windows.Forms.Label();
            this.StartDateTimeLabel = new System.Windows.Forms.Label();
            this.EndDateTimeLabel = new System.Windows.Forms.Label();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.StartTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.PeriodGroupBox = new System.Windows.Forms.GroupBox();
            this.AddFormToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.AddFormErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.DiscountChoiseGroupBox.SuspendLayout();
            this.ParametrsGroupBox.SuspendLayout();
            this.PeriodGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddFormErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // DiscountChoiceСomboBox
            // 
            this.DiscountChoiceСomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DiscountChoiceСomboBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.DiscountChoiceСomboBox.FormattingEnabled = true;
            this.DiscountChoiceСomboBox.Items.AddRange(new object[] {
            "Бессрочная скидка по сертификату",
            "Временная скидка по сертификату",
            "Бессрочная процентная скидка",
            "Временная процентная скидка"});
            this.DiscountChoiceСomboBox.Location = new System.Drawing.Point(6, 21);
            this.DiscountChoiceСomboBox.Name = "DiscountChoiceСomboBox";
            this.DiscountChoiceСomboBox.Size = new System.Drawing.Size(236, 21);
            this.DiscountChoiceСomboBox.TabIndex = 0;
            this.DiscountChoiceСomboBox.SelectedIndexChanged += new System.EventHandler(this.DiscountChoiceСomboBox_SelectedIndexChanged);
            // 
            // DiscountChoiseGroupBox
            // 
            this.DiscountChoiseGroupBox.AutoSize = true;
            this.DiscountChoiseGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DiscountChoiseGroupBox.Controls.Add(this.DiscountChoiceСomboBox);
            this.DiscountChoiseGroupBox.Location = new System.Drawing.Point(26, 22);
            this.DiscountChoiseGroupBox.Name = "DiscountChoiseGroupBox";
            this.DiscountChoiseGroupBox.Size = new System.Drawing.Size(248, 61);
            this.DiscountChoiseGroupBox.TabIndex = 1;
            this.DiscountChoiseGroupBox.TabStop = false;
            this.DiscountChoiseGroupBox.Text = "Выбирете тип";
            // 
            // OkAddDiscountButton
            // 
            this.OkAddDiscountButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OkAddDiscountButton.Location = new System.Drawing.Point(32, 334);
            this.OkAddDiscountButton.Name = "OkAddDiscountButton";
            this.OkAddDiscountButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.OkAddDiscountButton.Size = new System.Drawing.Size(75, 23);
            this.OkAddDiscountButton.TabIndex = 2;
            this.OkAddDiscountButton.Text = "OK";
            this.AddFormToolTip.SetToolTip(this.OkAddDiscountButton, "Для активации кнопки ОК должны быть корректно заполнены все поля");
            this.OkAddDiscountButton.UseVisualStyleBackColor = true;
            this.OkAddDiscountButton.Click += new System.EventHandler(this.OkAddDiscountButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CloseButton.Location = new System.Drawing.Point(193, 334);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 3;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ShopTextBox
            // 
            this.ShopTextBox.Location = new System.Drawing.Point(128, 28);
            this.ShopTextBox.Name = "ShopTextBox";
            this.ShopTextBox.Size = new System.Drawing.Size(114, 20);
            this.ShopTextBox.TabIndex = 4;
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Location = new System.Drawing.Point(128, 63);
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Size = new System.Drawing.Size(114, 20);
            this.ValueTextBox.TabIndex = 5;
            this.AddFormToolTip.SetToolTip(this.ValueTextBox, "Величина скидки может быть числом или десятичной дробью (через \',\')");
            // 
            // ParametrsGroupBox
            // 
            this.ParametrsGroupBox.Controls.Add(this.ValueLabel);
            this.ParametrsGroupBox.Controls.Add(this.ShopLabel);
            this.ParametrsGroupBox.Controls.Add(this.ShopTextBox);
            this.ParametrsGroupBox.Controls.Add(this.ValueTextBox);
            this.ParametrsGroupBox.Location = new System.Drawing.Point(26, 98);
            this.ParametrsGroupBox.Name = "ParametrsGroupBox";
            this.ParametrsGroupBox.Size = new System.Drawing.Size(248, 102);
            this.ParametrsGroupBox.TabIndex = 7;
            this.ParametrsGroupBox.TabStop = false;
            this.ParametrsGroupBox.Text = "Свойства скидки";
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Location = new System.Drawing.Point(6, 66);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(97, 13);
            this.ValueLabel.TabIndex = 8;
            this.ValueLabel.Text = "Величина скидки:";
            // 
            // ShopLabel
            // 
            this.ShopLabel.AutoSize = true;
            this.ShopLabel.Location = new System.Drawing.Point(6, 31);
            this.ShopLabel.Name = "ShopLabel";
            this.ShopLabel.Size = new System.Drawing.Size(54, 13);
            this.ShopLabel.TabIndex = 8;
            this.ShopLabel.Text = "Магазин:";
            // 
            // StartDateTimeLabel
            // 
            this.StartDateTimeLabel.AutoSize = true;
            this.StartDateTimeLabel.Location = new System.Drawing.Point(6, 34);
            this.StartDateTimeLabel.Name = "StartDateTimeLabel";
            this.StartDateTimeLabel.Size = new System.Drawing.Size(47, 13);
            this.StartDateTimeLabel.TabIndex = 9;
            this.StartDateTimeLabel.Text = "Начало:";
            // 
            // EndDateTimeLabel
            // 
            this.EndDateTimeLabel.AutoSize = true;
            this.EndDateTimeLabel.Location = new System.Drawing.Point(6, 69);
            this.EndDateTimeLabel.Name = "EndDateTimeLabel";
            this.EndDateTimeLabel.Size = new System.Drawing.Size(65, 13);
            this.EndDateTimeLabel.TabIndex = 8;
            this.EndDateTimeLabel.Text = "Окончание:";
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDatePicker.Location = new System.Drawing.Point(77, 28);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(91, 20);
            this.StartDatePicker.TabIndex = 8;
            this.StartDatePicker.Value = new System.DateTime(2021, 12, 2, 0, 0, 0, 0);
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndDatePicker.Location = new System.Drawing.Point(77, 63);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(91, 20);
            this.EndDatePicker.TabIndex = 8;
            this.EndDatePicker.Value = new System.DateTime(2021, 12, 2, 0, 0, 0, 0);
            // 
            // StartTimePicker
            // 
            this.StartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.StartTimePicker.Location = new System.Drawing.Point(174, 28);
            this.StartTimePicker.Name = "StartTimePicker";
            this.StartTimePicker.ShowUpDown = true;
            this.StartTimePicker.Size = new System.Drawing.Size(68, 20);
            this.StartTimePicker.TabIndex = 10;
            this.StartTimePicker.Value = new System.DateTime(2021, 12, 6, 2, 7, 29, 0);
            // 
            // EndTimePicker
            // 
            this.EndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.EndTimePicker.Location = new System.Drawing.Point(174, 63);
            this.EndTimePicker.Name = "EndTimePicker";
            this.EndTimePicker.ShowUpDown = true;
            this.EndTimePicker.Size = new System.Drawing.Size(68, 20);
            this.EndTimePicker.TabIndex = 11;
            this.EndTimePicker.Value = new System.DateTime(2021, 12, 6, 1, 59, 20, 0);
            // 
            // PeriodGroupBox
            // 
            this.PeriodGroupBox.Controls.Add(this.StartDateTimeLabel);
            this.PeriodGroupBox.Controls.Add(this.EndTimePicker);
            this.PeriodGroupBox.Controls.Add(this.EndDateTimeLabel);
            this.PeriodGroupBox.Controls.Add(this.StartDatePicker);
            this.PeriodGroupBox.Controls.Add(this.StartTimePicker);
            this.PeriodGroupBox.Controls.Add(this.EndDatePicker);
            this.PeriodGroupBox.Location = new System.Drawing.Point(26, 215);
            this.PeriodGroupBox.Name = "PeriodGroupBox";
            this.PeriodGroupBox.Size = new System.Drawing.Size(248, 102);
            this.PeriodGroupBox.TabIndex = 12;
            this.PeriodGroupBox.TabStop = false;
            this.PeriodGroupBox.Text = "Время действия скидки";
            // 
            // AddFormToolTip
            // 
            this.AddFormToolTip.AutomaticDelay = 100;
            this.AddFormToolTip.AutoPopDelay = 8000;
            this.AddFormToolTip.InitialDelay = 100;
            this.AddFormToolTip.ReshowDelay = 100;
            // 
            // AddFormErrorProvider
            // 
            this.AddFormErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.AddFormErrorProvider.ContainerControl = this;
            this.AddFormErrorProvider.RightToLeft = true;
            // 
            // AddDiscountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 376);
            this.ControlBox = false;
            this.Controls.Add(this.PeriodGroupBox);
            this.Controls.Add(this.ParametrsGroupBox);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.OkAddDiscountButton);
            this.Controls.Add(this.DiscountChoiseGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(320, 419);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(320, 300);
            this.Name = "AddDiscountForm";
            this.Text = "Добавить";
            this.DiscountChoiseGroupBox.ResumeLayout(false);
            this.ParametrsGroupBox.ResumeLayout(false);
            this.ParametrsGroupBox.PerformLayout();
            this.PeriodGroupBox.ResumeLayout(false);
            this.PeriodGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddFormErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox DiscountChoiceСomboBox;
        private System.Windows.Forms.GroupBox DiscountChoiseGroupBox;
        private System.Windows.Forms.Button OkAddDiscountButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.TextBox ShopTextBox;
        private System.Windows.Forms.TextBox ValueTextBox;
        private System.Windows.Forms.GroupBox ParametrsGroupBox;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.Label ShopLabel;
        private System.Windows.Forms.Label EndDateTimeLabel;
        private System.Windows.Forms.Label StartDateTimeLabel;
        private System.Windows.Forms.DateTimePicker EndDatePicker;
        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.DateTimePicker StartTimePicker;
        private System.Windows.Forms.DateTimePicker EndTimePicker;
        private System.Windows.Forms.GroupBox PeriodGroupBox;
        private System.Windows.Forms.ToolTip AddFormToolTip;
        private System.Windows.Forms.ErrorProvider AddFormErrorProvider;
    }
}