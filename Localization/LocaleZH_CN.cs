// LocaleZH.cs
// Simplified Chinese (zh-HANS) for Options UI.

namespace AdjustTransitCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleZH : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleZH(Setting setting)
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
                { m_Setting.GetSettingsLocaleID(), "公共交通容量调整" },
                { m_Setting.GetOptionTabLocaleID(Setting.MainTab), "主要" },

                { m_Setting.GetOptionGroupLocaleID(Setting.DepotGroup), "车库容量" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PassengerGroup), "乘客数量" },

                // ---- DEPOT LABELS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusDepotPercent)), "公交车车库" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiDepotPercent)), "出租车车库" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramDepotPercent)), "有轨电车车库" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainDepotPercent)), "火车车库" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayDepotPercent)), "地铁车库" },

                // ---- PASSENGER LABELS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusPassengerPercent)), "公交车乘客" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramPassengerPercent)), "有轨电车乘客" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainPassengerPercent)), "火车乘客" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayPassengerPercent)), "地铁乘客" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ShipPassengerPercent)), "客运船乘客" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FerryPassengerPercent)), "渡轮乘客" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplanePassengerPercent)), "飞机乘客" },
            };
        }

        public void Unload()
        {
        }
    }
}
