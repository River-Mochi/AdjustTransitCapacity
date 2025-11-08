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
                // ---- MOD TITLE / TABS / GROUPS ----
                { m_Setting.GetSettingsLocaleID(), "公共交通容量调整 [ATC]" },

                { m_Setting.GetOptionTabLocaleID(Setting.MainTab),  "主要" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "关于" },

                { m_Setting.GetOptionGroupLocaleID(Setting.DepotGroup),     "车库容量（每个车库的最大车辆数）" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PassengerGroup), "乘客容量（每辆车的最大乘客数）" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup), "信息" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup),"支持链接" },
                { m_Setting.GetOptionGroupLocaleID(Setting.DebugGroup),     "调试 / 日志" },

                // ---- 车库 ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusDepotScalar)), "公交车车库" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusDepotScalar)),
                    "每个公交车车库可以维护/生成的公交车数量。\n" +
                    "使用 **1.0×**（原版）到 **10.0×** 之间的倍数。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiDepotScalar)), "出租车车库" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TaxiDepotScalar)),
                    "每个出租车车库可以维护的出租车数量（1.0× – 10.0×）。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramDepotScalar)), "有轨电车车库" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramDepotScalar)),
                    "每个车库可以维护的有轨电车数量（1.0× – 10.0×）。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainDepotScalar)), "火车车库" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainDepotScalar)),
                    "每个车库可以维护的火车数量（1.0× – 10.0×）。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayDepotScalar)), "地铁车库" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayDepotScalar)),
                    "每个车库可以维护的地铁车辆数量（1.0× – 10.0×）。" },

                // ---- 乘客 ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusPassengerScalar)), "公交车乘客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusPassengerScalar)),
                    "公交车乘客座位数量的倍数。\n" +
                    "**1.0×** = 原版容量，**10.0×** = 原版的十倍。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramPassengerScalar)), "有轨电车乘客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramPassengerScalar)),
                    "有轨电车乘客容量倍数（1.0× – 10.0×）。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainPassengerScalar)), "火车乘客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainPassengerScalar)),
                    "火车乘客容量倍数（1.0× – 10.0×）。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayPassengerScalar)), "地铁乘客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayPassengerScalar)),
                    "地铁乘客容量倍数（1.0× – 10.0×）。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ShipPassengerScalar)), "客运船乘客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ShipPassengerScalar)),
                    "仅对**客运船**生效（不影响货船）的乘客容量倍数。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FerryPassengerScalar)), "渡轮乘客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FerryPassengerScalar)),
                    "渡轮乘客容量倍数。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplanePassengerScalar)), "飞机乘客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AirplanePassengerScalar)),
                    "客机乘客容量倍数。" },

                // ---- 关于：信息 ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)),    "模组" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),     "此模组在选项菜单中的名称。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),  "当前模组版本。" },

                // ---- 关于：链接 ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),
                    "在浏览器中打开 Paradox Mods 网站上的此模组页面。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "在浏览器中打开社区 Discord 服务器。" },

                // ---- 调试 ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugLogging)), "启用调试日志" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugLogging)),
                    "启用后，模组会在游戏日志中写入更多容量相关的详细信息。\n" +
                    "对排查问题很有用，但可能会产生大量日志。" },
            };
        }

        public void Unload()
        {
        }
    }
}
