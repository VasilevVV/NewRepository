using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TPU.LB2.PersonLibrary
{
    /// <summary>
    /// класс взрослой персоны
    /// </summary>
    public class Adult : PersonBase
{
        /// <summary>
        /// номер паспорта
        /// </summary>
        private string _passportNumber;

        /// <summary>
        /// номер паспорта
        /// </summary>
        public string PassportNumber 
        {
            get
            {
                return _passportNumber;
            }
            set
            {
                PassportChecker(value);
                _passportNumber = value;
            }
        }
        
        /// <summary>
        /// партнер по браку
        /// </summary>
        public Adult Partner { get; set; }

        /// <summary>
        /// состояние брака
        /// </summary>
        public bool IsMarried
        {
            get
            {
                return (Partner != null);
            }
        }

        /// <summary>
        /// работа
        /// </summary>
        public string Job { get; set; }

        /// <summary>
        /// дети
        /// </summary>
        private PersonList _children = new PersonList();


        /// <summary>
        /// дети
        /// </summary>
        public PersonList Children 
        {
            get
            {
                return _children;
            }
        }
        

        /// <summary>
        /// конструктор взрослой персоны
        /// </summary>
        public Adult() : base()
        { }
               
        /// <summary>
        /// Информации о взрослой персоне
        /// </summary>
        public override string Infomation
        {
            get
            {
                string children = "";
                if ((_children != null) && (_children.Number != 0))
                {
                    children = $"{_children.GetPersonByIndex(0).Name} " +
                               $"{_children.GetPersonByIndex(0).Surname}";
                    for (int i = 1; i < _children.Number; i++)
                    {
                        children += $", {_children.GetPersonByIndex(i).Name} " +
                                    $"{_children.GetPersonByIndex(i).Surname}";
                    }
                }
                else
                {
                    children = "нет детей";
                }
                                
                string job = Job != null
                    ? $"{Job}"
                    : "безработный";
                string partner = Partner != null
                    ? $"{Partner.Name} {Partner.Surname}"
                    : "нет";
                string passportNumber = PassportNumber != null
                    ? $"{PassportNumber}"
                    : "нет паспорта";

                return base.Infomation +
                    $"паспортные данные: {passportNumber}\n" +
                    $"работа: {job}\n" +
                    $"муж/жена: {partner}\n" +
                    $"дети: {children}\n";
            }
        }

        /// <summary>
        /// Наименьший возраст взрослого
        /// </summary>
        public const int MinAdultAge = 18;

        /// <summary>
        /// Наибольший возраст деторождения
        /// </summary>
        public const int MaxAdultAgeForChild = 50;

        /// <summary>
        /// проверка правильности возраста
        /// </summary>
        /// <param name="age">возраст</param>
        protected override void AgeCheck(int age)
        {
            if ((age >= MaxAge) || (age < MinAdultAge))
            {
                throw new ArgumentException($"Возраст взрослого должен " +
                    $"быть от {MinAdultAge} до {MaxAge - 1} включительно");
            }
        }

        /// <summary>
        /// Проверяет номер паспорта
        /// </summary>
        /// <param name="passportNumber">проверяемый номер паспорта</param>
        private void PassportChecker(string passportNumber)
        {
            if (!Regex.IsMatch(passportNumber, @"\d{10}",
                RegexOptions.Singleline))
            {
                throw new ArgumentException("Паспорт должен содержать " +
                    "последовательно десять цифр. Первые четыре цифры - " +
                    "серия паспорта. Следующие шесть цифр - " +
                    "номер паспорта.");
            }
        }

        /// <summary>
        /// Добавление одного ребенка в список детей,
        /// чтобы прописать ему отца и мать
        /// и фамилию родителей
        /// </summary>
        /// <param name="child">ребенок</param>
        public void AddСhild(Child child)
        {
            child.Surname = Surname;
            switch (Gender)
            {
                case Gender.Female:
                    {
                        child.Mother = this;
                        child.Father = Partner;
                        break;
                    }
                case Gender.Male:
                    {
                        child.Father = this;
                        child.Mother = Partner;
                        break;
                    }
            }
            _children.AddPerson(child);
        }


        /// <summary>
        /// Добавление массива детей 
        /// при бракосочетании
        /// </summary>
        /// <param name="childList"></param>
        public void AddСhildren(PersonList childList)
        {
            if (childList != null)
            {
                if (_children == null)
                {
                    _children = new PersonList();
                }
                for (int i = 0; i < childList.Number; i++)
                {
                    if (childList.GetPersonByIndex(i) is Child child)
                    {
                        AddСhild(child);
                    }
                }
            }
        }
        

        /// <summary>
        /// Бракосочетание
        /// </summary>
        /// <param name="partner">Жених/невеста</param>
        public void GetMarried(Adult partner)
        {
            switch (Gender)
            {
                case Gender.Female:
                    {
                        Partner = partner;
                        partner.Partner = this;
                        Surname = partner.Surname;
                        if (_children != null)
                        {
                            for (int i = 0; i < _children.Number; i++)
                            {
                                _children.GetPersonByIndex(0).Surname =
                                                        partner.Surname;
                            }
                            AddСhildren(partner._children);
                            partner._children = _children;
                        }
                        break;
                    }
                case Gender.Male:
                    {
                        Partner = partner;
                        partner.Partner = this;
                        partner.Surname = Surname;
                        if (_children != null)
                        {
                            AddСhildren(partner._children);
                            partner._children = _children;
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// Добавление места работы взрослому
        /// (Для проверки типа по заданию)
        /// </summary>
        /// <param name="job">Название места работы</param>
        /// <returns>Сообщение о месте работы</returns>
        public string GetJob(string job)
        {
            Job = job;
            return $"Теперь у {Name} {Surname} место работы: {Job}";
        }
    }
}
