using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RazorMvc.Models;

namespace RazorMvc.Data
{
    public static class SeedData
    {
        private static Location defaultLocation;

        public static void Initialize(InternDbContext context)
        {
            context.Database.Migrate();
            if (!context.Locations.Any())
            {
                var locations = new Location[]
                {
                    defaultLocation = new Location { Name = "Kyiv", NativeName = "Київ", Longitude = 30.5167, Latitude = 50.4333, },
                    new Location { Name = "Brasov", NativeName = "Braşov", Longitude = 25.3333, Latitude = 45.75, },
                };
                context.Locations.AddRange(locations);
                context.SaveChanges();
            }

            if (!context.Employees.Any())
            {
                var employees = new Employee[]
                {
                     new Employee { FirstName = "Borys", LastName = "Lebeda", Email = "borys@gmail.com", Gender = "Male", Birthdate = DateTime.Parse("2021-04-01"), Picture = "poza" },
                };
                context.Employees.AddRange(employees);
                context.SaveChanges();
            }

            if (!context.Interns.Any())
            {
                var interns = new Intern[]
                {
                    new Intern { Name = "Borys", DateOfJoin = DateTime.Parse("2021-04-01"), Location = defaultLocation },
                    new Intern { Name = "Liova", DateOfJoin = DateTime.Parse("2021-04-01"), Location = defaultLocation},
                    new Intern { Name = "Orest", DateOfJoin = DateTime.Parse("2021-03-31"), Location = defaultLocation },
                };

                context.Interns.AddRange(interns);
                context.SaveChanges();
            }

            if (!context.Projects.Any())
            {
                var projects = new Project[]
                {
                    new Project
                    {
                        Name = "Build a bot",
                        StartDate = DateTime.Parse("2020-09-01"),
                        Interns = context.Interns.ToList(),
                        Url = "https://gitlab.com/borysl/build-a-bot",
                        IsPublished = false,
                    },
                    new Project
                    {
                        Name = "Multiplication table",
                        StartDate = DateTime.Parse("2020-02-01"),
                        Interns = new Intern[]
                        {
                            context.Interns.Single(_ => _.Name == "Liova"),
                        },
                        Url = "https://mtab.herokuapp.com/",
                        IsPublished = true,
                    },
                };

                context.Projects.AddRange(projects);
                context.SaveChanges();
            }
        }
    }
}
