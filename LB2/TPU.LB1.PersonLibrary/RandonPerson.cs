using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPU.LB1.PersonLibrary
{
    /// <summary>
    /// Статический класс рандомайзера персон
    /// </summary>
    public static class RandomPerson
    {
        /// <summary>
        /// Список мужских имен для рандома
        /// </summary>
        private static string[] NamesMale =
        {
            "Jeffrey", "James", "Robert", "Ryan",
            "Johnn", "Barry", "Donald", "Robert",
            "Jason", "Eric"
        };

        /// <summary>
        /// Список женских имен для рандома
        /// </summary>
        private static string[] NamesFemale =
        {
            "Bobbie", "Beth", "Sara", "Amandan",
            "Ruth", "Jennifer", "Anna", "Patricia",
            "Sharon", "Mary"
        };

        /// <summary>
        /// Список фамилий, на англ - гендерно-нейтральные
        /// </summary>
        private static string[] Surnames =
        {
            "Green", "Bates", "Moore", "Robinson",
            "Guzman", "Green", "Schmidt", "Miller",
            "Jackson", "Arnold"
        };

        /// <summary>
        /// рандомайзер
        /// </summary>
        private static Random RNDnumber = new Random();

        /// <summary>
        /// Статический метод, возвращающий рандомную персону
        /// </summary>
        /// <returns>Рандомная персона</returns>
        public static Person GetRandomPerson()
        {
            Person person = new Person();

            person.Gender = (Gender)RNDnumber.Next(1,
                Enum.GetNames(typeof(Gender)).Length);

            if (person.Gender == Gender.Female)
            {
                person.Name =
                    NamesFemale[RNDnumber.Next(NamesFemale.Length)];
            }
            else if (person.Gender == Gender.Male)
            {
                person.Name =
                    NamesMale[RNDnumber.Next(NamesMale.Length)];
            }

            person.Аge = RNDnumber.Next(Person.MinAge, Person.MaxAge);

            person.Surname = Surnames[RNDnumber.Next(Surnames.Length)];

            return person;
        }


        public static ChildPerson GetRandomChild()
        {
            ChildPerson childPerson = new ChildPerson();

            childPerson.Gender = (Gender)RNDnumber.Next(1,
                Enum.GetNames(typeof(Gender)).Length);

            if (childPerson.Gender == Gender.Female)
            {
                childPerson.Name =
                    NamesFemale[RNDnumber.Next(NamesFemale.Length)];
            }
            else if (childPerson.Gender == Gender.Male)
            {
                childPerson.Name =
                    NamesMale[RNDnumber.Next(NamesMale.Length)];
            }

            childPerson.Аge = RNDnumber.Next(ChildPerson.MinAge, ChildPerson.MaxAge);

            childPerson.Surname = Surnames[RNDnumber.Next(Surnames.Length)];

            childPerson.Father = GetRandomFather(childPerson);



            return childPerson;
        }


        public static AdultPerson GetRandomFather(ChildPerson childPerson)
        {
            AdultPerson father = new AdultPerson();

            father.Gender = Gender.Male;

            father.Name =
                    NamesMale[RNDnumber.Next(NamesMale.Length)];

            father.Аge = RNDnumber.Next(AdultPerson.MinAge + childPerson.Аge, AdultPerson.MaxAge);

            father.Surname = childPerson.Surname;

            father.Partner = GetRandomMather(childPerson, father);

            return father;
        }

        public static AdultPerson GetRandomMather(ChildPerson childPerson, AdultPerson father)
        {
            AdultPerson mather = new AdultPerson();

            father.Gender = Gender.Female;

            father.Name =
                    NamesFemale[RNDnumber.Next(NamesFemale.Length)];

            father.Аge = RNDnumber.Next(AdultPerson.MinAge + childPerson.Аge, AdultPerson.MaxAge);

            father.Surname = childPerson.Surname;

            father.Partner = father;

            return father;
        }

    }
}
