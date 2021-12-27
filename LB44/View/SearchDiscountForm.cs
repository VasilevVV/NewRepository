using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model.DiscountsNamespace;

namespace View
{
    /// <summary>
    /// Класс, описывающий форму для поиска 
    /// </summary>
    public partial class SearchDiscountForm : Form
    {
        /// <summary>
        /// Ивент для передачи данных 
        /// </summary>
        public event EventHandler<DiscountEventArgs> SendDataFromFormEvent;

        /// <summary>
        /// Инициализация формы
        /// </summary>
        /// <param name="discountList"></param>
        public SearchDiscountForm(List<IDiscount> discountList)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _listDiscountSearch = discountList;
            MaximizeBox = false;
            DiscountValueTextBox.Enabled = false;
            ShopComboBox.Enabled = false;

            HashSet<string> shopComboBoxItems = new HashSet<string>();
            foreach (IDiscount discount in _listDiscountSearch)
            {
                if (discount is DiscountBase discountBase)
                {
                    shopComboBoxItems.Add(discountBase.Shop);
                }
            }
            ShopComboBox.Items.AddRange(shopComboBoxItems.ToArray());

            StartDateFromPicker.Value = DateTime.Now;
            StartTimeFromPicker.Value = DateTime.Now;
            StartDateByPicker.Value = DateTime.Now;
            StartTimeByPicker.Value = DateTime.Now;
            EndDateFromPicker.Value = DateTime.Now;
            EndTimeFromPicker.Value = DateTime.Now;
            EndDateByPicker.Value = DateTime.Now;
            EndTimeByPicker.Value = DateTime.Now;
            StartDateFromPicker.Enabled = false;
            StartTimeFromPicker.Enabled = false;
            StartDateByPicker.Enabled = false;
            StartTimeByPicker.Enabled = false;
            EndDateFromPicker.Enabled = false;
            EndTimeFromPicker.Enabled = false;
            EndDateByPicker.Enabled = false;
            EndTimeByPicker.Enabled = false;
            StartDateFromLabel.Enabled = false;
            StartDateByLabel.Enabled = false;
            EndDateFromLabel.Enabled = false;
            EndDateByLabel.Enabled = false;

            EndDateCheckBox.Enabled = false;
            StartDateCheckBox.Enabled = false;
        }

        /// <summary>
        /// Лист фильтрованных скидок
        /// </summary>
        private readonly List<IDiscount> _listDiscountSearch;
        
