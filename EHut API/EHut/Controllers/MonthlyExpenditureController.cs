 
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
    [RoutePrefix("api/MonthlyExpenditures")]
    public class MonthlyExpenditureController : ApiController
    {
        MonthlyExpenditureServices meServices = new MonthlyExpenditureServices();
        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {

            return Ok(meServices.GetAll());
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(meServices.Get(id));
        }

        [HttpPost, Route("", Name = "MonthlyExpenditurePath")]
        public IHttpActionResult Create(MonthlyExpenditure  model)
        {
            if (ModelState.IsValid)
            {
                meServices.Insert(model);
                string url = Url.Link("MonthlyExpenditurePath", new { id = model.MonthlyExpenditureId });
                return Created(url, model);
             
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult Edit([FromBody] MonthlyExpenditure  model, [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                 model.MonthlyExpenditureId = id;
                meServices.Update(model);
                return Ok("model");
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            meServices.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
