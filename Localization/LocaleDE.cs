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
                // ---- MOD TITLE / TAB / GROUPS ----
                { m_Setting.GetSettingsLocaleID(), "Adjust Transit Capacity" },
                { m_Setting.GetOptionTabLocaleID(Setting.MainTab), "Hauptmenü" },

                { m_Setting.GetOptionGroupLocaleID(Setting.DepotGroup), "Depotkapazität" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PassengerGroup), "Passagierkapazität" },

                // ---- DEPOT LABELS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusDepotPercent)), "Busdepots" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiDepotPercent)), "Taxidepots" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramDepotPercent)), "Straßenbahndepots" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainDepotPercent)), "Zugdepots" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayDepotPercent)), "U-Bahn-Depots" },

                // ---- PASSENGER LABELS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusPassengerPercent)), "Fahrgäste – Bus" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramPassengerPercent)), "Fahrgäste – Straßenbahn" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainPassengerPercent)), "Fahrgäste – Zug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayPassengerPercent)), "Fahrgäste – U-Bahn" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ShipPassengerPercent)), "Fahrgäste – Schiff" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FerryPassengerPercent)), "Fahrgäste – Fähre" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplanePassengerPercent)), "Fahrgäste – Flugzeug" },
            };
        }

        public void Unload()
        {
        }
    }
}
