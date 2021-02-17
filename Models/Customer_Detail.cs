using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RK_Hotels.Models
{
    public class Customer_Detail
    {
        public int Id { get; set; }

        [Required]

        public string Customer_Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

      
    }
}
