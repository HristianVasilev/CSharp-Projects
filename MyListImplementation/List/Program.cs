using List.Models.Classes;
using System;
using System.Collections.Generic;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> l = new List<int>();


            CList<int> listOfInt = new CList<int>();
            int a = listOfInt[0];
            Console.WriteLine(a);
        }
    }
}
