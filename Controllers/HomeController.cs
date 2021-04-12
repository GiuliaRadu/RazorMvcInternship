using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RazorMvc.Data;
using RazorMvc.Models;
using RazorMvc.Services;

namespace RazorMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IInternshipService intershipService;
        private readonly InternDbContext db;

        public HomeController(ILogger<HomeController> logger, IInternshipService intershipService, InternDbContext db)
        {
            _logger = logger;
            this.intershipService = intershipService;
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(intershipService.GetMembers());
        }

        public IActionResult Privacy()
        {
            var interns = db.Interns.ToList();
            return View(interns);
        }

        public IActionResult Chat()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpDelete]
        public void RemoveMember(int index)
        {
            var internsList = intershipService.GetMembers();
            Intern intern = internsList.FirstOrDefault(intern => intern.Id == index);

            if (intern == null)
            {
                return;
            }

            intershipService.RemoveMember(intern.Id);
        }

        [HttpGet]
        public Intern AddMember(string memberName)
        {
            Intern intern = new Intern();
            intern.Name = memberName;
            intern.DateOfJoin = DateTime.Now;
            return intershipService.AddMember(intern);
        }

        [HttpPut]
        public void UpdateMember(int index, string name)
        {
            var internsList = intershipService.GetMembers();
            Intern intern = internsList.FirstOrDefault(intern => intern.Id == index);
            if (intern == null)
            {
                return;
            }

            intern.Name = name;
            intern.DateOfJoin = DateTime.Now;
            intershipService.UpdateMember(intern);
        }

    }
}
