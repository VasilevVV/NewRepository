﻿
namespace View
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DiscountDataGridView = new System.Windows.Forms.DataGridView();
            this.iDiscountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DiscountGridGroupBox = new System.Windows.Forms.GroupBox();
            this.AddDiscountButton = new System.Windows.Forms.Button();
            this.DeleteDiscountButton = new System.Windows.Forms.Button();
            this.RandomDiscountButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.DropFilterButton = new System.Windows.Forms.Button();
            this.PriceTextBox = new System.Windows.Forms.TextBox();
            this.CalculateGroupBox = new System.Windows.Forms.GroupBox();
            this.ResultPriceTextBox = new System.Windows.Forms.TextBox();
            this.DiscountPriceLabel = new System.Windows.Forms.Label();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.MainFormToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.СontrolGroupBox = new System.Windows.Forms.GroupBox();
            this.discountInformationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewDataDiscountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiscountDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDiscountBindingSource)).BeginInit();
            this.DiscountGridGroupBox.SuspendLayout();
            this.CalculateGroupBox.SuspendLayout();
            this.СontrolGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataDiscountBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(397, 24);
            this.MainMenuStrip.TabIndex = 0;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.SaveToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.OpenToolStripMenuItem.Text = "Открыть";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.SaveToolStripMenuItem.Text = "Сохранить";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // DiscountDataGridView
            // 
            this.DiscountDataGridView.AutoGenerateColumns = false;
            this.DiscountDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DiscountDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.discountInformationDataGridViewTextBoxColumn});
            this.DiscountDataGridView.DataSource = this.dataGridViewDataDiscountBindingSource;
            this.DiscountDataGridView.Location = new System.Drawing.Point(6, 19);
            this.DiscountDataGridView.Name = "DiscountDataGridView";
            this.DiscountDataGridView.Size = new System.Drawing.Size(360, 243);
            this.DiscountDataGridView.TabIndex = 1;
            // 
            // iDiscountBindingSource
            // 
            this.iDiscountBindingSource.DataSource = typeof(DiscountsNamespace.IDiscount);
            // 
            // DiscountGridGroupBox
            // 
            this.DiscountGridGroupBox.AutoSize = true;
            this.DiscountGridGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DiscountGridGroupBox.Controls.Add(this.DiscountDataGridView);
            this.DiscountGridGroupBox.Location = new System.Drawing.Point(12, 37);
            this.DiscountGridGroupBox.Name = "DiscountGridGroupBox";
            this.DiscountGridGroupBox.Size = new System.Drawing.Size(372, 281);
            this.DiscountGridGroupBox.TabIndex = 2;
            this.DiscountGridGroupBox.TabStop = false;
            this.DiscountGridGroupBox.Text = "Скидки";
            // 
            // AddDiscountButton
            // 
            this.AddDiscountButton.Location = new System.Drawing.Point(6, 19);
            this.AddDiscountButton.Name = "AddDiscountButton";
            this.AddDiscountButton.Size = new System.Drawing.Size(112, 23);
            this.AddDiscountButton.TabIndex = 3;
            this.AddDiscountButton.Text = "Добавить скидку";
            this.AddDiscountButton.UseVisualStyleBackColor = true;
            this.AddDiscountButton.Click += new System.EventHandler(this.AddDiscountButton_Click);
            // 
            // DeleteDiscountButton
            // 
            this.DeleteDiscountButton.Location = new System.Drawing.Point(6, 48);
            this.DeleteDiscountButton.Name = "DeleteDiscountButton";
            this.DeleteDiscountButton.Size = new System.Drawing.Size(112, 23);
            this.DeleteDiscountButton.TabIndex = 4;
            this.DeleteDiscountButton.Text = "Удалить скидку";
            this.DeleteDiscountButton.UseVisualStyleBackColor = true;
            this.DeleteDiscountButton.Click += new System.EventHandler(this.DeleteDiscountButton_Click);
            // 
            // RandomDiscountButton
            // 
            this.RandomDiscountButton.Location = new System.Drawing.Point(18, 409);
            this.RandomDiscountButton.Name = "RandomDiscountButton";
            this.RandomDiscountButton.Size = new System.Drawing.Size(112, 23);
            this.RandomDiscountButton.TabIndex = 5;
            this.RandomDiscountButton.Text = "Случайная скидка";
            this.RandomDiscountButton.UseVisualStyleBackColor = true;
            this.RandomDiscountButton.Click += new System.EventHandler(this.RandomDiscountButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(126, 19);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(112, 23);
            this.SearchButton.TabIndex = 6;
            this.SearchButton.Text = "Найти";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // DropFilterButton
            // 
            this.DropFilterButton.Location = new System.Drawing.Point(126, 48);
            this.DropFilterButton.Name = "DropFilterButton";
            this.DropFilterButton.Size = new System.Drawing.Size(112, 23);
            this.DropFilterButton.TabIndex = 7;
            this.DropFilterButton.Text = "Сбросить фильтр";
            this.DropFilterButton.UseVisualStyleBackColor = true;
            this.DropFilterButton.Click += new System.EventHandler(this.DropFilterButton_Click);
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.Location = new System.Drawing.Point(10, 37);
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.Size = new System.Drawing.Size(105, 20);
            this.PriceTextBox.TabIndex = 8;
            this.MainFormToolTip.SetToolTip(this.PriceTextBox, "Необходимо ввести число больше 0, в том числе десятичные дроби (через \',\'), и выб" +
        "рать одну или несколько скидок из списка");
            // 
            // CalculateGroupBox
            // 
            this.CalculateGroupBox.Controls.Add(this.ResultPriceTextBox);
            this.CalculateGroupBox.Controls.Add(this.DiscountPriceLabel);
            this.CalculateGroupBox.Controls.Add(this.CalculateButton);
            this.CalculateGroupBox.Controls.Add(this.PriceLabel);
            this.CalculateGroupBox.Controls.Add(this.PriceTextBox);
            this.CalculateGroupBox.Location = new System.Drawing.Point(260, 324);
            this.CalculateGroupBox.Name = "CalculateGroupBox";
            this.CalculateGroupBox.Size = new System.Drawing.Size(124, 132);
            this.CalculateGroupBox.TabIndex = 9;
            this.CalculateGroupBox.TabStop = false;
            this.CalculateGroupBox.Text = "Расчитать цену";
            // 
            // ResultPriceTextBox
            // 
            this.ResultPriceTextBox.Location = new System.Drawing.Point(10, 105);
            this.ResultPriceTextBox.Name = "ResultPriceTextBox";
            this.ResultPriceTextBox.ReadOnly = true;
            this.ResultPriceTextBox.Size = new System.Drawing.Size(105, 20);
            this.ResultPriceTextBox.TabIndex = 10;
            // 
            // DiscountPriceLabel
            // 
            this.DiscountPriceLabel.AutoSize = true;
            this.DiscountPriceLabel.Location = new System.Drawing.Point(7, 89);
            this.DiscountPriceLabel.Name = "DiscountPriceLabel";
            this.DiscountPriceLabel.Size = new System.Drawing.Size(108, 13);
            this.DiscountPriceLabel.TabIndex = 10;
            this.DiscountPriceLabel.Text = "Цена после скидок:";
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(10, 63);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(105, 23);
            this.CalculateButton.TabIndex = 10;
            this.CalculateButton.Text = "Расчитать";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Location = new System.Drawing.Point(7, 21);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(78, 13);
            this.PriceLabel.TabIndex = 9;
            this.PriceLabel.Text = "Введите цену:";
            // 
            // MainFormToolTip
            // 
            this.MainFormToolTip.AutoPopDelay = 5000;
            this.MainFormToolTip.InitialDelay = 200;
            this.MainFormToolTip.ReshowDelay = 100;
            // 
            // СontrolGroupBox
            // 
            this.СontrolGroupBox.Controls.Add(this.AddDiscountButton);
            this.СontrolGroupBox.Controls.Add(this.DeleteDiscountButton);
            this.СontrolGroupBox.Controls.Add(this.DropFilterButton);
            this.СontrolGroupBox.Controls.Add(this.SearchButton);
            this.СontrolGroupBox.Location = new System.Drawing.Point(12, 324);
            this.СontrolGroupBox.Name = "СontrolGroupBox";
            this.СontrolGroupBox.Size = new System.Drawing.Size(242, 79);
            this.СontrolGroupBox.TabIndex = 10;
            this.СontrolGroupBox.TabStop = false;
            this.СontrolGroupBox.Text = "Управление";
            // 
            // discountInformationDataGridViewTextBoxColumn
            // 
            this.discountInformationDataGridViewTextBoxColumn.DataPropertyName = "DiscountInformation";
            this.discountInformationDataGridViewTextBoxColumn.HeaderText = "DiscountInformation";
            this.discountInformationDataGridViewTextBoxColumn.Name = "discountInformationDataGridViewTextBoxColumn";
            this.discountInformationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewDataDiscountBindingSource
            // 
            this.dataGridViewDataDiscountBindingSource.DataSource = typeof(View.DataGridViewDataDiscount);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 469);
            this.Controls.Add(this.СontrolGroupBox);
            this.Controls.Add(this.CalculateGroupBox);
            this.Controls.Add(this.RandomDiscountButton);
            this.Controls.Add(this.DiscountGridGroupBox);
            this.Controls.Add(this.MainMenuStrip);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(413, 508);
            this.MinimumSize = new System.Drawing.Size(413, 508);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "СКИДКИ!";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiscountDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDiscountBindingSource)).EndInit();
            this.DiscountGridGroupBox.ResumeLayout(false);
            this.CalculateGroupBox.ResumeLayout(false);
            this.CalculateGroupBox.PerformLayout();
            this.СontrolGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataDiscountBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.DataGridView DiscountDataGridView;
        private System.Windows.Forms.GroupBox DiscountGridGroupBox;
        private System.Windows.Forms.Button AddDiscountButton;
        private System.Windows.Forms.Button DeleteDiscountButton;
        private System.Windows.Forms.Button RandomDiscountButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button DropFilterButton;
        private System.Windows.Forms.TextBox PriceTextBox;
        private System.Windows.Forms.GroupBox CalculateGroupBox;
        private System.Windows.Forms.Label DiscountPriceLabel;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.TextBox ResultPriceTextBox;
        private System.Windows.Forms.ToolTip MainFormToolTip;
        private System.Windows.Forms.GroupBox СontrolGroupBox;
        private System.Windows.Forms.BindingSource iDiscountBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountInformationDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource dataGridViewDataDiscountBindingSource;
    }
}

