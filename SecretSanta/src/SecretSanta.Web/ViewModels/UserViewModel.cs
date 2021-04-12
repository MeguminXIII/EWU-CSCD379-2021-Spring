using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SecretSanta.Web.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string FirstName {get; set;} = "";

        [Required]
        public string LastName {get; set;} = "";

        public string FullName => $"{FirstName} {LastName}";

        public int UserID {get; set;}

        public List<GiftViewModel>? Gifts;

        [Display(Name = "GroupName")]
        public string? GroupName {get; set;}
    }
}