using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumDemo.Models
{
    [NotMapped]
    public class LoginUser
    {
        [Required(ErrorMessage = "Required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string LoginEmail { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(8, ErrorMessage = "Must be at least 8 characters.")]
        [DataType(DataType.Password)]
        public string LoginPassword { get; set; }
    }
}