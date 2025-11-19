// Localization/LocaleJA.cs
// Japanese (ja-JP) strings for Options UI.

namespace AdjustTransitCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleJA : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleJA(Setting setting)
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
                { m_Setting.GetSettingsLocaleID(), "交通容量調整 [ATC]" },

                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "操作" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "情報" },

                { m_Setting.GetOptionGroupLocaleID(Setting.DepotGroup),
                    "車庫容量（車庫ごとの最大車両数）" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PassengerGroup),
                    "乗客容量（車両ごとの最大人数）" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup), "情報" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup), "サポートリンク" },
                { m_Setting.GetOptionGroupLocaleID(Setting.DebugGroup), "デバッグ / ログ" },
                { m_Setting.GetOptionGroupLocaleID(Setting.LogGroup), "ログファイル" },

                // DEPOT labels & descriptions (1.0–10.0x)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusDepotScalar)), "バス車庫" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusDepotScalar)),
                    "各**バス車庫**が維持・スポーンできるバスの台数。\n" +
                    "**1.0×**（バニラ）から**10.0×**までの倍率を使用できます。\n" +
                    "拡張ではなく、**元の車庫建物**の容量を変更します。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiDepotScalar)), "タクシー車庫" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TaxiDepotScalar)),
                    "各**タクシー車庫**が維持できるタクシーの台数。\n" +
                    "変更は車庫のベース建物にのみ適用されます。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramDepotScalar)), "トラム車庫" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramDepotScalar)),
                    "各**トラム車庫**が維持できるトラムの台数。\n" +
                    "変更は車庫のベース建物にのみ適用されます。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainDepotScalar)), "列車車庫" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainDepotScalar)),
                    "各**列車車庫**が維持できる列車の本数。\n" +
                    "変更は車庫のベース建物にのみ適用されます。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayDepotScalar)), "地下鉄車庫" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayDepotScalar)),
                    "各**地下鉄車庫**が維持できる編成数。\n" +
                    "変更は車庫のベース建物にのみ適用されます。" },

                // Depot reset button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetDepotToVanillaButton)), "すべての車庫をリセット" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetDepotToVanillaButton)),
                    "すべての車庫を **1.0×**（ゲーム標準の容量 / バニラ）に戻します。" },

                // PASSENGER labels & descriptions (0.1–10.0x)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusPassengerScalar)), "バス乗客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusPassengerScalar)),
                    "**バス乗客**の座席数を変更します。\n" +
                    "**0.1×** = バニラの10％（減少）。\n" +
                    "**1.0×** = バニラと同じ（標準）。\n" +
                    "**10.0×** = 10倍の座席数（増加）。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramPassengerScalar)), "トラム乗客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramPassengerScalar)),
                    "**トラム乗客**の最大人数を変更します。\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainPassengerScalar)), "列車乗客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainPassengerScalar)),
                    "**旅客列車**（先頭車・中間車）の座席数を変更します。\n" +
                    "タイプが **Train** のすべてのプレハブが同じ倍率で調整されます。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayPassengerScalar)), "地下鉄乗客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayPassengerScalar)),
                    "**地下鉄乗客**の最大人数を変更します。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ShipPassengerScalar)), "旅客船乗客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ShipPassengerScalar)),
                    "**旅客船**の容量を変更します（貨物船は対象外）。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FerryPassengerScalar)), "フェリー乗客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FerryPassengerScalar)),
                    "**フェリー乗客**の最大人数を変更します。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplanePassengerScalar)), "旅客機乗客" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AirplanePassengerScalar)),
                    "**旅客機**の最大乗客数を変更します。" },

                // Passenger convenience + reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DoublePassengersButton)), "2倍にする" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DoublePassengersButton)),
                    "すべての乗客倍率を **2.0×**（200％）に設定します。\n" +
                    "バス・トラム・列車・地下鉄・船・フェリー・飛行機に適用されます。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetPassengerToVanillaButton)), "すべての乗客をリセット" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetPassengerToVanillaButton)),
                    "すべての乗客倍率を **1.0×**（ゲーム標準の容量 / バニラ）に戻します。" },

                // About tab: info
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),     "この Mod の表示名。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "バージョン" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),  "現在の Mod バージョン。" },

                // About tab: links
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),
                    "作者の Mod がある Paradox Mods のページを開きます。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "コミュニティ Discord をブラウザで開きます。" },

                // About tab: debug
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugLogging)), "詳細なデバッグログを有効化" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugLogging)),
                    "有効 = 多くの追加情報を AdjustTransitCapacity.log に出力します。\n" +
                    "トラブルシューティングには便利ですが、ログが大量になります。\n" +
                    "通常プレイでは **無効**（チェックしない）を推奨します。\n" +
                    "<何か分からない場合は **オフ** のままにして、> \n" +
                    "<ログの出力が多すぎるとパフォーマンスに影響するのでチェックしないでください。>"
                },

                // About tab: log button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLogButton)), "ログを開く" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLogButton)),
                    "ATC のログファイルを既定のテキストエディタで開きます。" },
            };
        }

        public void Unload()
        {
        }
    }
}
