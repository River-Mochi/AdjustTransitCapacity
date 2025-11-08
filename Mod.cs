// Mod.cs
// Entrypoint for Adjust Transit Capacity; registers settings, locales, and the ECS system.

namespace AdjustTransitCapacity
{
    using Colossal.IO.AssetDatabase;
    using Colossal.Logging;
    using Game;
    using Game.Modding;
    using Game.SceneFlow;
    using Unity.Entities;

    /// <summary>Mod entry point: registers settings, locales, and ECS system.</summary>
    public sealed class Mod : IMod
    {
        public const string ModName = "Adjust Transit Capacity";
        public const string ModId = "AdjustTransitCapacity";
        public const string ModTag = "[ATC]";
        public const string ModVersion = "1.2.7";

        private static bool s_BannerLogged;

        public static readonly ILog Log =
            LogManager.GetLogger(ModId).SetShowsErrorsInUI(false);

        public static Setting? Settings;

        public void OnLoad(UpdateSystem updateSystem)
        {
            Log.Info($"{ModName} v{ModVersion} OnLoad");
            if (!s_BannerLogged)
            {
                s_BannerLogged = true;
            }

            var setting = new Setting(this);
            Settings = setting;

            var lm = GameManager.instance?.localizationManager;
            if (lm != null)
            {
                lm.AddSource("en-US", new LocaleEN(setting));
                lm.AddSource("fr-FR", new LocaleFR(setting));
                lm.AddSource("es-ES", new LocaleES(setting));
                lm.AddSource("de-DE", new LocaleDE(setting));
                lm.AddSource("zh-HANS", new LocaleZH(setting));
            }
            else
            {
                Log.Warn($"{ModTag} LocalizationManager not found; settings UI texts may be missing.");
            }

            AssetDatabase.global.LoadSettings(ModId, setting, new Setting(this));

            setting.RegisterInOptionsUI();

            // Scheduled after PrefabUpdate so prefab data and components are initialized.
            updateSystem.UpdateAfter<AdjustTransitCapacitySystem>(SystemUpdatePhase.PrefabUpdate);

            // Enable once for an already-running city (if any city exists).
            World world = World.DefaultGameObjectInjectionWorld;
            if (world != null)
            {
                var system = world.GetExistingSystemManaged<AdjustTransitCapacitySystem>();
                if (system != null)
                {
                    system.Enabled = true;
                }
            }
        }

        public void OnDispose()
        {
            Log.Info("OnDispose");

            if (Settings != null)
            {
                Settings.UnregisterInOptionsUI();
                Settings = null;
            }
        }
    }
}
