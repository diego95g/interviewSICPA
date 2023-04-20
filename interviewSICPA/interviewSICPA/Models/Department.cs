using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace interviewSICPA.Models
{
    public class Department
    {  
        public int idEnterprise { get; set; }
        public int id { get; set; }
        public bool status { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string phone { get; set; }

        public Department() { }

        public Department(bool status, string description, string name, string phone)
        {
            this.status = status;
            this.description = description;
            this.name = name;
            this.phone = phone;
        }
    }
}