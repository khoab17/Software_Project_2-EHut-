using BEL.Model;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EHut.Controllers
{
    [RoutePrefix("api/Manager")]
    public class ManagerController : ApiController
    {
        ManagerServices managerServices = new ManagerServices();

        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {

            return Ok(managerServices.GetAll());
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(managerServices.Get(id));
        }

        [HttpPost, Route("", Name = "ManagerPath")]
        public IHttpActionResult Create(ManagerModel model)
        {
            if (ModelState.IsValid)
            {
                managerServices.Insert(model);
                string url = Url.Link("ManagerPath", new { id = model.ManagerId });
                return Created(url, model);
                
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult Edit([FromBody] ManagerModel model, [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                 model.ManagerId = id;
                managerServices.Update(model);
                return Ok("model");
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            managerServices.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
