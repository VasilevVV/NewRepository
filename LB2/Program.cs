using System;
using TPU.LB1.PersonLibrary;


namespace LB2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Person aaa = new Person();
            AdultPerson nnnn = new AdultPerson();
            ChildPerson ddd = new ChildPerson();
            nnnn.Job = "d";
            
            Console.WriteLine(aaa.Infomation);
            Console.WriteLine(nnnn.Infomation);
            Console.WriteLine(ddd.Infomation);
            Console.ReadKey();*/

            ChildPerson dddsss = RandomPerson.GetRandomChild();

            Console.WriteLine(dddsss.Infomation);
        }
    }
}
