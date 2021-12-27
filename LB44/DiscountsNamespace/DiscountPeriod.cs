using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DiscountsNamespace
{
    /// <summary>
    /// класс описывающий период действия скидки
    /// </summary>
    [Serializable]
    public class DiscountPeriod
    {
        /// <summary>
        /// приватное поле дата появления скидки
        /// </summary>
        private readonly DateTime _dateTimeEmergence = DateTime.Now;

        /// <summary>
        /// публичный параметр дата появления скидки
        /// устанавливает текущую дату
        /// </summary>
        public DateTime DateTimeEmergence 
        {
            get
            {
                return _dateTimeEmergence;
            }
        }

        /// <summary>
        /// приватное поле дата начала действия скидки
        /// </summary>
        private DateTime _dateTimeDiscountStart;

        /// <summary>
        /// публичный параметр дата начала действия скидки
        /// не может быть меньше даты появления скидки
        /// не может быть больше даты окончания действия скидки
        /// </summary>
        public DateTime DateTimeDiscountStart
        {
            get
            {
                return _dateTimeDiscountStart;
            }
            set
            {
                CheckDiscountStart(value);
                _dateTimeDiscountStart = value;
            }
        }

        /// <summary>
        /// приватное поле дата окончания действия скидки
        /// </summary>
        private DateTime _dateTimeDiscountEnd;

        /// <summary>
        /// публичный параметр дата окончания действия скидки
        /// не может быть меньше даты появления скидки
        /// не может быть меньше даты начала действия скидки
        /// </summary>
        public DateTime DateTimeDiscountEnd
        {
            get
            {
                return _dateTimeDiscountEnd;
            }
            set
            {
                CheckDiscountEnd(value);
                _dateTimeDiscountEnd = value;
            }
        }

        /// <summary>
        /// конструктор прост чтобы был
        /// </summary>
        public DiscountPeriod()
        { }

        /// <summary>
        /// Проверка даты начала действия скидки
        /// </summary>
        /// <param name="endDateTime">дата начала действия скидки</param>
        private void CheckDiscountEnd(DateTime endDateTime)
        {
            if ((_dateTimeDiscountStart != DateTime.MinValue && 
                (endDateTime < _dateTimeDiscountStart)) ||
                (endDateTime < _dateTimeEmergence))
            {
                throw new ArgumentException($"Дата окончания действия " +
                    $"скидки {endDateTime} не может быть " +
                    $"меньше даты появления скидки: " +
                    $"{_dateTimeEmergence}\n" +
                    $"и не может быть меньше даты начале действия скидки: " +
                    $"{_dateTimeDiscountStart}");
            }
        }

        /// <summary>
        /// Проверка даты окончания действия скидки
        /// </summary>
        /// <param name="startDateTime">дата окончания действия скидки</param>
        private void CheckDiscountStart(DateTime startDateTime)
        {
            if ((startDateTime < _dateTimeEmergence) ||
                ((startDateTime > _dateTimeDiscountEnd) &&
                (_dateTimeDiscountEnd != DateTime.MinValue)))
            {
                throw new ArgumentException($"Дата начала действия скидки " +
                    $"{startDateTime} " +
                    $"не может быть меньше даты появления скидки: " +
                    $"{_dateTimeEmergence}\n" +
                    $"и не может быть больше даты окончания действия скидки: " +
                    $"{_dateTimeDiscountEnd}");
            }
        }

        /// <summary>
        /// Показывает срок действия скидки в строке
        /// </summary>
        /// <returns>Срок действия скидки в строке</returns>
        public override string ToString()
        {
            string dateTimeDiscountStart = DateTimeDiscountStart != DateTime.MinValue
                ? DateTimeDiscountStart.ToString()
                : "неизвестно";
            string dateTimeDiscountEnd = DateTimeDiscountEnd != DateTime.MinValue
                ? DateTimeDiscountEnd.ToString()
                : "неизвестно";

            return $"Срок действия с {dateTimeDiscountStart} " +
                   $"по {dateTimeDiscountEnd}.";
        }


        /// <summary>
        /// Проверяет возможность уменьшения цены 
        /// согласно периоду действия скидки
        /// </summary>
        /// <param name="priceDecreaser">Уменьшатор цены</param>
        /// <returns>Тот же самый уменьшатор цены, 
        /// если метод вызывается в срок действия скидки</returns>
        internal float ChekPriceDecreaserForPeriod(float priceDecreaser)
        {
            if ((DateTimeDiscountStart > DateTime.Now) ||
                (DateTime.Now > DateTimeDiscountEnd))
            {
                return 0.0f;
            }
            else
            {
                return priceDecreaser;
            }
        }

    }
}