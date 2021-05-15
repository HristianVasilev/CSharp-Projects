using List.Models.Classes;
using System;
using System.Collections.Generic;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            CList<int> listOfInt = new CList<int>();

            

            for (int i = 0; i < 5; i++)
            {
                listOfInt.Add(i + 10);
                Console.WriteLine(listOfInt[i]);
            }
            ;
            
        }
    }
}
