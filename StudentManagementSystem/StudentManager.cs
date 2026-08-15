using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem
{
    //manages the list of students (add, remove, search, sort, count, edit)

    public class StudentManager
    {
        private List<Student> StudentList = new List<Student>();
        public void AddStudent(string fullname, int age, string email, string phonenumber)
        {
            Student s = new Student(Guid.NewGuid(), fullname.ToLower(), age, email.ToLower(), phonenumber);
            StudentList.Add(s);
        }

        public bool RemoveStudent(Guid id)
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


        public Student? SearchStudentId(Guid id)
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

        public bool EditStudent(Guid id, string fullname, int age, string email, string phonenumber)
        {
            Student? found = StudentList.FirstOrDefault(x => x.ID == id);

            if (found == null)
            {
                return false;
            }
            found.FullName = fullname.ToLower();
            found.Age = age;
            found.Email = email.ToLower();
            found.PhoneNumber = phonenumber;

            //student changed
            return true;
        }
        //checking for exist email
        public bool EmailExist(string email)
        {
            bool found = StudentList.Any(x => x.Email.ToLower() == email.ToLower());
            return found;
        }

        //checking for exist phone number
        public bool PhoneNumberExist(string phone)
        {
            bool found = StudentList.Any(x => x.PhoneNumber == phone);
            return found;
        }
    }
}

