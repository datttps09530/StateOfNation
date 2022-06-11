using StateOfNation.Hubs;
using StateOfNation.Models;
using StateOfNation.Requests;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StateOfNation.Connection
{
    public class ConnectionSQL : ConnectionSQL_QueryDatabase
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["StateOfNationConnection"].ConnectionString;
        #region GET
        public async Task<List<AgentStatus>> getAgentStatusDepedencyUpdated(FilterAgentStatusRequest request, PagingParameter pagingparametermodel)
        {
            List<AgentStatus> listAgentStatus = new List<AgentStatus>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                    "sp_Dependency_LiveFeedControl_LastUpdated", connection))
                {
                    command.Notification = null;

                    SqlDependency dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);
                    listAgentStatus = await getListAgentStatus(request, pagingparametermodel).ConfigureAwait(false);
                }
            }

            return listAgentStatus;
        }
        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            AgentStatusHubs.Show();
        }
        #endregion

        #region get all agentStatus

        public async Task<List<AgentStatus>> getListAgentStatus(FilterAgentStatusRequest request, PagingParameter pagingparametermodel)
        {
            int pageSize = pagingparametermodel.pageSize;
            int currentPage = pagingparametermodel.pageNumber;

            List<AgentStatus> listAgentStatus = new List<AgentStatus>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                    "sp_Filter_Agent_Status", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    
                    command.Parameters.Add("@status", SqlDbType.Int).Value = request.status;
                    command.Parameters.Add("@region", SqlDbType.VarChar).Value = request.region;
                    command.Parameters.Add("@processince", SqlDbType.Time).Value = Convert.ToDateTime(request.processingSince);
                    command.Parameters.Add("@teamId", SqlDbType.Int).Value = request.teamId;
                    command.Parameters.Add("@pageSize", SqlDbType.Int).Value = pageSize;
                    command.Parameters.Add("@curentPage", SqlDbType.Int).Value = currentPage;

                    command.Notification = null;
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    
                    SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);
                    
                    listAgentStatus =  reader.Cast<IDataRecord>()
                            .Select(x => new AgentStatus()
                            {
                                agent = (string)x["Agent"],
                                region = (string)x["Region"],
                                processingSince = Convert.ToDateTime(x["Processing_Since"]).ToShortTimeString(),
                                notReadySince = Convert.ToDateTime(x["Not_ready_since"]).ToShortTimeString(),
                                firstLoggedIn = Convert.ToDateTime(x["First_logged_in"]).ToShortTimeString(),
                                lastLoggedOut = Convert.ToDateTime(x["Last_logged_out"]).ToShortTimeString(),
                                availableSince = Convert.ToDateTime(x["Available_Since"]).ToShortTimeString(),
                                status = (int)x["Status"],
                    
                            }).ToList();
                }
            }
            return listAgentStatus;

        }
        #endregion
    }
}