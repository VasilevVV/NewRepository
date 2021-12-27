using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Класс с инструментами для работы с DateTimePicker
    /// </summary>
    public class DataTimePickersTools
    {
        //TODO: Соответствие XML коду
        /// <summary>
        /// Выполняет формирование DateTime из Picker-ов
        /// </summary>
        /// <param name="DatePicker">Picker с датой</param>
        /// <param name="TimePicker">Picker с временем</param>
        /// <returns>Сформированная DateTime</returns>
        public static DateTime GetDataTimeFromPickers
            (DateTimePicker DatePicker, DateTimePicker TimePicker)
        {
            return new DateTime
                (DatePicker.Value.Year,
                DatePicker.Value.Month,
                DatePicker.Value.Day,
                TimePicker.Value.Hour,
                TimePicker.Value.Minute,
                TimePicker.Value.Second,
                TimePicker.Value.Millisecond);
        }
    }
}
