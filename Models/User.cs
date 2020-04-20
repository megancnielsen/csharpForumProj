using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumDemo.Models
{
    public class User
    {
        [Key] // denoted PK
        public int UserId { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(3, ErrorMessage = "Must be at least 3 characters.")]
        [Display(Name = "First Name")]

        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(3, ErrorMessage = "Must be at least 3 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(8, ErrorMessage = "Must be at least 8 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string PasswordConfirm { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // if you add your own constructor then you need to also add a parameterless constructor
        public User () {}
    }
}