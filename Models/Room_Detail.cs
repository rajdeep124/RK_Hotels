using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RK_Hotels.Models
{
    public class Room_Detail
    {
        public int Id { get; set; }

        [Required]

        public string Room_Type { get; set; }

        public string Room_Description { get; set; }

        public decimal Price_Per_Night { get; set; }

      
    }
}
