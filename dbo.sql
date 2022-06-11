/*
 Navicat Premium Data Transfer

 Source Server         : StateOfNation
 Source Server Type    : SQL Server
 Source Server Version : 15002000
 Source Host           : 192.168.1.6:1433
 Source Catalog        : DB_StateOfNation
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 15002000
 File Encoding         : 65001

 Date: 11/06/2022 16:12:55
*/


-- ----------------------------
-- Table structure for agentStatus
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[agentStatus]') AND type IN ('U'))
	DROP TABLE [dbo].[agentStatus]
GO

CREATE TABLE [dbo].[agentStatus] (
  [agentPein] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [availableSince] time(7)  NULL,
  [processingSince] time(7)  NULL,
  [lastLoggedIn] time(7)  NULL,
  [lastLoggedOut] time(7)  NULL,
  [Province] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [TeamId] int  NULL,
  [notReadySince] time(7)  NULL
)
GO

ALTER TABLE [dbo].[agentStatus] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of agentStatus
-- ----------------------------

-- ----------------------------
-- Table structure for liveFeedControl
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[liveFeedControl]') AND type IN ('U'))
	DROP TABLE [dbo].[liveFeedControl]
GO

CREATE TABLE [dbo].[liveFeedControl] (
  [idLiveFeed] int  NOT NULL,
  [feedName] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [procedureName] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [refreshTime] nvarchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [lastUpdated] datetime  NOT NULL
)
GO

ALTER TABLE [dbo].[liveFeedControl] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of liveFeedControl
-- ----------------------------

-- ----------------------------
-- procedure structure for sp_Filter_Agent_Status
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Filter_Agent_Status]') AND type IN ('FN', 'FS', 'FT', 'IF', 'TF'))
	DROP PROCEDURE[dbo].[sp_Filter_Agent_Status]
GO

CREATE PROCEDURE [dbo].[sp_Filter_Agent_Status]
@status int =0,
@region varchar(50) = '', 
@processince time(7),
@teamId int =0
AS
BEGIN
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

END
GO


-- ----------------------------
-- procedure structure for sp_Dependency_LiveFeedControl_LastUpdated
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Dependency_LiveFeedControl_LastUpdated]') AND type IN ('FN', 'FS', 'FT', 'IF', 'TF'))
	DROP PROCEDURE[dbo].[sp_Dependency_LiveFeedControl_LastUpdated]
GO

CREATE PROCEDURE [dbo].[sp_Dependency_LiveFeedControl_LastUpdated]

AS
BEGIN
		SELECT [lastUpdated]
          FROM [dbo].[liveFeedControl] WHERE [dbo].[liveFeedControl].[feedName] = 'AgentStatus'

END
GO

