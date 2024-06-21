using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<float> numbers = new List<float>();
        float number = -1;
        float sum = 0;
        int count = 0; 
        float avg = 0;
        float largest = float.MinValue;
        float smallest = float.MaxValue;

        while (number != 0)
        {
            Console.Write("Enter number: ");
            number = float.Parse(Console.ReadLine());

            if (number == 0)
            {
                break;
            }

            numbers.Add(number);
            sum += number;
            count++; 
            avg = sum / count;

            if (number > largest)
            {
                largest = number;
            }

            if (number > 0 && number < smallest)
            {
                smallest = number;
            }
        }

        numbers.Sort();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {avg}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine($"The smallest positive number is: {smallest}");

        Console.WriteLine("The sorted list:");
        foreach (float num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}