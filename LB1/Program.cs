using System;
using Class_Person;

namespace LB1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person Mark = new Person("Mark", "Smith", 15, Gender.Мужской);
            Mark.GetInfo();
        }
    }
}
