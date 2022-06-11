using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StateOfNation.Requests
{
    public class FilterAgentStatusRequest
    {
        public int teamId { get; set; }
        public string status { get; set; }
        public string processingSince { get; set; }
        public string region { get; set; }
    }
}