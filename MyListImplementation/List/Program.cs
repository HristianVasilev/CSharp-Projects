using List.Models.Classes;
using System;
using System.Collections.Generic;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < 9; i++)
            {
                list.Add(10 + i);
            }

            Console.WriteLine(list.Capacity);

            CList<int> clist = new CList<int>();

            clist[0] = 4;

            Console.WriteLine(clist[0]);
            Console.WriteLine(clist[1]);
            
        }
    }
}
