using System.ComponentModel.DataAnnotations;//cal:used for the [Required] and [Display] tags

namespace SecretSanta.Web.ViewModels
{
    public class GroupViewModel
    {
 
        public int Id { get; set; }
        [Required]
        [Display(Name = "Group Name")]
        public string GroupName { get; set; } = "";
        
    }
}