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
        /// <summary>
        /// Выполняет формирование DateTime из Picker-ов
        /// </summary>
        /// <param name="datePicker">Picker с датой</param>
        /// <param name="timePicker">Picker с временем</param>
        /// <returns>Сформированная DateTime</returns>
        public static DateTime GetDataTimeFromPickers
            (DateTimePicker datePicker, DateTimePicker timePicker)
        {
            return new DateTime
                (datePicker.Value.Year,
                datePicker.Value.Month,
                datePicker.Value.Day,
                timePicker.Value.Hour,
                timePicker.Value.Minute,
                timePicker.Value.Second,
                timePicker.Value.Millisecond);
        }
    }
}
