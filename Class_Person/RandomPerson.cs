﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PersonLibrary
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
            "Jeffrey",
            "James",
            "Robert", 
            "Ryan", 
            "Johnn",
            "Barry",
            "Donald",
            "Robert", 
            "Jason", 
            "Eric"
        };

        /// <summary>
        /// Список женских имен для рандома
        /// </summary>
        private static string[] NamesFemale =
        {
            "Bobbie",
            "Beth",
            "Sara",
            "Amandan",
            "Ruth",
            "Jennifer",
            "Anna",
            "Patricia",
            "Sharon",
            "Mary"
        };

        /// <summary>
        /// Список фамилий, на англ - гендерно-нейтральные
        /// </summary>
        private static string[] Surnames =
        {
            "Green",
            "Bates",
            "Moore",
            "Robinson",
            "Guzman",
            "Green",
            "Schmidt",
            "Miller",
            "Jackson",
            "Arnold"
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
            Person person = new Person();

            person.Gender = (Gender)RNDnumber.Next(1, Enum.GetNames(typeof(Gender)).Length);

            if (person.Gender == Gender.Женский)
            {
                person.Name = NamesFemale[RNDnumber.Next(NamesFemale.Length)];
            }
            else if (person.Gender == Gender.Мужской)
            {
                person.Name = NamesMale[RNDnumber.Next(NamesMale.Length)];
            }

            person.Аge = RNDnumber.Next(1, 100);

            person.Surname = Surnames[RNDnumber.Next(Surnames.Length)];

            return person;
        }

    }
}
