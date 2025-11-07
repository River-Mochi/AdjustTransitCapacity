// LocaleEN.cs
// English (en-US) for Options UI.

namespace AdjustTransitCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleEN : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleEN(Setting setting)
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
                { m_Setting.GetSettingsLocaleID(), "Adjust Transit Capacity [ATC]" },
                { m_Setting.GetOptionTabLocaleID(Setting.MainTab), "Main" },

                { m_Setting.GetOptionGroupLocaleID(Setting.DepotGroup), "Depot capacity (max vehicles per depot)" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PassengerGroup), "Passenger capacity (max riders per vehicle)" },

                // ---- DEPOT LABELS & DESCRIPTIONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusDepotPercent)), "Bus depots" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusDepotPercent)), "How many buses each bus depot can maintain/spawn. 100% = vanilla, 1000% = 10×." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiDepotPercent)), "Taxi depots" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TaxiDepotPercent)), "How many taxis each taxi depot can maintain." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramDepotPercent)), "Tram depots" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramDepotPercent)), "How many trams each tram depot can maintain." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainDepotPercent)), "Train depots" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainDepotPercent)), "How many trains each train depot can maintain." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayDepotPercent)), "Subway depots" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayDepotPercent)), "How many subway vehicles each depot can maintain." },

                // ---- PASSENGER LABELS & DESCRIPTIONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusPassengerPercent)), "Bus passengers" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusPassengerPercent)), "Multiplier for bus passenger seats. 100% = vanilla seats, 1000% = 10× seats." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramPassengerPercent)), "Tram passengers" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramPassengerPercent)), "Multiplier for tram passenger seats." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainPassengerPercent)), "Train passengers" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainPassengerPercent)), "Multiplier for train passenger seats." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayPassengerPercent)), "Subway passengers" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayPassengerPercent)), "Multiplier for subway passenger seats." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ShipPassengerPercent)), "Ship passengers" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ShipPassengerPercent)), "Multiplier for passenger ships only (not cargo ships)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FerryPassengerPercent)), "Ferry passengers" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FerryPassengerPercent)), "Multiplier for ferries." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplanePassengerPercent)), "Airplane passengers" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AirplanePassengerPercent)), "Multiplier for passenger airplanes." },
            };
        }

        public void Unload()
        {
        }
    }
}
