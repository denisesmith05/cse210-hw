using System;
using System.Xml.Serialization;
using Microsoft.Win32.SafeHandles;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredUserNumber = SquareNumber(userNumber);
        DisplayResult(userName, squaredUserNumber);
    }
    static void DisplayWelcome(){
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName(){
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    static int PromptUserNumber(){
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }
    static int SquareNumber(int userNumber){
        int squaredNumber = userNumber * userNumber;
        return squaredNumber;
    }
    static void DisplayResult(string userName, int squaredUserNumber){
        Console.WriteLine($"{userName}, the square of your number is {squaredUserNumber}");
    }
}