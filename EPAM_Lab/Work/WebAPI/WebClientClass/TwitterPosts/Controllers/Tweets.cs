using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TwitterPosts.Controllers
{
    public class Tweets
    {
        public Tweet[] results;
    }

    public class Tweet
    {
        [JsonProperty("from_user")]
        public string UserName { get; set; }

        [JsonProperty("text")]
        public string TweetText { get; set; }
    }
}
