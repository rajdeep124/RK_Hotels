using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RK_Hotels.Models
{
    public class Hotel_Detail
    {

        public int Id { get; set; }

        [Required]
        public string Branch_Name { get; set; }

        public string Email { get; set; }

        public string Phone_Number { get; set; }

        public string Address { get; set; }

    }
}
