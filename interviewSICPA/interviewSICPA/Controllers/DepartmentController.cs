using interviewSICPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace interviewSICPA.Controllers
{
    public class DepartmentController : ApiController
    {
        // GET: api/Department
        public IEnumerable<Department> Get()
        {
            DepartmentManagement gDepartment = new DepartmentManagement();
            return gDepartment.getDepartment();
        }

        // GET: api/Department/5
        public string Get(int id)
        {
            Console.WriteLine("ingresa a metodo get");
            return "value";
        }

        // POST: api/Department
        public int Post([FromBody] Department department)
        {

            DepartmentManagement gDepartment = new DepartmentManagement();
            int res = gDepartment.addDepartment(department);

            return res;
        }

        // PUT: api/Department/5
        public int Put(int id, [FromBody] Department department)
        {
            DepartmentManagement gDepartment = new DepartmentManagement();
            int res = gDepartment.updateDepartment(id, department);

            return res;
        }
    }
}
