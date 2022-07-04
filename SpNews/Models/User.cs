using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpNews.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Email { get; set; }
        [Required]
        [MaxLength(15)]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsBanned { get; set; }
    }
}
