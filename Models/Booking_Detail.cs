using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RK_Hotels.Models
{
    public class Booking_Detail
    {
        [Key]
        public int Id { get; set; }

        [Required] 

        //code to connect the other classes with forign key
        public int Customer_DetailId { get; set; }
        public Customer_Detail Customer_Detail { get; set; }

        public int Hotel_DetailId { get; set; }
        public Hotel_Detail Hotel_Detail { get; set; }

        public int Room_DetailId { get; set; }
        public Room_Detail Room_Detail { get; set; }

        public int Service_DetailId { get; set; }
        public Service_Detail Service_Detail { get; set; }
    }
}
