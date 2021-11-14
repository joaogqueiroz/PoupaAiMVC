using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SePoupeMVC.Controllers.Manual
{
    [Authorize]
    public class ManualController : Controller
    {
        //private readonly IRepository _taskRepository;
        //private readonly IRepository _userRepository;

        public IActionResult Manual()
        {
            return View();
        }/*
        [HttpPost]
        public IActionResult Criar(TaskRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //getting user email
                    var email = User.Identity.Name;

                    //getting user data
                    var user = _userRepository.Get(email);

                    //creating task
                    var task = new Task();
                    task.Name = model.Name;
                    task.Date = DateTime.Parse(model.Date);
                    task.Hour = TimeSpan.Parse(model.Hour);
                    task.Description = model.Description;
                    task.Priority = model.Priority.ToString();
                    task.UserID = user.UserID; //Foreign key

                    _taskRepository.Create(task);
                    TempData["Message"] = $"Task {task.Name}, was created com sucesso";
                    ModelState.Clear();
                }
                catch (Exception e)
                {

                    TempData["Message"] = "Erro: " + e.Message;
                }
            }
            return View();
        }*/
    }
}
