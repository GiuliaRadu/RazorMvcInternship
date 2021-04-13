using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RazorMvc.Hubs;
using RazorMvc.Models;
using RazorMvc.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RazorMvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternshipController : ControllerBase
    {
        private readonly IInternshipService intershipService;
        private readonly IHubContext<MessageHub> hubContext;

        public InternshipController(IInternshipService intershipService, IHubContext<MessageHub> hubContext)
        {
            this.intershipService = intershipService;
            this.hubContext = hubContext;
        }

        // GET: api/<InternshipController>
        [HttpGet]
        public IEnumerable<Intern> Get()
        {
            return intershipService.GetMembers();
        }

        // GET api/<InternshipController>/5
        [HttpGet("{id}")]
        public Intern Get(int id)
        {
            return intershipService.GetMemberById(id);
        }

        // POST api/<InternshipController>
        [HttpPost]
        public void Post([FromBody] Intern intern)
        {
            intern.DateOfJoin = DateTime.Now;
            var newMember = intershipService.AddMember(intern);
            hubContext.Clients.All.SendAsync("AddMember", newMember.Name, newMember.Id);
        }

        // PUT api/<InternshipController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Intern intern)
        {
            intern.Id = id;
            intershipService.UpdateMember(intern);
        }

        // DELETE api/<InternshipController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            intershipService.RemoveMember(id);
        }
    }
}
