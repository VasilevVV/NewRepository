using System;
using System.Collections.Generic;
using System.Text;

namespace TPU.LB2.PersonLibrary
{
    //TODO: RSDN (V)
    /// <summary>
    /// класс ребенка
    /// </summary>
    public class Child : PersonBase
    {
        /// <summary>
        /// публичный параметр о матери
        /// </summary>
        public Adult Mother { get; set; }

        /// <summary>
        /// публичный параметр об отце
        /// </summary>
        public Adult Father { get; set; }

        /// <summary>
        /// публичный параметр о месте учебы
        /// </summary>
        public string Education { get; set; }


        /// <summary>
        /// конструктор ребенка
        /// </summary>
        public Child() : base()
        { }

        /// <summary>
        /// информация о ребенке
        /// </summary>
        public override string Infomation
        {
            get
            {
                string parents;
                if ((Mother == null) && (Father == null))
                {
                    parents = "отсутствуют";
                }
                else if ((Mother != null) && (Father == null))
                {
                    parents = $"мать-одиночка - {Mother.Name} " +
                              $"{Mother.Surname}";
                }
                else if ((Mother == null) && (Father != null))
                {
                    parents = $"отец-одиночка - {Father.Name} " +
                              $"{Father.Surname}";
                }
                else
                {
                    parents = $"отец - {Father.Name} {Father.Surname}, " +
                              $"мать - {Mother.Name} {Mother.Surname}";
                }

                string education = Education != null
                    ? $"{Education}"
                    : "нет";

                return base.Infomation +
                    $"родители: {parents}\n" +
                    $"учебное заведение: {education}\n";
            }
        }

        /// <summary>
        /// Наибольший возраст ребёнка
        /// </summary>
        public const int MaxChildAge = 17;

        /// <summary>
        /// проверка правильности возраста
        /// </summary>
        /// <param name="age">возраст</param>
        protected override void AgeCheck(int age)
        {
            if ((age >= MaxChildAge) || (age < MinAge))
            {
                throw new ArgumentException($"Возраст ребёнка должен " +
                    $"быть от {MinAge} до {MaxChildAge} включительно");
            }
        }

        /// <summary>
        /// Добавление традиционного места учебы ребенку
        /// </summary>
        /// <returns>School of Kindergarten</returns>
        public string GetSimpleEducation()
        {
            //TODO: скобочки (V)
            if (Аge >= 7)
            {
                Education = "School";
            }
            else if (Аge < 7 && Аge > 3)
            {
                Education = "Kindergarten";
            }
            return Education;
        }

        /// <summary>
        /// Добавление заданного места учебы ребенку
        /// (Для проверки типа по заданию)
        /// </summary>
        /// <param name="education">Название места учебы</param>
        /// <returns>Сообщение о смене места учебы</returns>
        public string GetEducation(string education)
        {
            this.Education = education;
            return $"Теперь у {Name} {Surname} место учёбы: {Education}";
        }
    }
}
