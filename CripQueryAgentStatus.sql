CREATE PROCEDURE [dbo].[sp_Filter_Agent_Status]
@status int = 0,
@region varchar(50) = '', 
@processince time(7),
@teamId int = 0,
@pageSize int = 20,
@curentPage int = 1
AS
BEGIN
		DECLARE @offset INT
    DECLARE @newsize INT
		BEGIN
		SET @offset = (@curentPage - 1) * @pageSize
		SET @fetchData = @pageSize
		END
		select 
		[agentPein],
		[availableSince],
		[processingSince],
		[notReadySince],
		[lastLoggedIn],
		[lastLoggedOut],
		[Province],
		[TeamId]
		from [dbo].[agentStatus]
		WHERE [Province] LIKE @region + '%'
		OFFSETS @offset ROWS
		FETCH @fetchData ROWS ONLY
END

GO
CREATE PROCEDURE [dbo].[sp_Dependency_LiveFeedControl_LastUpdated]

AS
BEGIN
		SELECT [lastUpdated]
          FROM [dbo].[liveFeedControl] WHERE [dbo].[liveFeedControl].[feedName] = 'AgentStatus'

END


