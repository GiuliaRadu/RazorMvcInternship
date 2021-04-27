using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RazorMvc.Data;
using RazorMvc.Models;

namespace RazorMvc.Services
{
    public class EmployeeDbService
    {
        private readonly InternDbContext db;
        private IConfiguration configuration;

        public EmployeeDbService(InternDbContext db, IConfiguration configuration)
        {
            this.db = db;
            this.configuration = configuration;
        }

        public Employee AddEmployee(Employee employee)
        {
            db.Employees.AddRange(employee);
            db.SaveChanges();
            return employee;
        }

        public IList<Employee> GetEmployees()
        {
            var employees = db.Employees.ToList();
            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            return db.Find<Employee>(id);
        }
    }
}
