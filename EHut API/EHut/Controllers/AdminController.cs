
using BLL.Services;
using DAL.Models;
using EHut.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;



namespace EHut.Controllers
{
    [BasicAuthentication]
    [RoutePrefix("api/Admins")]
    public class AdminController : ApiController
    {
        private string role;

        AdminServices adminServices = new AdminServices();
        CredentialServices credentialServices = new CredentialServices();
        
        [HttpGet, Route("")]
        //[Authorize]
        public IHttpActionResult GetAll()
        {
            role = Thread.CurrentPrincipal.Identity.AuthenticationType;
            if (role == "Admin")
                return Ok(adminServices.GetAll());
            else
                return StatusCode(HttpStatusCode.Unauthorized);
           


        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            role = Thread.CurrentPrincipal.Identity.AuthenticationType;
            if (role == "Admin")
                return Ok(adminServices.Get(id));
            else
                return StatusCode(HttpStatusCode.Unauthorized);


            

        }

        [HttpPost, Route("", Name = "AdminPath")]
        public IHttpActionResult Create(Admin admin)
        {
            role = Thread.CurrentPrincipal.Identity.AuthenticationType;
            if (role == "Admin")
            {
                if (ModelState.IsValid)
                {
                    //insert in Admin table
                   var done= adminServices.Insert(admin);
                    if(done != null)
                    {
                        string url = Url.Link("AdminPath", new { id = admin.AdminId });
                        return Created(url, admin);
                    }
                    else 
                        return StatusCode(HttpStatusCode.NoContent);
                }
                else
                {
                    return StatusCode(HttpStatusCode.NoContent); /// if No Content then User tried to insert duplicate email or phone.
                }
            }

            else
                return StatusCode(HttpStatusCode.Unauthorized);
            
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult Edit([FromBody] Admin model, [FromUri] int id)
        {

            role = Thread.CurrentPrincipal.Identity.AuthenticationType;
            if (role == "Admin")
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

            else
                 return StatusCode(HttpStatusCode.Unauthorized);

           
        }

        [HttpPut, Route("ChangePassword/{id}")]
        public IHttpActionResult ChangePassword([FromBody] Admin model, [FromUri] int id)
        {

            role = Thread.CurrentPrincipal.Identity.AuthenticationType;
            if (role == "Admin")
            {
                if (ModelState.IsValid)
                {
                    model.AdminId = id;
                    var done=adminServices.Update(model);

                    if (done != null)
                    {
                        Credential credential = credentialServices.GetByPhone(model.Phone);
                        credential.Password = model.Password;
                        credentialServices.Update(credential);

                        return Ok(model);
                    }
                    else
                        return StatusCode(HttpStatusCode.NoContent);
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

            role = Thread.CurrentPrincipal.Identity.AuthenticationType;
            if (role == "Admin")
            {
                adminServices.Delete(id);
                return StatusCode(HttpStatusCode.NoContent);
            }

            else
                return StatusCode(HttpStatusCode.Unauthorized);
            
        }
    }
}
