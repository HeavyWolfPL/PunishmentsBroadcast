using Exiled.API.Interfaces;
using System.ComponentModel;

namespace PunishmentsBroadcast
{
	public class Config : IConfig
	{
		public bool IsEnabled { get; set; } = true;
		[Description("Kick broadcast")]
		public bool Kicked { get; set; } = true;
		public ushort KickedTime { get; set; } = 15;
		[Description("Ban broadcast")]
		public bool Banned { get; set; } = true;
		public ushort BannedTime { get; set; } = 15;


	}
}
