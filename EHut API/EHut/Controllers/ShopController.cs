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
    [RoutePrefix("api/Shop")]
    public class ShopController : ApiController
    {
        ShopServices shopServices = new ShopServices();
        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {

            return Ok(shopServices.GetAll());
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(shopServices.Get(id));
        }

        [HttpPost, Route("", Name = "ShopPath")]
        public IHttpActionResult Create(ShopModel model)
        {
            if (ModelState.IsValid)
            {
                shopServices.Insert(model);
                string url = Url.Link("ShopPath", new { id = model.ShopId });
                return Created(url, model);
                
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult Edit([FromBody] ShopModel model, [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                 model.ShopId = id;
                shopServices.Update(model);
                return Ok("model");
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            shopServices.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
