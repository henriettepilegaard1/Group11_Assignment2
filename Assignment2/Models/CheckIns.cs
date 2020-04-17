using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class CheckIns
    {
        [Key]
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public int RoomNumber { get; set; }

        public int Adults { get; set; }

        public int Kids { get; set; }

    }
}