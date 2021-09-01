using BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EHut.Controllers
{
    [RoutePrefix("api/Products")]
    public class ProductController : ApiController
    {

        ProductServices productServices = new ProductServices();

        [Route(""), HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(productServices.GetAll());
        }
    }
}
