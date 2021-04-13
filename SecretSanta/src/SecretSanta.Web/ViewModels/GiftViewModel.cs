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

        [Display(Name = "GiftUser")]
        public string? GiftUser {get; set;}
        public int UserID {get; set;}
        public int GiftId {get; set;}
    }
}