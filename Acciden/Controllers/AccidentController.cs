using Accident.Models.RequestModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acciden.Controllers
{
    public class AccidentController : Controller
    {
        public async Task<IActionResult> Ceeate(AccidentCreateDto model)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
    }
}
