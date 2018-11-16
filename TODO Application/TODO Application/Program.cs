using System;
using System.Collections.Generic;
using System.IO;

namespace TODO_Application
{   
    class Program
    {
        public static List<Task> listTask = new List<Task>();
        static void Main(string[] args)
        {
            while (true)
            {
                PrintMenu();
                string[] input = ReadInput();
                ChoseFunction(input);
                Console.WriteLine();
            }            
        }

        private static void ChoseFunction(string[] input)
        {
            if (input == null)
            {
                return;
            }
            switch (input[0])
            {
                case "-l":
                    ListAllTasks(false);
                    break;
                case "-la":
                    ListAllTasks(true);
                    break;
                case "-a":
                    AddNewTask(input[1]);
                    break;
                case "-r":
                    RemoveTask(input[1]);
                    break;
                case "-c":
                    CheckTask(input[1]);
                    break;
                case "-e":
                    Environment.Exit(0);
                    break;
                default:
                    break;

            }
        }

        public static void PrintEnterKeyMessage()
        {
            Console.WriteLine("Please enter any key to continue");
            Console.ReadKey();
        }

        private static void CheckTask(string v)
        {
            if (v == null || v == "")
            {
                Console.WriteLine("Unable to check: no index provided");
                PrintEnterKeyMessage();
                return;
            }

            if (!int.TryParse(v, out var i))
            {
                Console.WriteLine("Unable to check: index is not a number");
                PrintEnterKeyMessage();
                return;
            }

            if (i<=0 &&i >= listTask.Count)
            {
                Console.WriteLine("Unable to check: index is out of bound");
                PrintEnterKeyMessage();
                return;
            }

            listTask[i - 1].ShowState();
            PrintEnterKeyMessage();
        }


        private static void RemoveTask(string v)
        {
            if (v==null|| v =="")
            {
                Console.WriteLine("Unable to remove: no index provided");
                PrintEnterKeyMessage();
                return;
            }

            if (!int.TryParse(v, out var i))
            {
                Console.WriteLine("Unable to remove: index is not a number");
                PrintEnterKeyMessage();
                return;
            }

            if (i<= 0 &&i >= listTask.Count)
            {
                Console.WriteLine("Unable to remove: index is out of bound");
                PrintEnterKeyMessage();
                return;
            }

            listTask.RemoveAt(--i);
            Console.WriteLine("The task have been removed");
            PrintEnterKeyMessage();
        }

        private static void AddNewTask(string v)
        {
            /*
            foreach (Task task in listTask)
            {
                if (task.Name.Equals(v))
                {
                    Console.WriteLine($"Sorry, cannot add the task because {v} is existing");
                    return;
                }        
            }
            */
            if (v!=null && v!= "")
            {
                listTask.Add(new Task(v));
                Console.WriteLine("The task have been added");
                PrintEnterKeyMessage();
            }
            else
            {
                Console.WriteLine("Unable to add: no task provided");
                PrintEnterKeyMessage();
            }
            
        }

        private static void ListAllTasks(bool flag)
        {
            if (listTask.Count == 0)
            {
                Console.WriteLine("No todos for today! :)");
            }
            else
            {
                for (int i = 0; i < listTask.Count; i++)
                {
                    if (flag)
                    {
                        Console.Write($"{i + 1} - ");
                        listTask[i].ShowState();
                    }
                    else
                    {
                        if (listTask[i].IsComplete)
                        {
                            listTask[i].ShowState();
                        }
                    }
                                  
                }
            }
            PrintEnterKeyMessage();
        }

        private static string[] ReadInput()
        {
            try
            {
                string input = Console.ReadLine().Trim();
                if (input.Length < 2)
                {
                    throw new ArgumentNullException();
                }

                string command = "";

                if (input.Length == 3)
                {
                     command = input.Substring(0, 3);
                }
                else
                {
                    command = input.Substring(0, 2);
                }

                string date = input.Substring(2).Trim();
                if (command.Equals("-l") || command.Equals("-a") || command.Equals("-r") || command.Equals("-c")|| command.Equals("-e")||command.Equals("-la"))
                {
                    return new string[]{ command, date };                  
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (ArgumentNullException )
            {
                Console.WriteLine("Unsupported argument");
                PrintEnterKeyMessage();
            }

            return null;

        }

        private static void PrintMenu()
        {
            Console.WriteLine("Command Line Todo application\n" +
                              "=============================\n\n"+

                                "Command line arguments:\n"+
                                " -l   Lists all undone tasks\n"+
                                " -la   Lists all tasks\n" + 
                                " -a   Adds a new task\n" +
                                " -r   Removes an task\n"+
                                " -c   Completes an task\n"+
                                " -e   Exit\n");
        }
    }
}
