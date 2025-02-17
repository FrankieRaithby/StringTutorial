using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StringTutorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string to encrypt:");
            try
            {
                string userInput = Console.ReadLine();
                EncryptString(userInput);
            }
            catch (Exception ex)
            {
                  Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        static string EncryptString(string inputString)
        {
            // Guard clause to check if input is a valid string
            if (string.IsNullOrWhiteSpace(inputString))
            {
                throw new ArgumentNullException(nameof(inputString), "String cannot be null or empty.");
            }
            // Reverse the string
            char[] stringArray = inputString.ToCharArray();
            Array.Reverse(stringArray);
            // Convert every second charatcer to uppercase
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (i % 2 == 0)
                {
                    char character = stringArray[i];
                    character = char.ToUpper(character);
                    stringArray[i] = character;
                }
            }
            // Interpolateion and concatenation
            string reversedString = stringArray.ToString();
            string secretString = "Secret-" + reversedString + "-Code";
            // String conversion using ASCII values to shift each character by 1
            char[] finalEncryptionChars = null;
            foreach (char c in secretString)
            {
                int ASCII = (int)c + 1;
                finalEncryptionChars.Append((char)ASCII);
            }

            string finalEncryption = new string(finalEncryptionChars);
            return finalEncryption;
        }
    }
}
