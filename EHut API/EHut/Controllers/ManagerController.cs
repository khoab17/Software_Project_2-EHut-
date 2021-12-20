 
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
    [RoutePrefix("api/Managers")]
    public class ManagerController : ApiController
    {
        ManagerServices managerServices = new ManagerServices();

        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            string role= Thread.CurrentPrincipal.Identity.AuthenticationType;
            if (role == "Admin" || role == "Accountant" || role == "HR")
            {
                return Ok(managerServices.GetAll());
            }
            else
                return StatusCode(HttpStatusCode.Unauthorized);

            

        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            string role = Thread.CurrentPrincipal.Identity.AuthenticationType;
            if (role == "Admin" || role == "Accountant" || role == "HR")
            {
                return Ok(managerServices.Get(id));
            }
            else
                return StatusCode(HttpStatusCode.Unauthorized);

           
        }

        [HttpPost, Route("", Name = "ManagerPath")]
        public IHttpActionResult Create(Manager  model)
        {

            string role = Thread.CurrentPrincipal.Identity.AuthenticationType;
            if (role == "Admin" || role == "Accountant" || role == "HR")
            {
                if (ModelState.IsValid)
                {
                    var temp = managerServices.Insert(model);
                    string url = Url.Link("ManagerPath", new { id = model.ManagerId });
                    return Created(url, temp);

                }
                else
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
            }
            else
                return StatusCode(HttpStatusCode.Unauthorized);
            
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult Edit([FromBody] Manager model, [FromUri] int id)
        {

            string role = Thread.CurrentPrincipal.Identity.AuthenticationType;
            if (role == "Admin" || role == "Accountant" || role == "HR")
            {
                if (ModelState.IsValid)
                {
                    model.ManagerId = id;
                    managerServices.Update(model);
                    return Ok(model);
                }
                else
                    return StatusCode(HttpStatusCode.NoContent);
            }
            else
                return StatusCode(HttpStatusCode.Unauthorized);

            
        }
        
        [HttpPut, Route("ChangePassword/{id}")]
        public IHttpActionResult ChangePassword([FromBody] Manager  model, [FromUri] int id)
        {

            string role = Thread.CurrentPrincipal.Identity.AuthenticationType;
            if (role == "Admin" || role == "Accountant" || role == "HR")
            {
                if (ModelState.IsValid)
                {
                    model.ManagerId = id;
                    managerServices.Update(model);

                    CredentialServices credentialServices = new CredentialServices();
                    Credential credentialModel = credentialServices.GetByPhone(model.Phone);
                    credentialModel.Password = model.Password;
                    credentialServices.Update(credentialModel);

                    return Ok(model);
                }
                else
                    return StatusCode(HttpStatusCode.NoContent);
            }
            else
                return StatusCode(HttpStatusCode.Unauthorized);

            
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            string role = Thread.CurrentPrincipal.Identity.AuthenticationType;
            if (role == "Admin" || role == "Accountant" || role == "HR")
            {
                managerServices.Delete(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
                return StatusCode(HttpStatusCode.Unauthorized);

           
        }
    }
}
