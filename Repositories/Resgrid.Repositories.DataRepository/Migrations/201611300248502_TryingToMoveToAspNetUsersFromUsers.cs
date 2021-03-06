namespace Resgrid.Repositories.DataRepository.Migrations
{
	using System;
	using System.Data.Entity.Migrations;

	public partial class TryingToMoveToAspNetUsersFromUsers : DbMigration
	{
		public override void Up()
		{
			DropForeignKey("dbo.Inventories", "AddedByUserId", "dbo.Users");
			DropForeignKey("dbo.Logs", "LoggedByUserId", "dbo.Users");
			DropForeignKey("dbo.DepartmentProfileUserFollows", "DepartmentProfileUserId", "dbo.DepartmentProfileUsers");
			DropIndex("dbo.ActionLogs", new[] { "UserId" });
			DropIndex("dbo.ActionLogs", "IX_ActionLogs_UserIdTimestamp");
			DropIndex("dbo.ActionLogs", "nci_wi_ActionLogs_86E9724D-7460-475C-846E-84CA52E2367B");
			DropForeignKey("dbo.ActionLogs", "FK_ActionLogs_Users_UserId");
			DropIndex("dbo.Departments", new[] { "ManagingUserId" });
			DropForeignKey("dbo.Departments", "FK_Departments_Users_ManagingUserId");
			DropIndex("dbo.CalendarItemAttendees", new[] { "UserId" });
			DropForeignKey("dbo.CalendarItemAttendees", "FK_dbo.CalendarItemAttendees_dbo.Users_UserId");
			DropIndex("dbo.Calls", new[] { "ReportingUserId" });
			DropIndex("dbo.Calls", new[] { "ClosedByUserId" });
			DropIndex("dbo.Calls", "nci_wi_Calls_0125530133DE4FF1347A");
			DropIndex("dbo.Calls", "nci_wi_Calls_6AEE0E27-BE26-4F5C-BE0B-DEB197CE79B6");
			DropForeignKey("dbo.Calls", "FK_Calls_Users_ReportingUserId");
			DropForeignKey("dbo.Calls", "FK_dbo.Calls_dbo.Users_ClosedByUserId");
			DropIndex("dbo.CallNotes", new[] { "UserId" });
			DropForeignKey("dbo.CallNotes", "FK_dbo.CallNotes_dbo.Users_UserId");
			DropIndex("dbo.CallDispatches", new[] { "UserId" });
			DropForeignKey("dbo.CallDispatches", "FK_dbo.CallDispatches_dbo.Users_UserId");
			DropIndex("dbo.DepartmentGroupMembers", new[] { "UserId" });
			DropForeignKey("dbo.DepartmentGroupMembers", "FK_DepartmentGroupMembers_Users_UserId");
			DropForeignKey("dbo.DepartmentGroupMembers", "FK_dbo.DepartmentGroupMembers_dbo.Users_UserId");
			DropIndex("dbo.PersonnelRoleUsers", new[] { "UserId" });
			DropForeignKey("dbo.PersonnelRoleUsers", "FK_dbo.PersonnelRoleUsers_dbo.Users_UserId");
			DropIndex("dbo.CallLogs", new[] { "LoggedByUserId" });
			DropForeignKey("dbo.CallLogs", "FK_dbo.CallLogs_dbo.Users_LoggedByUserId");
			DropIndex("dbo.UnitStateRoles", new[] { "UserId" });
			DropForeignKey("dbo.UnitStateRoles", "FK_dbo.UnitStateRoles_dbo.Users_UserId");
			DropIndex("dbo.DepartmentMembers", new[] { "UserId" });
			DropForeignKey("dbo.DepartmentMembers", "FK_DepartmentMembers_Users_UserId");
			DropIndex("dbo.DepartmentProfileArticles", new[] { "CreatedByUserId" });
			Sql(@"
					DECLARE @schema_name NVARCHAR(256)
					DECLARE @table_name NVARCHAR(256)
					DECLARE @col_name NVARCHAR(256)
					DECLARE @Command  NVARCHAR(1000)

					SET @schema_name = N'dbo'
					SET @table_name = N'DepartmentProfileUsers'
					SET @col_name = N'DepartmentProfileUserId'

					SELECT @Command = 'ALTER TABLE ' + @schema_name + '.[' + @table_name + '] DROP CONSTRAINT ' + d.name
					 FROM sys.tables t
					  JOIN sys.default_constraints d ON d.parent_object_id = t.object_id
					  JOIN sys.columns c ON c.object_id = t.object_id AND c.column_id = d.parent_column_id
					 WHERE t.name = @table_name
					  AND t.schema_id = schema_id(@schema_name)
					  AND c.name = @col_name

					execute (@Command)
			");
			Sql(@"
					DECLARE @schema_name NVARCHAR(256)
					DECLARE @table_name NVARCHAR(256)
					DECLARE @col_name NVARCHAR(256)
					DECLARE @Command  NVARCHAR(1000)

					SET @schema_name = N'dbo'
					SET @table_name = N'DepartmentProfileArticles'
					SET @col_name = N'CreatedByUserId'

					SELECT @Command = 'ALTER TABLE ' + @schema_name + '.[' + @table_name + '] DROP CONSTRAINT ' + d.name
					 FROM sys.tables t
					  JOIN sys.default_constraints d ON d.parent_object_id = t.object_id
					  JOIN sys.columns c ON c.object_id = t.object_id AND c.column_id = d.parent_column_id
					 WHERE t.name = @table_name
					  AND t.schema_id = schema_id(@schema_name)
					  AND c.name = @col_name

					execute (@Command)
			");
			DropForeignKey("dbo.DepartmentProfileArticles", "FK_dbo.DepartmentProfileArticles_dbo.Users_CreatedByUserId");
			DropIndex("dbo.DepartmentProfileUserFollows", new[] { "DepartmentProfileUserId" });
			DropIndex("dbo.DistributionListMembers", new[] { "UserId" });
			DropForeignKey("dbo.DistributionListMembers", "FK_dbo.DistributionListMembers_dbo.Users_UserId");
			DropIndex("dbo.Documents", new[] { "UserId" });
			DropForeignKey("dbo.Documents", "FK_dbo.Documents_dbo.Users_UserId");
			DropIndex("dbo.Inventories", new[] { "AddedByUserId" });
			DropIndex("dbo.Invites", new[] { "SendingUserId" });
			DropForeignKey("dbo.Invites", "FK_dbo.Invites_dbo.Users_SendingUserId");
			DropIndex("dbo.Logs", new[] { "InvestigatedByUserId" });
			DropForeignKey("dbo.Logs", "FK_dbo.Logs_dbo.Users_InvestigatedByUserId");
			DropIndex("dbo.Logs", new[] { "LoggedByUserId" });
			DropForeignKey("dbo.Logs", "FK_dbo.Logs_dbo.Users_LoggedByUserId");
			DropIndex("dbo.Logs", new[] { "OfficerUserId" });
			DropForeignKey("dbo.Logs", "FK_dbo.Logs_dbo.Users_OfficerUserId");
			DropIndex("dbo.LogUsers", new[] { "UserId" });
			DropForeignKey("dbo.LogUsers", "FK_dbo.LogUsers_dbo.Users_UserId");
			DropIndex("dbo.MessageRecipients", new[] { "UserId" });
			DropForeignKey("dbo.MessageRecipients", "FK_dbo.MessageRecipients_dbo.Users_UserId");
			DropIndex("dbo.Messages", new[] { "SendingUserId" });
			DropForeignKey("dbo.Messages", "FK_Messages_Users_SendingUserId");
			DropIndex("dbo.Messages", new[] { "ReceivingUserId" });
			DropForeignKey("dbo.Messages", "FK_dbo.Messages_dbo.Users_ReceivingUserId");
			DropForeignKey("dbo.Messages", "FK_Messages_Users_ReceivingUserId");
			Sql(@"
					DECLARE @schema_name NVARCHAR(256)
					DECLARE @table_name NVARCHAR(256)
					DECLARE @col_name NVARCHAR(256)
					DECLARE @Command  NVARCHAR(1000)

					SET @schema_name = N'dbo'
					SET @table_name = N'Messages'
					SET @col_name = N'ReceivingUserId'

					SELECT @Command = 'ALTER TABLE ' + @schema_name + '.[' + @table_name + '] DROP CONSTRAINT ' + d.name
					 FROM sys.tables t
					  JOIN sys.default_constraints d ON d.parent_object_id = t.object_id
					  JOIN sys.columns c ON c.object_id = t.object_id AND c.column_id = d.parent_column_id
					 WHERE t.name = @table_name
					  AND t.schema_id = schema_id(@schema_name)
					  AND c.name = @col_name

					execute (@Command)
			");
			DropIndex("dbo.Payments", new[] { "PurchasingUserId" });
			DropForeignKey("dbo.Payments", "FK_dbo.Payments_dbo.Users_PurchasingUserId");
			Sql(@"
					DECLARE @schema_name NVARCHAR(256)
					DECLARE @table_name NVARCHAR(256)
					DECLARE @col_name NVARCHAR(256)
					DECLARE @Command  NVARCHAR(1000)

					SET @schema_name = N'dbo'
					SET @table_name = N'Permissions'
					SET @col_name = N'UpdatedBy'

					SELECT @Command = 'ALTER TABLE ' + @schema_name + '.[' + @table_name + '] DROP CONSTRAINT ' + d.name
					 FROM sys.tables t
					  JOIN sys.default_constraints d ON d.parent_object_id = t.object_id
					  JOIN sys.columns c ON c.object_id = t.object_id AND c.column_id = d.parent_column_id
					 WHERE t.name = @table_name
					  AND t.schema_id = schema_id(@schema_name)
					  AND c.name = @col_name

					execute (@Command)
			");
			DropIndex("dbo.PersonnelCertifications", new[] { "UserId" });
			DropForeignKey("dbo.PersonnelCertifications", "FK_dbo.PersonnelCertifications_dbo.Users_UserId");
			DropIndex("dbo.PushUris", new[] { "UserId" });
			DropForeignKey("dbo.PushUris", "FK_dbo.PushUris_dbo.Users_UserId");
			DropIndex("dbo.ScheduledTasks", new[] { "UserId" });
			DropForeignKey("dbo.ScheduledTasks", "FK_dbo.ScheduledTasks_dbo.Users_UserId");
			DropIndex("dbo.ShiftAdmins", new[] { "UserId" });
			DropForeignKey("dbo.ShiftAdmins", "FK_dbo.ShiftAdmins_dbo.Users_UserId");
			DropIndex("dbo.ShiftGroupAssignments", new[] { "UserId" });
			DropForeignKey("dbo.ShiftGroupAssignments", "FK_dbo.ShiftGroupAssignments_dbo.Users_UserId");
			DropIndex("dbo.ShiftPersons", new[] { "UserId" });
			DropForeignKey("dbo.ShiftPersons", "FK_dbo.ShiftPersons_dbo.Users_UserId");
			DropIndex("dbo.ShiftSignups", new[] { "UserId" });
			DropForeignKey("dbo.ShiftSignups", "FK_dbo.ShiftSignups_dbo.Users_UserId");
			DropIndex("dbo.ShiftSignupTrades", new[] { "UserId" });
			DropForeignKey("dbo.ShiftSignupTrades", "FK_dbo.ShiftSignupTrades_dbo.Users_UserId");
			DropIndex("dbo.ShiftSignupTradeUsers", new[] { "UserId" });
			DropForeignKey("dbo.ShiftSignupTradeUsers", "FK_dbo.ShiftSignupTradeUsers_dbo.Users_UserId");
			DropIndex("dbo.ShiftStaffingPersons", new[] { "UserId" });
			DropForeignKey("dbo.ShiftStaffingPersons", "FK_dbo.ShiftStaffingPersons_dbo.Users_UserId");
			DropIndex("dbo.ShiftStaffings", new[] { "AddedByUserId" });
			DropForeignKey("dbo.ShiftStaffings", "FK_dbo.ShiftStaffings_dbo.Users_AddedByUserId");
			DropIndex("dbo.TrainingUsers", new[] { "UserId" });
			DropForeignKey("dbo.TrainingUsers", "FK_dbo.TrainingUsers_dbo.Users_UserId");
			DropIndex("dbo.UserProfiles", new[] { "UserId" });
			DropForeignKey("dbo.UserProfiles", "FK_dbo.UserProfiles_dbo.Users_UserId");
			DropIndex("dbo.UserStates", new[] { "UserId" });
			DropForeignKey("dbo.UserStates", "FK_UserStates_Users_UserId");
			DropPrimaryKey("dbo.DepartmentProfileUsers");
			AlterColumn("dbo.ActionLogs", "UserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.Departments", "ManagingUserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.AuditLogs", "UserId", c => c.String());
			AlterColumn("dbo.CalendarItemAttendees", "UserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.CalendarItems", "CreatorUserId", c => c.String());
			AlterColumn("dbo.CallAttachments", "UserId", c => c.String());
			AlterColumn("dbo.Calls", "ReportingUserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.Calls", "ClosedByUserId", c => c.String(maxLength: 128));
			AlterColumn("dbo.CallNotes", "UserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.CallDispatches", "UserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.DepartmentGroupMembers", "UserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.PersonnelRoleUsers", "UserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.CallLogs", "LoggedByUserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.UnitStateRoles", "UserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.DepartmentMembers", "UserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.DepartmentProfileArticles", "CreatedByUserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.DepartmentProfileUserFollows", "DepartmentProfileUserId", c => c.String(nullable: false, maxLength: 128));
			Sql("IF OBJECT_ID('dbo.[DF__Departmen__Depar__090A5324]') IS NOT NULL ALTER TABLE dbo.DepartmentProfileUsers DROP CONSTRAINT DF__Departmen__Depar__090A5324");
			AlterColumn("dbo.DepartmentProfileUsers", "DepartmentProfileUserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.DistributionListMembers", "UserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.Documents", "UserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.Inventories", "AddedByUserId", c => c.String(maxLength: 128));
			AlterColumn("dbo.Invites", "SendingUserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.Invites", "CompletedUserId", c => c.String());
			AlterColumn("dbo.LogAttachments", "UserId", c => c.String());
			AlterColumn("dbo.Logs", "InvestigatedByUserId", c => c.String(maxLength: 128));
			AlterColumn("dbo.Logs", "LoggedByUserId", c => c.String(maxLength: 128));
			AlterColumn("dbo.Logs", "OfficerUserId", c => c.String(maxLength: 128));
			AlterColumn("dbo.LogUsers", "UserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.MessageRecipients", "UserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.Messages", "SendingUserId", c => c.String(maxLength: 128));
			Sql("IF OBJECT_ID('dbo.[DF__Messages__Receiv__6E01572D]') IS NOT NULL ALTER TABLE dbo.Messages DROP CONSTRAINT DF__Messages__Receiv__6E01572D");
			AlterColumn("dbo.Messages", "ReceivingUserId", c => c.String(maxLength: 128));
			AlterColumn("dbo.Notes", "UserId", c => c.String());
			AlterColumn("dbo.Payments", "PurchasingUserId", c => c.String(nullable: false, maxLength: 128));
			Sql("IF OBJECT_ID('dbo.[DF__Permissio__Updat__1F2E9E6D]') IS NOT NULL ALTER TABLE dbo.Permissions DROP CONSTRAINT DF__Permissio__Updat__1F2E9E6D");
			AlterColumn("dbo.Permissions", "UpdatedBy", c => c.String());
			AlterColumn("dbo.PersonnelCertifications", "UserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.PushUris", "UserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.ScheduledTasks", "UserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.ShiftAdmins", "UserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.ShiftGroupAssignments", "UserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.ShiftPersons", "UserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.ShiftSignups", "UserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.ShiftSignupTrades", "UserId", c => c.String(maxLength: 128));
			AlterColumn("dbo.ShiftSignupTradeUsers", "UserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.ShiftStaffingPersons", "UserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.ShiftStaffings", "AddedByUserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.Trainings", "CreatedByUserId", c => c.String(nullable: false));
			AlterColumn("dbo.TrainingUsers", "UserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.UserProfiles", "UserId", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.UserStates", "UserId", c => c.String(nullable: false, maxLength: 128));
			AddPrimaryKey("dbo.DepartmentProfileUsers", "DepartmentProfileUserId");
			CreateIndex("dbo.ActionLogs", "UserId");
			CreateIndex("dbo.Departments", "ManagingUserId");
			CreateIndex("dbo.CalendarItemAttendees", "UserId");
			CreateIndex("dbo.Calls", "ReportingUserId");
			CreateIndex("dbo.Calls", "ClosedByUserId");
			CreateIndex("dbo.CallNotes", "UserId");
			CreateIndex("dbo.CallDispatches", "UserId");
			CreateIndex("dbo.DepartmentGroupMembers", "UserId");
			CreateIndex("dbo.PersonnelRoleUsers", "UserId");
			CreateIndex("dbo.CallLogs", "LoggedByUserId");
			CreateIndex("dbo.UnitStateRoles", "UserId");
			CreateIndex("dbo.DepartmentMembers", "UserId");
			CreateIndex("dbo.DepartmentProfileArticles", "CreatedByUserId");
			CreateIndex("dbo.DepartmentProfileUserFollows", "DepartmentProfileUserId");
			CreateIndex("dbo.DistributionListMembers", "UserId");
			CreateIndex("dbo.Documents", "UserId");
			CreateIndex("dbo.Inventories", "AddedByUserId");
			CreateIndex("dbo.Invites", "SendingUserId");
			CreateIndex("dbo.Logs", "InvestigatedByUserId");
			CreateIndex("dbo.Logs", "LoggedByUserId");
			CreateIndex("dbo.Logs", "OfficerUserId");
			CreateIndex("dbo.LogUsers", "UserId");
			CreateIndex("dbo.MessageRecipients", "UserId");
			CreateIndex("dbo.Messages", "SendingUserId");
			CreateIndex("dbo.Messages", "ReceivingUserId");
			CreateIndex("dbo.Payments", "PurchasingUserId");
			CreateIndex("dbo.PersonnelCertifications", "UserId");
			CreateIndex("dbo.PushUris", "UserId");
			CreateIndex("dbo.ScheduledTasks", "UserId");
			CreateIndex("dbo.ShiftAdmins", "UserId");
			CreateIndex("dbo.ShiftGroupAssignments", "UserId");
			CreateIndex("dbo.ShiftPersons", "UserId");
			CreateIndex("dbo.ShiftSignups", "UserId");
			CreateIndex("dbo.ShiftSignupTrades", "UserId");
			CreateIndex("dbo.ShiftSignupTradeUsers", "UserId");
			CreateIndex("dbo.ShiftStaffingPersons", "UserId");
			CreateIndex("dbo.ShiftStaffings", "AddedByUserId");
			CreateIndex("dbo.TrainingUsers", "UserId");
			CreateIndex("dbo.UserProfiles", "UserId");
			CreateIndex("dbo.UserStates", "UserId");
			AddForeignKey("dbo.Inventories", "AddedByUserId", "dbo.AspNetUsers", "Id");
			AddForeignKey("dbo.Logs", "LoggedByUserId", "dbo.AspNetUsers", "Id");
			AddForeignKey("dbo.DepartmentProfileUserFollows", "DepartmentProfileUserId", "dbo.DepartmentProfileUsers", "DepartmentProfileUserId", cascadeDelete: true);
		}

		public override void Down()
		{
			DropForeignKey("dbo.DepartmentProfileUserFollows", "DepartmentProfileUserId", "dbo.DepartmentProfileUsers");
			DropForeignKey("dbo.Logs", "LoggedByUserId", "dbo.AspNetUsers");
			DropForeignKey("dbo.Inventories", "AddedByUserId", "dbo.AspNetUsers");
			DropIndex("dbo.UserStates", new[] { "UserId" });
			DropIndex("dbo.UserProfiles", new[] { "UserId" });
			DropIndex("dbo.TrainingUsers", new[] { "UserId" });
			DropIndex("dbo.ShiftStaffings", new[] { "AddedByUserId" });
			DropIndex("dbo.ShiftStaffingPersons", new[] { "UserId" });
			DropIndex("dbo.ShiftSignupTradeUsers", new[] { "UserId" });
			DropIndex("dbo.ShiftSignupTrades", new[] { "UserId" });
			DropIndex("dbo.ShiftSignups", new[] { "UserId" });
			DropIndex("dbo.ShiftPersons", new[] { "UserId" });
			DropIndex("dbo.ShiftGroupAssignments", new[] { "UserId" });
			DropIndex("dbo.ShiftAdmins", new[] { "UserId" });
			DropIndex("dbo.ScheduledTasks", new[] { "UserId" });
			DropIndex("dbo.PushUris", new[] { "UserId" });
			DropIndex("dbo.PersonnelCertifications", new[] { "UserId" });
			DropIndex("dbo.Payments", new[] { "PurchasingUserId" });
			DropIndex("dbo.Messages", new[] { "ReceivingUserId" });
			DropIndex("dbo.Messages", new[] { "SendingUserId" });
			DropIndex("dbo.MessageRecipients", new[] { "UserId" });
			DropIndex("dbo.LogUsers", new[] { "UserId" });
			DropIndex("dbo.Logs", new[] { "OfficerUserId" });
			DropIndex("dbo.Logs", new[] { "LoggedByUserId" });
			DropIndex("dbo.Logs", new[] { "InvestigatedByUserId" });
			DropIndex("dbo.Invites", new[] { "SendingUserId" });
			DropIndex("dbo.Inventories", new[] { "AddedByUserId" });
			DropIndex("dbo.Documents", new[] { "UserId" });
			DropIndex("dbo.DistributionListMembers", new[] { "UserId" });
			DropIndex("dbo.DepartmentProfileUserFollows", new[] { "DepartmentProfileUserId" });
			DropIndex("dbo.DepartmentProfileArticles", new[] { "CreatedByUserId" });
			DropIndex("dbo.DepartmentMembers", new[] { "UserId" });
			DropIndex("dbo.UnitStateRoles", new[] { "UserId" });
			DropIndex("dbo.CallLogs", new[] { "LoggedByUserId" });
			DropIndex("dbo.PersonnelRoleUsers", new[] { "UserId" });
			DropIndex("dbo.DepartmentGroupMembers", new[] { "UserId" });
			DropIndex("dbo.CallDispatches", new[] { "UserId" });
			DropIndex("dbo.CallNotes", new[] { "UserId" });
			DropIndex("dbo.Calls", new[] { "ClosedByUserId" });
			DropIndex("dbo.Calls", new[] { "ReportingUserId" });
			DropIndex("dbo.CalendarItemAttendees", new[] { "UserId" });
			DropIndex("dbo.Departments", new[] { "ManagingUserId" });
			DropIndex("dbo.ActionLogs", new[] { "UserId" });
			DropPrimaryKey("dbo.DepartmentProfileUsers");
			AlterColumn("dbo.UserStates", "UserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.UserProfiles", "UserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.TrainingUsers", "UserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.Trainings", "CreatedByUserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.ShiftStaffings", "AddedByUserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.ShiftStaffingPersons", "UserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.ShiftSignupTradeUsers", "UserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.ShiftSignupTrades", "UserId", c => c.Guid());
			AlterColumn("dbo.ShiftSignups", "UserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.ShiftPersons", "UserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.ShiftGroupAssignments", "UserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.ShiftAdmins", "UserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.ScheduledTasks", "UserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.PushUris", "UserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.PersonnelCertifications", "UserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.Permissions", "UpdatedBy", c => c.Guid(nullable: false));
			AlterColumn("dbo.Payments", "PurchasingUserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.Notes", "UserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.Messages", "ReceivingUserId", c => c.Guid());
			AlterColumn("dbo.Messages", "SendingUserId", c => c.Guid());
			AlterColumn("dbo.MessageRecipients", "UserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.LogUsers", "UserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.Logs", "OfficerUserId", c => c.Guid());
			AlterColumn("dbo.Logs", "LoggedByUserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.Logs", "InvestigatedByUserId", c => c.Guid());
			AlterColumn("dbo.LogAttachments", "UserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.Invites", "CompletedUserId", c => c.Guid());
			AlterColumn("dbo.Invites", "SendingUserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.Inventories", "AddedByUserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.Documents", "UserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.DistributionListMembers", "UserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.DepartmentProfileUsers", "DepartmentProfileUserId", c => c.Guid(nullable: false, identity: true));
			AlterColumn("dbo.DepartmentProfileUserFollows", "DepartmentProfileUserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.DepartmentProfileArticles", "CreatedByUserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.DepartmentMembers", "UserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.UnitStateRoles", "UserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.CallLogs", "LoggedByUserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.PersonnelRoleUsers", "UserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.DepartmentGroupMembers", "UserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.CallDispatches", "UserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.CallNotes", "UserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.Calls", "ClosedByUserId", c => c.Guid());
			AlterColumn("dbo.Calls", "ReportingUserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.CallAttachments", "UserId", c => c.Guid());
			AlterColumn("dbo.CalendarItems", "CreatorUserId", c => c.Guid());
			AlterColumn("dbo.CalendarItemAttendees", "UserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.AuditLogs", "UserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.Departments", "ManagingUserId", c => c.Guid(nullable: false));
			AlterColumn("dbo.ActionLogs", "UserId", c => c.Guid(nullable: false));
			AddPrimaryKey("dbo.DepartmentProfileUsers", "DepartmentProfileUserId");
			CreateIndex("dbo.UserStates", "UserId");
			CreateIndex("dbo.UserProfiles", "UserId");
			CreateIndex("dbo.TrainingUsers", "UserId");
			CreateIndex("dbo.ShiftStaffings", "AddedByUserId");
			CreateIndex("dbo.ShiftStaffingPersons", "UserId");
			CreateIndex("dbo.ShiftSignupTradeUsers", "UserId");
			CreateIndex("dbo.ShiftSignupTrades", "UserId");
			CreateIndex("dbo.ShiftSignups", "UserId");
			CreateIndex("dbo.ShiftPersons", "UserId");
			CreateIndex("dbo.ShiftGroupAssignments", "UserId");
			CreateIndex("dbo.ShiftAdmins", "UserId");
			CreateIndex("dbo.ScheduledTasks", "UserId");
			CreateIndex("dbo.PushUris", "UserId");
			CreateIndex("dbo.PersonnelCertifications", "UserId");
			CreateIndex("dbo.Payments", "PurchasingUserId");
			CreateIndex("dbo.Messages", "ReceivingUserId");
			CreateIndex("dbo.Messages", "SendingUserId");
			CreateIndex("dbo.MessageRecipients", "UserId");
			CreateIndex("dbo.LogUsers", "UserId");
			CreateIndex("dbo.Logs", "OfficerUserId");
			CreateIndex("dbo.Logs", "LoggedByUserId");
			CreateIndex("dbo.Logs", "InvestigatedByUserId");
			CreateIndex("dbo.Invites", "SendingUserId");
			CreateIndex("dbo.Inventories", "AddedByUserId");
			CreateIndex("dbo.Documents", "UserId");
			CreateIndex("dbo.DistributionListMembers", "UserId");
			CreateIndex("dbo.DepartmentProfileUserFollows", "DepartmentProfileUserId");
			CreateIndex("dbo.DepartmentProfileArticles", "CreatedByUserId");
			CreateIndex("dbo.DepartmentMembers", "UserId");
			CreateIndex("dbo.UnitStateRoles", "UserId");
			CreateIndex("dbo.CallLogs", "LoggedByUserId");
			CreateIndex("dbo.PersonnelRoleUsers", "UserId");
			CreateIndex("dbo.DepartmentGroupMembers", "UserId");
			CreateIndex("dbo.CallDispatches", "UserId");
			CreateIndex("dbo.CallNotes", "UserId");
			CreateIndex("dbo.Calls", "ClosedByUserId");
			CreateIndex("dbo.Calls", "ReportingUserId");
			CreateIndex("dbo.CalendarItemAttendees", "UserId");
			CreateIndex("dbo.Departments", "ManagingUserId");
			CreateIndex("dbo.ActionLogs", "UserId");
			AddForeignKey("dbo.DepartmentProfileUserFollows", "DepartmentProfileUserId", "dbo.DepartmentProfileUsers", "DepartmentProfileUserId", cascadeDelete: true);
			AddForeignKey("dbo.Logs", "LoggedByUserId", "dbo.Users", "UserId", cascadeDelete: true);
			AddForeignKey("dbo.Inventories", "AddedByUserId", "dbo.Users", "UserId", cascadeDelete: true);
		}
	}
}
