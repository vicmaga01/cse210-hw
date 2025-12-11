using System;
using System.Diagnostics;

namespace Mindfulness
{
    class Program
    {
        static void Main(string[] args)
        {
            new App().Run();
        }
    }

    internal sealed class App
    {
        private readonly System.Collections.Generic.List<Activity> _activities =
            new System.Collections.Generic.List<Activity>
            {
                new BreathingActivity(),
                new ReflectionActivity(),
                new ListingActivity(),
            };
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program");
                Console.WriteLine("-------------------");
                for (int i = 0; i < _activities.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {_activities[i].Name}");
                }
                Console.WriteLine($"{_activities.Count + 1}) Quit");
                Console.Write("Select an option: ");
                var choice = Console.ReadLine();

                int index;
                if (int.TryParse(choice, out index))
                {
                    if (index == _activities.Count + 1) return;
                    if (index >= 1 && index <= _activities.Count)
                    {
                        _activities[index - 1].Run();
                        continue;
                    }
                }

                Console.WriteLine("Invalid selection. Press Enter.");
                Console.ReadLine();
            }
        }
    }
}           