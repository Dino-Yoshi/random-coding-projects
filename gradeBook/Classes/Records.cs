using System.Runtime.InteropServices;

namespace gradeBook.Classes;

public class Record
{
    public string StudentName {get; set;}

    public Record(string studentName, double studentGrade)
    {
        StudentName = studentName;
        addGrade(studentGrade);
    }

    public void addGrade(double stdGrade) // Add grade method
    {
        string path = @"c:\temp\Records.txt";
        using (StreamWriter sw = File.AppendText(path)) // Open stream for writing, adding new names, and grades.
        {
            sw.WriteLine(StudentName);
            sw.WriteLine(stdGrade);
        }
        Console.WriteLine("Scores saved.");
        
    }
}