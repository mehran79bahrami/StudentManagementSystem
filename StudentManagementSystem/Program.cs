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
                        Console.WriteLine("Remove Student");
                        //todo
                        break;
                    case "3":
                        Console.WriteLine("Edit Student");
                        //todo
                        break;
                    case "4":
                        ShowAllStudents();
                        break;

                    case "5":
                        Console.WriteLine("Search by ID");
                        //todo
                        break;
                    case "6":
                        Console.WriteLine("Search by Name");
                        //todo
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
                    FullName= input;
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
                if (error == null && NewAge!=0)
                {
                    age= NewAge;
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

            manager.AddStudent(FullName, age,Email,PhoneNumber);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("* * * * Student added successfully * * * *");
            Console.ResetColor();
        }
    }
}
