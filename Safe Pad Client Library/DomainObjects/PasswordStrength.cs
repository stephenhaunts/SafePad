using System.Text.RegularExpressions;
namespace HauntedHouseSoftware.SecureNotePad.DomainObjects
{
    public enum PasswordScore
    {
        Blank = 0,
        VeryWeak = 1,
        Weak = 2,
        Medium = 3,
        Strong = 4,
        VeryStrong = 5
    }

    public sealed class PasswordStrength
    {
        private PasswordStrength()
        { }

        public static PasswordScore CheckStrength(string password)
        {
            int score = 0;

            if (string.IsNullOrEmpty(password))
            {
                return PasswordScore.Blank;
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
    }
}
