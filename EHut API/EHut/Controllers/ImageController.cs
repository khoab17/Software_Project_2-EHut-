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
    public class ImageController : ApiController
    {
        ImageServices imageServices = new ImageServices();
        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {

            return Ok(imageServices.GetAll());
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(imageServices.Get(id));
        }

        [HttpPost, Route("", Name = "ImagePath")]
        public IHttpActionResult Create(ImageModel model)
        {
            if (ModelState.IsValid)
            {
                imageServices.Insert(model);
                string url = Url.Link("ImagePath", new { id = model.ImageId });
                return Created(url, model);
                
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult Edit([FromBody] ImageModel model,[FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                 model.ImageId = id;
                imageServices.Update(model);
                return Ok("model");
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            imageServices.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
