using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RK_Hotels.Models
{
    public class Service_Detail
    {
        public int Id { get; set; }

        [Required]

        public string Name { get; set; }

        public string Availablity { get; set; }

        public decimal Price { get; set; }

        public string Opening_Hours { get; set; }

    }
}
