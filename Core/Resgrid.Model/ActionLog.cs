﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework6;
using System.Linq;
using ProtoBuf;

namespace Resgrid.Model
{
	[Table("ActionLogs")]
	[ProtoContract]
	public class ActionLog : IEntity
	{
		[Key]
		[Required]
		[ProtoMember(1)]
		public int ActionLogId { get; set; }

		[Required]
		[ProtoMember(2)]
		public string UserId { get; set; }

		[Required]
		[ProtoMember(3)]
		public int DepartmentId { get; set; }

		[Required]
		[ProtoMember(4)]
		public int ActionTypeId { get; set; }

		[Required]
		[ProtoMember(5)]
		public DateTime Timestamp { get; set; }

		[ProtoMember(6)]
		public string GeoLocationData { get; set; }

		[ProtoMember(7)]
		public int? DestinationId { get; set; }

		[ProtoMember(8)]
		public int? DestinationType { get; set; }

		[ProtoMember(9)]
		public string Note { get; set; }

		[NotMapped]
		[ProtoMember(10)]
		public double Eta { get; set; }

		[NotMapped]
		[ProtoMember(11)]
		public DateTime? EtaPulledOn { get; set; }

		[ForeignKey("UserId")]
		public virtual IdentityUser User { get; set; }

		[ForeignKey("DepartmentId")]
		public virtual Department Department { get; set; }

		[NotMapped]
		public object Id
		{
			get { return ActionLogId; }
			set { ActionLogId = (int)value; }
		}

		public string GetActionText()
		{
			switch (((ActionTypes)ActionTypeId))
			{
				case ActionTypes.StandingBy:
					return "Standing By";
				case ActionTypes.NotResponding:
					return "Not Responding";
				case ActionTypes.Responding:
					return "Responding";
				case ActionTypes.OnScene:
					return "On Scene";
				case ActionTypes.AvailableStation:
					return "Available Station";
				case ActionTypes.RespondingToStation:
					return "Responding to Station";
				case ActionTypes.RespondingToScene:
					return "Responding to Scene";
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public string GetActionCss()
		{
			switch (((ActionTypes)ActionTypeId))
			{
				case ActionTypes.StandingBy:
					return "label-default";
				case ActionTypes.NotResponding:
					return "label-danger";
				case ActionTypes.Responding:
					return "label-success";
				case ActionTypes.OnScene:
					return "label-inverse";
				case ActionTypes.AvailableStation:
					return "label-default";
				case ActionTypes.RespondingToStation:
					return "label-success";
				case ActionTypes.RespondingToScene:
					return "label-success";
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public Coordinates GetCoordinates()
		{
			if (!String.IsNullOrWhiteSpace(GeoLocationData))
			{
				string[] values = GeoLocationData.Split(char.Parse(","));

				if (values != null && values.Count() == 2)
				{
					var coordinates = new Coordinates();
					coordinates.Latitude = double.Parse(values[0]);
					coordinates.Longitude = double.Parse(values[1]);

					return coordinates;
				}
			}

			return null;
		}
	}

	public class ActionLog_Mapping : EntityTypeConfiguration<ActionLog>
	{
		public ActionLog_Mapping()
		{
			this.HasRequired(t => t.Department).WithMany().HasForeignKey(t => t.DepartmentId).WillCascadeOnDelete(false);
		}
	}


	public static class ActionLogExtensions
	{
		public static int GetWeightForAction(this ActionLog actionLog)
		{
			if (actionLog == null)
				return 10;

			if (actionLog.ActionTypeId == (int)ActionTypes.StandingBy)
				return 10;
			else if (actionLog.ActionTypeId == (int)ActionTypes.Responding)
				return 1;
			else if (actionLog.ActionTypeId == (int)ActionTypes.RespondingToStation)
				return 1;
			else if (actionLog.ActionTypeId == (int)ActionTypes.RespondingToScene)
				return 1;
			else if (actionLog.ActionTypeId == (int)ActionTypes.OnScene)
				return 2;
			else if (actionLog.ActionTypeId == (int)ActionTypes.NotResponding)
				return 3;
			else if (actionLog.ActionTypeId == (int)ActionTypes.AvailableStation)
				return 4;

			return 10;
		}

	}
}