using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem
{
    //Simple data model for a student
    public class Student
    {

        public int ID { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegisterDate { get; set; }

        public Student(int id, string fullname, int age, string email, string phonenumber)
        {
            this.ID = id;
            this.FullName = fullname;
            this.Age = age;
            this.Email = email;
            this.PhoneNumber = phonenumber;
            this.RegisterDate = DateTime.Now;
        }

    }
}
