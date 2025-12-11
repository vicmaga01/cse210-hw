using System;

namespace Mindfulness
{
    internal sealed class BreathingActivity : Activity
    {
        public BreathingActivity()
            : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly") 
            { }
        
        protected override void PerformActivity(int durationSeconds)
        {
            var end = DateTime.UtcNow.AddSeconds(durationSeconds);
            while (DateTime.UtcNow < end)
            {
                Console.Write("Breathe in...");
                ShowCount(4);

                if (DateTime.UtcNow >= end) break;

                Console.Write("Breathe out...");
                ShowCount(6);
            }
        }
    }
}