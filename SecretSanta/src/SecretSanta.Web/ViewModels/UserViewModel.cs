using System.ComponentModel.DataAnnotations;//cal:used for the [Required] and [Display] tags

namespace SecretSanta.Web.ViewModels
{
    public class UserViewModel
    {
        //cal:typing "prop" and then [tab] auto fills a property
        //setting to empty string because of the nullable stuff.
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = "";
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = "";
    }
}