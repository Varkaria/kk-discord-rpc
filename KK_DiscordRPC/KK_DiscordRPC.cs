using System;
using BepInEx;
using BepInEx.Logging;
using DiscordRPC;

namespace KK_DiscordRPC
{
    [BepInPlugin(GUID, "Koikatsu: Discord Rich Presence", Version)]
    [BepInDependency(KKAPI.KoikatuAPI.GUID, KKAPI.KoikatuAPI.VersionConst)]
    public partial class Koi_DiscordRPC : BaseUnityPlugin
    {
        public const string GUID = "varkaria.DiscordRPC";
        public const string Version = "1.0";

        internal static Koi_DiscordRPC Instance;
        internal static new ManualLogSource Logger;
        
        public static readonly DiscordRpc.RichPresence Presence = new DiscordRpc.RichPresence();

        private void Awake()
        {
            Instance = this;
            Logger = base.Logger;
            
            var handlers = new DiscordRpc.EventHandlers();
            DiscordRpc.Initialize(
                "604588957208150016",
                ref handlers,
                false,
                "643270");

            Console.WriteLine("Current gamemode is {0}", KKAPI.KoikatuAPI.GetCurrentGameMode());
        }
    }
}
