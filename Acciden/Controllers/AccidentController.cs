using Accident.BLL.Abstraction.Accident;
using Accident.Models.Models;
using Accident.Models.RequestModel;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Acciden.Controllers
{
    public class AccidentController : Controller
    {
        private readonly IAccidentBLL _manager;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _hostingvironment;
        public AccidentController(IAccidentBLL manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Create()
        {
            var data = await _manager.GetAll();
            int incedenceNo = data.Count() + 1;
            ViewBag.AccidentNo = incedenceNo;
            //ViewBag.Form = "";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AccidentCreateDto model)
        {
            if (ModelState.IsValid)
            {
                if (model.File!= null)
                {
                    string filePath = Path.Combine(_hostingvironment.WebRootPath, "AccidentFile");
                    model.FilePath = await ProcessUploadFileAsync(model.File, filePath);
                }

                var data = _mapper.Map<AccidentModel>(model);
                var result = await _manager.Add(data);
                if (result.Succeeded)
                {
                    return RedirectToAction("List");
                }
            }
            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethod(string name)
        {
            return Json("Method Call");
        }

        public async Task<JsonResult> Create2()
        {
            return Json(false);
        }

        public string List()
        {
            return "List Return";
        }


        private async Task<string> ProcessUploadFileAsync(IFormFile model, string filePath)
        {
            string uniqueFilename = null;
            if (model != null && model.Length > 0)
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                uniqueFilename = Guid.NewGuid().ToString() + '_' + model.FileName;
                string location = Path.Combine(filePath, uniqueFilename);

                using (var stream = System.IO.File.Create(location))
                {
                    await model.CopyToAsync(stream);
                }
            }
            return uniqueFilename;
        }
    }
}
