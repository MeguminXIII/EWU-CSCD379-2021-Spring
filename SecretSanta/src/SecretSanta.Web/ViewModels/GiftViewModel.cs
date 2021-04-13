using System.ComponentModel.DataAnnotations;//cal:used for the [Required] and [Display] tags

namespace SecretSanta.Web.ViewModels
{
    public class GiftViewModel
    {
        public int Id { get; set; }

        //cal:typing "prop" and then [tab] auto fills a property
        //setting to empty string because of the nullable stuff.
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; } = "";
        
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; } = "";

        [Required]
        [Url]
        [Display(Name = "Url")]
        public string Url { get; set; } = "";

        [Required]
        [Display(Name = "Priority")]
        public int Priority { get; set; } = 0;

        [Display(Name = "Suggested For")]
        public int UserId { get; set; }
    }
}