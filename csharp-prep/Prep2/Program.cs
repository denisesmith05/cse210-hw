// My Code:

using System;

class Program
{
    static void Main(string[] args)
    {
        // This is prep 2
        Console.WriteLine("What is your grade percentage? ");
        string input = Console.ReadLine();
        int grade_num;
        string letter = "";
        if (int.TryParse(input, out grade_num)){       
            if (grade_num >= 90){
                letter = "A";
            }
            else if (grade_num >= 80){
                letter = "B";
            }
            else if (grade_num >= 70){
                letter = "C";
            }
            else if (grade_num >= 60){
                letter = "D";
            }
            else{
                letter = "F";
            }
            if (letter != "A" && grade_num % 10 >= 7)
            {
                letter += "+";
            }
            else if (grade_num % 10 <= 3 && grade_num >= 53)
            {
                letter += "-";
            }
            Console.WriteLine($"Your grade is {letter}");

            if (grade_num >= 70){
                Console.WriteLine("Congrats! You passed the class!");
            }
            else {
                Console.WriteLine("Aww man! You didn't pass this time. You can always pass next time!");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}