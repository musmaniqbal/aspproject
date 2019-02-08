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
    public class UserAssignmentController : ControllerBase
    {
        public readonly MyDbContext db;
        public UserAssignmentController(MyDbContext mdb)
        {
            db = mdb;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            IEnumerable<UserAssignmet> userassignment = from v in db.userassignment
                                         select v;
            userassignment.ToList();
            String result = JsonConvert.SerializeObject(userassignment.ToList());
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
        public void Post([FromBody]UserAssignmet assig)
        {
            db.userassignment.Add(assig);

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHuaweiItem(long id, UserAssignmet Item)
        {


            db.Entry(Item).State = EntityState.Modified;
            await db.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            var item = await db.userassignment.FindAsync(id);
            if (item == null)
            {
                // return "not found";
            }
            db.userassignment.Remove(item);
            await db.SaveChangesAsync();
            // return NoContent();


        }
    }
}