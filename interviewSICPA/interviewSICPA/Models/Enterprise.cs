using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace interviewSICPA.Models
{
    public class Enterprise
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get;set; }
        public string address { get; set; }
        public Boolean status { get; set; }

        public Enterprise() { }

        public Enterprise(string name, string phone, string address, Boolean status)
        {
            this.name = name;
            this.phone= phone;
            this.address = address;
            this.status = status;
        }
    }
}