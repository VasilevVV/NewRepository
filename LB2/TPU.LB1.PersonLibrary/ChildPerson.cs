using System;
using System.Collections.Generic;
using System.Text;

namespace TPU.LB1.PersonLibrary
{
    public class ChildPerson : Person
    {
        /// <summary>
        /// публичный парметр о матери
        /// </summary>
        public AdultPerson Mother { get; set; }

        /// <summary>
        /// публичный парметр об отце
        /// </summary>
        public AdultPerson Father { get; set; }

        /// <summary>
        /// публичный парметр о месте учебы
        /// </summary>
        public string Education { get; set; }


        /// <summary>
        /// конструктор ребенка
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="surname">фамилия</param>
        /// <param name="age">возраст</param>
        /// <param name="gender">пол</param>
        /// <param name="education">место учебы</param>
        public ChildPerson(string name, string surname, int age,
            Gender gender, string education) : base(name, surname, age, gender)
        {
            Education = education;
        }

        /// <summary>
        /// конструктор ребенка
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="surname">фамилия</param>
        /// <param name="age">возраст</param>
        /// <param name="gender">пол</param>
        /// <param name="mother">мать</param>
        /// <param name="father">отец</param>
        /// <param name="education">место учебы</param>
        public ChildPerson(string name, string surname, int age,
            Gender gender, AdultPerson mother, AdultPerson father,
            string education) : base(name, surname, age, gender)
        {
            Mother = mother;
            Father = father;
            Education = education;
        }

        /// <summary>
        /// конструктор ребенка
        /// </summary>
        public ChildPerson() : base()
        {
        }

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
                    parents = $"мать-одиночка - {Mother.Name} {Mother.Surname}";
                }
                else if ((Mother == null) && (Father != null))
                {
                    parents = $"отец-одиночка - {Father.Name} {Father.Surname}";
                }
                else
                {
                    parents = $"отец - {Father.Name} {Father.Surname},\n" +
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
        private const int MaxChildAge = 18;

        /// <summary>
        /// проверка правильности возраста
        /// </summary>
        /// <param name="age">возраст</param>
        public override void AgeCheck(int age)
        {
            if ((age >= MaxChildAge) || (age < MinAge))
            {
                throw new ArgumentException($"Возраст ребёнка должен " +
                    $"быть от {MinAge + 1} до {MaxChildAge - 1} включительно");
            }
        }
    }
}
