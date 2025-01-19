// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System;
using System.IO;
using System.Data;
using System.ComponentModel;
using gradeBook.Classes;

string st = "";
while (st != "q")
{
    Console.WriteLine("GradeBook Program"); // Program Name and Menu Options
    Console.WriteLine("Make a Selection: ");
    Console.WriteLine("Add New Grade (g) ");
    Console.WriteLine("Get Average of Student (a)");
    Console.WriteLine("Read all grades (r)");
    Console.WriteLine("Close Program (q)");
    st = Console.ReadLine().ToLower(); // Prompt User for choice
    string[] choices = ["g","a","r","q"]; // valid options
    if (Array.IndexOf(choices, st) == 0) // if the user adds a new grade
    {
        string path = @"c:\temp\Records.txt"; // define the directory
        if (!File.Exists(path)) // should the file not exist
        {
            using (StreamWriter sw = File.CreateText(path)) // create 'records.txt'
            {
                Console.WriteLine("File 'Records.txt' was created.");
            }
        }
        Console.WriteLine("Provide a Student Name: "); // Enter a student name, with error handling
        string name = Console.ReadLine();
        while (name.Length == 1 | name == "")
            {
                Console.WriteLine("Name cannot be null or char.");
                name = Console.ReadLine();
            }
        Console.WriteLine("Provide a valid Grade entry: "); // Enter a valid grade, with error handling
        double grade = Convert.ToDouble(Console.ReadLine()); 
        while (grade < 0)
            {
                Console.WriteLine("Grade cannot be negative.");
                grade = Convert.ToDouble(Console.ReadLine());
            }
        var student = new Record(name, grade); // Create a new student object with the name and grade values
        
    }
    if (Array.IndexOf(choices, st) == 1) // if the user wants to get a student's average
    {
        string path = @"c:\temp\Records.txt";
        if (!File.Exists(path)) // should the records.txt not exist, return to main
        {
            Console.WriteLine("Records.txt does not exist. No grades were pulled. Returning to main.");
            return;
        }
        else // otherwise:
        {
            Console.WriteLine("Choose a student's name for their average: "); // prompt for a student to choose
            string n = Console.ReadLine();
            double totScore = 0; // accumulate their total score
            int count = 0; // accumulate their total assignments
            using (StreamReader sr = File.OpenText(path)) // Open a stream for reading
            {
                string s = "";
                while ((s = sr.ReadLine()) != null) // While the line is not empty
                {
                    if (s.ToLower() == n.ToLower()) // if the name matches to the submitted one
                    {
                        totScore += Convert.ToDouble(sr.ReadLine()); // read the succeeding score and add it to totScore
                        count++; // increment their assignment count by one
                    }
                }
            }
            if (count == 0) // If the name is not found
            {
                Console.WriteLine($"The student {n} is not found in this gradebook.");
            }
            else // Print the average to User
            {
                Console.WriteLine($"The average grade for {n} is {totScore/count}.");
            }
        }
    }
    if (Array.IndexOf(choices, st) == 2) // If user wants to read all records
    {
        string path = @"C:\temp\Records.txt";
        if (!File.Exists(path)) // If file does not exist:
        {
            Console.WriteLine("Records.txt does not exist. No grades can be read. Returning to main.");
            return;
        }
        else
        {
            foreach (string line in File.ReadLines(path)) // reads every line in the file, writing them to the user
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("End of Gradebook.");
        }
    }
    if (Array.IndexOf(choices, st) == 3) // If user quits the program
    {
        Console.WriteLine("Closing Progam.");
    }
    if (Array.IndexOf(choices, st) == -1)
    {
        Console.WriteLine("Invalid Choice.");
    }
}
