using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SecretSanta.Web.ViewModels
{
    public class GroupViewModel
    {
        public List<UserViewModel>? Users;
        public string GroupName {get; set;} = "";        
        [Display(Name = "GroupName")]
        [Required]
        public int ID {get; set;}
    }
}