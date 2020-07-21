using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTest.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string TextTopic { get; set; }

        public ICollection<Message> Messages { get; set; }
        public Topic()
        {
            Messages = new List<Message>();
        }
    }
}
