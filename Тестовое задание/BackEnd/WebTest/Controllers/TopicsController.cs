using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTest.Models;
using Microsoft.EntityFrameworkCore;

namespace WebTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        ContactContext db;
        public TopicsController(ContactContext context)
        {
            db = context;
            if (!db.Topics.Any())
            {
                Topic t1 = new Topic { TextTopic = "Техподдержка" };
                Topic t2 = new Topic { TextTopic = "Продажи" };
                Topic t3 = new Topic { TextTopic = "Другое" };
                Topic t4 = new Topic { TextTopic = "Еще один пункт" };
                db.Topics.AddRange(new List<Topic> { t1, t2, t3, t4 });
                db.SaveChanges();
            }
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Topic>>> Get()
        {
            return await db.Topics.ToListAsync();
        }

        // GET api/Topics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Topic>> Get(int id)
        {
            Topic Topic = await db.Topics.FirstOrDefaultAsync(x => x.Id == id);
            if (Topic == null)
                return NotFound();
            return new ObjectResult(Topic);
        }

        // POST api/Topics
        [HttpPost]
        public async Task<ActionResult<Topic>> Post(Topic Topic)
        {
            if (Topic == null)
            {
                return BadRequest();
            }

            db.Topics.Add(Topic);
            await db.SaveChangesAsync();
            return Ok(Topic);
        }

        // PUT api/Topics/
        [HttpPut]
        public async Task<ActionResult<Topic>> Put(Topic Topic)
        {
            if (Topic == null)
            {
                return BadRequest();
            }
            if (!db.Topics.Any(x => x.Id == Topic.Id))
            {
                return NotFound();
            }

            db.Update(Topic);
            await db.SaveChangesAsync();
            return Ok(Topic);
        }

        // DELETE api/Topics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Topic>> Delete(int id)
        {
            Topic Topic = db.Topics.FirstOrDefault(x => x.Id == id);
            if (Topic == null)
            {
                return NotFound();
            }
            db.Topics.Remove(Topic);
            await db.SaveChangesAsync();
            return Ok(Topic);
        }
    }
}
