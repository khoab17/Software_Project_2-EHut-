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
    [RoutePrefix("api/DeliverymanReview")]
    public class DeliverymanReviewController : ApiController
    {
        DeliverymanReviewServices deliverymanReviewServices = new DeliverymanReviewServices();

        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(deliverymanReviewServices.GetAll());
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            
            return Ok(deliverymanReviewServices.Get(id));
        }

        ////////////////////////////////////

        [HttpPost, Route("", Name = "DeliverymanReviewPath")]
        public IHttpActionResult Create(DeliverymanReviewModel deliverymanReview)
        {
            if (ModelState.IsValid)
            {
                deliverymanReviewServices.Insert(deliverymanReview);
                string url = Url.Link("DeliverymanReviewPath", new { id = deliverymanReview.DeliveryManReviewId });
                return Created(url, deliverymanReview);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult Edit([FromBody] DeliverymanReviewModel deliverymanReview, [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                deliverymanReview.DeliveryManReviewId = id;
                deliverymanReviewServices.Update(deliverymanReview);
                return Ok(deliverymanReview);
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            deliverymanReviewServices.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
