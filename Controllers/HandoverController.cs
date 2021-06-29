using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PSMan.Controllers
{
    public class HandoverController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
