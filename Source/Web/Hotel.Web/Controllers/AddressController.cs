using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Web.Controllers
{
    [RoutePrefix("address")]
    public class AddressController : BaseController
    {
        [Route]
        public ActionResult Index()
        {
            return View();
        }
    }
}