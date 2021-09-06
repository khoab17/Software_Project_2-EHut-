using BEL.Model;
using BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EHut.Controllers
{
    [RoutePrefix("api/deliveryman")]
    public class DeliverymanController : ApiController
    {
        DeliverymanServices deliverymanServices = new DeliverymanServices();

        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(deliverymanServices.GetAll());
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            DeliverymanModel deliverymanModel = deliverymanServices.Get(id);
            return Ok(deliverymanModel);
        }

        ////////////////////////////////////

        [HttpPost, Route("", Name = "DeliverymanPath")]
        public IHttpActionResult Create(DeliverymanModel deliveryman)
        {
            if (ModelState.IsValid)
            {
                deliverymanServices.Insert(deliveryman);
                string url = Url.Link("DeliverymanPath", new { id = deliveryman.DeliveryManId });
                return Created(url, deliveryman);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult Edit([FromBody] DeliverymanModel deliveryman, [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                deliveryman.DeliveryManId = id;
                deliverymanServices.Update(deliveryman);
                return Ok(deliveryman);
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            deliverymanServices.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
