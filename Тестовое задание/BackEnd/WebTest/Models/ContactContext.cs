using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebTest.Models
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        internal Task<ActionResult<IEnumerable<Contact>>> ToListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
