using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RazorMvc.Models;

namespace RazorMvc.Data
{
    public static class SeedData
    {
        public static void Initialize(InternDbContext context)
        {
            context.Database.Migrate();
            if (context.Interns.Any())
            {
                return;   // DB has been seeded
            }

            var interns = new Intern[]
            {
                new Intern { Name = "Borys", DateOfJoin = DateTime.Parse("2021-04-01") },
                new Intern { Name = "Liova", DateOfJoin = DateTime.Parse("2021-04-01") },
                new Intern { Name = "Orest", DateOfJoin = DateTime.Parse("2021-03-31") },
            };

            context.Interns.AddRange(interns);
            context.SaveChanges();
        }
    }
}
