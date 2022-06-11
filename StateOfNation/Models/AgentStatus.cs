using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StateOfNation.Models
{
    public class AgentStatus
    {
        
        public string agent { get; set; }
        public string region { get; set; }
        public string availableSince { get; set; }
        public string processingSince { get; set; }
        public string notReadySince { get; set; }
        public string firstLoggedIn { get; set; }
        public string lastLoggedOut { get; set; }
        public int status { get; set; }
    }
}