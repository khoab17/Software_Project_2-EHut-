 
using BLL.Services;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EHut.Controllers
{
    [RoutePrefix("api/Products")]
    public class ProductController : ApiController
    {

        ProductServices productServices = new ProductServices();

        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {

            return Ok(productServices.GetAll());
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(productServices.Get(id));
        }

        [HttpPost, Route("", Name = "ProductPath")]
        public IHttpActionResult Create(Product  model)
        {
            if (ModelState.IsValid)
            {
                productServices.Insert(model);
                string url = Url.Link("ProductPath", new { id = model.BrandId });
                return Created(url, model);
                
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult Edit([FromBody] Product  model, [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                 model.ProductId = id;
                productServices.Update(model);
                return Ok("model");
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            productServices.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
