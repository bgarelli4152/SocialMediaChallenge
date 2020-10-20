using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialMediaChallenge.Models
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Text { get; set; }
        public User Author { get; set;}
        public Post CommentPost { get; set; }
    }
}