using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Medfar.Interview.Types;
using System.ComponentModel.DataAnnotations;

namespace Medfar.Interview.Web.Models
{
    public class ExamViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }
}