using System;

namespace TODO_Application
{
    public class Task
    {

        public string Name { get; set; }
        public string Content { get; set; }
        public bool IsComplete { get; set; }
        public Task(string v)
        {
            this.Name = v;
        }

        internal void ShowState()
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
    }
}