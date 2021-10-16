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
    public class BrandController : ApiController
    {
        BrandServices brandServices = new BrandServices();
        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {

            return Ok(brandServices.GetAll());
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(brandServices.Get(id));
        }

        [HttpPost, Route("", Name = "BrandPath")]
        public IHttpActionResult Create(BrandModel model)
        {
            if (ModelState.IsValid)
            {
                brandServices.Insert(model);
                string url = Url.Link("BrandPath", new { id = model.BrandId });
                return Created(url, model);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult Edit([FromBody] BrandModel model, [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                model.BrandId = id;
                brandServices.Update(model);
                return Ok("model");
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            brandServices.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
