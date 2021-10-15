using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EHut.Controllers
{
    public class CustomerController : ApiController
    {
        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {

            return Ok();
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok();
        }

        [HttpPost, Route("", Name = "/*BankInformationPath*/")]
        public IHttpActionResult Create(/*BankInformationModel model*/)
        {
            if (ModelState.IsValid)
            {

                /* string url = Url.Link("BankInformationPath", new { id = model.BankInformationId });
                 return Created(url, model);*/
                return Created("url", "model");
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult Edit(/*[FromBody] BankInformationModel model,*/ [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                // model.BankInformationId = id;

                return Ok("model");
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