        /// <summary>
        /// Кнопка поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            int count = 0;
            List<IDiscount> findDiscounts = new List<IDiscount>();
            if (SertificateDiscountInfiniteСheckBox.Checked == false &&
                SertificateDiscountPeriodСheckBox.Checked == false &&
                ProcentDiscountInfiniteСheckBox.Checked == false &&
                ProcentDiscountPeriodСheckBox.Checked == false &&
                ValueCheckBox.Checked == false &&
                ShopCheckBox.Checked == false &&
                StartDateCheckBox.Checked == false &&
                EndDateCheckBox.Checked == false)
            {
                MessageBox.Show("Вы не ввели критерии для поиска!");
                return;
            }
            foreach (IDiscount findDiscount in _listDiscountSearch)
            {
                // TODO: Не очевидный код. (V)
                // TODO: Срабатывать на найденный список скидок. (V)
                if (findDiscount is ProcentDiscount procentDiscount)
                {
                    DiscountTypeSearcher(procentDiscount, 
                        ref count, ref findDiscounts, 
                        ProcentDiscountInfiniteСheckBox, 
                        ProcentDiscountPeriodСheckBox);
                }
                if (findDiscount is SertificateDiscount sertificateDiscount)
                {
                    DiscountTypeSearcher(sertificateDiscount,
                        ref count, ref findDiscounts,
                        SertificateDiscountInfiniteСheckBox,
                        SertificateDiscountPeriodСheckBox);
                }
                if (ValueCheckBox.Checked && 
                    findDiscount is DiscountBase discountBaseForValue &&
                    discountBaseForValue.DiscountValue.ToString().
                    StartsWith(DiscountValueTextBox.Text))
                {
                    count++;
                    findDiscounts.Add(findDiscount);
                }
                if (ShopCheckBox.Checked &&
                    findDiscount is DiscountBase discountBaseForShop &&
                    discountBaseForShop.Shop.
                    StartsWith(ShopComboBox.Text))
                {
                    count++;
                    findDiscounts.Add(findDiscount);
                }
                if (StartDateCheckBox.Checked && !EndDateCheckBox.Checked &&
                    findDiscount is DiscountBase discountBaseForStartDate &&
                    discountBaseForStartDate.Period.DateTimeDiscountStart >= 
                    DataTimePickersTools.GetDataTimeFromPickers
                    (StartDateFromPicker, StartTimeFromPicker) &&
                    discountBaseForStartDate.Period.DateTimeDiscountStart <=
                    DataTimePickersTools.GetDataTimeFromPickers
                    (StartDateByPicker, StartDateByPicker) &&
                    discountBaseForStartDate.Period.DateTimeDiscountEnd != 
                    DateTime.MaxValue)
                {
                    count++;
                    findDiscounts.Add(findDiscount);
                }
                if (EndDateCheckBox.Checked && !StartDateCheckBox.Checked &&
                    findDiscount is DiscountBase discountBaseForEndDate &&
                    discountBaseForEndDate.Period.DateTimeDiscountEnd >=
                    DataTimePickersTools.GetDataTimeFromPickers
                    (EndDateFromPicker, EndTimeFromPicker) &&
                    discountBaseForEndDate.Period.DateTimeDiscountEnd <=
                    DataTimePickersTools.GetDataTimeFromPickers
                    (EndDateByPicker, EndTimeByPicker) &&
                    discountBaseForEndDate.Period.DateTimeDiscountEnd !=
                    DateTime.MaxValue)
                {
                    count++;
                    findDiscounts.Add(findDiscount);
                }
                if (EndDateCheckBox.Checked && StartDateCheckBox.Checked 
                    && findDiscount is DiscountBase discountBaseForDate 
                    && discountBaseForDate.Period.DateTimeDiscountEnd <=
                        DataTimePickersTools.GetDataTimeFromPickers(EndDateFromPicker, EndTimeFromPicker) 
                    && discountBaseForDate.Period.DateTimeDiscountStart <=
                        DataTimePickersTools.GetDataTimeFromPickers(StartDateByPicker, StartDateByPicker) 
                    && discountBaseForDate.Period.DateTimeDiscountStart >=
                        DataTimePickersTools.GetDataTimeFromPickers(StartDateFromPicker, StartTimeFromPicker) 
                    && discountBaseForDate.Period.DateTimeDiscountEnd <=
                        DataTimePickersTools.GetDataTimeFromPickers(EndDateByPicker, EndTimeByPicker) 
                    && discountBaseForDate.Period.DateTimeDiscountEnd != DateTime.MaxValue)
                {
                    count++;
                    findDiscounts.Add(findDiscount);
                }
            }
            if (count == 0)
            {
                MessageBox.Show("Таких скидок нет: " +
                    "или вы ввели нечисловое значение, " +
                    "или неправильно ввели даты.\n" +
                    "Будьте внимательны!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SendDataFromFormEvent?.
                Invoke(this, new DiscountEventArgs(findDiscounts));
            Close();
            SertificateDiscountInfiniteСheckBox.Checked = false;
            SertificateDiscountPeriodСheckBox.Checked = false;
            ProcentDiscountInfiniteСheckBox.Checked = false;
            ProcentDiscountPeriodСheckBox.Checked = false;
            ValueCheckBox.Checked = false;
            ShopCheckBox.Checked = false;
            StartDateCheckBox.Checked = false;
            EndDateCheckBox.Checked = false;
        }

        //TODO: RSDN
        /// <summary>
        /// Определения соответствия типа скидки и СheckBox-ов
        /// </summary>
        /// <param name="discount">Определяемая скидка</param>
        /// <param name="count">Счетчик найденных скидок</param>
        /// <param name="findDiscounts">Список отфильтрованных скидок</param>
        /// <param name="InfiniteСheckBox">СheckBox для скидки
        /// без периода</param>
        /// <param name="PeriodСheckBox">СheckBox для ограниченных 
        /// временем скидок</param>
        private void DiscountTypeSearcher
            (DiscountBase discount, ref int count, ref List<IDiscount> findDiscounts,
             CheckBox InfiniteСheckBox, CheckBox PeriodСheckBox)
        {
            if (discount.Period.DateTimeDiscountEnd ==
                        DateTime.MaxValue)
            {
                if (InfiniteСheckBox.Checked)
                {
                    count++;
                    findDiscounts.Add(discount);
                }
            }
            else
            {
                if (PeriodСheckBox.Checked)
                {
                    count++;
                    findDiscounts.Add(discount);
                }
            }
        }

        /// <summary>
        /// Обработка чисел
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiscountValueTextBox_KeyPress(object sender,
            KeyPressEventArgs e)
        {
            if (float.TryParse(((TextBox)sender).Text + e.KeyChar, out _)
                || e.KeyChar == (char)Keys.Back) return;
        }

        /// <summary>
        /// Обработчик изменения свойства Check объекта ValueCheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValueCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DiscountValueTextBox.Enabled = ValueCheckBox.Checked;
        }

