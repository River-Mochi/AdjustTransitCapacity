// LocaleFR.cs
// French (fr-FR) for Options UI.

namespace AdjustTransitCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleFR : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleFR(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // ---- MOD TITLE / TABS / GROUPS ----
                { m_Setting.GetSettingsLocaleID(), "Adjust Transit Capacity [ATC]" },

                { m_Setting.GetOptionTabLocaleID(Setting.MainTab),  "Principal" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "À propos" },

                { m_Setting.GetOptionGroupLocaleID(Setting.DepotGroup),
                    "Capacité du dépôt (véhicules max par dépôt)" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PassengerGroup),
                    "Capacité passagers (max passagers par véhicule)" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup),
                    "Infos" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup),
                    "Liens de support" },
                { m_Setting.GetOptionGroupLocaleID(Setting.DebugGroup),
                    "Débogage / Journaux" },

                // ---- DÉPÔTS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusDepotScalar)), "Dépôts de bus" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusDepotScalar)),
                    "Nombre de bus que chaque dépôt de bus peut gérer.\n" +
                    "Utilisez un multiplicateur entre **1,0×** (vanilla) et **10,0×**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiDepotScalar)), "Dépôts de taxis" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TaxiDepotScalar)),
                    "Nombre de taxis que chaque dépôt peut gérer (1,0× – 10,0×)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramDepotScalar)), "Dépôts de tram" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramDepotScalar)),
                    "Nombre de trams que chaque dépôt peut gérer (1,0× – 10,0×)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainDepotScalar)), "Dépôts de trains" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainDepotScalar)),
                    "Nombre de trains que chaque dépôt peut gérer (1,0× – 10,0×)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayDepotScalar)), "Dépôts de métro" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayDepotScalar)),
                    "Nombre de rames de métro que chaque dépôt peut gérer (1,0× – 10,0×)." },

                // ---- PASSAGERS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusPassengerScalar)), "Passagers – bus" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusPassengerScalar)),
                    "Multiplicateur pour les sièges passagers des bus.\n" +
                    "**1,0×** = capacité vanilla, **10,0×** = dix fois plus de sièges." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramPassengerScalar)), "Passagers – tram" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramPassengerScalar)),
                    "Multiplicateur pour les sièges passagers des trams (1,0× – 10,0×)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainPassengerScalar)), "Passagers – train" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainPassengerScalar)),
                    "Multiplicateur pour les sièges passagers des trains (1,0× – 10,0×)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayPassengerScalar)), "Passagers – métro" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayPassengerScalar)),
                    "Multiplicateur pour les sièges passagers du métro (1,0× – 10,0×)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ShipPassengerScalar)), "Passagers – navire" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ShipPassengerScalar)),
                    "Multiplicateur pour les navires **de passagers** uniquement (pas les cargos)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FerryPassengerScalar)), "Passagers – ferry" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FerryPassengerScalar)),
                    "Multiplicateur pour la capacité des ferries." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplanePassengerScalar)), "Passagers – avion" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AirplanePassengerScalar)),
                    "Multiplicateur pour la capacité des avions de passagers." },

                // ---- À PROPOS : INFOS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),     "Nom affiché de ce mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),  "Version actuelle du mod." },

                // ---- À PROPOS : LIENS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),
                    "Ouvrir ce mod sur le site Paradox Mods dans un navigateur." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Ouvrir le serveur Discord de la communauté dans un navigateur." },

                // ---- DÉBOGAGE ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugLogging)), "Activer les journaux de débogage" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugLogging)),
                    "Lorsque cette option est activée, le mod écrit des détails supplémentaires " +
                    "sur les capacités dans le journal du jeu.\n" +
                    "Utile pour le dépannage, mais peut remplir le journal." },
            };
        }

        public void Unload()
        {
        }
    }
}
