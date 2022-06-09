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

namespace StateOfNation.Connection
{
    public class ConnectionSQL : ConnectionSQL_QueryDatabase
    {
        #region GET
        public List<AgentStatus> GetAgentStatus()
        {
            List<AgentStatus> listAgStus = new List<AgentStatus>();

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AgentStatusConnection"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                    Get_AgentStatus_All, connection))
                {
                    // Make sure the command object does not already have
                    // a notification object associated with it.
                    command.Notification = null;

                    SqlDependency dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                        
                    
                    listAgStus = reader.Cast<IDataRecord>()
                            .Select(x => new AgentStatus()
                            {
                                //CusId = (string)x["CusId"],
                                //CusName = (string)x["CusName"],
                                Agent = (string)x["Agent"],
                                Region = (string)x["Region"],
                                Processing_Since = Convert.ToDateTime(x["Processing_Since"]).ToShortTimeString(),
                                Not_ready_since = Convert.ToDateTime(x["Not_ready_since"]).ToShortTimeString(),
                                First_logged_in = Convert.ToDateTime(x["First_logged_in"]).ToShortTimeString(),
                                Last_logged_out = Convert.ToDateTime(x["Last_logged_out"]).ToShortTimeString(),
                                Available_Since = Convert.ToDateTime(x["Available_Since"]).ToShortTimeString(),
                                Status = (int)x["Status"],

                            }).ToList();
                }
            }

            return listAgStus;
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            AgentStatusHubs.Show();
        }
        #endregion
    }
}