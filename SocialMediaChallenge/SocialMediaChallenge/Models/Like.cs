using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace SocialMediaChallenge.Models
{
    public class Like
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public Post LikedPost { get; set; }
        [ForeignKey(nameof(LikedPost))]
        public virtual Post post { get; set; }
        [Required]
        public User UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public virtual User user { get; set; }
        public User Liker { get; set; }
    }
}