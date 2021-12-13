using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscountsNamespace;

namespace View
{
    /// <summary>
    /// Класс, описывающий форму добавления
    /// </summary>
    public partial class AddDiscountForm : Form
    {
        /// <summary>
        /// Инициализация формы
        /// </summary>
        public AddDiscountForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            ParametrsGroupBox.Visible = true;
            ShopLabel.Visible = false;
            ShopTextBox.Visible = false;
            ValueLabel.Visible = false;
            ValueTextBox.Visible = false;

            PeriodGroupBox.Visible = true;
            StartDateTimeLabel.Visible = false;
            StartDatePicker.Visible = false;
            StartTimePicker.Visible = false;
            EndDateTimeLabel.Visible = false;
            EndDatePicker.Visible = false;
            EndTimePicker.Visible = false;

            OkAddDiscountButton.Enabled = false;
            ShopTextBox.TextChanged += ShowOKButton;
            ValueTextBox.TextChanged += ShowOKButton;
        }

        /// <summary>
        /// Создаваемая скидка
        /// </summary>
        private IDiscount _discountData;

        /// <summary>
        /// Созданная скидка
        /// </summary>
        public IDiscount DiscountData
        {
            get
            {
                return _discountData;
            }
        }

        /// <summary>
        /// Загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDiscountForm_Load(object sender, EventArgs e)
        { }

        /// <summary>
        /// Закрыть форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Выбор скидки из выпадающего списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiscountChoiceСomboBox_SelectedIndexChanged
            (object sender, EventArgs e)
        {
            switch (DiscountChoiceСomboBox.SelectedIndex)
            {
                case 0:
                    {
                        _discountData = new SertificateDiscountNoPeriod();
                        MakeVisible();
                        break;
                    }
                case 1:
                    {
                        _discountData = new SertificateDiscountWithPeriod();
                        MakeVisible();
                        break;
                    }
                case 2:
                    {
                        _discountData = new ProcentDiscountNoPeriod();
                        MakeVisible();
                        break;
                    }
                case 3:
                    {
                        _discountData = new ProcentDiscountWithPeriod();
                        MakeVisible();
                        break;
                    }
            }
        }

        /// <summary>
        /// Добавление новой скидки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkAddDiscountButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_discountData is DiscountBase discountBase)
                {
                    discountBase.Shop = ShopTextBox.Text;
                    discountBase.DiscountValue =
                        float.Parse(ValueTextBox.Text);
                }

                if (_discountData is IDiscountWithPeriod discountWithPeriod)
                {
                    discountWithPeriod.Period.DateTimeDiscountEnd =
                        new DateTime
                        (EndDatePicker.Value.Year,
                        EndDatePicker.Value.Month,
                        EndDatePicker.Value.Day,
                        EndTimePicker.Value.Hour,
                        EndTimePicker.Value.Minute,
                        EndTimePicker.Value.Second,
                        EndTimePicker.Value.Millisecond
                        );

                    discountWithPeriod.Period.DateTimeDiscountStart =
                        new DateTime
                        (StartDatePicker.Value.Year,
                        StartDatePicker.Value.Month,
                        StartDatePicker.Value.Day,
                        StartTimePicker.Value.Hour,
                        StartTimePicker.Value.Minute,
                        StartTimePicker.Value.Second,
                        StartTimePicker.Value.Millisecond
                        );
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Установка видимых TextBox в зависимости
        /// от выбранной скидки
        /// </summary>
        private void MakeVisible()
        {
            ShopLabel.Visible = true;
            ShopTextBox.Visible = true;
            ValueLabel.Visible = true;
            ValueTextBox.Visible = true;

            StartDateTimeLabel.Visible = false;
            StartDatePicker.Visible = false;
            StartTimePicker.Visible = false;
            EndDateTimeLabel.Visible = false;
            EndDatePicker.Visible = false;
            EndTimePicker.Visible = false;

            if (_discountData is IDiscountWithPeriod)
            {
                StartDateTimeLabel.Visible = true;
                StartDatePicker.Visible = true;
                StartTimePicker.Visible = true;
                EndDateTimeLabel.Visible = true;
                EndDatePicker.Visible = true;
                EndTimePicker.Visible = true;

                StartDatePicker.Value = DateTime.Now;
                StartTimePicker.Value = DateTime.Now;
                EndDatePicker.Value = DateTime.Now;
                EndTimePicker.Value = DateTime.Now;
            }
        }

        /// <summary>
        /// Активация кнопки ОК при заполнении полей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowOKButton(object sender, EventArgs e)
        {
            OkAddDiscountButton.Enabled =
                !string.IsNullOrEmpty(ShopTextBox.Text)
                && float.TryParse(ValueTextBox.Text, out _);
        }


    }
}
