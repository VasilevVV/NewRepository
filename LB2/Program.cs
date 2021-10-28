using System;
using TPU.LB1.PersonLibrary;

namespace LB2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Person aaa = new Person();
            Adult nnnn = new Adult();
            Child ddd = new Child();
            nnnn.Job = "d";
           
            Console.WriteLine(aaa.Infomation);
            Console.WriteLine(nnnn.Infomation);
            Console.WriteLine(ddd.Infomation);
            Console.ReadKey();
        }
    }
}
