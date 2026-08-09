using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem
{
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
            foreach (Student temp in StudentList)
            {
                if (temp.ID == id)
                {
                    StudentList.Remove(temp);
                    return true;
                }

            }
            return false;
        }

        public List<Student> ShowStudentList()
        {
            return StudentList;
        }

        public List<Student> SearchStudentFullName(string fullname)
        {
            List<Student> ResultList = new List<Student>();
            foreach (Student temp in StudentList)
            {
                if (temp.FullName.ToLower() == fullname.ToLower())
                {
                    ResultList.Add(temp);
                }
            }
            return ResultList;
        }

        //todo
    }
}
