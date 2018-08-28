using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Delivery.Controllers
{
    public class DeliveryController : Controller
    {
        // GET: Delivery
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Delivery.Models.Delivery delivery)
        {
            if (ModelState.IsValid)
                return Redirect("~/Content/Success.html");
            else return View();
        }
    }
}