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

        public Student? SearchStudentId(int id)
        {
            Student? found = StudentList.FirstOrDefault(x => x.ID == id);
            return found;
        }

        public List<Student> SortByFullName()
        {
            List<Student> ResultList = new List<Student>(StudentList);



            for (int i = 0; i < ResultList.Count - 1; i++)
            {
                for (int j = 0; j < ResultList.Count - 1 - i; j++)
                {
                    if (ResultList[j].FullName.CompareTo(ResultList[j + 1].FullName) > 0)
                    {
                        Student temp = ResultList[j];
                        ResultList[j] = ResultList[j + 1];
                        ResultList[j + 1] = temp;
                    }
                }
            }

            return ResultList;
        }

        public List<Student> SortByAge()
        {
            List<Student> ResultList = new List<Student>(StudentList);

            for (int i = 0; i < ResultList.Count - 1; i++)
            {
                for (int j = 0; j < ResultList.Count - 1 - i; j++)
                {
                    if (ResultList[j].Age.CompareTo(ResultList[j + 1].Age) > 0)
                    {
                        Student temp = ResultList[j];
                        ResultList[j] = ResultList[j + 1];
                        ResultList[j + 1] = temp;
                    }
                }
            }
            return ResultList;
        }

        public int StudentCount()
        {
            return StudentList.Count;
        }



        public bool EditStudent(int id, string fullname, int age, string email, string phonenumber)
        {
            for (int i = 0; i < StudentList.Count; i++)
            {
                if (StudentList[i].ID == id)
                {
                    StudentList[i].FullName = fullname;
                    StudentList[i].Age = age;
                    StudentList[i].Email = email;
                    StudentList[i].PhoneNumber = phonenumber;
                    //student changed
                    return true;
                }
            }

            //student not found
            return false;


        }
    }
}

