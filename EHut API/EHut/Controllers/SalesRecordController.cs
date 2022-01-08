﻿ 
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
    [RoutePrefix("api/SalesRecords")]
    public class SalesRecordController : ApiController
    {
        SalesRecordServices srServices = new SalesRecordServices();
        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {

            return Ok(srServices.GetAll());
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(srServices.Get(id));
        }

        [HttpGet, Route("GetNonDeliveredRecors/{id}")]
        public IHttpActionResult GetNonDeliveredRecors(int id)
        {
            var products= srServices.GetNonDeliveredRecors(id);
            if(products == null)
            {
                return Ok("No Pending Order in your Shop");
            }
            else
                return Ok(products);
        }

        //[HttpPost, Route("", Name = "SalesRecordPath")]
        //public IHttpActionResult Create(SalesRecord  model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        srServices.Insert(model);
        //        string url = Url.Link("SalesRecordPath", new { id = model.SalesRecordId });
        //        return Created(url, model);
                
        //    }
        //    else
        //    {
        //        return StatusCode(HttpStatusCode.NoContent);
        //    }
        //}

        //[HttpPut, Route("{id}")]
        //public IHttpActionResult Edit([FromBody] SalesRecord  model, [FromUri] int id)
        //{

        //    if (ModelState.IsValid)
        //    {
        //         model.SalesRecordId = id;
        //        srServices.Update(model);
        //        return Ok("model");
        //    }
        //    else
        //        return StatusCode(HttpStatusCode.NoContent);
        //}

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            srServices.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
