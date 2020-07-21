using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebTest.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Пустое сообщение!")]
        [StringLength(maximumLength:400)]
        public string TextMessage { get; set; }
        public int? ContactId { get; set; }
        public Contact Contact { get; set; }

        public int? TopicId { get; set; }
        public  Topic Topic { get; set; }

    }
}
