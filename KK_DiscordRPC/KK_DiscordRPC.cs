using System;
using BepInEx;
using BepInEx.Logging;
using KKAPI;

namespace KK_DiscordRPC
{
    [BepInPlugin(GUID, "Koikatsu: Discord Rich Presence", Version)]
    [BepInDependency(KoikatuAPI.GUID, KoikatuAPI.VersionConst)]
    public class Koi_DiscordRPC : BaseUnityPlugin
    {
        public const string GUID = "varkaria.DiscordRPC";
        public const string Version = "1.0";

        // internal static Koi_DiscordRPC Instance;
        internal static DiscordRPC.RichPresence prsnc;
        internal new static ManualLogSource Logger;

        // public static readonly DiscordRpc.RichPresence Presence = new DiscordRpc.RichPresence();

        private void Awake()
        {
            // Instance = this;
            Logger = base.Logger;

            var handlers = new DiscordRPC.EventHandlers();
            DiscordRPC.Initialize(
                "676435940499128350",
                ref handlers,
                false,
                "643270");

            Console.WriteLine("Current gamemode is {0}", KoikatuAPI.GetCurrentGameMode());
            SetStatus();
            Logger.LogInfo("Status Set");
        }
        static void SetStatus()
        {
            prsnc.state = "Main Menu";
            prsnc.details = "Testing DiscordRPC for KK";
            prsnc.startTimestamp = 0;
            prsnc.largeImageKey = null;
            prsnc.largeImageText = "this is a test";
            prsnc.smallImageKey = null;
            prsnc.smallImageText = null;
            prsnc.partySize = 0;
            prsnc.partyMax = 0;
            DiscordRPC.UpdatePresence(ref prsnc);
        }
    }
}