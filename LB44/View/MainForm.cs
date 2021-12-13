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
using System.Runtime.Serialization.Formatters.Binary;
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

            #if !DEBUG
            RandomDiscountButton.Visible = false;
            #endif
        }

        /// <summary>
		/// Cписок фигур для отображения информации
		/// </summary>
		private BindingList<DataGridViewDataDiscount> 
            _dataGridViewDiscountList =
            new BindingList<DataGridViewDataDiscount>();

        /// <summary>
		/// Cписок фигур используется для общения между формами
		/// </summary>
		private List<IDiscount> _discountList =
            new List<IDiscount>();

        /// <summary>
		/// Cписок фильтрованных фигур
		/// </summary>
		private BindingList<DataGridViewDataDiscount>
            _dataGridViewDiscountListForSearch =
            new BindingList<DataGridViewDataDiscount>();

        /// <summary>
        /// Для файлов
        /// </summary>
        private readonly BinaryFormatter _serializer =
            new BinaryFormatter();

        /// <summary>
        /// Загрузка формы
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            DataGridTools.CreateTable(_dataGridViewDiscountList, DiscountDataGridView);
        }

        /// <summary>
        /// Добавление скидки
        /// </summary>
        private void AddDiscountButton_Click(object sender, EventArgs e)
        {
            AddDiscountForm addDiscountForm = new AddDiscountForm();

            if (addDiscountForm.ShowDialog() == DialogResult.OK)
            {
                _discountList.Add(addDiscountForm.DiscountData);
                _dataGridViewDiscountList.Add
                (new DataGridViewDataDiscount(addDiscountForm.DiscountData));
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
                _dataGridViewDiscountList.RemoveAt
               (DiscountDataGridView.SelectedRows[0].Index);
            }
        }

        /// <summary>
        /// Добавление рандомной скидки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RandomDiscountButton_Click(object sender, EventArgs e)
        {
            IDiscount randomDiscount = RandomDiscount.GetRandomDiscount();
            _discountList.Add(randomDiscount);
            _dataGridViewDiscountList.Add
               (new DataGridViewDataDiscount(randomDiscount));
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
        private void AddSearchFigureEvent(object sender, DiscountEventArgs e)
        {
            IDiscount sendDiscount = e.SendingDiscount;
            _dataGridViewDiscountListForSearch.Add
                (new DataGridViewDataDiscount(sendDiscount));
            DataGridTools.CreateTable
                (_dataGridViewDiscountListForSearch, DiscountDataGridView);
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
            DataGridTools.CreateTable
                (_dataGridViewDiscountList, DiscountDataGridView);
            DropFilterButton.Enabled = false;
            DeleteDiscountButton.Enabled = true;
            SearchButton.Enabled = true;
            AddDiscountButton.Enabled = true;
            RandomDiscountButton.Enabled = true;
            _dataGridViewDiscountListForSearch.Clear();
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
            CalculateButton.Enabled =
                float.TryParse(PriceTextBox.Text, out float result) &&
                result > 0.0f && !string.IsNullOrEmpty(PriceTextBox.Text);
        }

        /// <summary>
        /// Сохранить скидки в файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveToolStripMenuItem_Click
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
                using (FileStream fileStream = new FileStream(path,
                    FileMode.Create))
                {
                    _serializer.Serialize(fileStream, _discountList);
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

            try
            {
                string path = openFileDialog.FileName.ToString();
                using (FileStream fileStream = new FileStream(path,
                    FileMode.OpenOrCreate))
                {
                    _discountList = (List<IDiscount>)_serializer.
                        Deserialize(fileStream);
                }

                _dataGridViewDiscountList.Clear();
                foreach (IDiscount readDiscount in _discountList)
                {
                    _dataGridViewDiscountList.Add
                        (new DataGridViewDataDiscount(readDiscount));
                }

                DataGridTools.CreateTable
                    (_dataGridViewDiscountList, DiscountDataGridView);
                MessageBox.Show("Файл успешно загружен.", "Загрузка завершена",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
