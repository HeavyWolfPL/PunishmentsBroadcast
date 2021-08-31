using Exiled.API.Interfaces;
using System.ComponentModel;

namespace PunishmentsBroadcast
{
    public class Translation : ITranslation
    {
        [Description("Do not put dots at the end!")]
        public string Player { get; set; } = "Player";
        public string hasBeenBanned { get; set; } = "has been banned";
        [Description("For how long")]
        public string ForLong { get; set; } = "For";
        public string ForWhat { get; set; } = "for";
        public string Staff { get; set; } = "Administrator";
        public string NoReason { get; set; } = "No Reason";

    }
}
