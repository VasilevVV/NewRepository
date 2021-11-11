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
    public class AdultPerson : Person
    {
        /// <summary>
        /// приватное поле номера паспорта
        /// </summary>
        private string _passportNumber;

        /// <summary>
        /// публичный парметр для номера паспорта
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
        /// публичный парметр партнера по браку
        /// </summary>
        public AdultPerson Partner { get; set; }

        /// <summary>
        /// публичный парметр о состоянии брака
        /// </summary>
        public bool IsMarried
        {
            get
            {
                return (Partner != null);
            }
        }

        /// <summary>
        /// публичный парметр о работе
        /// </summary>
        public string Job { get; set; }

        /// <summary>
        /// приватный массив, содержащий детей
        /// </summary>
        private ChildPerson[] _children = new ChildPerson[0];

        /// <summary>
        /// публичный парметр о детях
        /// </summary>
        public ChildPerson[] Children
        {
            get
            {
                return _children;
            }
            set
            {
                _children = value;
            }
        }
        
        /// <summary>
        /// конструктор взрослой персоны
        /// </summary>
        public AdultPerson() : base()
        { }
               
        /// <summary>
        /// Информации о взрослой персоне
        /// </summary>
        public override string Infomation
        {
            get
            {
                string children = "";
                if ((Children != null) && (Children.Length != 0))
                {
                    children = $"{Children[0].Name} {Children[0].Surname}";
                    for (int i = 1; i < Children.Length; i++)
                        children += $", {Children[i].Name} " +
                                    $"{Children[i].Surname}";
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
        /// Добавление ребенка в массив детей
        /// </summary>
        /// <param name="child">ребенок</param>
        public void AddСhild(ChildPerson child)
        {
            child.Surname = this.Surname;
            if (this.Gender == Gender.Female)
            {
                child.Mother = this;
                child.Father = this.Partner;
            }
            else if (this.Gender == Gender.Male)
            {
                child.Father = this;
                child.Mother = this.Partner;
            }
            Array.Resize<ChildPerson>(ref _children, _children.Length + 1);
            _children[_children.Length - 1] = child;
        }

        /// <summary>
        /// Добавление ребенка в массив детей
        /// </summary>
        /// <param name="child">ребенок</param>
        public void AddСhildren(ChildPerson[] childArray)
        {
            for (int i = 0; i < childArray.Length; i++)
                AddСhild(childArray[i]);
        }

        /// <summary>
        /// Бракосочетание
        /// </summary>
        /// <param name="partner">Жених/невеста</param>
        public void GetMarried(AdultPerson partner)
        {
            if (this.Gender == Gender.Female)
            {
                this.Partner = partner;
                partner.Partner = this;
                this.Surname = partner.Surname;
                for (int i = 0; i < this.Children.Length; i++)
                    this.Children[i].Surname = partner.Surname;
                this.AddСhildren(partner.Children);
                partner.Children = this.Children;
            }
            else if (this.Gender == Gender.Male)
            {
                this.Partner = partner;
                partner.Partner = this;
                partner.Surname = this.Surname;
                this.AddСhildren(partner.Children);
                partner.Children = this.Children;
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
            this.Job = job;
            return $"Теперь {Name} {Surname} работает в {Job}";
        }
    }
}
