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
            return View();
        }

        [HttpPost]
        public string Process(string shortNumber)
        {
            var response = new ProcessingResponse();

            try
            {
                var bank = new BankAccount(shortNumber);
                var longNumber = bank.GetLongFormat();
                var checkDigitValid = bank.IsCheckDigitCorrect();

                response.LongNumber = longNumber;
                response.CheckDigitValid = checkDigitValid;
                response.Status = "ok";
            }
            catch (Exception ex)
            {
                response.Status = ex.Message;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(response);
        }
    }
}
