using System;

namespace Mindfulness
{
    internal sealed class ReflectionActivity : Activity
    {
            private readonly string[] _prompts =
            {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            };

            private readonly string[] _questions =
            {
                "Why was this experience meaningful to you",
                "Have you ever done anything like this before",
                "How did you get started",
                "How did you feel when it was complete",
                "What made this time different from other times you were not as successful",
                "What is your favorite thing about this experience",
                "What could you learn from this experience that applies to other situations",
                "What did you learn about yourself through this experience",
                "What can you keep this experience in mind in the future"
            };

            private readonly Random _rng = new Random();

            public ReflectionActivity()
                : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strenght") 
                { }

            protected override void PerformActivity(int durationSeconds)
            {
                var prompt = _prompts[_rng.Next(_prompts.Length)];
                Console.WriteLine("Consider the following prompt");
                Console.WriteLine();
                Console.WriteLine($"---{prompt}---");
                Console.WriteLine();
                Console.WriteLine("Now ponder on each of the following questions.");
                Console.Write("You may begin in: ");
                ShowCount(5);

                var end = DateTime.UtcNow.AddSeconds(durationSeconds);
                while (DateTime.UtcNow < end)
                {
                    var question = _questions[_rng.Next(_questions.Length)];
                    Console.Write($"> {question} ");
                    ShowSpinner(6);
                    Console.WriteLine();
                }
            }
        }
    }