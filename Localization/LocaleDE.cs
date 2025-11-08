// LocaleDE.cs
// German (de-DE) for Options UI.

namespace AdjustTransitCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleDE : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleDE(Setting setting)
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

                { m_Setting.GetOptionTabLocaleID(Setting.MainTab),  "Aktionen" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "Info" },

                { m_Setting.GetOptionGroupLocaleID(Setting.DepotGroup),
                    "Depotkapazität (max. Fahrzeuge pro Depot)" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PassengerGroup),
                    "Passagierkapazität (max. Fahrgäste pro Fahrzeug)" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup),
                    "Informationen" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup),
                    "Support-Links" },
                { m_Setting.GetOptionGroupLocaleID(Setting.DebugGroup),
                    "Debug / Logging" },

                // ---- DEPOTS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusDepotScalar)), "Busdepots" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusDepotScalar)),
                    "Wie viele Busse jedes Busdepot warten/spawnen kann.\n" +
                    "Verwende einen Multiplikator zwischen **1,0×** (Vanilla) und **10,0×**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiDepotScalar)), "Taxidepots" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TaxiDepotScalar)),
                    "Wie viele Taxis jedes Depot warten kann (1,0× – 10,0×)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramDepotScalar)), "Straßenbahndepots" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramDepotScalar)),
                    "Wie viele Straßenbahnen jedes Depot warten kann (1,0× – 10,0×)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainDepotScalar)), "Zugdepots" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainDepotScalar)),
                    "Wie viele Züge jedes Depot warten kann (1,0× – 10,0×)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayDepotScalar)), "U-Bahn-Depots" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayDepotScalar)),
                    "Wie viele U-Bahn-Züge jedes Depot warten kann (1,0× – 10,0×)." },

                // ---- PASSAGIERE ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusPassengerScalar)), "Fahrgäste – Bus" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusPassengerScalar)),
                    "Multiplikator für die Sitzplatzkapazität von Bussen.\n" +
                    "**1,0×** = Vanilla, **10,0×** = zehnmal so viele Plätze." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramPassengerScalar)), "Fahrgäste – Straßenbahn" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramPassengerScalar)),
                    "Multiplikator für die Sitzplatzkapazität von Straßenbahnen (1,0× – 10,0×)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainPassengerScalar)), "Fahrgäste – Zug" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainPassengerScalar)),
                    "Multiplikator für die Sitzplatzkapazität von Zügen (1,0× – 10,0×)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayPassengerScalar)), "Fahrgäste – U-Bahn" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayPassengerScalar)),
                    "Multiplikator für die Sitzplatzkapazität der U-Bahn (1,0× – 10,0×)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ShipPassengerScalar)), "Fahrgäste – Schiff" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ShipPassengerScalar)),
                    "Multiplikator nur für **Passagierschiffe** (keine Frachtschiffe)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FerryPassengerScalar)), "Fahrgäste – Fähre" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FerryPassengerScalar)),
                    "Multiplikator für die Kapazität von Fähren." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplanePassengerScalar)), "Fahrgäste – Flugzeug" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AirplanePassengerScalar)),
                    "Multiplikator für die Kapazität von Passagierflugzeugen." },

                // ---- INFO ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),     "Anzeigename dieses Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),  "Aktuelle Mod-Version." },

                // ---- LINKS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),
                    "Öffnet diesen Mod auf der Paradox-Mods-Seite im Browser." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Öffnet den Community-Discord im Browser." },

                // ---- DEBUG ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugLogging)), "Debug-Logging aktivieren" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugLogging)),
                    "Wenn aktiviert, schreibt der Mod zusätzliche Details zu Kapazitäten " +
                    "in das Spielprotokoll.\n" +
                    "Nützlich zum Debuggen, kann das Log aber füllen." },
            };
        }

        public void Unload()
        {
        }
    }
}
