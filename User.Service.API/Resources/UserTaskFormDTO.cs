using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace User.Service.API.Resources
{
    public class UserTaskFormDTO
    {
        [Required]
        [MaxLength(10)]
        public string Title { get; set; }
        [Required]
        [MaxLength(30)]
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
