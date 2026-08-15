using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudentManagementSystem
{
    internal class Program
    {
        static StudentManager manager = new StudentManager();
        static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║        STUDENT MANAGEMENT SYSTEM         ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");
            Console.WriteLine("║                                          ║");
            Console.WriteLine("║   [1] Add Student                        ║");
            Console.WriteLine("║   [2] Remove Student                     ║");
            Console.WriteLine("║   [3] Edit Student                       ║");
            Console.WriteLine("║   [4] Show All Students                  ║");
            Console.WriteLine("║   [5] Search by ID                       ║");
            Console.WriteLine("║   [6] Search by Name                     ║");
            Console.WriteLine("║   [7] Sort by Name                       ║");
            Console.WriteLine("║   [8] Sort by Age                        ║");
            Console.WriteLine("║   [9] Show Total Count                   ║");
            Console.WriteLine("║   [0] Exit                               ║");
            Console.WriteLine("║                                          ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.Write("Enter your choice: ");
            Console.ResetColor();
        }
        static void ShowHeader(string title)
        {
            Console.Write("\x1b[2J\x1b[3J\x1b[H");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine($"║ {title,-54} ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.ResetColor();
        }
        static void DisplayStudent(Student student)
        {
            Console.WriteLine(
                    $"Full Name       : {student.FullName}" +
                    $"\nID              : {student.ID}" +
                    $"\nAge             : {student.Age}" +
                    $"\nPhone           : {student.PhoneNumber}" +
                    $"\nEmail           : {student.Email}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("═════════════════════════════════════════════════════════\n");
            Console.ResetColor();
        }
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    ShowMenu();
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AddStudentFlow();
                            break;
                        case "2":
                            RemoveStudentFlow();
                            break;
                        case "3":
                            EditStudentFlow();
                            break;
                        case "4":
                            ShowAllStudents();
                            break;
                        case "5":
                            SearchbyIDFlow();
                            break;
                        case "6":
                            SearchbyNameFlow();
                            break;
                        case "7":
                            SortbyNameFlow();
                            break;
                        case "8":
                            SortbyAgeFlow();
                            break;
                        case "9":
                            ShowTotalCount();
                            break;
                        case "0":
                            Console.Clear();
                            Console.WriteLine("----- GoodBye -----");
                            return;
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid choice. Please try again");
                            Console.ResetColor();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("unexpected ERROR");
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        static void AddStudentFlow()
        {
            Console.Clear();
            ShowHeader("Add Student");
            Console.WriteLine("you can type 'cancel' to abort");
            string FullName = null;
            int age = 0;
            string Email = null;
            string PhoneNumber = null;

            //get a valid full name
            while (true)
            {
                Console.Write("\nEnter Student Full Name: ");
                var input = Console.ReadLine();

                if (input?.ToLower() == "cancel")
                {
                    return;
                }
                var error = StudentValidation.ValidateFullName(input);
                if (error == null)
                {
                    FullName = input;
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error);
                Console.ResetColor();
            }

            //get a valid age
            while (true)
            {
                Console.Write("\nEnter Student Age: ");
                var input = Console.ReadLine();
                if (input?.ToLower() == "cancel")
                {
                    return;
                }
                string? error = StudentValidation.ValidateAge(input, out int NewAge);
                if (error == null && NewAge != 0)
                {
                    age = NewAge;
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error);
                Console.ResetColor();
            }
            //get a valid phone number
            while (true)
            {
                Console.Write("\nEnter Student Phone Number: ");
                var input = Console.ReadLine();
                if (input?.ToLower() == "cancel")
                {
                    return;
                }
                string? error = StudentValidation.ValidatePhoneNumber(input);
                if (error == null && manager.PhoneNumberExist(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This Phone Number is already used by another student");
                    Console.ResetColor();
                }
                else if (error == null)
                {
                    PhoneNumber = input;
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error);
                Console.ResetColor();
            }

            //get a valid email
            while (true)
            {
                Console.Write("\nEnter Student Email: ");
                var input = Console.ReadLine();
                if (input?.ToLower() == "cancel")
                {
                    return;
                }
                string? error = StudentValidation.ValidateEmail(input);

                if (error == null && manager.EmailExist(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This email is already used by another student");
                    Console.ResetColor();
                }
                else if (error == null)
                {
                    Email = input;
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error);
                Console.ResetColor();
            }

            //added new student
            manager.AddStudent(FullName, age, Email, PhoneNumber);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("* * * * Student added successfully * * * *");
            Console.ResetColor();
        }

        static void ShowAllStudents()
        {
            Console.Clear();
            ShowHeader("Show All Students");

            IReadOnlyList<Student> StudentList = manager.ShowStudentList();
            foreach (Student student in StudentList)
            {
                DisplayStudent(student);
            }
        }

        static void SortbyNameFlow()
        {
            Console.Clear();
            ShowHeader("Sort by Name");


            List<Student> StudentList = manager.SortByFullName();
            foreach (Student student in StudentList)
            {
                DisplayStudent(student);
            }
        }

        static void SortbyAgeFlow()
        {
            Console.Clear();
            ShowHeader("Sort by Age");
            List<Student> StudentList = manager.SortByAge();
            foreach (Student student in StudentList)
            {
                DisplayStudent(student);
            }
        }

        static void ShowTotalCount()
        {
            Console.Clear();
            ShowHeader("Show Total Count");

            int total = manager.StudentCount();
            Console.WriteLine($"Total students in the system: {total}");
        }

        static void RemoveStudentFlow()
        {
            Console.Clear();
            ShowHeader("Remove Student");
            Console.WriteLine("you can type 'cancel' to abort");

            Guid InputID;

            //get a valid input
            while (true)
            {
                Console.Write("\nEnter Student ID to remove: ");
                var input = Console.ReadLine();
                if (input?.ToLower() == "cancel")
                {
                    return;
                }

                if (Guid.TryParse(input, out InputID))
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid ID, Enter a Number");
                Console.ResetColor();
            }

            bool remove = manager.RemoveStudent(InputID);
            if (remove)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"* * * * Student with ID:{InputID} removed successfully * * * *");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Student with ID:{InputID} NOT FOUND");
                Console.ResetColor();
            }
        }
        static void SearchbyIDFlow()
        {
            Console.Clear();
            ShowHeader("Search Student by ID");
            Console.WriteLine("you can type 'cancel' to abort");

            Guid InputID;

            //get a valid input
            while (true)
            {
                Console.Write("\nEnter Student ID to Search: ");
                var input = Console.ReadLine();
                if (input?.ToLower() == "cancel")
                {
                    return;
                }

                if (Guid.TryParse(input, out InputID))
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid ID, Enter a Number");
                Console.ResetColor();
            }

            //get student data with remove
            Student? result = manager.SearchStudentId(InputID);

            if (result == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Student with ID:{InputID} NOT FOUND");
                Console.ResetColor();
                return;
            }
            else
            {
                DisplayStudent(result);
            }
        }

        static void SearchbyNameFlow()
        {
            Console.Clear();
            ShowHeader("Search by Full Name ID");
            Console.WriteLine("you can type 'cancel' to abort");

            string? error = null;
            string? input = null;

            //get a valid inpur
            while (true)
            {

                Console.Write("\nEnter Student Full Name to Search: ");
                input = Console.ReadLine();
                input = input?.Trim();
                if (input?.ToLower() == "cancel")
                {
                    return;
                }
                error = StudentValidation.ValidateNameSearch(input);
                if (error == null)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(error + " Enter again: ");
                    Console.ResetColor();
                }
            }

            List<Student> result = manager.SearchStudentFullName(input);

            if (result.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Student with Full Name:{input} NOT FOUND");
                Console.ResetColor();
                return;
            }
            else
            {
                foreach (Student student in result)
                {
                    DisplayStudent(student);
                }
                
            }
        }

        static void EditStudentFlow()
        {
            Console.Clear();
            ShowHeader("Edit Student");
            Console.WriteLine("you can type 'cancel' to abort");

            Guid InputID;

            //get a valid input
            while (true)
            {
                Console.Write("\nEnter Student ID to Edit: ");
                var input = Console.ReadLine();
                if (input?.ToLower() == "cancel")
                {
                    return;
                }

                if (Guid.TryParse(input, out InputID))
                {
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid ID, Enter a Number");
                Console.ResetColor();
            }

            Student? result = manager.SearchStudentId(InputID);

            if (result == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Student with ID:{InputID} NOT FOUND");
                Console.ResetColor();
                return;
            }

            //editing student

            Console.Clear();
            DisplayStudent(result);
            ShowHeader("Editing Student");
            Console.WriteLine("you can type 'cancel' to abort");

            string FullName = result.FullName;
            int age = result.Age;
            string Email = result.Email;
            string PhoneNumber = result.PhoneNumber;

            //get a valid name to change
            while (true)
            {
                Console.Write("\nEnter new Full Name or type '0' to Skip Change: ");
                var input = Console.ReadLine();
                if (input?.ToLower() == "cancel")
                {
                    return;
                }
                if (input == "0")
                {
                    break;
                }
                string? error = StudentValidation.ValidateFullName(input);
                if (error == null)
                {
                    FullName = input;
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error);
                Console.ResetColor();
            }

            //get a valid age to change
            while (true)
            {
                Console.Write("\nEnter new Age or type '0' to Skip Change: ");
                var input = Console.ReadLine();
                if (input?.ToLower() == "cancel")
                {
                    return;
                }
                if (input == "0")
                {
                    break;
                }
                string? error = StudentValidation.ValidateAge(input, out int NewAge);
                if (error == null && NewAge != 0)
                {
                    age = NewAge;
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error);
                Console.ResetColor();
            }

            //get a valid phone number to change
            while (true)
            {
                Console.Write("\nEnter new Phone Number or type '0' to Skip Change: ");
                var input = Console.ReadLine();
                if (input?.ToLower() == "cancel")
                {
                    return;
                }
                if (input == "0")
                {
                    break;
                }
                string? error = StudentValidation.ValidatePhoneNumber(input);

                if (error == null && manager.PhoneNumberExist(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This Phone Number is already used by another student");
                    Console.ResetColor();
                }
                else if (error == null)
                {
                    PhoneNumber = input;
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error);
                Console.ResetColor();
            }

            //get a valid email to change
            while (true)
            {
                Console.Write("\nEnter new Email or type '0' to Skip Change: ");
                var input = Console.ReadLine();
                if (input?.ToLower() == "cancel")
                {
                    return;
                }
                if (input == "0")
                {
                    break;
                }
                string? error = StudentValidation.ValidateEmail(input);

                if (error == null && manager.EmailExist(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This Email is already used by another student");
                    Console.ResetColor();
                }
                else if (error == null)
                {
                    Email = input;
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error);
                Console.ResetColor();
            }

            //complete edit
            manager.EditStudent(result.ID, FullName, age, Email, PhoneNumber);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("* * * * Student Edited successfully * * * *");
            Console.ResetColor();

        }
    }
}
