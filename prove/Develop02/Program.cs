using System;
using System.ComponentModel;
using System.Dynamic;
using System.IO.Enumeration;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// To exceed the requirements, I made a counter to congratulate the user for writing in their journal.
class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        
        int journalOption = 0;
        Console.WriteLine("Welcome to the Journal Program!");

        while(journalOption != 5){
            Console.WriteLine("Please select one of the following choices: ");
            Console.WriteLine("1. Write \n2. Display \n3. Load \n4. Save \n5. Quit");
            Console.WriteLine("What would you like to do? ");
            journalOption = int.Parse(Console.ReadLine());

            if (journalOption == 1){
                string randomPrompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(randomPrompt);
                string userResponse = Console.ReadLine();

                // Create a new entry and add it to the journal
                Entry newEntry = new Entry {
                    _date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    _promptText = randomPrompt,
                    _entryText = userResponse
                };
                myJournal.AddEntry(newEntry);
                Console.WriteLine($"Congrats! You've written in your journal {myJournal.EntryCount} time(s).");

            }
            else if (journalOption == 2) {
                // Display all entries in the journal
                myJournal.DisplayAll();
            }
            else if (journalOption == 3) {
                Console.WriteLine("Enter the filename to load: ");
                string filename = Console.ReadLine();
                // Load entries from the file
                myJournal.LoadFromFile(filename);
            }
            else if (journalOption == 4) {
                Console.WriteLine("Enter the filename to save: ");
                string filename = Console.ReadLine();
                // Save entries to a file
                myJournal.SaveToFile(filename);
            }
            else if(journalOption == 5){
                break;
            }
        }
    }
}