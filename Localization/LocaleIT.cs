// Localization/LocaleIT.cs
// Italian (it-IT) strings for Options UI.

namespace AdjustTransitCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleIT : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleIT(Setting setting)
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
                { m_Setting.GetSettingsLocaleID(), "Capacità trasporti [ATC]" },

                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Azioni" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "Info" },

                { m_Setting.GetOptionGroupLocaleID(Setting.DepotGroup),
                    "Capacità depositi (veicoli massimi per deposito)" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PassengerGroup),
                    "Capacità passeggeri (persone massime per veicolo)" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup), "Informazioni" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup), "Link di supporto" },
                { m_Setting.GetOptionGroupLocaleID(Setting.DebugGroup), "Debug / Log" },
                { m_Setting.GetOptionGroupLocaleID(Setting.LogGroup), "File di log" },

                // DEPOT labels & descriptions (1.0–10.0x)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusDepotScalar)), "Depositi autobus" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusDepotScalar)),
                    "Quanti autobus può gestire/generare ogni edificio **Deposito autobus**.\n" +
                    "Usa un moltiplicatore tra **1,0×** (vanilla) e **10,0×**.\n" +
                    "Moltiplica solo l’**edificio di base**, non le estensioni." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiDepotScalar)), "Depositi taxi" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TaxiDepotScalar)),
                    "Quanti taxi può gestire ogni **deposito taxi**.\n" +
                    "L’aumento si applica solo all’edificio base del deposito." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramDepotScalar)), "Depositi tram" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramDepotScalar)),
                    "Quanti tram può gestire ogni **deposito tram**.\n" +
                    "L’aumento si applica solo all’edificio base del deposito." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainDepotScalar)), "Depositi treni" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainDepotScalar)),
                    "Quanti treni può gestire ogni **deposito treni**.\n" +
                    "L’aumento si applica solo all’edificio base del deposito." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayDepotScalar)), "Depositi metro" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayDepotScalar)),
                    "Quanti convogli di **metropolitana** può gestire ogni deposito.\n" +
                    "L’aumento si applica solo all’edificio base del deposito." },

                // Depot reset button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetDepotToVanillaButton)), "Reimposta tutti i depositi" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetDepotToVanillaButton)),
                    "Reimposta tutti i depositi a **1,0×** (capacità predefinita del gioco - vanilla)." },

                // PASSENGER labels & descriptions (0.1–10.0x)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusPassengerScalar)), "Passeggeri autobus" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusPassengerScalar)),
                    "Modifica la capacità **passeggeri degli autobus**.\n" +
                    "**0,1×** = 10 % dei posti vanilla (riduzione).\n" +
                    "**1,0×** = posti vanilla, valore predefinito.\n" +
                    "**10,0×** = dieci volte più posti (aumento)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramPassengerScalar)), "Passeggeri tram" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramPassengerScalar)),
                    "Modifica il numero massimo di **passeggeri del tram**.\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainPassengerScalar)), "Passeggeri treno" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainPassengerScalar)),
                    "Modifica i posti dei **treni passeggeri** (locomotive e carrozze).\n" +
                    "Tutti i prefab di tipo **Train** vengono regolati insieme." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayPassengerScalar)), "Passeggeri metro" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayPassengerScalar)),
                    "Modifica i massimi di **passeggeri della metro**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ShipPassengerScalar)), "Passeggeri nave" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ShipPassengerScalar)),
                    "Modifica la capacità delle **navi passeggeri** (non cargo)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FerryPassengerScalar)), "Passeggeri traghetto" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FerryPassengerScalar)),
                    "Modifica il massimo di **passeggeri dei traghetti**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplanePassengerScalar)), "Passeggeri aereo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AirplanePassengerScalar)),
                    "Modifica il massimo di **passeggeri degli aerei**." },

                // Passenger convenience + reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DoublePassengersButton)), "Raddoppia" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DoublePassengersButton)),
                    "Imposta tutti i moltiplicatori passeggeri a **2,0×** (200 %).\n" +
                    "Si applica ad autobus, tram, treni, metro, navi, traghetti e aerei." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetPassengerToVanillaButton)), "Reimposta tutti i passeggeri" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetPassengerToVanillaButton)),
                    "Reimposta tutti i moltiplicatori passeggeri a **1,0×** (capacità predefinita del gioco - vanilla)." },

                // About tab: info
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),     "Nome visualizzato di questa mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Versione" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),  "Versione attuale della mod." },

                // About tab: links
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),
                    "Apri la pagina Paradox Mods dei mod dell’autore." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Apri il Discord della community nel browser." },

                // About tab: debug
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugLogging)), "Abilita log di debug dettagliato" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugLogging)),
                    "Attivo = invia molti dettagli extra in AdjustTransitCapacity.log.\n" +
                    "Utile per il debugging, ma riempie il log.\n" +
                    "**Disattivare** (non spuntare) per gioco normale.\n" +
                    "<Se non sai cos’è, lascialo **DISATTIVATO**, e> \n" +
                    "<non spuntare la casella perché troppo log può influire sulle prestazioni.>"
                },

                // About tab: log button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLogButton)), "Apri log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLogButton)),
                    "Apri il file di log di ATC nell’editor di testo predefinito." },
            };
        }

        public void Unload()
        {
        }
    }
}
