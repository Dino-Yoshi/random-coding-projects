namespace ass4.Classes; // directory

public class Decryption // class
{
    public int NumShift {get;} // getter for numShift
    public string ModString {get;} // getter for ModString
    public string Decrypted {get; set;} // getter and setter for Decrypted

    public Decryption(int numShift, string modString) // initalizer
    {
        NumShift = numShift; 
        ModString = modString;
    }

    public string Decrypt() // Decryption Method
    {
        string decString = ""; // Accumulator String Variable
        string[] letters = ["a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"]; // string array for alpha
        
        foreach (char i in ModString) // iterates through each letter of string (ModString)
        {
            int index = Array.IndexOf(letters, i.ToString().ToLower()); // retrieve index value of current letter, returning -1 if not found

            if (index != -1) // if index IS NOT -1
            {
                index += 26 - NumShift; // proceed with standard decryption shift process
            }
            
            if ((i.ToString() != i.ToString().ToUpper()) & index != -1) // if the letter is lowercase
            {
                decString += letters[index % 26]; // modulate the index by 26 to find the original letter
            }

            if ((i.ToString() == i.ToString().ToUpper()) & index != -1) // if the letter is uppercase
            {
                decString += letters[index % 26].ToString().ToUpper(); // modulate the index by 26 to find the original character
            }

            if (index == -1) // if index IS -1
            {
                decString += i; // add the letter without any modification for it is not an alpha character
            }
        }
        Decrypted = decString; // store decrypted string into Decrypted
        return decString; // return decrypted string to main

    }
}