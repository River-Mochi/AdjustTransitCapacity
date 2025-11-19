// Localization/LocaleZH_HANT.cs
// Traditional Chinese (zh-HANT) strings for Options UI.

namespace AdjustTransitCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleZH_HANT : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleZH_HANT(Setting setting)
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
                { m_Setting.GetSettingsLocaleID(), "大眾運輸容量調整 [ATC]" },

                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "操作" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "關於" },

                { m_Setting.GetOptionGroupLocaleID(Setting.DepotGroup),
                    "車庫容量（每個車庫的最大車輛數）" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PassengerGroup),
                    "乘客容量（每輛車的最大乘客數）" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup), "資訊" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup), "支援連結" },
                { m_Setting.GetOptionGroupLocaleID(Setting.DebugGroup), "除錯 / 日誌" },
                { m_Setting.GetOptionGroupLocaleID(Setting.LogGroup), "日誌檔" },

                // DEPOT labels & descriptions (1.0–10.0x)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusDepotScalar)), "公車車庫" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusDepotScalar)),
                    "每座 **公車車庫** 可以維護 / 產生多少輛公車。\n" +
                    "可使用 **1.0×**（原版）到 **10.0×** 的倍率。\n" +
                    "只會影響**基礎車庫建築**，不影響擴充建築。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiDepotScalar)), "計程車車庫" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TaxiDepotScalar)),
                    "每座 **計程車車庫** 可以維護多少輛計程車。\n" +
                    "加成只套用在基礎車庫建築。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramDepotScalar)), "電車車庫" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramDepotScalar)),
                    "每座 **電車車庫** 可以維護多少輛電車。\n" +
                    "加成只套用在基礎車庫建築。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainDepotScalar)), "火車車庫" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainDepotScalar)),
                    "每座 **火車車庫** 可以維護多少列火車。\n" +
                    "加成只套用在基礎車庫建築。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayDepotScalar)), "捷運車庫" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayDepotScalar)),
                    "每座 **捷運車庫** 可以維護多少列捷運列車。\n" +
                    "加成只套用在基礎車庫建築。" },

                // Depot reset button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetDepotToVanillaButton)), "重設所有車庫" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetDepotToVanillaButton)),
                    "將所有車庫重設為 **1.0×**（遊戲預設容量 / 原版）。" },

                // PASSENGER labels & descriptions (0.1–10.0x)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusPassengerScalar)), "公車乘客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusPassengerScalar)),
                    "調整 **公車乘客** 座位數。\n" +
                    "**0.1×** = 原版座位的 10%（降低）。\n" +
                    "**1.0×** = 原版座位，預設值。\n" +
                    "**10.0×** = 十倍座位數（提高）。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramPassengerScalar)), "電車乘客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramPassengerScalar)),
                    "調整 **電車乘客** 最大人數。\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainPassengerScalar)), "火車乘客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainPassengerScalar)),
                    "調整 **客運火車** 的座位數（車頭與車廂）。\n" +
                    "所有型別為 **Train** 的預製物會一起按相同倍率調整。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayPassengerScalar)), "捷運乘客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayPassengerScalar)),
                    "調整 **捷運乘客** 最大人數。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ShipPassengerScalar)), "客船乘客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ShipPassengerScalar)),
                    "調整 **客船** 的容量（不影響貨船）。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FerryPassengerScalar)), "渡輪乘客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FerryPassengerScalar)),
                    "調整 **渡輪乘客** 最大人數。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplanePassengerScalar)), "飛機乘客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AirplanePassengerScalar)),
                    "調整 **客機** 的最大乘客數。" },

                // Passenger convenience + reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DoublePassengersButton)), "全部 ×2" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DoublePassengersButton)),
                    "將所有乘客倍率設為 **2.0×**（200%）。\n" +
                    "適用於公車、電車、火車、捷運、客船、渡輪與飛機。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetPassengerToVanillaButton)), "重設所有乘客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetPassengerToVanillaButton)),
                    "將所有乘客倍率重設為 **1.0×**（遊戲預設容量 / 原版）。" },

                // About tab: info
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)),    "模組" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),     "此模組的顯示名稱。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),  "目前模組版本。" },

                // About tab: links
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),
                    "開啟作者模組所在的 Paradox Mods 頁面。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "在瀏覽器中開啟社群 Discord。" },

                // About tab: debug
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugLogging)), "啟用詳細除錯日誌" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugLogging)),
                    "啟用後，會將大量額外資訊寫入 AdjustTransitCapacity.log。\n" +
                    "對問題排查很有幫助，但日誌會非常多。\n" +
                    "一般遊戲建議 **關閉**（不要勾選）。\n" +
                    "<如果不清楚這個選項是做什麼用的，請保持 **關閉**，並且> \n" +
                    "<不要勾選，因為過多日誌可能影響效能。>"
                },

                // About tab: log button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLogButton)), "開啟日誌" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLogButton)),
                    "在預設文字編輯器中開啟 ATC 日誌檔。" },
            };
        }

        public void Unload()
        {
        }
    }
}
