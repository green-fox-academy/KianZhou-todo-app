using System;
using System.Collections.Generic;

namespace TODO_Application
{
    public class Menu
    {
        public List<Users> UsersList { set; get; }
        public List<Task> ListTask { private set; get; }
        public Menu()
        {
            UsersList = new List<Users>();
        }

        public void ChoseUsers()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Please input your name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Please input your password ");
                string password = Console.ReadLine();

                foreach (var user in UsersList)
                {
                    if (name.Equals(user.Name) && password.Equals(user.Password))
                    {
                        ListTask = user.ListTasks;
                        flag = false;
                        break;
                    }
                }
                Console.WriteLine("The user is not existing or wrong password, please try again");
            }           
        }

        public void ChoseFunction(string[] input)
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
                case "-w":
                    ChoseUsers();
                    break;
                case "-e":
                    Environment.Exit(0);
                    break;
                default:
                    return;  
            }
        }
        public void CheckTask(string data)
        {
            List<int> numbers = ParseStringToInt(data);
            if (numbers == null) return;
            foreach (var i in numbers)
            {
                ListTask[i - 1].PrintAllFields();
            }            
        }


        public void RemoveTask(string data)
        {
            List<int> numbers =ParseStringToInt(data);
            if (numbers == null) return;

            for (int j = ListTask.Count-1; j >= 0; --j)
            {
                if (numbers.Contains(j+1))
                {
                    ListTask.RemoveAt(j);
                }
            }
          Console.WriteLine("The task have been removed");
        }

        private List<int> ParseStringToInt(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                Console.WriteLine("Unable to remove: no index provided");
                return null;
            }
            string[] numbersOrStrings = data.Trim().Split(";");
            List<int> numbers = new List<int>();
            foreach (var numbersOrString in numbersOrStrings)
            {
                if (int.TryParse(numbersOrString, out var i))
                {
                    if (i <= 0 || i <= ListTask.Count)
                    {
                        Console.WriteLine("Unable to remove: index is out of bound");
                        return null;
                    }
                    else
                    {
                        numbers.Add(i);
                    }
                }
                else
                {
                    Console.WriteLine("Unable to remove: index is not a number");
                    return null;
                }
            }
            return numbers;
        }

        public void AddNewTask(string data)
        {

            if (!string.IsNullOrEmpty(data))
            {
                string[] list = data.Trim().Split(";"); ;
                foreach (var task in list)
                {
                    if (!string.IsNullOrWhiteSpace(task))
                    {
                        ListTask.Add(new Task(task.Trim()));
                    }                
                }                
                Console.WriteLine("The task have been added");
            }
            else
            {
                Console.WriteLine("Unable to add: no task provided");

            }

        }

        public void ListAllTasks(bool flag)
        {
            if (ListTask.Count == 0)
            {
                Console.WriteLine("No todos for today! :)");
            }
            else
            {
                for (int i = 0; i < ListTask.Count; i++)
                {
                    if (flag)
                    {
                        Console.Write($"{i + 1} - ");
                        ListTask[i].PrintAllFields();
                    }
                    else
                    {
                        Console.WriteLine("Completed tasks :");
                        if (ListTask[i].IsComplete)
                        {
                            
                            ListTask[i].PrintAllFields();
                        }
                    }

                }
            }

        }
        public string[] ReadInput()
        {
            try
            {
                string[] inputArray = Console.ReadLine().Trim().Split(" ");
                string command = inputArray[0];
                inputArray[0] = "";
                string date = string.Join(" ", inputArray).Trim();

                if (new List<string>(){"-l","-a","-c","-e","-r","-c","-la","-w"}.Contains(command) )
                {
                    return new string[] { command, date };
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Unsupported argument");
            }
            return null;

        }

        public void PrintMenu()
        {
            Console.WriteLine("Command Line Todo application\n" +
                              "=============================\n\n" +

                                "Command line arguments ( separates different tasks/numbers by ';' ):\n" +
                                " -l   Lists all undone tasks\n" +
                                " -la  Lists all tasks\n" +
                                " -a   Adds new tasks \n" +
                                " -r   Removes tasks \n" +
                                " -c   Completes tasks \n" +
                                " -w   Change another user \n" +
                                " -e   Exit\n");
        }
    }
}
