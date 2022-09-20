using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Salon_and_Spa.Models
{
    public class BookingSystem
    {
        
        public int Id { get; set; }
        [Required]
        public Nullable<int> UserId { get; set; }

        [Required]
        public Nullable<int> CorporateId { get; set; }

        [Required]
        public Nullable<System.DateTime> Date { get; set; }

        [Required]
        public Nullable<System.TimeSpan> Time { get; set; }
    }
}