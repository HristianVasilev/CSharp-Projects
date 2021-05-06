using System;

namespace Random
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How much dicks you want to eat?");

            int count = int.Parse(Console.ReadLine());
            Console.WriteLine("Horse or monkey?");
            string input = Console.ReadLine();

            string type;
            if (input == "horse")
            {
                type = "horses";
            }
            else if (input == "monkey")
            {
                type = "monkeys";
            }
            else
            {
                throw new InvalidOperationException();
            }

            Console.WriteLine($"You will eat {count} {type} dicks!");
        }
    }
}
