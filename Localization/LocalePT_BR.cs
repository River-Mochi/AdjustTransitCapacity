// Localization/LocalePT_BR.cs
// Brazilian Portuguese (pt-BR) strings for Options UI.

namespace AdjustTransitCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocalePT_BR : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocalePT_BR(Setting setting)
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
                { m_Setting.GetSettingsLocaleID(), "Capacidade do transporte [ATC]" },

                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Ações" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "Sobre" },

                { m_Setting.GetOptionGroupLocaleID(Setting.DepotGroup),
                    "Capacidade dos depósitos (máx. veículos por depósito)" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PassengerGroup),
                    "Capacidade de passageiros (máx. pessoas por veículo)" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup), "Informações" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup), "Links de suporte" },
                { m_Setting.GetOptionGroupLocaleID(Setting.DebugGroup), "Depuração / Log" },
                { m_Setting.GetOptionGroupLocaleID(Setting.LogGroup), "Arquivo de log" },

                // DEPOT labels & descriptions (1.0–10.0x)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusDepotScalar)), "Depósitos de ônibus" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusDepotScalar)),
                    "Quantos ônibus cada **Depósito de ônibus** pode manter/gerar.\n" +
                    "Use um multiplicador entre **1,0×** (vanilla) e **10,0×**.\n" +
                    "Afeta apenas o **prédio base**, não as extensões." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiDepotScalar)), "Depósitos de táxi" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TaxiDepotScalar)),
                    "Quantos táxis cada **depósito de táxi** pode manter.\n" +
                    "O aumento se aplica somente ao prédio base do depósito." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramDepotScalar)), "Depósitos de bonde" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramDepotScalar)),
                    "Quantos bondes cada **depósito de bonde** pode manter.\n" +
                    "O aumento se aplica somente ao prédio base do depósito." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainDepotScalar)), "Depósitos de trem" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainDepotScalar)),
                    "Quantos trens cada **depósito de trem** pode manter.\n" +
                    "O aumento se aplica somente ao prédio base do depósito." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayDepotScalar)), "Depósitos de metrô" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayDepotScalar)),
                    "Quantos trens de **metrô** cada depósito pode manter.\n" +
                    "O aumento se aplica somente ao prédio base do depósito." },

                // Depot reset button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetDepotToVanillaButton)), "Redefinir todos os depósitos" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetDepotToVanillaButton)),
                    "Redefine todos os depósitos para **1,0×** (capacidade padrão do jogo - vanilla)." },

                // PASSENGER labels & descriptions (0.1–10.0x)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusPassengerScalar)), "Passageiros de ônibus" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusPassengerScalar)),
                    "Altera a capacidade de **passageiros de ônibus**.\n" +
                    "**0,1×** = 10 % dos assentos vanilla (reduzir).\n" +
                    "**1,0×** = assentos vanilla, valor padrão.\n" +
                    "**10,0×** = dez vezes mais assentos (aumentar)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramPassengerScalar)), "Passageiros de bonde" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramPassengerScalar)),
                    "Altera o máximo de **passageiros de bonde**.\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainPassengerScalar)), "Passageiros de trem" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainPassengerScalar)),
                    "Altera os assentos de **trens de passageiros** (locomotivas e vagões).\n" +
                    "Todos os prefabs do tipo **Train** são ajustados juntos." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayPassengerScalar)), "Passageiros de metrô" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayPassengerScalar)),
                    "Altera os valores máximos de **passageiros de metrô**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ShipPassengerScalar)), "Passageiros de navio" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ShipPassengerScalar)),
                    "Altera a capacidade de **navios de passageiros** (não navios de carga)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FerryPassengerScalar)), "Passageiros de balsa" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FerryPassengerScalar)),
                    "Altera o máximo de **passageiros de balsas**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplanePassengerScalar)), "Passageiros de avião" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AirplanePassengerScalar)),
                    "Altera o máximo de **passageiros de avião**." },

                // Passenger convenience + reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DoublePassengersButton)), "Dobrar" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DoublePassengersButton)),
                    "Define todos os multiplicadores de passageiros para **2,0×** (200 %).\n" +
                    "Se aplica a ônibus, bondes, trens, metrôs, navios, balsas e aviões." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetPassengerToVanillaButton)), "Redefinir todos os passageiros" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetPassengerToVanillaButton)),
                    "Redefine todos os multiplicadores de passageiros para **1,0×** (capacidade padrão do jogo - vanilla)." },

                // About tab: info
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),     "Nome exibido deste mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Versão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),  "Versão atual do mod." },

                // About tab: links
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),
                    "Abre a página do Paradox Mods para os mods do autor." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Abre o Discord da comunidade no navegador." },

                // About tab: debug
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugLogging)), "Ativar log detalhado de depuração" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugLogging)),
                    "Ativado = envia muitos detalhes extras para AdjustTransitCapacity.log.\n" +
                    "Útil para depuração, mas gera muito log.\n" +
                    "**Desative** (não marque) para jogatina normal.\n" +
                    "<Se você não sabe o que é, deixe **DESATIVADO**, e> \n" +
                    "<não marque a caixa, pois log demais pode afetar o desempenho.>"
                },

                // About tab: log button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLogButton)), "Abrir log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLogButton)),
                    "Abre o arquivo de log do ATC no editor de texto padrão." },
            };
        }

        public void Unload()
        {
        }
    }
}
