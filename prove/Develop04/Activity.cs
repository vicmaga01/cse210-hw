using System;
using System.Diagnostics;
using System.Threading;

namespace Mindfulness
{
    internal abstract class Activity
    {
        private readonly string _name;
        private readonly string _description;
        private int _durationSeconds;

        public string Name => _name;

        protected Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public void Run()
        {
            Console.Clear();
            DisplayStartingMessage();
            _durationSeconds = PromptDuration();
            Console.WriteLine();
            Console.WriteLine("Get ready...");
            ShowSpinner(3);
            Console.WriteLine();

            PerformActivity(_durationSeconds);

            Console.WriteLine();
            DisplayEndingMessage(_durationSeconds);
            Console.WriteLine("Press Enter to return to the menu.");
            Console.ReadLine();
        }

        protected abstract void PerformActivity(int durationSeconds);

        protected void DisplayStartingMessage()
        {
            Console.WriteLine($"Welcome to the {_name}.");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
        }

        protected void DisplayEndingMessage(int seconds)
        {
            Console.WriteLine("Well done.");
            ShowSpinner(2);
            Console.WriteLine($"You have completed {seconds} seconds of the {_name}.");
            ShowSpinner(2);
        }

        protected int PromptDuration()
        {
            while (true)
            {
                Console.Write("Enter duration in seconds: ");
                var input = Console.ReadLine();
                int seconds;
                if (int.TryParse(input, out seconds) && seconds > 0) return seconds;
                Console.WriteLine("Please enter a positive whole number.");
            }
        }

        protected void ShowSpinner(int seconds)
        {
            var frames = new[] { "|", "/", "-", "\\" };
            var sw = Stopwatch.StartNew();
            int i = 0;
            while (sw.Elapsed.TotalSeconds < seconds)
            {
                Console.Write(frames[i % frames.Length]);
                Thread.Sleep(120);
                Console.Write('\b');
                i++;
            }
        }

        protected void ShowCount(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i + " ");
                Thread.Sleep(1000);
                Console.Write("\b\b");
            }
            Console.WriteLine();
        }
    }
}