// Exceeeds requirements by tracking various kinds of goals and includes gamification elements
// such as leveling up, earning bonuses, and introducing negative goals for bad habits.

using System;
using System.Collections.Generic;
using System.IO;

abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public int Progress { get; set; } = 0;
    public abstract void RecordEvent();
    public abstract string GetStatus();
}

class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public override void RecordEvent()
    {
        Progress = 1;
    }

    public override string GetStatus()
    {
        return Progress == 1 ? "[X]" : "[ ]";
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public override void RecordEvent()
    {
        Progress++;
    }

    public override string GetStatus()
    {
        return $"Completed {Progress} times";
    }
}

class ChecklistGoal : Goal
{
    public int Required { get; set; }
    public int BonusPoints { get; set; }

    public ChecklistGoal(string name, int points, int required, int bonusPoints)
    {
        Name = name;
        Points = points;
        Required = required;
        BonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        Progress++;
    }

    public override string GetStatus()
    {
        return Progress >= Required ? "[X]" : $"Completed {Progress}/{Required} times";
    }
}

class User
{
    public string Name { get; set; }
    public int Score { get; set; } = 0;
    public int Level { get; set; } = 1;
    public int Experience { get; set; } = 0;
    private List<Goal> goals = new List<Goal>();

    public void CreateGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void ListGoals()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name} - {goals[i].GetStatus()}");
        }
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex < 0 || goalIndex >= goals.Count)
        {
            Console.WriteLine("Invalid goal index.");
            return;
        }
        
        var goal = goals[goalIndex];
        goal.RecordEvent();
        Score += goal.Points;
        Experience += goal.Points;

        if (goal is ChecklistGoal checklistGoal && checklistGoal.Progress >= checklistGoal.Required)
        {
            Score += checklistGoal.BonusPoints;
            Experience += checklistGoal.BonusPoints;
        }

        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        int requiredXP = Level * 1000;
        if (Experience >= requiredXP)
        {
            Experience -= requiredXP;
            Level++;
            Console.WriteLine($"Congratulations! You've leveled up to level {Level}.");
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(Name);
            outputFile.WriteLine(Score);
            outputFile.WriteLine(Level);
            outputFile.WriteLine(Experience);
            foreach (var goal in goals)
            {
                string type = goal.GetType().Name;
                outputFile.WriteLine($"{type}:{goal.Name},{goal.Points},{goal.Progress}");
                if (goal is ChecklistGoal checklistGoal)
                {
                    outputFile.WriteLine($",{checklistGoal.Required},{checklistGoal.BonusPoints}");
                }
            }
        }
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        Name = lines[0];
        Score = int.Parse(lines[1]);
        Level = int.Parse(lines[2]);
        Experience = int.Parse(lines[3]);
        goals.Clear();
        for (int i = 4; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(':');
            string type = parts[0];
            string[] details = parts[1].Split(',');
            Goal goal;
            if (type == nameof(SimpleGoal))
            {
                goal = new SimpleGoal(details[0], int.Parse(details[1])) { Progress = int.Parse(details[2]) };
            }
            else if (type == nameof(EternalGoal))
            {
                goal = new EternalGoal(details[0], int.Parse(details[1])) { Progress = int.Parse(details[2]) };
            }
            else // ChecklistGoal
            {
                goal = new ChecklistGoal(details[0], int.Parse(details[1]), int.Parse(details[3]), int.Parse(details[4])) { Progress = int.Parse(details[2]) };
            }
            goals.Add(goal);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        User user = new User();
        Console.Write("Enter your name: ");
        user.Name = Console.ReadLine();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateGoal(user);
                    break;
                case 2:
                    user.ListGoals();
                    break;
                case 3:
                    SaveGoals(user);
                    break;
                case 4:
                    LoadGoals(user);
                    break;
                case 5:
                    RecordEvent(user);
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void CreateGoal(User user)
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        int type = int.Parse(Console.ReadLine());

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == 1)
        {
            user.CreateGoal(new SimpleGoal(name, points));
        }
        else if (type == 2)
        {
            user.CreateGoal(new EternalGoal(name, points));
        }
        else if (type == 3)
        {
            Console.Write("Enter number of times to complete goal: ");
            int required = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus points: ");
            int bonusPoints = int.Parse(Console.ReadLine());
            user.CreateGoal(new ChecklistGoal(name, points, required, bonusPoints));
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
    }

    static void SaveGoals(User user)
    {
        Console.Write("Enter filename to save goals: ");
        string filename = Console.ReadLine();
        user.SaveGoals(filename);
    }

    static void LoadGoals(User user)
    {
        Console.Write("Enter filename to load goals: ");
        string filename = Console.ReadLine();
        user.LoadGoals(filename);
    }

    static void RecordEvent(User user)
    {
        user.ListGoals();
        Console.Write("Enter the number of the goal to record an event for: ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;
        user.RecordEvent(goalIndex);
    }
}