
namespace LB4
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDiscountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iDiscountBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.procentDiscountForPeriodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.procentDiscountForPeriodBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.discountPeriodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Period = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.discountValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDiscountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDiscountBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.procentDiscountForPeriodBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.procentDiscountForPeriodBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discountPeriodBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 317);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Period,
            this.discountValueDataGridViewTextBoxColumn,
            this.companyDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.iDiscountBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(465, 298);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // iDiscountBindingSource
            // 
            this.iDiscountBindingSource.DataSource = typeof(Model.IDiscount);
            // 
            // iDiscountBindingSource1
            // 
            this.iDiscountBindingSource1.DataSource = typeof(Model.IDiscount);
            // 
            // procentDiscountForPeriodBindingSource
            // 
            this.procentDiscountForPeriodBindingSource.DataSource = typeof(Model.ProcentDiscountForPeriod);
            // 
            // procentDiscountForPeriodBindingSource1
            // 
            this.procentDiscountForPeriodBindingSource1.DataSource = typeof(Model.ProcentDiscountForPeriod);
            // 
            // discountPeriodBindingSource
            // 
            this.discountPeriodBindingSource.DataSource = typeof(Model.DiscountPeriod);
            // 
            // Period
            // 
            this.Period.DataPropertyName = "Period";
            this.Period.HeaderText = "Period";
            this.Period.Name = "Period";
            // 
            // discountValueDataGridViewTextBoxColumn
            // 
            this.discountValueDataGridViewTextBoxColumn.DataPropertyName = "DiscountValue";
            this.discountValueDataGridViewTextBoxColumn.HeaderText = "DiscountValue";
            this.discountValueDataGridViewTextBoxColumn.Name = "discountValueDataGridViewTextBoxColumn";
            // 
            // companyDataGridViewTextBoxColumn
            // 
            this.companyDataGridViewTextBoxColumn.DataPropertyName = "Company";
            this.companyDataGridViewTextBoxColumn.HeaderText = "Company";
            this.companyDataGridViewTextBoxColumn.Name = "companyDataGridViewTextBoxColumn";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "ГОРЯЧИЕ СКИДКИ!!!";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDiscountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDiscountBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.procentDiscountForPeriodBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.procentDiscountForPeriodBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discountPeriodBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource iDiscountBindingSource;
        private System.Windows.Forms.DataGridViewComboBoxColumn Period;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource iDiscountBindingSource1;
        private System.Windows.Forms.BindingSource procentDiscountForPeriodBindingSource;
        private System.Windows.Forms.BindingSource procentDiscountForPeriodBindingSource1;
        private System.Windows.Forms.BindingSource discountPeriodBindingSource;
    }
}

