// Mod.cs
// Entrypoint: registers settings, locales, and the ECS system.

namespace AdjustTransitCapacity
{
    using System.Reflection;            // Metadata: Assembly version
    using Colossal.IO.AssetDatabase;    // AssetDatabase.LoadSettings
    using Colossal.Localization;        // LocalizationManager
    using Colossal.Logging;             // ILog, defines shared s_Log
    using Game;                         // UpdateSystem, GameManager
    using Game.Modding;                 // IMod, ModSetting base
    using Game.SceneFlow;               // GameMode, GameManager access
    using Unity.Entities;               // World, ECS system registration


    /// <summary>Mod entry point: registers settings, locales, and ECS system.</summary>
    public sealed class Mod : IMod
    {
        // ---- PUBLIC CONSTANTS / METADATA ----
        public const string ModName = "Adjust Transit Capacity";
        public const string ModId = "AdjustTransitCapacity";
        public const string ModTag = "[ATC]";

        /// <summary>
        /// Read Version from .csproj (3-part).
        /// </summary>
        public static readonly string ModVersion =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "1.0.0";


        private static bool s_BannerLogged;

        // ----- Logger & public properties -----
        public static readonly ILog s_Log =
           LogManager.GetLogger(ModId).SetShowsErrorsInUI(false);

        public static Setting? Settings;

        public void OnLoad(UpdateSystem updateSystem)
        {
            // metadata banner (once)
            if (!s_BannerLogged)
            {
                s_BannerLogged = true;
               s_Log.Info($"{ModName} v{ModVersion} OnLoad");
            }

            Setting setting = new Setting(this);
            Settings = setting;

            // Register languages here
            LocalizationManager? lm = GameManager.instance?.localizationManager;
            if (lm != null)
            {
                lm.AddSource("en-US", new LocaleEN(setting));
                lm.AddSource("fr-FR", new LocaleFR(setting));
                lm.AddSource("es-ES", new LocaleES(setting));
                lm.AddSource("de-DE", new LocaleDE(setting));
                lm.AddSource("it-IT", new LocaleIT(setting));
                lm.AddSource("ja-JP", new LocaleJA(setting));
                lm.AddSource("ko-KR", new LocaleKO(setting));
                lm.AddSource("pt-BR", new LocalePT_BR(setting));
                lm.AddSource("zh-HANS", new LocaleZH_CN(setting));   // Simplified Chinese
                lm.AddSource("zh-HANT", new LocaleZH_HANT(setting)); // Traditional Chinese


            }
            else
            {
               s_Log.Warn($"{ModTag} LocalizationManager not found; settings UI texts may be missing.");
            }

            AssetDatabase.global.LoadSettings(ModId, setting, new Setting(this));

            setting.RegisterInOptionsUI();

            // Scheduled after PrefabUpdate so prefab data and components are initialized.
            updateSystem.UpdateAfter<AdjustTransitCapacitySystem>(SystemUpdatePhase.PrefabUpdate);

            // If the mod is loaded while a city is already running, apply once.
            // In main menu, stay idle
            // First real run in OnGameLoadingComplete.
            GameManager? gm = GameManager.instance;
            if (gm != null && gm.gameMode.IsGame())
            {
                World world = World.DefaultGameObjectInjectionWorld;
                if (world != null)
                {
                    AdjustTransitCapacitySystem system =
                        world.GetExistingSystemManaged<AdjustTransitCapacitySystem>();
                    if (system != null)
                    {
                        system.Enabled = true;
                    }
                }
            }
        }

        public void OnDispose()
        {
           s_Log.Info("OnDispose");

            if (Settings != null)
            {
                Settings.UnregisterInOptionsUI();
                Settings = null;
            }
        }
    }
}
