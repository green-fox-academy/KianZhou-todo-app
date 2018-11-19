using System;
using Printable;
namespace TODO_Application
{
    public class Task : IComparable, IPrintable
    {

        public string Name { get; set; }
        public string Content { get; set; }
        public bool IsComplete { get; set; }

        public Task(string v)
        {
            this.Name = v;
        }

        public void PrintAllFields()
        {
            if (IsComplete)
            {
                Console.WriteLine($"[x] {Name}");
            }
            else
            {
                Console.WriteLine($"[ ] {Name}");
            }

        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Task otherTask = obj as Task;
            if (otherTask != null)
            {
                throw new ArgumentException("Object is not a Task");
            }
            else
            {
                int temp = IsComplete.CompareTo(otherTask.IsComplete);
                if (temp != 0)
                {
                    return temp;
                }
                else
                {
                    return Content.CompareTo(otherTask.Content);
                }
            }
        }
    }
}