using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SePoupeMVC.Controllers.Questoes
{
    [Authorize]
    public class QuestoesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
