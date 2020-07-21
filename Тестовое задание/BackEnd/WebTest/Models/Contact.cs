using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTest.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(maximumLength:30,  ErrorMessage = "Длина строки должна быть от 1 до 30 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан телефон")]
        [StringLength(maximumLength:20)]
        /*[RegularExpressionAttribute(@"/\+7\(\d{3}\)\-\d{3}\-\d{4}/")]*/
        public string Phone { get; set; }

        [Required(ErrorMessage = "Не указан email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
        public ICollection<Message> Messages { get; set; }
        public Contact()
        {
            Messages = new List<Message>();
        }
    }
}
