using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaDay.Models;

namespace SpaDay.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("/User")]
        public IActionResult SubmitAddUserForm(User newUser, string verify)
        {
            // add form submission handling code here
            
            ViewBag.newUser = newUser;
            ViewBag.error = "";
            
            if (newUser.Password == verify)
            {
                ViewBag.username = newUser.Username;
                return View("Index");
            }
            else
            {
                ViewBag.error = $"Passwords do not match.";
                ViewBag.email = newUser.Email;
                ViewBag.username = newUser.Username;
                return View("Add");
            }
        }
    }
}
