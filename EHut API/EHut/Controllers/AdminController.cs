
using BLL.Services;
using DAL.Models;
using EHut.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace EHut.Controllers
{
    [BasicAuthentication]
    [RoutePrefix("api/Admins")]
    public class AdminController : ApiController
    {
        AdminServices adminServices = new AdminServices();
        CredentialServices credentialServices = new CredentialServices();
        
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
        public IHttpActionResult Create(Admin admin)
        {
            if (ModelState.IsValid)
            {
                //insert in Admin table
                adminServices.Insert(admin);
                string url = Url.Link("AdminPath", new { id = admin.AdminId });
                return Created(url, admin);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent); /// if No Content then User tried to insert duplicate email or phone.
            }
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult Edit([FromBody] Admin model, [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                model.AdminId = id;
                adminServices.Update(model);
                return Ok(model);
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPut, Route("ChangePassword/{id}")]
        public IHttpActionResult ChangePassword([FromBody] Admin model, [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                model.AdminId = id;
                adminServices.Update(model);

                Credential credential = credentialServices.GetByPhone(model.Phone);
                credential.Password = model.Password;
                credentialServices.Update(credential);
                
                return Ok(model);
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
