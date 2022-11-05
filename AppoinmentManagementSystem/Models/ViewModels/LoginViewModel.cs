using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagementSystem.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(8, ErrorMessage = "The {0} must be {2} characters long.", MinimumLength = 8)]
        [Display(Name = "User Login Code")]
        public string LoginCode { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
