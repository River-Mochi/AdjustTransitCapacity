// LocaleES.cs
// Spanish (es-ES) for Options UI.

namespace AdjustTransitCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleES : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleES(Setting setting)
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

                { m_Setting.GetOptionGroupLocaleID(Setting.DepotGroup), "Capacidad del depósito" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PassengerGroup), "Capacidad de pasajeros" },

                // ---- DEPOT LABELS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusDepotPercent)), "Depósitos de autobuses" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiDepotPercent)), "Depósitos de taxis" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramDepotPercent)), "Depósitos de tranvías" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainDepotPercent)), "Depósitos de trenes" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayDepotPercent)), "Depósitos de metro" },

                // ---- PASSENGER LABELS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusPassengerPercent)), "Pasajeros – autobús" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramPassengerPercent)), "Pasajeros – tranvía" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainPassengerPercent)), "Pasajeros – tren" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayPassengerPercent)), "Pasajeros – metro" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ShipPassengerPercent)), "Pasajeros – barco" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FerryPassengerPercent)), "Pasajeros – ferry" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplanePassengerPercent)), "Pasajeros – avión" },
            };
        }

        public void Unload()
        {
        }
    }
}
