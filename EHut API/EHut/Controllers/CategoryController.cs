﻿
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
    [RoutePrefix("api/Categories")]
    public class CategoryController : ApiController
    {
        CategoryServices categoryServices = new CategoryServices();

        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {

            return Ok(categoryServices.GetAll());
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(categoryServices.Get(id));
        }

        [HttpPost, Route("", Name = "CategoryPath")]
        public IHttpActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                categoryServices.Insert(model);
                string url = Url.Link("CategoryPath", new { id = model.CategoryId });
                return Created(url, model);
                
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult Edit([FromBody] Category model , [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                model.CategoryId = id;
                categoryServices.Update(model);
                return Ok("model");
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            categoryServices.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
