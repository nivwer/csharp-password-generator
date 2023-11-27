using System;
using PasswordGenerator.Security;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("How many characters do you want in your password? ");
            string stringLength = Console.ReadLine() ?? "8";
            bool ok = !int.TryParse(stringLength, out int length);

            if (length < 173)
            {
                Console.WriteLine("Do you want to include speacial characters? (y/n) ");
                string includeSpecialChars = Console.ReadLine() ?? "n";

                string password = PasswordManager.GeneratePassword(length, includeSpecialChars);
                string strength = PasswordManager.CheckStrength(password);
                string encryptedPassword = PasswordManager.EncryptedPassword(password);

                Console.WriteLine($"Your password is: {password}");
                Console.WriteLine($"Your password is {strength}");
                Console.WriteLine($"Your encrypted password is: {encryptedPassword}");
            }
            else
            {
                Console.WriteLine("The maximum length of the password should be 173.");
            }


        }
    }
}
