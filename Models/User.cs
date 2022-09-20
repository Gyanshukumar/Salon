using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Salon_and_Spa.Models
{
    public class User
    {
        
        public string  UserId{get;set;}

        [Required (ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required (ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}