using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SePoupeMVC.Controllers.Questionario
{
    [Authorize]
    public class QuestionarioController : Controller
    {
        public IActionResult Questoes()
        {
            return View();
        }

        public IActionResult Consulta()
        {
            try
            {
                //getting user email
                var email = User.Identity.Name;

                //getting user informations using email
                //var user = _userRepository.Get(email);

                //getting user tasks
                //TempData["Tasks"] = _taskRepository.GetByUser(user.UserID);

            }
            catch (Exception e)
            {

                TempData["Messege"] = "Error" + e.Message;
            }
            return View();
        }
    }
}
