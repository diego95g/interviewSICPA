using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace interviewSICPA.Models
{
    public class Employee
    {
        public int id { get; set; }
        public bool status { get; set; }
        public int age { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public string surname { get; set; }

        public Employee() { }

        public Employee( bool status, int age, string email, string name, string position, string surname)
        {
            this.status = status;
            this.age = age;
            this.email = email;
            this.name = name;
            this.position = position;
            this.surname = surname;
        }
    }
}