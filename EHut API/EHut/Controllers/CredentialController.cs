
using BLL.Services;
using DAL.Models;
using DAL.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EHut.Controllers
{
    [RoutePrefix("api/Credentials")]
    public class CredentialController : ApiController
    {
        CredentialServices credentialServices = new CredentialServices();

        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {

            return Ok(credentialServices.GetAll());
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(credentialServices.Get(id));
        }
        [HttpPost, Route("Login")]
        public IHttpActionResult Login(LoginViewModel viewModel)
        {
            if(viewModel.Password  ==null || viewModel.Phone==null)
            {
                return StatusCode(HttpStatusCode.NotAcceptable);
            }
            var temp = credentialServices.GetByPhone(viewModel.Phone);
            if(temp!=null)
            {
                if (temp.Phone == viewModel.Phone && temp.Password == viewModel.Password)
                {
                    return Ok(temp);
                }
                else
                {
                    return StatusCode(HttpStatusCode.Unauthorized);
                }
            }
            else
            {
                return StatusCode(HttpStatusCode.Unauthorized);
            }
            
        }

        [HttpPost, Route("", Name = "CredentialPath")]
        public IHttpActionResult Create(Credential model)
        {
            if (ModelState.IsValid)
            {
                credentialServices.Insert(model);
                string url = Url.Link("CredentialPath", new { id = model.CredentialId });
                return Created(url, model);
                
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult Edit([FromBody] Credential model, [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                model.CredentialId = id;
                credentialServices.Update(model);
                return Ok("model");
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            credentialServices.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
