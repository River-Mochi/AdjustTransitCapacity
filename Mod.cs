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

    public sealed class Mod : IMod
    {
        public const string ModName = "Adjust Transit Capacity";
        public const string ModId = "AdjustTransitCapacity";
        public const string ModTag = "[ATC]";
        public const string ModVersion = "1.2.3";

        public static readonly ILog Log =
            LogManager.GetLogger(ModId).SetShowsErrorsInUI(false);

        public static Setting? Settings;

        public void OnLoad(UpdateSystem updateSystem)
        {
            Log.Info($"{ModName} v{ModVersion} OnLoad");

            // 1) create settings
            Setting setting = new Setting(this);
            Settings = setting;

            // 2) register locales
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
                Log.Warn("LocalizationManager not found; settings UI texts may be missing.");
            }

            // 3) load saved settings from fixed path
            AssetDatabase.global.LoadSettings(ModId, setting, new Setting(this));

            // 4) show in Options
            setting.RegisterInOptionsUI();

            // 5) make sure ECS system runs after prefab data is ready
            updateSystem.UpdateAfter<AdjustTransitCapacitySystem>(SystemUpdatePhase.PrefabUpdate);

            // 6) if a world is already running, apply once right now
            World world = World.DefaultGameObjectInjectionWorld;
            if (world != null)
            {
                AdjustTransitCapacitySystem system = world.GetExistingSystemManaged<AdjustTransitCapacitySystem>();
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
