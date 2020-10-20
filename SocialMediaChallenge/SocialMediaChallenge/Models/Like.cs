using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialMediaChallenge.Models
{
    public class Like
    {
        public Post LikedPost { get; set; }
        public User Liker { get; set; }
    }
}