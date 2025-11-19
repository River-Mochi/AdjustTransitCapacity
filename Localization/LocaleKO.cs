// Localization/LocaleKO.cs
// Korean (ko-KR) strings for Options UI.

namespace AdjustTransitCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleKO : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleKO(Setting setting)
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
                { m_Setting.GetSettingsLocaleID(), "대중교통 수용량 조절 [ATC]" },

                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "동작" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "정보" },

                { m_Setting.GetOptionGroupLocaleID(Setting.DepotGroup),
                    "차고 수용량 (차고당 최대 차량 수)" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PassengerGroup),
                    "승객 수용량 (차량당 최대 승객 수)" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup), "정보" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup), "지원 링크" },
                { m_Setting.GetOptionGroupLocaleID(Setting.DebugGroup), "디버그 / 로그" },
                { m_Setting.GetOptionGroupLocaleID(Setting.LogGroup), "로그 파일" },

                // DEPOT labels & descriptions (1.0–10.0x)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusDepotScalar)), "버스 차고" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusDepotScalar)),
                    "각 **버스 차고**가 유지/배치할 수 있는 버스 수.\n" +
                    "**1.0×** (바닐라)부터 **10.0×**까지 배율을 설정할 수 있습니다.\n" +
                    "확장 건물이 아니라 **기본 차고 건물**의 수용량을 조정합니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiDepotScalar)), "택시 차고" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TaxiDepotScalar)),
                    "각 **택시 차고**가 유지할 수 있는 택시 수.\n" +
                    "변경은 차고 기본 건물에만 적용됩니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramDepotScalar)), "트램 차고" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramDepotScalar)),
                    "각 **트램 차고**가 유지할 수 있는 트램 수.\n" +
                    "변경은 차고 기본 건물에만 적용됩니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainDepotScalar)), "기차 차고" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainDepotScalar)),
                    "각 **기차 차고**가 유지할 수 있는 열차 편성 수.\n" +
                    "변경은 차고 기본 건물에만 적용됩니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayDepotScalar)), "지하철 차고" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayDepotScalar)),
                    "각 **지하철 차고**가 유지할 수 있는 편성 수.\n" +
                    "변경은 차고 기본 건물에만 적용됩니다." },

                // Depot reset button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetDepotToVanillaButton)), "모든 차고 초기화" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetDepotToVanillaButton)),
                    "모든 차고를 **1.0×** (게임 기본 수용량 / 바닐라)로 되돌립니다." },

                // PASSENGER labels & descriptions (0.1–10.0x)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusPassengerScalar)), "버스 승객" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusPassengerScalar)),
                    "**버스 승객** 좌석 수를 변경합니다.\n" +
                    "**0.1×** = 바닐라의 10 % (감소).\n" +
                    "**1.0×** = 바닐라와 동일 (기본값).\n" +
                    "**10.0×** = 10배 좌석 수 (증가)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramPassengerScalar)), "트램 승객" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramPassengerScalar)),
                    "**트램 승객** 최대 인원을 변경합니다.\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainPassengerScalar)), "기차 승객" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainPassengerScalar)),
                    "**여객 열차**(기관차 및 객차)의 좌석 수를 변경합니다.\n" +
                    "**Train** 타입의 모든 프리팹이 함께 조정됩니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayPassengerScalar)), "지하철 승객" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayPassengerScalar)),
                    "**지하철 승객** 최대 인원을 변경합니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ShipPassengerScalar)), "여객선 승객" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ShipPassengerScalar)),
                    "**여객선**의 수용 인원을 변경합니다 (화물선 제외)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FerryPassengerScalar)), "페리 승객" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FerryPassengerScalar)),
                    "**페리 승객** 최대 인원을 변경합니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplanePassengerScalar)), "여객기 승객" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AirplanePassengerScalar)),
                    "**여객기**의 최대 승객 수를 변경합니다." },

                // Passenger convenience + reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DoublePassengersButton)), "2배로" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DoublePassengersButton)),
                    "모든 승객 배율을 **2.0×** (200 %)로 설정합니다.\n" +
                    "버스, 트램, 기차, 지하철, 선박, 페리, 비행기에 적용됩니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetPassengerToVanillaButton)), "모든 승객 초기화" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetPassengerToVanillaButton)),
                    "모든 승객 배율을 **1.0×** (게임 기본 수용량 / 바닐라)로 되돌립니다." },

                // About tab: info
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)),    "모드" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),     "이 모드의 표시 이름입니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "버전" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),  "현재 모드 버전입니다." },

                // About tab: links
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),
                    "제작자의 모드가 있는 Paradox Mods 페이지를 엽니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "커뮤니티 Discord를 브라우저에서 엽니다." },

                // About tab: debug
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugLogging)), "자세한 디버그 로그 사용" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugLogging)),
                    "사용 시 AdjustTransitCapacity.log에 많은 추가 정보를 기록합니다.\n" +
                    "문제 해결에는 유용하지만 로그가 매우 많아집니다.\n" +
                    "일반 플레이에서는 **비활성**(체크 해제)을 권장합니다.\n" +
                    "<무슨 기능인지 모르겠다면 **꺼짐**으로 두고,> \n" +
                    "<로그가 너무 많으면 성능에 영향을 줄 수 있으니 체크하지 마세요.>"
                },

                // About tab: log button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLogButton)), "로그 열기" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLogButton)),
                    "ATC 로그 파일을 기본 텍스트 편집기로 엽니다." },
            };
        }

        public void Unload()
        {
        }
    }
}
