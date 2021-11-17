 
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
    [RoutePrefix("api/ProductDistributions")]
    public class ProductDistributionController : ApiController
    {
        ProductDistributionServices pdServices = new ProductDistributionServices();
        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {

            return Ok(pdServices.GetAll());
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(pdServices.Get(id));
        }

        [HttpPost, Route("", Name = "ProductDistributionPath")]
        public IHttpActionResult Create(ProductDistribution  model)
        {
            if (ModelState.IsValid)
            {
                pdServices.Insert(model);
                string url = Url.Link("ProductDistributionPath", new { id = model.ProductDistributionId });
                return Created(url, model);
                
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult Edit([FromBody] ProductDistribution  model, [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                 model.ProductDistributionId = id;
                pdServices.Update(model);
                return Ok("model");
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            pdServices.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
