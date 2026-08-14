using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace StudentManagementSystem
{
    //all validation ruls
    public static class StudentValidation
    {

        public static string? ValidateFullName(string fullname)
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

        public static string? ValidateAge(string input, out int age)
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

        public static string? ValidatePhoneNumber(string phonenumber)
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


        public static string? ValidateEmail(string email)
        {

            if (string.IsNullOrWhiteSpace(email))
            {
                return "Email cannot be empty";
            }

            if (email.Length > 120)
            {
                return "Enail is too long (MAX 120 characters)";
            }
            //check format
            var checkemail = MailAddress.TryCreate(email,out var mail);
            
            if(!checkemail)
            {
                return "Invalid email format";
            }

            if (email != mail?.Address)
            {
                return "Enter only the email address";
            }
            var tld = mail.Host.Split('.').Last();
            if (tld.Length < 2)
            {
                return "Invalid email format";
            }

            return null;
        }

        //just validate name for name search
        public static string? ValidateNameSearch(string searchname)
        {
            
            if (searchname.Any(char.IsDigit))
            {
                return "name cannot contains number";
            }

            else if (string.IsNullOrWhiteSpace(searchname))
            {
                return "name cannot be empty";
            }
            else if (searchname.Length > 30)
            {
                return "Name is too long (MAX 30 characters)";
            }

            return null;

        }

    }
}
