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
    //[BasicAuthentication]
    [RoutePrefix("api/Checkout")]
    public class CheckoutController : ApiController
    {
        private CheckoutServices services=new CheckoutServices();
        private string role;

        [HttpPost, Route("",Name = "CheckoutPath")]
        public IHttpActionResult ConformCheckout(List<CheckoutViewModel> model)
        {
            role = Thread.CurrentPrincipal.Identity.AuthenticationType;
            role = "Customer";                                              /////change
            if (role == "Customer")
            {
                if (model.Count > 0)
                {
                    Order order = services.Insert(model);
                    string url = Url.Link("CheckoutPath", new { id = -1 });
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
