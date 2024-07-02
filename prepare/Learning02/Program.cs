// My code:

using System;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job {
            _company = "Microsoft",
            _jobTitle = "Software Engineer",
            _startYear = 2019,
            _endYear = 2022
        };

        Job job2 = new Job {
            _company = "Apple",
            _jobTitle = "Manager",
            _startYear = 2022,
            _endYear = 2023
        };

        Resume myResume = new Resume {
            _name = "Allison Rose",
        };
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        Console.WriteLine($"Name: {myResume._name}");
        Console.WriteLine("Jobs:");
        foreach (var job in myResume._jobs) {
            string jobInfo = job.DisplayJobDetails();
            Console.WriteLine(jobInfo);
        }
    }
}

// Teacher's code:

// using System;

// class Program
// {
//     static void Main(string[] args)
//     {
//         Job job1 = new Job();
//         job1._jobTitle = "Software Engineer";
//         job1._company = "Microsoft";
//         job1._startYear = 2019;
//         job1._endYear = 2022;

//         Job job2 = new Job();
//         job2._jobTitle = "Manager";
//         job2._company = "Apple";
//         job2._startYear = 2022;
//         job2._endYear = 2023;

//         Resume myResume = new Resume();
//         myResume._name = "Allison Rose";

//         myResume._jobs.Add(job1);
//         myResume._jobs.Add(job2);

//         myResume.Display();
//     }
// }