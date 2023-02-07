using System;
using System.Text.RegularExpressions;

namespace ValidationsLibrary
{
    public class EmailValidator
    {
        public static bool EmailValidation(string email)
        {
            string pattern = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";

            if (Regex.IsMatch(email, pattern))
                return true;
            else
                return false;
        }
    }
}
