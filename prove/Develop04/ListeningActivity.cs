using System;

namespace Mindfulness
{
    internal sealed class ListingActivity : Activity
    {
        private readonly string[] _prompts =
        {
            "Who are people that you appreciate",
            "What are personal strengths of yours",
            "Who are people that you have helped this week",
            "Wen have you felt the Holy Ghost this month",
            "Who are some of you personal heroes"
        };

        private readonly Random _rng = new Random();

        public ListingActivity()
            : base("listing Activity", "This activity will help you reflect on the good things in your life ")
        { }

        protected override void PerformActivity(int durationSeconds)
        {
            var prompt = _prompts[_rng.Next(_prompts.Length)];
            Console.WriteLine("List as many responses as you can to the following prompts:");
            Console.WriteLine();
            Console.WriteLine($"---{prompt}---");
            Console.Write("You may begin in: ");
            ShowCount(5);

            int count = 0;
            var end = DateTime.UtcNow.AddSeconds(durationSeconds);

            while (DateTime.UtcNow < end)
            {
                Console.Write("> ");
                var line = Console.ReadLine();
                if (line != null && line.Trim().Length > 0) count++;
            }

            Console.WriteLine($"You listed {count} items.");
        }        
    }
}