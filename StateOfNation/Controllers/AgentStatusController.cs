using StateOfNation.Connection;
using StateOfNation.Hubs;
using StateOfNation.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateOfNation.Controllers
{
    public class AgentStatusController : Controller
    {
        public ActionResult AgentStatus()
        {
            return View();
        }

        public JsonResult GetDataTable()
        {
            ConnectionSQL getAgentStatus = new ConnectionSQL();
            var getlistAgStus = getAgentStatus.GetAgentStatus();
            return Json(new { listAgStus = getlistAgStus }, JsonRequestBehavior.AllowGet);
        }
    }
}