        /// <summary>
        /// Обработчик изменения свойства Check объекта ShopCheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ShopComboBox.Enabled = ShopCheckBox.Checked;
        }

        /// <summary>
        /// Обработчик изменения свойства Check объекта EndDateCheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            EndDateFromPicker.Enabled = EndDateCheckBox.Checked;
            EndTimeFromPicker.Enabled = EndDateCheckBox.Checked;
            EndDateByPicker.Enabled = EndDateCheckBox.Checked;
            EndTimeByPicker.Enabled = EndDateCheckBox.Checked;
            EndDateFromLabel.Enabled = EndDateCheckBox.Checked;
            EndDateByLabel.Enabled = EndDateCheckBox.Checked;
        }
        
        /// <summary>
        /// Обработчик изменения свойства Check объекта StartDateCheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            StartDateFromPicker.Enabled = StartDateCheckBox.Checked;
            StartTimeFromPicker.Enabled = StartDateCheckBox.Checked;
            StartDateByPicker.Enabled = StartDateCheckBox.Checked;
            StartTimeByPicker.Enabled = StartDateCheckBox.Checked;
            StartDateFromLabel.Enabled = StartDateCheckBox.Checked;
            StartDateByLabel.Enabled = StartDateCheckBox.Checked;
        }

        /// <summary>
        /// Обработчик изменения свойства Check объекта SertificateDiscountPeriodСheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SertificateDiscountPeriodСheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //TODO: Дубль
            EndDateCheckBox.Enabled = 
                ProcentDiscountPeriodСheckBox.Checked || SertificateDiscountPeriodСheckBox.Checked;
            StartDateCheckBox.Enabled = 
                ProcentDiscountPeriodСheckBox.Checked || SertificateDiscountPeriodСheckBox.Checked;
        }

        /// <summary>
        /// Обработчик изменения свойства Check объекта ProcentDiscountPeriodСheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcentDiscountPeriodСheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //TODO: Дубль
            EndDateCheckBox.Enabled = 
                ProcentDiscountPeriodСheckBox.Checked || SertificateDiscountPeriodСheckBox.Checked;
            StartDateCheckBox.Enabled = 
                ProcentDiscountPeriodСheckBox.Checked || SertificateDiscountPeriodСheckBox.Checked;
        }
        
    }
}
