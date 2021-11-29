using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderInFrontEnd2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SendOrderData()
        {
            bool status = false;
            string message = "";
            if(ModelState.IsValid)
            {
                //call API here and post order data
                //check response recieved is ok
                status = true;
                message = "Order Placed";
            }
            else
            {
                message = "Order failed! Please try again";
            }


            return new JsonResult { Data = new {status = status, message = message} };
        }
    }
}