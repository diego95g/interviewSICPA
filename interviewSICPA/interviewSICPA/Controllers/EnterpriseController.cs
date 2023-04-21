using interviewSICPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace interviewSICPA.Controllers
{
    
    public class EnterpriseController : ApiController
    {
        // GET: api/Enterprise
        public IEnumerable<Enterprise> Get()
        {
            EnterpriseManagement gEnterprise = new EnterpriseManagement();
            return gEnterprise.getEnterprise();
        }

        // GET: api/Enterprise/5
        [System.Web.Http.HttpGet]
        public ActionResult Get(int id)
        {
            Console.WriteLine("llega al metodo: ");
            return null;
        }

        // POST: api/Enterprise
        public int Post([FromBody] Enterprise enterprise)
        {

            EnterpriseManagement gEnterprise = new EnterpriseManagement();
            int res = gEnterprise.addEnterprise(enterprise);

            return res;
        }

        // PUT: api/Enterprise/5
        public int Put(int id, [FromBody] Enterprise enterprise)
        {
            EnterpriseManagement gEnterprise = new EnterpriseManagement();
            int res = gEnterprise.updateEnterprise(id, enterprise);

            return res;
        }

    }
}
