using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StateOfNation.Models
{
    public class AgentStatus
    {
        
        public string Agent { get; set; }
        public string Region { get; set; }
        public string Available_Since { get; set; }
        public string Processing_Since { get; set; }
        public string Not_ready_since { get; set; }
        public string First_logged_in { get; set; }
        public string Last_logged_out { get; set; }
        public int Status { get; set; }
    }
}