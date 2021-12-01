using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaAiMVC.Controllers.Manual
{
    [Authorize]
    public class ManualController : Controller
    {
        public IActionResult Manual()
        {
            return View();
        }
    }
}
