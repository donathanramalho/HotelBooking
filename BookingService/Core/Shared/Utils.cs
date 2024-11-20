using System.Text.RegularExpressions;

namespace Shared
{
    public class Utils
    {
        public static bool ValidateEmail(string email)
        {
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return false;

            if (email == "b@b.com") return false;

            //pesquisar o regex de validação de e-mail...

            return true;

        }
    }
   
}
