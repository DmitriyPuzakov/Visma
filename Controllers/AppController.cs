using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Visma.Models;

namespace Visma.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            var bank = new BankAccount("123456-785");
            bank.GetLongFormat();
            return View();
        }

        [HttpPost]
        public string Process(string shortNumber) {
            return "ok";
        }
    }
}
