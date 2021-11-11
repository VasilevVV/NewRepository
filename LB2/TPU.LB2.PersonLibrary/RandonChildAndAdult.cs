using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPU.LB2.PersonLibrary
{
    /// <summary>
    /// Статический класс рандомайзера персон
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
            "pilot", "teacher", "policeman", "driver",
        };
                
        /// <summary>
        /// рандомайзер
        /// </summary>
        private static Random _randomNumber = new Random();

        /// <summary>
        /// Статический метод, возвращающий рандомного ребенка без родителей
        /// </summary>
        /// <returns>Рандомный ребенк без родителей</returns>
        public static ChildPerson GetRandomSingleChild()
        {
            ChildPerson singleChil = new ChildPerson
            {
                Gender = (Gender)_randomNumber.
                          Next(1,Enum.GetNames(typeof(Gender)).Length),
                Аge = _randomNumber.Next(Person.MinAge, 
                                         ChildPerson.MaxChildAge),
                Surname = _surnames[_randomNumber.Next(_surnames.Length)],
            };

            if (singleChil.Gender == Gender.Female)
                singleChil.Name = _namesFemale[_randomNumber.
                                  Next(_namesFemale.Length)];
            else if (singleChil.Gender == Gender.Male)
                singleChil.Name = _namesMale[_randomNumber.
                                  Next(_namesMale.Length)];

            singleChil.Education = singleChil.GetSimpleEducation();

            return singleChil;
        }


        /// <summary>
        /// Статический метод, возвращающий рандомного ребенка
        /// с обоими родителями
        /// </summary>
        /// <returns>Рандомный ребёнок с обоими родителями</returns>
        public static ChildPerson GetRandomFullFamilyChild()
        {
            ChildPerson fullFamilyChild = new ChildPerson
            {
                Gender = (Gender)_randomNumber.
                         Next(1, Enum.GetNames(typeof(Gender)).Length),
                Аge = _randomNumber.
                      Next(Person.MinAge, ChildPerson.MaxChildAge),
                Surname = _surnames[_randomNumber.Next(_surnames.Length)],
                Father = new AdultPerson
                {
                    Gender = Gender.Male,
                    Name = _namesMale[_randomNumber.Next(_namesMale.Length)],
                    Job = _jobs[_randomNumber.Next(_jobs.Length)],
                    PassportNumber = GetRandomPassportNumber(),
                    Partner = new AdultPerson
                    {
                        Gender = Gender.Female,
                        Name = _namesFemale[_randomNumber.
                               Next(_namesFemale.Length)],
                        Job = _jobs[_randomNumber.Next(_jobs.Length)],
                        PassportNumber = GetRandomPassportNumber(),
                    }
                }
            };
            if (fullFamilyChild.Gender == Gender.Female)
            {
                fullFamilyChild.Name = _namesFemale[_randomNumber.
                                       Next(_namesFemale.Length)];
            }
            else if (fullFamilyChild.Gender == Gender.Male)
            {
                fullFamilyChild.Name = _namesMale[_randomNumber.
                                       Next(_namesMale.Length)];
            }
            fullFamilyChild.Education = fullFamilyChild.GetSimpleEducation();
            fullFamilyChild.Father.Аge = _randomNumber.
                Next(AdultPerson.MinAdultAge + fullFamilyChild.Аge, 
                AdultPerson.MaxAdultAgeForChild + fullFamilyChild.Аge);
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
        /// Статический метод, возвращающий рандомный номер паспорта
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
        /// Статический метод, возвращающий рандомного взрослого одиночку
        /// </summary>
        /// <returns>Рандомный взрослый без детей и партнера</returns>
        public static AdultPerson GetRandomSingleAdult()
        {
            AdultPerson singleAdult = new AdultPerson
            {
                Gender = (Gender)_randomNumber.
                         Next(1, Enum.GetNames(typeof(Gender)).Length),
                Surname = _surnames[_randomNumber.Next(_surnames.Length)],
                Job = _jobs[_randomNumber.Next(_jobs.Length)],
                PassportNumber = GetRandomPassportNumber(),
                Аge = _randomNumber.
                      Next(AdultPerson.MinAdultAge, 
                           AdultPerson.MaxAdultAgeForChild),
            };

            if (singleAdult.Gender == Gender.Female)
            {
                singleAdult.Name = _namesFemale[_randomNumber.
                                   Next(_namesFemale.Length)];
            }
            else if (singleAdult.Gender == Gender.Male)
            {
                singleAdult.Name = _namesMale[_randomNumber.
                                   Next(_namesMale.Length)];
            }

            return singleAdult;
        }

        /// <summary>
        /// Статический метод, возвращающий рандомного взрослого
        /// с партнером и одним ребенком
        /// </summary>
        /// <returns>Рандомный семейный взрослый</returns>
        public static AdultPerson GetRandomFullFamilyAdult()
        {
            AdultPerson fullFamilyAdult = GetRandomSingleAdult();
            fullFamilyAdult.GetMarried(GetRandomSingleAdult());
            fullFamilyAdult.AddСhild(GetRandomSingleChild());
            
            return fullFamilyAdult;
        }
    }
}
