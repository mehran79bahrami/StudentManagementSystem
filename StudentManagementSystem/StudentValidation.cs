using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StudentManagementSystem
{
    public static class StudentValidation
    {

        public static string ValidateFullName(string fullname)
        {

            if (fullname.Any(char.IsDigit))
            {
                return "Full name cannot contains number";
            }

            else if (string.IsNullOrWhiteSpace(fullname))
            {
                return "Full name cannot be empty";
            }

            else if (!(fullname.Contains(' ')))
            {
                return "Enter both first and last name separated by a space";
            }
            else if (fullname[0] == ' ' || fullname[fullname.Length - 1] == ' ')
            {
                return "Name cannot start or end with space";

            }
            else if (fullname.Length > 30)
            {
                return "Name is too long (MAX 30 characters)";
            }
            else if (fullname.Length < 5)
            {
                return "Name is too short (MIN 5 characters)";
            }

            return null;
        }

        public static string ValidateAge(string input, out int age)
        {

            age = 0;
            if (string.IsNullOrWhiteSpace(input))
            {
                return "Age cannot be empty";
            }

            else if (!(int.TryParse(input, out age)))
            {
                return "Age most be a integer";
            }
            else if (age < 14 || age > 23)
            {
                age = 0;

                return "Age most be between 14 and 23";
            }



            return null;
        }

        public static string ValidatePhoneNumber(string phonenumber)
        {


            if (string.IsNullOrEmpty(phonenumber))
            {
                return "Phone number cannot be empty";
            }
            else if (!(phonenumber.All(char.IsDigit)))
            {
                return "Phone number cannot contain letters or spaces";

            }
            else if (phonenumber.Length != 11)
            {
                return "Phone number must be exactly 11 digits long";
            }
            else if (phonenumber[0] != '0' || phonenumber[1] != '9')
            {
                return "Phone number must start with 09_________";

            }
            return null;
        }


        public static string ValidateEmail(string email)
        {

            if (string.IsNullOrWhiteSpace(email))
            {
                return "Email cannot be empty";
            }

            foreach (char c in email)
            {
                if (!((c >= '0' & c <= '9' || (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c == '.') || (c == '@'))))
                {
                    return "Email contains invalid characters. Only letters, numbers, Dot, and @ are allowed";
                }
            }

            if (!(email.Contains('@')))
            {
                return "Email most contain exactly one '@'";
            }
            if (!(email.Contains('.')))
            {
                return "Email most contain '.'";
            }

            if ((email[0] == '@' || email[email.Length - 1] == '@'))
            {
                return "Email cannot start or end with '@'";

            }
            if ((email[0] == '.' || email[email.Length - 1] == '.'))
            {
                return "Email cannot start or end with '.'";

            }

            int AtCount = 0;
            foreach (char c in email)
            {
                if (c == '@')
                {
                    AtCount++;
                }
            }
            if (AtCount != 1)
            {
                return "Email most contain exactly one '@'";

            }

            for (int i = 0; i < email.Length - 1; i++)
            {
                char c1 = email[i];
                char c2 = email[i + 1];

                bool DubleChar1 = ((c1 == '.') || (c1 == '@'));
                bool DubleChar2 = ((c2 == '.') || (c2 == '@'));

                if ((DubleChar1 == DubleChar2) && DubleChar1 == true)
                {
                    return "Email cannot have two consecutive characters (. and @)";
                }
            }

            //ty mmd
            int AtIndex = email.IndexOf('@');
            string DomainPart = email.Substring(AtIndex + 1);
            if (!(Regex.IsMatch(DomainPart, "^[^.]+(\\.[^.]+)+$")))
            {
                return "Invalid domain";
            }

            if (email.Length > 75)
            {
                return "Enail is too long (MAX 75 characters)";

            }
            return null;
        }
    }
}
