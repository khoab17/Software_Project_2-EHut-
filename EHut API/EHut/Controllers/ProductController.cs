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
    [RoutePrefix("api/Products")]
    //[BasicAuthentication]
    public class ProductController : ApiController
    {

        ProductServices productServices = new ProductServices();

        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {

            return Ok(productServices.GetAll());
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(productServices.Get(id));
        }

        ///
        // Cutoms Requests
        [HttpGet,Route("ProductsByCategory/{id}")]
        public IHttpActionResult GetProductsByCategory(int id)
        {
            return Ok(productServices.ProductsByCategory(id));
        }
        [HttpGet, Route("ProductsByBrand/{id}")]
        public IHttpActionResult GetProductsByBrand(int id)
        {
            return Ok(productServices.ProductsByBrand(id));
        }
        [HttpGet, Route("PriceFilter/{min}/{max}")]
        public IHttpActionResult PriceFilter(int min, int max)
        {
            return Ok(productServices.PriceFilter(min, max));
        }
        ///

        [HttpPost, Route("", Name = "ProductPath")]
        public IHttpActionResult Create(Product  model)
        {
            if (ModelState.IsValid)
            {
                var done=productServices.Insert(model);
                if (done != null)
                {
                    string url = Url.Link("ProductPath", new { id = model.BrandId });
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

        [HttpPut, Route("{id}")]
        public IHttpActionResult Edit([FromBody] Product  model, [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                 model.ProductId = id;
                var done=productServices.Update(model);
                if (done != null)
                {
                    return Ok("model");
                }
                else
                    return StatusCode(HttpStatusCode.NoContent);
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            productServices.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
