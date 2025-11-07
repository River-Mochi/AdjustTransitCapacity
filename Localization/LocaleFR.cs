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
                // ---- MOD TITLE / TAB / GROUPS ----
                { m_Setting.GetSettingsLocaleID(), "Adjust Transit Capacity" },
                { m_Setting.GetOptionTabLocaleID(Setting.MainTab), "Principal" },

                { m_Setting.GetOptionGroupLocaleID(Setting.DepotGroup), "Capacité du dépôt" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PassengerGroup), "Capacité passagers" },

                // ---- DEPOT LABELS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusDepotPercent)), "Dépôts de bus" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiDepotPercent)), "Dépôts de taxis" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramDepotPercent)), "Dépôts de tram" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainDepotPercent)), "Dépôts de trains" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayDepotPercent)), "Dépôts de métro" },

                // ---- PASSENGER LABELS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusPassengerPercent)), "Passagers – bus" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramPassengerPercent)), "Passagers – tram" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainPassengerPercent)), "Passagers – train" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayPassengerPercent)), "Passagers – métro" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ShipPassengerPercent)), "Passagers – navire" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FerryPassengerPercent)), "Passagers – ferry" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplanePassengerPercent)), "Passagers – avion" },
            };
        }

        public void Unload()
        {
        }
    }
}
