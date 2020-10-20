using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialMediaChallenge.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public User Author { get; set;}
        public Post CommentPost { get; set; }
    }
}