using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StateOfNation.Connection
{
    public class ConnectionSQL_QueryDatabase
    {
        #region GET
        public static string Get_AgentStatus_All = @"SELECT 
                         [Agent]
                        ,[Region]
                        ,[Available_Since]
                        ,[Processing_Since]
                        ,[Not_ready_since]
                        ,[First_logged_in]
                        ,[Last_logged_out]
                        ,[Status]
                    FROM [dbo].[AgentStatus]";
        #endregion
    }
}