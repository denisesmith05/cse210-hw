using System;
using System.Runtime.InteropServices.Marshalling;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        string play_again;
        do{
            int guess = 0;
            int counter = 0;
            int magic_num = randomGenerator.Next(1, 100);

            while (guess != magic_num){
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                counter += 1;

                if (guess > magic_num){
                    Console.WriteLine("Lower");
                }
                else if (guess < magic_num){
                    Console.WriteLine("Higher");
                }
                else{
                    Console.WriteLine("You guessed it! ");
                    Console.WriteLine($"You guessed {counter} time(s). ");
                }
            }
            Console.Write("Do you want to play again? ");
            play_again = Console.ReadLine();

        } while (play_again == "yes");
        if (play_again == "no"){
            Console.Write("Thanks for playing! Goodbye!");
        }
    }
}