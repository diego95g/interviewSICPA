using interviewSICPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Web;

namespace interviewSICPA.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class DepartmentController : ApiController
    {

        [System.Web.Http.HttpGet]
        // GET: api/Department
        public List<Department> Get(int id)
        {
            
            DepartmentManagement gDepartment = new DepartmentManagement();
            return gDepartment.getDepartment(id);
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
