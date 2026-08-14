using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem
{
    //manages the list of students (add, remove, search, sort, count, edit)

    public class StudentManager
    {
        private List<Student> StudentList = new List<Student>();
        private int IdCounter = 1000;

        public void AddStudent(string fullname, int age, string email, string phonenumber)
        {
            Student s = new Student(IdCounter++, fullname, age, email, phonenumber);
            StudentList.Add(s);
        }

        public bool RemoveStudent(int id)
        {
            var found = StudentList.FirstOrDefault(x => x.ID == id);
            if (found == null)
            {
                return false;
            }
            StudentList.Remove(found);
            return true;
        }

        //show read only list
        public IReadOnlyList<Student> ShowStudentList()
        {
            return StudentList.AsReadOnly();
        }

        public List<Student> SearchStudentFullName(string fullname)
        {
            var found = StudentList.Where(x => x.FullName.ToLower().StartsWith(fullname.ToLower())).ToList();
            return found;
        }
       

        public Student? SearchStudentId(int id)
        {
            Student? found = StudentList.FirstOrDefault(x => x.ID == id);
            return found;
        }

        public List<Student> SortByFullName()
        {
            var result = StudentList.OrderBy(x => x.FullName).ToList();
            return result;
        }

        public List<Student> SortByAge()
        {
            var result = StudentList.OrderBy(x => x.Age).ToList();
            return result;
        }

        public int StudentCount()
        {
            return StudentList.Count;
        }

        public bool EditStudent(int id, string fullname, int age, string email, string phonenumber)
        {
            Student? found = StudentList.FirstOrDefault(x => x.ID == id);

            if (found == null)
            {
                return false;
            }
            found.FullName = fullname;
            found.Age = age;
            found.Email = email;
            found.PhoneNumber = phonenumber;

            //student changed
            return true;
        }
    }
}

