using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SecretSanta.Web.ViewModels
{
    public class GiftViewModel
    {
        [Required]
        public string GiftName {get; set;} = "";

        [Required]
        public string GiftDescription {get; set;} = "";

        [Required]
        public string GiftUrl {get; set;} = "";

        [Required]
        public int GiftPriority {get; set;}

        public string? GiftUser {get; set;}
        [Display(Name = "GiftUser")]
        public int ID {get; set;}
        public int GiftId {get; set;}
    }
}