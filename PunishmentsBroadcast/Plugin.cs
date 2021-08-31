using Exiled.API.Features;
using Handlers = Exiled.Events.Handlers;
using System;

namespace PunishmentsBroadcast
{
	public class Plugin : Plugin<Config, Translation>
	{
		public override string Author { get; } = "Wafel";
		public override string Name { get; } = "PunishmentsBroadcast";
		public override string Prefix { get; } = "PB";
		public override Version Version { get; } = new Version(1, 0, 0);
		public override Version RequiredExiledVersion { get; } = new Version(2, 14, 0);


		public static Plugin Singleton;
		public PlayerEvents PlayerEvents;

		public override void OnEnabled()
		{
			if (!Config.IsEnabled) return;

			base.OnEnabled();

			Singleton = this;
			PlayerEvents = new PlayerEvents(this);

            Handlers.Player.Banning += PlayerEvents.OnPlayerBanned;
			Handlers.Player.Kicking += PlayerEvents.OnPlayerKicking;
		}

		public override void OnDisabled()
		{
			base.OnDisabled();

			Handlers.Player.Banning -= PlayerEvents.OnPlayerBanned;
			Handlers.Player.Kicking -= PlayerEvents.OnPlayerKicking;

			PlayerEvents = null;

		}
	}
}
