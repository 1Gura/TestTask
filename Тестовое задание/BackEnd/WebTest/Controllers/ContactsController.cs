using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebTest.Models;
using System.Threading.Tasks;

namespace WebTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        ContactContext db;
        public ContactsController(ContactContext context)
        {
            db = context;
            if (!db.Contacts.Any())
            {
               
                
            }
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> Get()
        {
            return
                await db.Contacts.ToListAsync();
        }




        // GET api/Contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> Get(int id)
        {
            Contact Contact = await db.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            if (Contact == null)
                return NotFound();
            return new ObjectResult(Contact);
        }

        // POST api/Contacts
        [HttpPost]
        public async Task<ActionResult<Contact>> Post(Contact newContact)
        {

            if (newContact.Name == "admin" || newContact.Name == "Admin" || newContact.Name == "ADMIN")
            {
                ModelState.AddModelError("Name", "Недопустимое имя пользователя - admin");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            /*if (Contact == null)
           {
               return BadRequest();
           }*/

            /* foreach (Contact contact in db.Contacts)
             {
                 if (Contact.Email != contact.Email && Contact.Phone != contact.Phone)
                 {
                     db.Contacts.Add(Contact);
                 }
                 else
                 {
                     if (!ModelState.IsValid)
                     {
                         return BadRequest(ModelState);
                     }
                 }
             }*/

            Contact contact = db.Contacts.FirstOrDefault(c => c.Phone == newContact.Phone && c.Email == newContact.Email );
            if(contact == null)
            {
                db.Contacts.Add(newContact);
                await db.SaveChangesAsync();
                return Ok(newContact);
            }
            else
            {
                return Ok(contact);
            }
        }

        // PUT api/Contacts/
        [HttpPut]
        public async Task<ActionResult<Contact>> Put(Contact Contact)
        {
            if (Contact == null)
            {
                return BadRequest();
            }
            if (!db.Contacts.Any(x => x.Id == Contact.Id))
            {
                return NotFound();
            }

            db.Update(Contact);
            await db.SaveChangesAsync();
            return Ok(Contact);
        }

        // DELETE api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contact>> Delete(int id)
        {
            Contact Contact = db.Contacts.FirstOrDefault(x => x.Id == id);
            if (Contact == null)
            {
                return NotFound();
            }
            db.Contacts.Remove(Contact);
            await db.SaveChangesAsync();
            return Ok(Contact);
        }
    }
}
