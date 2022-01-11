using BLL.Services;
using DAL.Models;
using DAL.View_Models;
using EHut.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace EHut.Controllers
{
    [BasicAuthentication]
    [RoutePrefix("api/Checkout")]
    public class CheckoutController : ApiController
    {
        private CheckoutServices services=new CheckoutServices();
        private string role;
        [HttpPost, Route("",Name = "CheckoutPath")]
        public IHttpActionResult ConformCheckout(CheckoutViewModel model)
        {
            role = Thread.CurrentPrincipal.Identity.AuthenticationType;
            if(role == "Customer")
            {
                if (model.CustomerId >= 1 && model.ShopId >= 1 && model.Products != null)
                {
                    Order order = services.Insert(model);
                    string url = Url.Link("CheckoutPath", new { id = order.OrderId });
                    return Ok();
                }
                else
                    return BadRequest();
            }
            else
                return StatusCode(HttpStatusCode.Unauthorized);
            
        }
        

    }
}
