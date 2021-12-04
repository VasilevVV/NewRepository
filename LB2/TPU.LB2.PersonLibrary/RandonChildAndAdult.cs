using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPU.LB2.PersonLibrary
{
    /// <summary>
    /// Статический класс рандомайзера
    /// </summary>
    public static class RandomChildAndAdult
    {
        /// <summary>
        /// Список мужских имен для рандома
        /// </summary>
        private static readonly string[] _namesMale =
        {
            "Jeffrey", "James", "Robert", "Ryan",
            "Johnn", "Barry", "Donald", "Robert",
            "Jason", "Eric", "Richard", "Joseph",
            "Salvador", "Tony", "Justin", "Paul",
            "Walter", "Ronald"
        };

        /// <summary>
        /// Список женских имен для рандома
        /// </summary>
        private static readonly string[] _namesFemale =
        {
            "Bobbie", "Beth", "Sara", "Amandan",
            "Ruth", "Jennifer", "Anna", "Patricia",
            "Sharon", "Mary", "Kelly", "Jeanne",
            "Darlene", "Stephanie", "Jamie", "Rebecca",
            "Deborah", "Viola", "Wanda"
        };

        /// <summary>
        /// Список фамилий, на англ - гендерно-нейтральные
        /// </summary>
        private static readonly string[] _surnames =
        {
            "Green", "Bates", "Moore", "Robinson",
            "Guzman", "Green", "Schmidt", "Miller",
            "Jackson", "Arnold", "Ramsey", "Cobb",
            "Jensen", "Daniels", "Moss", "Woods",
            "Pierce", "Silva", "Johnson", "Brown",
            "Edwards", "Carter", "Sandoval", "Harris",
            "Richardson", "Mitchell", "Franklin", "Rogers"
        };
      
        /// <summary>
        /// Список профессий на англ
        /// </summary>
        private static readonly string[] _jobs =
        {
            "accountant", "butcher", "baker", "banker",
            "bus driver", "cook", "doctor", "engineer",
            "programmer", "mechanic", "vet", "journalist",
            "pilot", "teacher", "policeman", "driver"
        };
                
        /// <summary>
        /// рандомайзер
        /// </summary>
        private static Random _randomNumber = new Random();

        /// <summary>
        /// рандомайзер имен
        /// </summary>
        /// <param name="person">Взрослый или ребенок</param>
        private static void GetRandomName(PersonBase person)
        {
            switch (person.Gender)
            {
                case Gender.Female:
                    {
                        person.Name = _namesFemale[_randomNumber.
                                      Next(_namesFemale.Length)];
                        break;
                    }
                case Gender.Male:
                    {
                        person.Name = _namesMale[_randomNumber.
                                      Next(_namesMale.Length)];
                        break;
                    }
            }
        }


        /// <summary>
        /// возвращающает рандомного ребенка без родителей
        /// </summary>
        /// <returns>Рандомный ребенк без родителей</returns>
        public static Child GetRandomSingleChild()
        {
            Child singleChil = new Child
            {
                Gender = (Gender)_randomNumber.
                          Next(1,Enum.GetNames(typeof(Gender)).Length),
                Аge = _randomNumber.Next(PersonBase.MinAge, 
                                         Child.MaxChildAge),
                Surname = _surnames[_randomNumber.Next(_surnames.Length)],
            };

            GetRandomName(singleChil);

            singleChil.Education = GetSimpleEducation(singleChil);

            return singleChil;
        }


        /// <summary>
        /// возвращающает рандомного ребенка
        /// с обоими родителями
        /// </summary>
        /// <returns>Рандомный ребёнок с обоими родителями</returns>
        public static Child GetRandomFullFamilyChild()
        {
            Child fullFamilyChild = new Child
            {
                Gender = (Gender)_randomNumber.
                         Next(1, Enum.GetNames(typeof(Gender)).Length),
                Аge = _randomNumber.
                      Next(PersonBase.MinAge, Child.MaxChildAge),
                Surname = _surnames[_randomNumber.Next(_surnames.Length)],
                Father = new Adult
                {
                    Gender = Gender.Male,
                    Name = _namesMale[_randomNumber.Next(_namesMale.Length)],
                    Job = _jobs[_randomNumber.Next(_jobs.Length)],
                    PassportNumber = GetRandomPassportNumber(),
                    Partner = new Adult
                    {
                        Gender = Gender.Female,
                        Name = _namesFemale[_randomNumber.
                               Next(_namesFemale.Length)],
                        Job = _jobs[_randomNumber.Next(_jobs.Length)],
                        PassportNumber = GetRandomPassportNumber(),
                    }
                }
            };

            GetRandomName(fullFamilyChild);
            fullFamilyChild.Education = GetSimpleEducation(fullFamilyChild);
            fullFamilyChild.Father.Аge = _randomNumber.
                Next(Adult.MinAdultAge + fullFamilyChild.Аge, 
                Adult.MaxAdultAgeForChild + fullFamilyChild.Аge);
            fullFamilyChild.Mother = fullFamilyChild.Father.Partner;
            fullFamilyChild.Mother.Аge = _randomNumber.
                Next(fullFamilyChild.Father.Аge - 5, 
                fullFamilyChild.Father.Аge + 5);
            fullFamilyChild.Father.Partner.Partner = fullFamilyChild.Father;
            fullFamilyChild.Father.Surname = fullFamilyChild.Surname;
            fullFamilyChild.Mother.Surname = fullFamilyChild.Surname;
            fullFamilyChild.Father.AddСhild(fullFamilyChild);
            fullFamilyChild.Mother.AddСhild(fullFamilyChild);

            return fullFamilyChild;
        }

        /// <summary>
        /// возвращающает рандомный номер паспорта
        /// </summary>
        /// <returns>номер паспорта</returns>
        public static string GetRandomPassportNumber()
        {
            string randomPassportNumber = new string("");
            for (int i = 0; i < 10; i++)
            {
                randomPassportNumber += _randomNumber.Next(0, 10);
            }

            return randomPassportNumber;
        }

        /// <summary>
        /// возвращающает рандомного взрослого одиночку
        /// </summary>
        /// <returns>Рандомный взрослый без детей и партнера</returns>
        public static Adult GetRandomSingleAdult()
        {
            Adult singleAdult = new Adult
            {
                Gender = (Gender)_randomNumber.
                         Next(1, Enum.GetNames(typeof(Gender)).Length),
                Surname = _surnames[_randomNumber.Next(_surnames.Length)],
                Job = _jobs[_randomNumber.Next(_jobs.Length)],
                PassportNumber = GetRandomPassportNumber(),
                Аge = _randomNumber.
                      Next(Adult.MinAdultAge, 
                           Adult.MaxAdultAgeForChild),
            };
            GetRandomName(singleAdult);

            return singleAdult;
        }

        /// <summary>
        /// возвращающает рандомного взрослого
        /// с партнером и одним ребенком
        /// </summary>
        /// <returns>Рандомный семейный взрослый</returns>
        public static Adult GetRandomFullFamilyAdult()
        {
            Adult fullFamilyAdult = GetRandomSingleAdult();
            fullFamilyAdult.GetMarried(GetRandomSingleAdult());
            fullFamilyAdult.AddСhild(GetRandomSingleChild());
            
            return fullFamilyAdult;
        }

        /// <summary>
        /// Добавление традиционного места учебы ребенку
        /// </summary>
        /// <returns>School of Kindergarten</returns>
        public static string GetSimpleEducation(Child child)
        {
            if (child.Аge >= 7)
            {
                child.Education = "School";
            }
            else if (child.Аge < 7 && child.Аge > 3)
            {
                child.Education = "Kindergarten";
            }
            return child.Education;
        }
    }
}
