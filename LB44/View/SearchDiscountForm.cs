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
            _listDiscountSearch = discountList;
            MaximizeBox = false;
            DiscountValueTextBox.Enabled = false;
            ShopComboBox.Enabled = false;

            // TODO: RSDN?
            // инициализация ShopComboBox.Items
            HashSet<string> ShopComboBoxItems = new HashSet<string>();
            foreach (IDiscount discount in _listDiscountSearch)
            {
                if (discount is DiscountBase discountBase)
                {
                    ShopComboBoxItems.Add(discountBase.Shop);
                }
            }
            ShopComboBox.Items.AddRange(ShopComboBoxItems.ToArray());
        }

        /// <summary>
        /// Лист фильтрованных скидок
        /// </summary>
        private readonly List<IDiscount> _listDiscountSearch;

        /// <summary>
        /// Загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchDiscountForm_Load(object sender, EventArgs e)
        {
            // TODO: RSDN
        }

        /// <summary>
        /// Кнопка поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            int count = 0;

            if (SertificateDiscountNoPeriodСheckBox.Checked == false &&
                SertificateDiscountWithPeriodСheckBox.Checked == false &&
                ProcentDiscountNoPeriodСheckBox.Checked == false &&
                ProcentDiscountWithPeriodСheckBox.Checked == false &&
                ValueCheckBox.Checked == false &&
                ShopCheckBox.Checked == false)
            {
                MessageBox.Show("Вы не ввели критерии для поиска!");
                return;
            }

            foreach (IDiscount findDiscount in _listDiscountSearch)
            {
                switch (findDiscount)
                {
                    // TODO: Не очевидный код.
                    //TODO: Срабатывать на найденный список скидок.
                    case SertificateDiscount findSertificateDiscountNoPeriod
                        when SertificateDiscountNoPeriodСheckBox.Checked &&
                        findSertificateDiscountNoPeriod.Period.DateTimeDiscountEnd 
                                                        == DateTime.MaxValue:
                    case SertificateDiscount findSertificateDiscountWithPeriod
                        when SertificateDiscountWithPeriodСheckBox.Checked &&
                        findSertificateDiscountWithPeriod.Period.DateTimeDiscountEnd
                                                        != DateTime.MaxValue:
                    case ProcentDiscount findProcentDiscountNoPeriod
                        when ProcentDiscountNoPeriodСheckBox.Checked &&
                        findProcentDiscountNoPeriod.Period.DateTimeDiscountEnd
                                                        == DateTime.MaxValue:
                    case ProcentDiscount findProcentDiscountWithPeriod
                        when ProcentDiscountWithPeriodСheckBox.Checked &&
                        findProcentDiscountWithPeriod.Period.DateTimeDiscountEnd
                                                        != DateTime.MaxValue:
                        {
                            count++;
                            SendDataFromFormEvent?.Invoke(this,
                                new DiscountEventArgs(findDiscount));
                            break;
                        }
                }

                if (ValueCheckBox.Checked && 
                    findDiscount is DiscountBase discountBaseForValue &&
                    discountBaseForValue.DiscountValue.ToString().
                    StartsWith(DiscountValueTextBox.Text))
                {
                    count++;
                    SendDataFromFormEvent?.Invoke(this,
                        new DiscountEventArgs(findDiscount));
                }

                if (ShopCheckBox.Checked &&
                    findDiscount is DiscountBase discountBaseForShop &&
                    discountBaseForShop.Shop.
                    StartsWith(ShopComboBox.Text))
                {
                    count++;
                    SendDataFromFormEvent?.Invoke(this,
                        new DiscountEventArgs(findDiscount));
                }
            }

            if (count == 0)
            {
                MessageBox.Show("Таких скидок нет " +
                    "или вы ввели нечисловое значение.\n" +
                    "Будьте внимательны!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
            SertificateDiscountNoPeriodСheckBox.Checked = false;
            SertificateDiscountWithPeriodСheckBox.Checked = false;
            ProcentDiscountNoPeriodСheckBox.Checked = false;
            ProcentDiscountWithPeriodСheckBox.Checked = false;
            ValueCheckBox.Checked = false;
            ShopCheckBox.Checked = false;
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
        /// Обработчик изменения свойства Check объекта ValueCheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ShopComboBox.Enabled = ShopCheckBox.Checked;
        }
    }
}
