using BEL.Model;
using BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EHut.Controllers
{
    [RoutePrefix("api/Admins")]
    public class AdminController : ApiController
    {
        AdminServices adminServices = new AdminServices();

        [Route(""), HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(adminServices.GetAll());
        }
    }
}
