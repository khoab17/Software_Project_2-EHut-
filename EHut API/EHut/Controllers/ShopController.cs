 
using BLL.Services;
using DAL.Models;
using DAL.View_Models;
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
    [RoutePrefix("api/Shops")]
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
        public IHttpActionResult Create(Shop  model)
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
        public IHttpActionResult Edit([FromBody] Shop  model, [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                 model.ShopId = id;
                shopServices.Update(model);
                return Ok(model);
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }
        
        [HttpPut, Route("ChangePassword/{id}")]
        public IHttpActionResult ChangePassword([FromBody] Shop  model, [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                model.ShopId = id;
                shopServices.Update(model);

                CredentialServices credentialServices = new CredentialServices();
                Credential  credentialModel = credentialServices.GetByPhone(model.Phone);
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
            shopServices.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }


        [HttpPost, Route("ProductOrderAcceptance", Name = "ProductOrderAcceptance")]      // Pending Accepted Rejected Delivered
        public IHttpActionResult ProductOrderAcceptance(OrderAcceptanceViewModel model )
        {
            if (model != null)
            {
                SalesRecordServices salesRecordServices = new SalesRecordServices();
                bool done= salesRecordServices.UpdateSalesRecorStatus(model.SalesRecordId, model.Status);
                if (done)
                {
                    return Ok(model.Status);
                }
                else 
                    return StatusCode(HttpStatusCode.NotModified);
            }
            else
                return StatusCode(HttpStatusCode.BadRequest);
        }
    }
}
