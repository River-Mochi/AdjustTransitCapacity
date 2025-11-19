// Localization/LocaleZH_CN.cs
// Simplified Chinese (zh-HANS) strings for Options UI.

namespace AdjustTransitCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleZH_CN : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleZH_CN(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Mod Title / Tabs / Groups
                { m_Setting.GetSettingsLocaleID(), "公共交通容量调整 [ATC]" },

                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "操作" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "关于" },

                { m_Setting.GetOptionGroupLocaleID(Setting.DepotGroup),
                    "车库容量（每个车库的最大车辆数）" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PassengerGroup),
                    "乘客容量（每辆车的最大乘客数）" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup), "信息" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup), "支持链接" },
                { m_Setting.GetOptionGroupLocaleID(Setting.DebugGroup), "调试 / 日志" },
                { m_Setting.GetOptionGroupLocaleID(Setting.LogGroup), "日志文件" },

                // DEPOT labels & descriptions (1.0–10.0x)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusDepotScalar)), "公交车库" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusDepotScalar)),
                    "每座 **公交车库** 可以维护 / 生成多少辆公交车。\n" +
                    "可选择 **1.0×**（原版）到 **10.0×** 的倍率。\n" +
                    "只修改**基础车库建筑**，不影响扩展建筑。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiDepotScalar)), "出租车车库" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TaxiDepotScalar)),
                    "每座 **出租车车库** 可以维护多少辆出租车。\n" +
                    "增益只作用于基础车库建筑。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramDepotScalar)), "有轨电车车库" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramDepotScalar)),
                    "每座 **电车车库** 可以维护多少辆电车。\n" +
                    "增益只作用于基础车库建筑。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainDepotScalar)), "火车车库" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainDepotScalar)),
                    "每座 **火车车库** 可以维护多少列火车。\n" +
                    "增益只作用于基础车库建筑。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayDepotScalar)), "地铁车库" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayDepotScalar)),
                    "每座 **地铁车库** 可以维护多少列地铁列车。\n" +
                    "增益只作用于基础车库建筑。" },

                // Depot reset button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetDepotToVanillaButton)), "重置所有车库" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetDepotToVanillaButton)),
                    "将所有车库恢复为 **1.0×**（游戏默认容量 / 原版）。" },

                // PASSENGER labels & descriptions (0.1–10.0x)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusPassengerScalar)), "公交乘客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusPassengerScalar)),
                    "调整 **公交车乘客** 座位数。\n" +
                    "**0.1×** = 原版座位的 10%（减少）。\n" +
                    "**1.0×** = 原版座位，默认值。\n" +
                    "**10.0×** = 十倍座位（增加）。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramPassengerScalar)), "电车乘客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramPassengerScalar)),
                    "调整 **有轨电车乘客** 最大人数。\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainPassengerScalar)), "火车乘客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainPassengerScalar)),
                    "调整 **客运火车** 的座位数（车头和车厢）。\n" +
                    "所有类型为 **Train** 的预制体一起按同一倍率调整。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayPassengerScalar)), "地铁乘客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayPassengerScalar)),
                    "调整 **地铁乘客** 最大人数。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ShipPassengerScalar)), "客船乘客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ShipPassengerScalar)),
                    "调整 **客船** 的容量（不影响货船）。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FerryPassengerScalar)), "渡轮乘客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FerryPassengerScalar)),
                    "调整 **渡轮乘客** 最大人数。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplanePassengerScalar)), "飞机乘客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AirplanePassengerScalar)),
                    "调整 **客机** 的最大乘客数。" },

                // Passenger convenience + reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DoublePassengersButton)), "全部 ×2" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DoublePassengersButton)),
                    "将所有乘客倍率设置为 **2.0×**（200%）。\n" +
                    "适用于公交、电车、火车、地铁、客船、渡轮和飞机。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetPassengerToVanillaButton)), "重置所有乘客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetPassengerToVanillaButton)),
                    "将所有乘客倍率恢复为 **1.0×**（游戏默认容量 / 原版）。" },

                // About tab: info
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)),    "模组" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),     "此模组的显示名称。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),  "当前模组版本。" },

                // About tab: links
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),
                    "打开作者模组所在的 Paradox Mods 页面。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "在浏览器中打开社区 Discord。" },

                // About tab: debug
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugLogging)), "启用详细调试日志" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugLogging)),
                    "启用后，会将大量额外调试信息写入 AdjustTransitCapacity.log。\n" +
                    "对排查问题很有帮助，但日志会非常多。\n" +
                    "正常游戏时建议 **关闭**（不要勾选）。\n" +
                    "<如果不清楚这个选项的作用，请保持 **关闭**，并且> \n" +
                    "<不要勾选此选项，因为过多日志会影响性能。>"
                },

                // About tab: log button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLogButton)), "打开日志" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLogButton)),
                    "在默认文本编辑器中打开 ATC 日志文件。" },
            };
        }

        public void Unload()
        {
        }
    }
}
