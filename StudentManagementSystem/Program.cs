using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudentManagementSystem
{
    internal class Program
    {
        static StudentManager manager = new StudentManager();



        static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----- STUDENT MANAGEMENT SYSTEM -----");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Remove Student");
            Console.WriteLine("3. Edit Student");
            Console.WriteLine("4. Show All Students");
            Console.WriteLine("5. Search by ID");
            Console.WriteLine("6. Search by Name");
            Console.WriteLine("7. Sort by Name");
            Console.WriteLine("8. Sort by Age");
            Console.WriteLine("9. Show Total Count");
            Console.WriteLine("0. Exit");

            Console.Write("Enter your choice: ");
            Console.ResetColor();

        }



        static void Main(string[] args)
        {

            
            while (true)
            {
                ShowMenu();
                string choise = Console.ReadLine();

                switch (choise)
                {
                    case "1":
                        AddStudentFlow();
                        break;
                    case "2":
                        RemoveStudentFlow();
                        break;
                    case "3":
                        Console.WriteLine("Edit Student");
                        //todo
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
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Please try again");
                        Console.ResetColor();
                        break;
                }
            }


        }

        static void ShowAllStudents()
        {
            Console.Clear();
            Console.WriteLine("----- Show All Students -----");

            List<Student> StudentList = manager.ShowStudentList();
            foreach (Student student in StudentList)
            {
                Console.WriteLine($"Full Name: {student.FullName},ID: {student.ID}, Age: {student.Age}, Phone Number: {student.PhoneNumber}, Email: {student.Email}");
            }
        }

        static void SortbyNameFlow()
        {
            Console.Clear();
            Console.WriteLine("----- Sort by Name -----");

            List<Student> StudentList = manager.SortByFullName();
            foreach (Student student in StudentList)
            {
                Console.WriteLine($"Full Name: {student.FullName},ID: {student.ID}, Age: {student.Age}, Phone Number: {student.PhoneNumber}, Email: {student.Email}");
            }


        }


        static void SortbyAgeFlow()
        {
            Console.Clear();
            Console.WriteLine("----- Sort by Age -----");

            List<Student> StudentList = manager.SortByAge();
            foreach (Student student in StudentList)
            {
                Console.WriteLine($"Full Name: {student.FullName},ID: {student.ID}, Age: {student.Age}, Phone Number: {student.PhoneNumber}, Email: {student.Email}");
            }


        }

        static void ShowTotalCount()
        {
            Console.Clear();
            Console.WriteLine("----- Show Total Count -----");
            int total = manager.StudentCount();
            Console.WriteLine($"Total students in the system: {total}");




        }




        static void AddStudentFlow()
        {
            Console.Clear();
            Console.WriteLine("----- Add Student -----");
            Console.WriteLine("you can type 'cancel' to abort");
            string FullName = null;
            int age = 0;
            string Email = null;
            string PhoneNumber = null;

            while (true)
            {
                Console.Write("\nEnter Full Name: ");
                string input = Console.ReadLine();
                if (input.ToLower() == "cancel")
                {
                    return;
                }
                string error = StudentValidation.ValidateFullName(input);
                if (error == null)
                {
                    FullName = input;
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error);
                Console.ResetColor();

            }

            while (true)
            {
                Console.Write("\nEnter Age: ");
                string input = Console.ReadLine();
                if (input.ToLower() == "cancel")
                {
                    return;
                }
                string error = StudentValidation.ValidateAge(input, out int NewAge);
                if (error == null && NewAge != 0)
                {
                    age = NewAge;
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error);
                Console.ResetColor();
            }

            while (true)
            {
                Console.Write("\nEnter Phone Number: ");
                string input = Console.ReadLine();
                if (input.ToLower() == "cancel")
                {
                    return;
                }
                string error = StudentValidation.ValidatePhoneNumber(input);
                if (error == null)
                {
                    PhoneNumber = input;
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error);
                Console.ResetColor();
            }

            while (true)
            {
                Console.Write("\nEnter Email: ");
                string input = Console.ReadLine();
                if (input.ToLower() == "cancel")
                {
                    return;
                }
                string error = StudentValidation.ValidateEmail(input);
                if (error == null)
                {
                    Email = input;
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error);
                Console.ResetColor();
            }

            manager.AddStudent(FullName, age, Email, PhoneNumber);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("* * * * Student added successfully * * * *");
            Console.ResetColor();
        }

        static void RemoveStudentFlow()
        {
            Console.Clear();
            Console.WriteLine("----- Remove Student -----");
            Console.WriteLine("you can type 'cancel' to abort");



            int InputID = 0;
            while (true)
            {
                Console.Write("\nEnter Student ID to remove: ");
                string input = Console.ReadLine();
                if (input.ToLower() == "cancel")
                {
                    return;
                }

                if (int.TryParse(input, out InputID))
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
            Console.WriteLine("----- Search Student by ID -----");
            Console.WriteLine("you can type 'cancel' to abort");

            int InputID = 0;

            while (true)
            {
                Console.Write("\nEnter Student ID to Search: ");
                string input = Console.ReadLine();
                if (input.ToLower() == "cancel")
                {
                    return;
                }

                if (int.TryParse(input, out InputID))
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid ID, Enter a Number");
                Console.ResetColor();
            }


            Student result = manager.SearchStudentId(InputID);

            if (result == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Student with ID:{InputID} NOT FOUND");
                Console.ResetColor();
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Full Name: {result.FullName},ID: {result.ID}, Age: {result.Age}, Phone Number: {result.PhoneNumber}, Email: {result.Email}");
                Console.ResetColor();
            }


        }

        static void SearchbyNameFlow()
        {

            Console.Clear();
            Console.WriteLine("----- Search by Full Name ID -----");
            Console.WriteLine("you can type 'cancel' to abort");

            string error = null;
            string input = null;
            while (true)
            {
                
                Console.Write("\nEnter Student Full Name to Search: ");
                input = Console.ReadLine();
                if (input.ToLower() == "cancel")
                {
                    return;
                }
                error = StudentValidation.ValidateFullName(input);
                if (error == null)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(error+" Enter again: ");
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
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (Student student in result)
                {
                    Console.WriteLine($"Full Name: {student.FullName},ID: {student.ID}, Age: {student.Age}, Phone Number: {student.PhoneNumber}, Email: {student.Email}");
                }
                Console.ResetColor();
            }
        }
    }
}
