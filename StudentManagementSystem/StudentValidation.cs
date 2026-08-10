using System;
using System.Collections.Generic;
using System.Text;

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

            else if (!fullname.Contains(' '))
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

        public static string ValidateEmail(string email)
        {
            //todo
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
                return "phone number cannot contain letters or spaces";

            }
            else if (phonenumber.Length != 11)
            {
                return "phone number must be exactly 11 digits long";
            }
            else if (phonenumber[0] != '0' || phonenumber[1] != '9')
            {
                return "phone number must start with 09_________";

            }
            return null;
        }


    }
}
