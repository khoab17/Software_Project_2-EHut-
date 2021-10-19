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
    [RoutePrefix("api/Category")]
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
        public IHttpActionResult Create(CategoryModel model)
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
        public IHttpActionResult Edit([FromBody] CategoryModel model , [FromUri] int id)
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
