using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPU.LB1.PersonLibrary
{
    
    public class Adult : Person
    {
        public int PassportNumber { get; set; }

        public Adult Partner { get; set; }

        public bool IsMarried
        {
            get
            {
                return (Partner != null);
            }
        }

        public string Job { get; set; }

 

        public Adult(string firstName, string lastName, int age,
            Gender gender, int passportNumber) : base(firstName, lastName, age, gender)
        {
            PassportNumber = passportNumber;
        }


    }
}
