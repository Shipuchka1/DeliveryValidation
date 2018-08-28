using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Delivery.Models
{
    public class Delivery
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public Sender Sender { get; set; }
        public Cargo Cargo { get; set; }
    }
}