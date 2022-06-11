using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StateOfNation.Models
{
    public class LiveFeedControl
    {
        public int IdLiveFeed { get; set; }
        public string FeedName { get; set; }
        public string ProcedureName { get; set; }
        public string RefreshTime { get; set; }
        public DateTime LastUpdated { get; set; }
    }

}