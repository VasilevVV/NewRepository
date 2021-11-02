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
        public static Person GetRNDperson()
        {
            Person person = new Person
            {
                Gender = (Gender)RNDnumber.Next(1,
                Enum.GetNames(typeof(Gender)).Length),
                Аge = RNDnumber.Next(Person.MinAge, Person.MaxAge - 1),
                Surname = Surnames[RNDnumber.Next(Surnames.Length)]
            };

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

            return person;
        }

    }
}
