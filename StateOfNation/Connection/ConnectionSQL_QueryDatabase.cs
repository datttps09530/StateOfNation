using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StateOfNation.Connection
{
    public class ConnectionSQL_QueryDatabase
    {
        #region Get lastUpdated
        public static string getLastUpdatedLiveFeed= @"SELECT 
                        [lastUpdated]
                    FROM [dbo].[liveFeedControl] WHERE [dbo].[liveFeedControl].[feedName] = 'AgentStatus'";
        #endregion

        #region GET
        public static string Get_AgentStatus_All = @"SELECT 
                        [agentPein],
		                [availableSince],
		                [processingSince],
		                [notReadySince],
		                [lastLoggedIn],
		                [lastLoggedOut],
		                [Province],
		                [TeamId]
                    FROM [dbo].[agentStatus]";
        #endregion
    }
}