using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task.Models;

namespace Task.Controllers
{  

    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {

        // Получение всех сотрудников
        [HttpGet]
        public IActionResult Get()
        {
            using(var db = new AppDbContext())
            {
                var employees = db.Employees.Join
                (
                    db.Companies,
                    e => e.CompanyId,
                    c => c.Id,
                    (e, c) => new
                    {
                        Id = e.Id,
                        FirstName = e.FirstName,
                        SecondName = e.SecondName,
                        MiddleName = e.MiddleName,
                        PhoneNumber = e.PhoneNumber,
                        Company = new
                        {
                            Id = c.Id,
                            CompanyName = c.CompanyName
                        }                  
                    }
                ).ToList();

                return Ok(employees);
            }
        }

        // Добавление нового сторудника
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            using(var db = new AppDbContext())
            {
                db.Companies.Attach(employee.Company);
                db.Employees.Add(employee);
                db.SaveChanges();

                return Ok(employee.Id);
            }
        }

        // Обновление существующего сотрудника
        [HttpPut]
        public IActionResult Put([FromBody] Employee employee)
        {
            using(var db = new AppDbContext())
            {
                db.Update(employee);
                db.SaveChanges();

                return Ok();
            }
        }

        // Удаление сотрудника
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using(var db = new AppDbContext())
            {
                Employee employee = db.Employees.Where(empl => empl.Id == id).FirstOrDefault();

                db.Employees.Remove(employee);
                db.SaveChanges();

                return Ok();
            }
        }
    }
}