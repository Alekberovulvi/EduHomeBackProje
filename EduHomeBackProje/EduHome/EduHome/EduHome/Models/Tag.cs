using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Tag 
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 25)]
        public string Name { get; set; }
    }
}
