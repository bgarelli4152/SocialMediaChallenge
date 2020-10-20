using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialMediaChallenge.Models
{
    public class Reply : Comment
    {
        public Comment ReplyComment { get; set; }
    }
}