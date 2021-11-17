
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
    [RoutePrefix("api/Deliverymen")]
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
            Deliveryman deliverymanModel = deliverymanServices.Get(id);
            return Ok(deliverymanModel);
        }

        ////////////////////////////////////

        [HttpPost, Route("", Name = "DeliverymanPath")]
        public IHttpActionResult Create(Deliveryman deliveryman)
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
        public IHttpActionResult Edit([FromBody] Deliveryman model, [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                model.DeliveryManId = id;
                deliverymanServices.Update(model);
                return Ok(model);
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }
        [HttpPut, Route("ChangePassword/{id}")]
        public IHttpActionResult ChangePassword([FromBody] Deliveryman model, [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                model.DeliveryManId = id;
                deliverymanServices.Update(model);

                CredentialServices credentialServices = new CredentialServices();
                Credential credentialModel = credentialServices.GetByPhone(model.Phone);
                credentialModel.Password = model.Password;
                credentialServices.Update(credentialModel);

                return Ok(model);
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
