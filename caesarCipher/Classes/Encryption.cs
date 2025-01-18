using System.Drawing;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace ass4.Classes; // directory

public class Encryption // class name
{
    public int NumShift {get; set;} // getting and setting number of shifts
    public string ToMod {get; set;} // getting and setting the string to be modded
    public string Modified {get; set;} // getting and setting the modified resulting string
    
    public Encryption(string toMod, int numShift) // initalizer
    {
        ToMod = toMod; // assigment of the string to modify
        NumShift = numShift; // assignment of the number of shifts to use
    }

    public string Encrypt() // Encryption Method
    {
        string encSt = ""; // variable for the encrypted string
        string[] letters = ["a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"]; // string array for the alphabet
        
        foreach (char i in ToMod) // loop iterating based on the contents of string
        {
            int index = Array.IndexOf(letters, i.ToString().ToLower()); // find the index value of the current letter and return it; return -1 if not found

            index += NumShift; // increase the index value by the number of shifts
            
            if ((index - NumShift) == -1) // determines if the original index value was -1 or not, if so:
            {
                encSt += i; // add the character to the encrypted string without any modification
                index -= NumShift; // set the index to a bad value to ignore all following conditions
            }

            if ((i.ToString() != i.ToString().ToUpper()) & index != -1) // determines if the letter is lowercase:
            {
                if (index > 26) // if the index is larger than 26:
                {
                    index -= 26; // subtract to be in within array values (modulo can also be used here)
                    encSt += letters[index]; // add this new modified letter to the encrypted string
                }
                else // if the index is already between values of 0-25
                {
                    encSt += letters[index]; // add the modified letter to the encrypted string
                }
            }

            if ((i.ToString() == i.ToString().ToUpper()) & index != -1) // determine if the letter is uppercase
            {
                if (index > 26) // if the index is larger than 26:
                {
                    index -= 26; // subtract to be in array values (modulo is alternative solution)
                    encSt += letters[index].ToString().ToUpper(); // add modified capital character to string
                }
                else // index between 0-25
                {
                    encSt += letters[index].ToString().ToUpper(); // add modified capital character to string
                }
            }
        }
        Modified = encSt; // assign modified string to Modified variable
        return encSt; // return encrypted string
    }
}