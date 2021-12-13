﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using DiscountsNamespace;


namespace View
{
    //TODO: RSDN
    /// <summary>
    /// Класс для создания таблицы желаемого формата в DataGridView
    /// </summary>
    class DataGridTools
    {
        /// <summary>
        /// Метод создания таблицы желаемого формата
        /// </summary>
        /// <param name="discounts">Список скидок</param>
        /// <param name="dataGridView">Форматируемый датагрид</param>
        /// <param name="dataGridView"></param>
        public static void CreateTable
            (BindingList<DataGridViewDataDiscount> discounts,
            DataGridView dataGridView)
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = discounts;
            dataGridView.Columns[0].HeaderText = "Список скидок";
            dataGridView.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.DefaultCellStyle.WrapMode = 
                DataGridViewTriState.True;
            dataGridView.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
