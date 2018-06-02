using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task.Models;

namespace Task.Controllers
{  

    [Route("api/[controller]")]
    public class CompanyController : Controller
    {

        // Получение всех компаний
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            using(var db = new AppDbContext())
            {
                return db.Companies.ToList();
            }
        }

        // Добавление новой компании
        [HttpPost]
        public IActionResult Post([FromBody] Company company)
        {
            using(var db = new AppDbContext())
            {
                db.Companies.Add(company);
                db.SaveChanges();

                return Ok(company.Id);
            }
        }

        // Обновление существующей компании
        [HttpPut]
        public IActionResult Put([FromBody] Company company)
        {
            using(var db = new AppDbContext())
            {                
                db.Update(company);
                db.SaveChanges();

                return Ok();
            }
        }

        // Удаление компании
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using(var db = new AppDbContext())
            {
                Company company = db.Companies.Where(comp => comp.Id == id).FirstOrDefault();

                db.Companies.Remove(company);
                db.SaveChanges();

                return Ok();
            }
        }

    }
}