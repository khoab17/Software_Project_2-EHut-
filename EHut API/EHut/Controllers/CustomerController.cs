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
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        CustomerServices customerServices = new CustomerServices();

        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {

            return Ok(customerServices.GetAll());
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(customerServices.Get(id));
        }

        [HttpPost, Route("", Name = "CustomerPath")]
        public IHttpActionResult Create(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                customerServices.Insert(model);
                string url = Url.Link("CustomerPath", new { id = model.CustomerId });
                return Created(url, model);
                
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult Edit([FromBody] CustomerModel model, [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                 model.CustomerId = id;
                customerServices.Update(model);
                return Ok("model");
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            customerServices.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
