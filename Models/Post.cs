using System;
using System.ComponentModel.DataAnnotations;

namespace ForumDemo.Models
{
    public class Post
    {
        [Key] // PostId is the primary key
        public int PostId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Must be at least 3 characters.")]
        [MaxLength(50, ErrorMessage = "Cannot be more than 50 characters.")]
        public string Username { get; set; }
        [Display(Name="User Name")]

        [Required]
        [MinLength(3, ErrorMessage = "Must be at least 3 characters.")]
        [MaxLength(50, ErrorMessage = "Cannot be more than 50 characters.")]
        public string Topic { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Must be at least 3 characters.")]
        public string Body { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // if you add your own constructor then you need to also add a parameterless constructor
        public Post () {}

        public Post (string username, string topic, string body)
        {
            Username = username;
            Topic = topic;
            Body = body;
        }
    }
}