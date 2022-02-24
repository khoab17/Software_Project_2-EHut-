 
using BLL.Services;
using DAL.Models;
using EHut.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EHut.Controllers
{
    [BasicAuthentication]
    [RoutePrefix("api/Orders")]
    public class OrderController : ApiController
    {
        OrderServices orderServices = new OrderServices();
        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {

            return Ok(orderServices.GetAll());
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(orderServices.Get(id));
        }

        [HttpPost, Route("", Name = "OrderPath")]
        public IHttpActionResult Create(Order  model)
        {
            if (ModelState.IsValid)
            {
                orderServices.Insert(model);
                string url = Url.Link("OrderPath", new { id = model.OrderId });
                return Created(url, model);
                
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult Edit([FromBody] Order  model, [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                 model.OrderId = id;
                orderServices.Update(model);
                return Ok("model");
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            orderServices.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
