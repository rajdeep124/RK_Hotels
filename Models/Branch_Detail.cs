using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RK_Hotels.Models
{
    //code for adding branch class
    public class Branch_Detail
    {

        public int Id { get; set; }

        [Required]

        public string Branch_Name { get; set; }

        public string Branch_Phone { get; set; }

        public string Brand_Address { get; set; }

        //code to connect the Brand Class with Product Details Class
        public int Hotel_DetailId { get; set; }
        public Hotel_Detail Hotel_Detail { get; set; }
    }
}
