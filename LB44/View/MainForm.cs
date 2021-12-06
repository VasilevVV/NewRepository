using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using DiscountsNamespace;

namespace View
{
    /// <summary>
    /// Класс главной формы
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Инициализация формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            DiscountDataGridView.AllowUserToAddRows = false;
            DiscountDataGridView.RowHeadersVisible = false;
            DropFilterButton.Enabled = false;
            CalculateButton.Enabled = false;
            PriceTextBox.TextChanged += ShowCalculateButton;
        }

        /// <summary>
		/// Cписок фигур
		/// </summary>
		private BindingList<IDiscount> _discountList =
            new BindingList<IDiscount>();

        /// <summary>
        /// Лист фильтрованных фигур
        /// </summary>
        private readonly BindingList<IDiscount> _listForSearch =
            new BindingList<IDiscount>();

        /// <summary>
        /// Для файлов
        /// </summary>
        private readonly XmlSerializer _serializer =
            new XmlSerializer(typeof(BindingList<DiscountBase>));

        /// <summary>
        /// Загрузка формы
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            DataGridTools.CreateTable(_discountList, DiscountDataGridView);
        }

        /// <summary>
        /// Добавление скидки
        /// </summary>
        private void AddDiscountButton_Click(object sender, EventArgs e)
        {
            AddDiscountForm addDiscountForm = new AddDiscountForm();

            if (addDiscountForm.ShowDialog() == DialogResult.OK)
            {
                _discountList.Add((IDiscount)addDiscountForm.DiscountData);
            }
        }

        /// <summary>
        /// Удаление скидки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteDiscountButton_Click(object sender, EventArgs e)
        {
            int countOfRows = DiscountDataGridView.SelectedRows.Count;
            for (int i = 0; i < countOfRows; i++)
            {
                _discountList.RemoveAt(DiscountDataGridView.SelectedRows[0].Index);
            }
        }

        private void RandomDiscountButton_Click(object sender, EventArgs e)
        {
            _discountList.Add((IDiscount)RandomDiscount.GetRandomDiscount());
        }

        /// <summary>
        /// Поиск скидки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchDiscountForm figureSearch = 
                new SearchDiscountForm(_discountList);
            figureSearch.SendDataFromFormEvent += AddSearchFigureEvent;
            figureSearch.Show();
        }

        /// <summary>
        /// Обработчик события получения данных из формы поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddSearchFigureEvent(object sender, DiscountEventArgs e)
        {
            _listForSearch.Add(e.SendingDiscount);
            DataGridTools.CreateTable(_listForSearch, DiscountDataGridView);
            DropFilterButton.Enabled = true;
            DeleteDiscountButton.Enabled = false;
            SearchButton.Enabled = false;
            AddDiscountButton.Enabled = false;
            RandomDiscountButton.Enabled = false;
        }

        /// <summary>
        /// Сброс фильтра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DropFilterButton_Click(object sender, EventArgs e)
        {
            DiscountDataGridView.DataSource = null;
            DataGridTools.CreateTable(_discountList, DiscountDataGridView);
            DropFilterButton.Enabled = false;
            DeleteDiscountButton.Enabled = true;
            SearchButton.Enabled = true;
            AddDiscountButton.Enabled = true;
            RandomDiscountButton.Enabled = true;
            _listForSearch.Clear();
        }

        /// <summary>
        /// Расчет цены со скидкой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            float priceAllDiscounts = float.Parse(PriceTextBox.Text);
            int countOfRows = DiscountDataGridView.SelectedRows.Count;
            for (int i = 0; i < countOfRows; i++)
            {
                priceAllDiscounts = _discountList[DiscountDataGridView.
                        SelectedRows[i].Index].GetPrice(priceAllDiscounts);

            }
            ResultPriceTextBox.Text = $"{priceAllDiscounts}";
        }

        /// <summary>
        /// Активация кнопки Расчитать при заполнении поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowCalculateButton(object sender, EventArgs e)
        {
            float result = 0;
            CalculateButton.Enabled =
                float.TryParse(PriceTextBox.Text, out result) &&
                result > 0.0f && !string.IsNullOrEmpty(PriceTextBox.Text);
        }

        /// <summary>
        /// Сохранить скидки в файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void сохранитьToolStripMenuItem_Click
            (object sender, EventArgs e)
        {
            if (_discountList.Count == 0)
            {
                MessageBox.Show("Отсутствуют данные для сохранения.",
                    "Данные не сохранены",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Файлы (*.discounts)|*.discounts|Все файлы " +
                "(*.*)|*.*",
                AddExtension = true,
                DefaultExt = ".discounts"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName.ToString();

                BindingList<DiscountBase> discountBaseList = 
                    new BindingList<DiscountBase>();
                foreach (IDiscount discount in _discountList)
                {
                    if (discount is DiscountBase discountBase)
                    {
                        discountBaseList.Add(discountBase);
                    }
                }

                using (FileStream fileStream = new FileStream(path,
                    FileMode.OpenOrCreate))
                {
                    _serializer.Serialize(fileStream, discountBaseList);
                }
                MessageBox.Show("Файл успешно сохранён.", 
                    "Сохранение завершено",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Загрузить скидки из списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenToolStripMenuItem_Click
            (object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Файлы (*.discounts)|*.discounts|Все файлы " +
                "(*.*)|*.*",
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            string path = openFileDialog.FileName.ToString();


            BindingList<DiscountBase> discountBaseList =
                    new BindingList<DiscountBase>();

            using (FileStream fileStream = new FileStream(path,
                FileMode.OpenOrCreate))
            {
                discountBaseList = (BindingList<DiscountBase>)_serializer.
                    Deserialize(fileStream);
            }

            foreach (DiscountBase discount in discountBaseList)
            {
                if (discount is IDiscount discountBase)
                {
                    _discountList.Add(discountBase);
                }
            }

            DataGridTools.CreateTable(_discountList, DiscountDataGridView);

            MessageBox.Show("Файл успешно загружен.", "Загрузка завершена",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            try
            {
                
            }
            catch (Exception)
            {
                MessageBox.Show("Файл повреждён или не соответствует формату.",
                    "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
