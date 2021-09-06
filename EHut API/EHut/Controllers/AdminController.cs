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
    [RoutePrefix("api/admins")]
    public class AdminController : ApiController
    {
        AdminServices adminServices = new AdminServices();

        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
             return Ok(adminServices.GetAll());
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(adminServices.Get(id));
        }

        [HttpPost, Route("", Name = "AdminPath")]
        public IHttpActionResult Create(AdminModel admin)
        {
            if (ModelState.IsValid)
            {
                adminServices.Insert(admin);
                string url = Url.Link("AdminPath", new { id = admin.AdminId });
                return Created(url, admin);
            }
            else
            { 
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult Edit([FromBody] AdminModel admin, [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                admin.AdminId = id;
                adminServices.Update(admin);
                return Ok(admin);
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            adminServices.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
