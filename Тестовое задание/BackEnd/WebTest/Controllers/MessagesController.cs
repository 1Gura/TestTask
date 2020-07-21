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
    public class MessagesController : ControllerBase
    {
        ContactContext db;
        public MessagesController(ContactContext context)
        {
            db = context;
            if (!db.Messages.Any())
            {
               
            }
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> Get()
        {
            return await db.Messages.ToListAsync();
        }

        // GET api/Messages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> Get(int id)
        {
            Message Message = await db.Messages.FirstOrDefaultAsync(x => x.Id == id);
            if (Message == null)
                return NotFound();
            return new ObjectResult(Message);
        }

        // POST api/Messages
        [HttpPost]
        public async Task<ActionResult<Message>> Post(Message Message)
        {
            if (Message == null)
            {
                return BadRequest();
            }

            db.Messages.Add(Message);
            await db.SaveChangesAsync();
            return Ok(Message);
        }

        // PUT api/Messages/
        [HttpPut]
        public async Task<ActionResult<Message>> Put(Message Message)
        {
            if (Message == null)
            {
                return BadRequest();
            }
            if (!db.Messages.Any(x => x.Id == Message.Id))
            {
                return NotFound();
            }

            db.Update(Message);
            await db.SaveChangesAsync();
            return Ok(Message);
        }

        // DELETE api/Messages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Message>> Delete(int id)
        {
            Message Message = db.Messages.FirstOrDefault(x => x.Id == id);
            if (Message == null)
            {
                return NotFound();
            }
            db.Messages.Remove(Message);
            await db.SaveChangesAsync();
            return Ok(Message);
        }
    }
}
