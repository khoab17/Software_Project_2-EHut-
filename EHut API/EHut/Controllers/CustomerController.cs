
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
    [RoutePrefix("api/Customers")]
    public class CustomerController : ApiController
    {
        SalesRecordServices srServices=new SalesRecordServices();
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

        [HttpGet, Route("GetExisting/{phone}")]
        public IHttpActionResult GetExisting(string phone)
        {
            var data = customerServices.GetAll();
            foreach (var item in data)
            {
                if(item.Phone == phone)
                {
                    return StatusCode(HttpStatusCode.Conflict);
                }
            }
            return Ok();
        }

        [HttpPost, Route("", Name = "CustomerPath")]
        public IHttpActionResult Create(Customer model)
        {
            if (ModelState.IsValid)
            {
                var done=customerServices.Insert(model);
                if(done!=null)
                {
                    string url = Url.Link("CustomerPath", new { id = model.CustomerId });
                    return Created(url, model);
                }
                else
                    return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpGet, Route("GetRecordsByStatus/{id}/{status}")]
        public IHttpActionResult GetRecordsByStatus(int id, string status)
        {
            var products = srServices.GetOrderHistoryByStatus(id, status);
            if (products == null)
            {
                return Ok("No Order with " + status + " Status");
            }
            else
                return Ok(products);
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult Edit([FromBody] Customer model, [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                 model.CustomerId = id;
                var done=customerServices.Update(model);
                if (done != null)
                {
                    return Ok(model);
                }
                else
                    return StatusCode(HttpStatusCode.NoContent);
                
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        } 
        
        
        [HttpPut, Route("ChangePassword/{id}")]
        public IHttpActionResult ChangePassword([FromBody] Customer model, [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                 model.CustomerId = id;
                customerServices.Update(model);

                CredentialServices credentialServices = new CredentialServices();
                Credential credential = credentialServices.GetByPhone(model.Phone);
                credential.Password = model.Password;
                credentialServices.Update(credential);

                return Ok(model);
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
