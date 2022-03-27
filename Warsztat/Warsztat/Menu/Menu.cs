using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warsztat.Menu
{
    public class Menu
    {
        public static void WriteMenu(List<Option> options, Option selectedOption)
        {
            Console.Clear();
            Console.WriteLine($"Welcome! This is Service Station V.1.0. written by Majtry. \n What do you want to do?");
            foreach (Option option in options)
            {
                if (option == selectedOption)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write(" ");
                }
                Console.WriteLine(option.Name);
            }
        }
    }
}