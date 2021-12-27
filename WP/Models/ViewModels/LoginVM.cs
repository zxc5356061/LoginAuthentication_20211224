using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WP.Models.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Account")]
        [Required(ErrorMessage = "{0} is MUST-HAVE!")]
        public string Account { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "{0} is MUST-HAVE!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}