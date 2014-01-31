using System.Text.RegularExpressions;
namespace HauntedHouseSoftware.SecureNotePad.DomainObjects
{
    public sealed class PasswordStrength
    {
        private PasswordStrength()
        { }

        private readonly static string[] _weakPasswordList = { "password", "123456", "1234567", "12345678", "abc123", "qwerty", "monkey", "letmein", "dragon", "111111", "baseball", "iloveyou", "trustno1", "sunshine", "master", "123123", "welcome", "shadow", "ashley", "football", "jesus", "michael", "ninja", "mustang", "password1" };

        public static PasswordScore CheckStrength(string password)
        {
            int score = 0;

            if (string.IsNullOrEmpty(password))
            {
                return PasswordScore.Blank;
            }

            if (IsPasswordInWeakList(password))
            {
                return PasswordScore.Weak;
            }

            if (password.Length < 1)
            {
                return PasswordScore.Blank;
            }

            if (password.Length < 4)
            {
                return PasswordScore.VeryWeak;
            }

            if (password.Length >= 8)
            {
                score++;
            }

            if (password.Length >= 10)
            {
                score++;
            }

            if (Regex.Match(password, @"\d", RegexOptions.ECMAScript).Success)
            {
                score++;
            }

            if (Regex.Match(password, @"[a-z]", RegexOptions.ECMAScript).Success &&
                Regex.Match(password, @"[A-Z]", RegexOptions.ECMAScript).Success)
            {
                score++;
            }

            if (Regex.Match(password, @"[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]", RegexOptions.ECMAScript).Success)
            {
                score++;
            }

            return (PasswordScore)score;
        }

        private static bool IsPasswordInWeakList(string password)
        {
            foreach (string weakPassword in _weakPasswordList)
            {
                if (string.Compare(password,weakPassword,System.StringComparison.OrdinalIgnoreCase) == 0)
                {
                    return true;
                }

                if (PerformSubstitutions(weakPassword, password))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool PerformSubstitutions(string weakPassword, string password)
        {
            char[] vowels =            { 'A', 'a', 'e', 'i', 'o', 's', 'S'};
            char[] vowelSubstitution = { '4', '@', '3', '1', '0', '$', '5' };

            ReplaceLettersWithSubStitutions(password,vowels, vowelSubstitution);

            if (string.Compare(ReplaceLettersWithSubStitutions(weakPassword, vowels, vowelSubstitution), password, System.StringComparison.OrdinalIgnoreCase) == 0)
            {
                return true;
            }

            char[] qwerty = { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P' };
            char[] qwertySubstitution = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};

            if (string.Compare(ReplaceLettersWithSubStitutions(weakPassword, qwerty, qwertySubstitution), password, System.StringComparison.OrdinalIgnoreCase) == 0)
            {
                return true;
            }

            return false;
        }

        private static string ReplaceLettersWithSubStitutions(string password, char[] original, char[] substitution)
        {
            string newPassword = string.Empty;

            foreach (char c in password)
            {
                bool numberAdded = false;

                for (int q = 0; q < original.Length; q++)
                {
                    if (c == original[q])
                    {
                        newPassword = newPassword + substitution[q];
                        numberAdded = true;
                        break;
                    }                    
                }

                if (!numberAdded)
                {
                    newPassword = newPassword + c;
                }
            }
            
            return newPassword;
        }
    }
}
