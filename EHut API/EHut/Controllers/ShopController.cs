 
using BLL.Services;
using DAL.Models;
using DAL.View_Models;
using EHut.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EHut.Controllers
{
    //[BasicAuthentication]
    [RoutePrefix("api/Shops")]
    public class ShopController : ApiController
    {
        ShopServices shopServices = new ShopServices();
        CredentialServices credentialServices = new CredentialServices();
        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {

            return Ok(shopServices.GetAll());
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(shopServices.Get(id));
        }

        [HttpGet, Route("GetExisting/{phone}")]
        public IHttpActionResult GetExisting(string phone)
        {
            if(phone !=null || phone.Length!=11)
            {
                var data = credentialServices.GetAll();
                foreach (var item in data)
                {
                    if (item.Phone == phone)
                    {
                        return Ok("old");
                    }
                }
                return Ok("new");
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost, Route("", Name = "ShopPath")]
        public IHttpActionResult Create(Shop  model)
        {
            if (ModelState.IsValid)
            {

                var done=shopServices.Insert(model);
                if (done != null)
                {
                    string url = Url.Link("ShopPath", new { id = model.ShopId });

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
        public IHttpActionResult Edit([FromBody] Shop  model, [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                 model.ShopId = id;
                var done=shopServices.Update(model);
                if (done != null)
                {
                    return Ok(model);
                }
                else
                    return StatusCode(HttpStatusCode.NoContent);
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }
        
        [HttpPut, Route("ChangePassword/{id}")]
        public IHttpActionResult ChangePassword([FromBody] Shop  model, [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                model.ShopId = id;
                shopServices.Update(model);

                CredentialServices credentialServices = new CredentialServices();
                Credential  credentialModel = credentialServices.GetByPhone(model.Phone);
                credentialModel.Password = model.Password;
                credentialServices.Update(credentialModel);

                return Ok(model);
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            shopServices.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }


        [HttpPost, Route("ProductOrderAcceptance", Name = "ProductOrderAcceptance")]      // Pending Accepted Rejected Delivered
        public IHttpActionResult ProductOrderAcceptance(OrderAcceptanceViewModel model )
        {
            if (model != null)
            {
                SalesRecordServices salesRecordServices = new SalesRecordServices();
                bool done= salesRecordServices.UpdateSalesRecorStatus(model.SalesRecordId, model.Status);
                if (done)
                {
                    return Ok(model.Status);
                }
                else 
                    return StatusCode(HttpStatusCode.NotModified);
            }
            else
                return StatusCode(HttpStatusCode.BadRequest);
        }


        [HttpGet, Route("yearlySalesReports")]
        public IHttpActionResult YearlySalesReport()
        {

            List<SumGroupByModel> yearlySalesInfo = shopServices.GetYearlySalesData();
            return Ok(yearlySalesInfo);
        }

        [HttpGet, Route("monthlySalesForYearReports/{year}")]
        public IHttpActionResult MonthlySalesForYearReport(int year)
        {
        
            List<SumGroupByModel> monthlyInfoForYear = shopServices.GetMonthlySalesDataForAYear(year);
            monthlyInfoForYear = shopServices.GetMonthlySalesDataForAYear(year);

            List<BarChartModel> chart = new List<BarChartModel>();

            string[] months = { "Jan", "Feb", "March", "April", "May", "June", "July", "Aug", "Sep", "Oct", "Nov", "Dec" };

            int i, j;
            int count = monthlyInfoForYear.Count();

            //Adding All the Months and Giving the Sum Amount Zero to the chart
            for (i = 0; i < 12; i++)
            {
                BarChartModel barChartModel = new BarChartModel(months[i], 0);
                chart.Add(barChartModel);
            }

            //Now Assigning Value to the months where the Sum Amount exists for that particular month
            for (i = 0; i < count; i++)
            {
                chart[monthlyInfoForYear[i].Id - 1].Y = monthlyInfoForYear[i].Column1;
            }
            return Ok(chart);
        }

    }
}
