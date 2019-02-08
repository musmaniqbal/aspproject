using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myproject.Models;
using Newtonsoft.Json;

namespace myproject.Controllers
{
    [Route("api/[controller]")]
    public class assignmentController : ControllerBase
    {
        public readonly MyDbContext db;
        public assignmentController(MyDbContext mdb)
        {
            db = mdb;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            IEnumerable<Assignment> course = from v in db.assignment
                                         select v;
            course.ToList();
            String result = JsonConvert.SerializeObject(course.ToList());
            yield return result;

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Assignment assignment)
        {
            db.assignment.Add(assignment);

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHuaweiItem(long id, Assignment Item)
        {


            db.Entry(Item).State = EntityState.Modified;
            await db.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id) {
            var item = await db.assignment.FindAsync(id);
            if (item == null)
            {
                // return "not found";
            }
            db.assignment.Remove(item);
            await db.SaveChangesAsync();
           // return NoContent();


        }
    }

      
    