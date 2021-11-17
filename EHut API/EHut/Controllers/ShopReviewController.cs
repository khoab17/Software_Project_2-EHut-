 
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
    [RoutePrefix("api/ShopReviews")]
    public class ShopReviewController : ApiController
    {
        ShopReviewServices shopReviewServices = new ShopReviewServices();
        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {

            return Ok(shopReviewServices.GetAll());
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(shopReviewServices.Get(id));
        }

        [HttpPost, Route("", Name = "ShopReviewPath")]
        public IHttpActionResult Create(ShopReview  model)
        {
            if (ModelState.IsValid)
            {
                shopReviewServices.Insert(model);
                string url = Url.Link("ShopReviewPath", new { id = model.ShopReviewId });
                return Created(url, model);

            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult Edit([FromBody] ShopReview  model, [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                model.ShopReviewId = id;
                shopReviewServices.Update(model);
                return Ok("model");
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            shopReviewServices.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
