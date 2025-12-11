using System;
using System.Security.Cryptography.X509Certificates;

public class Resume;
{
    public string_name;
    public List<Job> _jobs = new List<Job>();
    public void DisplayResumeDetails()
    public void Display()

    Console.WriteLine($"Name: {_name}");
    Console.WriteLine("Jobs:");
    
    foreach (Job job in _jobs)
    {
        job.DisplayDetails();
        job.Display();
        }
    }
}