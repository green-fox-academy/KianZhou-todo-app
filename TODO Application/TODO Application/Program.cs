using System;
using System.Collections.Generic;
using System.IO;

namespace TODO_Application
{
    class Program
    {

        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.UsersList.Add(new Users("kian",1,"1"));
            menu.ChoseUsers();
            while (true)
            {
                menu.PrintMenu();
                string[] input = menu.ReadInput();
                menu.ChoseFunction(input);
                Console.WriteLine();
            }

        }

    }
}
