// Exceeded requirements by adding a fourth activity, GratitudeJournalActivity".

using System;
using System.Threading;
using System.Collections.Generic;

public abstract class Activity
{
    protected string Name { get; set; }
    protected string Description { get; set; }

    public void StartActivity(int duration)
    {
        Console.WriteLine($"Starting {Name} Activity");
        Console.WriteLine(Description);
        Console.WriteLine("Prepare to begin...");
        PauseWithAnimation(3);
        RunActivity(duration);
        EndActivity(duration);
    }

    protected abstract void RunActivity(int duration);

    protected void EndActivity(int duration)
    {
        Console.WriteLine($"Good job! You have completed the {Name} Activity for {duration} seconds.");
        PauseWithAnimation(3);
    }

    protected void PauseWithAnimation(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        Name = "Breathing";
        Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    protected override void RunActivity(int duration)
    {
        int elapsed = 0;
        while (elapsed < duration)
        {
            Console.WriteLine("Breathe in...");
            PauseWithAnimation(3);
            Console.WriteLine("Breathe out...");
            PauseWithAnimation(3);
            elapsed += 6;
        }
    }
}

public class ReflectionActivity : Activity
{
    private string[] prompts = new string[]
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = new string[]
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
    {
        Name = "Reflection";
        Description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    protected override void RunActivity(int duration)
    {
        Random random = new Random();
        Console.WriteLine(prompts[random.Next(prompts.Length)]);
        PauseWithAnimation(3);

        int elapsed = 0;
        while (elapsed < duration)
        {
            Console.WriteLine(questions[random.Next(questions.Length)]);
            PauseWithAnimation(5);
            elapsed += 8;
        }
    }
}

public class ListingActivity : Activity
{
    private string[] prompts = new string[]
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        Name = "Listing";
        Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    protected override void RunActivity(int duration)
    {
        Random random = new Random();
        Console.WriteLine(prompts[random.Next(prompts.Length)]);
        PauseWithAnimation(3);

        Console.WriteLine("Start listing items:");
        int count = 0;
        int elapsed = 0;
        while (elapsed < duration)
        {
            string item = Console.ReadLine();
            count++;
            elapsed += 5;  // Assuming each item takes around 5 seconds to think and type
        }

        Console.WriteLine($"You have listed {count} items.");
    }
}

public class GratitudeJournalActivity : Activity
{
    public GratitudeJournalActivity()
    {
        Name = "Gratitude Journal";
        Description = "This activity will help you reflect on the things you are grateful for. Write down as many things as you can think of.";
    }

    protected override void RunActivity(int duration)
    {
        Console.WriteLine("Think about the things you are grateful for and write them down:");
        List<string> gratitudeItems = new List<string>();
        int elapsed = 0;
        while (elapsed < duration)
        {
            string item = Console.ReadLine();
            gratitudeItems.Add(item);
            elapsed += 5;  // Assuming each item takes around 5 seconds to think and type
        }

        Console.WriteLine("Here are the things you are grateful for:");
        foreach (var item in gratitudeItems)
        {
            Console.WriteLine(item);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. Gratitude Journal");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();
            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    activity = new GratitudeJournalActivity();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }

            Console.WriteLine("Enter duration in seconds:");
            int duration;
            if (int.TryParse(Console.ReadLine(), out duration))
            {
                activity.StartActivity(duration);
            }
            else
            {
                Console.WriteLine("Invalid duration. Please try again.");
            }
        }
    }
}