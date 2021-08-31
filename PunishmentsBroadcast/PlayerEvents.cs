using Exiled.API.Features;
using Exiled.Events.EventArgs;
using TimeFormatter = PunishmentsBroadcast.Functions.TimeFormat;

namespace PunishmentsBroadcast
{
    public class PlayerEvents
    {
		public Plugin plugin;
		public PlayerEvents(Plugin plugin) => this.plugin = plugin;

		Exiled.API.Features.Broadcast broadcast = new Exiled.API.Features.Broadcast($"<color=red>[PunishmentsBroadcast] Broadcast couldn't be retrieved from config</color>", 10, true, Broadcast.BroadcastFlags.Normal);

		public void OnPlayerBanned(BanningEventArgs ev)
		{
            if (Plugin.Singleton.Config.Banned)
            {
				string duration = TimeFormatter.TimeFormatter(ev.Duration);
				if (ev.Reason == "") ev.Reason = Plugin.Singleton.Translation.NoReason;
				broadcast = new Exiled.API.Features.Broadcast($"<color=green>|</color> {Plugin.Singleton.Translation.Player} <color=#bb00ff>{ev.Target.Nickname}</color> {Plugin.Singleton.Translation.hasBeenBanned} <color=green>|</color> \n<color=green>|</color> {Plugin.Singleton.Translation.ForLong} <color=orange>{duration}</color> {Plugin.Singleton.Translation.ForWhat} <color=orange>{ev.Reason}</color> <color=green>|</color> \n<color=green>|</color> {Plugin.Singleton.Translation.Staff} <color=red>{ev.Issuer.Nickname}</color> <color=green>|</color>", Plugin.Singleton.Config.BannedTime, true, Broadcast.BroadcastFlags.Normal);
				Map.Broadcast(broadcast, false);
			}
            Log.Info($"Player banned for '{ev.Reason}'");
		}

		public void OnPlayerKicking(KickingEventArgs ev)
		{
			if (Plugin.Singleton.Config.Kicked)
            {
				if (ev.Reason == "") ev.Reason = Plugin.Singleton.Translation.NoReason;
				broadcast = new Exiled.API.Features.Broadcast($"<color=green>|</color> {Plugin.Singleton.Translation.Player} <color=#bb00ff>{ev.Target.Nickname}</color> {Plugin.Singleton.Translation.hasBeenBanned} <color=green>|</color> \n<color=green>|</color> {Plugin.Singleton.Translation.ForWhat} <color=orange>{ev.Reason}</color> <color=green>|</color> \n<color=green>|</color> {Plugin.Singleton.Translation.Staff} <color=red>{ev.Issuer.Nickname}</color> <color=green>|</color>", Plugin.Singleton.Config.BannedTime, true, Broadcast.BroadcastFlags.Normal);
				Map.Broadcast(broadcast, false);
			}
		}
	}
}
