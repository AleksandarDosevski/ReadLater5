using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadLater5.Controllers
{

    public class WidgetController : Controller
    {
        public IActionResult Index(int? userId = null)
        {

            return View();
        }
    }
}
