using BEL.Model;
using BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EHut.Controllers
{
    [RoutePrefix("api/Deliveryman")]
    public class DeliverymanController : ApiController
    {
        DeliverymanServices deliverymanServices = new DeliverymanServices();

        [Route(""), HttpGet]
        public IHttpActionResult Get(int id)
        {
            DeliverymanModel deliverymanModel = deliverymanServices.Get(id);
            return Ok(deliverymanModel);
        }
    }
}
