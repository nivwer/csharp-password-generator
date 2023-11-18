using System.Security.Cryptography;
using System.Text;

namespace PasswordGenerator.Security
{
    public class PasswordManager
    {
        // Password Generator.
        public static string GeneratePassword(int length, string includeSpecialChars)
        {
            length = (length == 0) ? 8 : length;
            includeSpecialChars = (includeSpecialChars.ToLower() != "y" && includeSpecialChars.ToLower() != "n") ? "n" : includeSpecialChars;

            string upperCaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowerCaseLetters = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "0123456789";
            string specialCharacters = "!@#$%^&*()-_=+[]{}|;:,.<>?";

            StringBuilder allChars = new(upperCaseLetters + lowerCaseLetters + numbers);

            if (includeSpecialChars.ToLower() == "y" || includeSpecialChars == "")
            {
                allChars.Append(specialCharacters);
            }

            Random random = new();
            StringBuilder password = new();

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(allChars.Length);
                password.Append(allChars[index]);
            }

            return password.ToString();
        }

        // Check the Strenght of the password.
        public static string CheckStrength(string password)
        {
            string res = "weak";
            bool hasDigit = false;
            bool hasUpperCase = false;
            bool hasLowerCase = false;

            foreach (char c in password.ToCharArray())
            {
                if (Char.IsDigit(c)) hasDigit = true;
                else if (Char.IsUpper(c)) hasUpperCase = true;
                else if (Char.IsLower(c)) hasLowerCase = true;
                if (hasDigit && hasLowerCase && hasUpperCase) break;
            }

            if (password.Length >= 8 && hasDigit && hasLowerCase && hasUpperCase)
            {
                res = "strong";
            }

            return res;
        }

        // Password Encryption.
        public static string EncryptedPassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashedBytes = SHA256.HashData(passwordBytes);

            StringBuilder sb = new();
            foreach (byte b in hashedBytes)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}