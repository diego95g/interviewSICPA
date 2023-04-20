using interviewSICPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace interviewSICPA.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: api/Employee
        public IEnumerable<Employee> Get()
        {
            EmployeeManagement gEmployee = new EmployeeManagement();
            return gEmployee.getEmployee();
        }

        // GET: api/Employee/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employee
        public int Post([FromBody] Employee employee)
        {

            EmployeeManagement gEmployee = new EmployeeManagement();
            int res = gEmployee.addEmployee(employee);

            return res;
        }

        // PUT: api/Employee/5
        public int Put(int id, [FromBody] Employee employee)
        {
            EmployeeManagement gEmployee = new EmployeeManagement();
            int res = gEmployee.updateEmployee(id, employee);

            return res;
        }
    }
}
