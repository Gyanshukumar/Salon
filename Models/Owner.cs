using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Salon_and_Spa.Models
{
    public class Owner
    {
        
        public int CorporateId { get; set; }

        [Required]
        public string Name_Of_The_Salon { get; set; }

        [Required(ErrorMessage = "Valid Email is Required")]
        [EmailAddress]
        public string EmailId { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        
        public string Password { get; set; }

        [Required]
        public string Phone_Number { get; set; }

        [Required]
        public Nullable<int> Price { get; set; }
    }
}