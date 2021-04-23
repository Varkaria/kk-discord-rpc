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

        internal static DiscordRPC.RichPresence prsnc;
        internal new static ManualLogSource Logger;

        private void Awake()
        {
            Logger = base.Logger;

            var handlers = new DiscordRPC.EventHandlers();
            DiscordRPC.Initialize(
                "835112124295806987",
                ref handlers,
                false,
                "643270");

            switch (KoikatuAPI.GetCurrentGameMode())
            {
                case GameMode.Unknown:
                    SetStatus("Koikatsu","Playing something", "studio", "Main game");
                    break;
                case GameMode.Maker:
                    SetStatus("Koikatsu","Making a cute character", "main", "CharaStudio");
                    break;
                case GameMode.Studio:
                    SetStatus("CharaStudio","Making a picture", "studio", "Koikatsu");
                    break;
                case GameMode.MainGame:
                    SetStatus("Koikatsu","Playing inside the main game", "studio", "Main game");
                    break;
                default:
                    SetStatus("Koikatsu","Playing something", "studio", "Main game");
                    break;
            }
        }
        static void SetStatus(string mode, string status, string img, string img_text)
        {
            prsnc.state = mode;
            prsnc.details = status;
            prsnc.startTimestamp = 0;
            prsnc.largeImageKey = img;
            prsnc.largeImageText = img_text;
            prsnc.smallImageKey = null;
            prsnc.smallImageText = null;
            prsnc.partySize = 0;
            prsnc.partyMax = 0;
            DiscordRPC.UpdatePresence(ref prsnc);
        }
    }
}