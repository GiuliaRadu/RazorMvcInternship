using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using RazorMvc.Data;
using RazorMvc.Hubs;
using RazorMvc.Models;
using RazorMvc.Services;

namespace RazorMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IInternshipService intershipService;
        private readonly IHubContext<MessageHub> hubContext;
        private readonly MessageService messageService;

        public HomeController(ILogger<HomeController> logger, IInternshipService intershipService, IHubContext<MessageHub> hubContext, MessageService messageService)
        {
            _logger = logger;
            this.intershipService = intershipService;
            this.hubContext = hubContext;
            this.messageService = messageService;
        }

        public IActionResult Index()
        {
            return View(intershipService.GetMembers());
        }

        public IActionResult Privacy()
        {
            return View(intershipService.GetMembers());
        }

        public IActionResult Chat()
        {
            return View(messageService.GetAllMessages());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
