// Localization/LocaleDE.cs
// German (de-DE) strings for Options UI.

namespace AdjustTransitCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleDE : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleDE(Setting setting)
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
                { m_Setting.GetSettingsLocaleID(), "ÖPNV-Kapazität anpassen [ATC]" },

                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Aktionen" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "Info" },

                { m_Setting.GetOptionGroupLocaleID(Setting.DepotGroup),
                    "Depotkapazität (max. Fahrzeuge pro Depot)" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PassengerGroup),
                    "Passagierkapazität (max. Personen pro Fahrzeug)" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup), "Infos" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup), "Support-Links" },
                { m_Setting.GetOptionGroupLocaleID(Setting.DebugGroup), "Debug / Logging" },
                { m_Setting.GetOptionGroupLocaleID(Setting.LogGroup), "Logdatei" },

                // DEPOT labels & descriptions (1.0–10.0x)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusDepotScalar)), "Busdepots" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusDepotScalar)),
                    "Wie viele Busse jedes **Busdepot** warten / spawnen kann.\n" +
                    "Verwende einen Multiplikator zwischen **1,0×** (Vanilla) und **10,0×**.\n" +
                    "Multipliziert nur das **Basisgebäude**, nicht Erweiterungen." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiDepotScalar)), "Taxidepots" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TaxiDepotScalar)),
                    "Wie viele Taxis jedes **Taxidepot** warten kann.\n" +
                    "Die Erhöhung gilt nur für das Basisdepot." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramDepotScalar)), "Straßenbahndepots" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramDepotScalar)),
                    "Wie viele Straßenbahnen jedes **Straßenbahndepot** warten kann.\n" +
                    "Die Erhöhung gilt nur für das Basisdepot." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainDepotScalar)), "Zugdepots" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainDepotScalar)),
                    "Wie viele Züge jedes **Zugdepot** warten kann.\n" +
                    "Die Erhöhung gilt nur für das Basisdepot." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayDepotScalar)), "U-Bahn-Depots" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayDepotScalar)),
                    "Wie viele **U-Bahn-Züge** jedes Depot warten kann.\n" +
                    "Die Erhöhung gilt nur für das Basisdepot." },

                // Depot reset button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetDepotToVanillaButton)), "Alle Depots zurücksetzen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetDepotToVanillaButton)),
                    "Setzt alle Depots auf **1,0×** zurück (Standardkapazität des Spiels - Vanilla)." },

                // PASSENGER labels & descriptions (0.1–10.0x)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusPassengerScalar)), "Bus-Passagiere" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusPassengerScalar)),
                    "Ändert die **Passagierkapazität von Bussen**.\n" +
                    "**0,1×** = 10 % der Vanilla-Sitze (verringern).\n" +
                    "**1,0×** = Vanilla-Sitze, Standardwert.\n" +
                    "**10,0×** = zehnmal so viele Sitze (erhöhen)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramPassengerScalar)), "Tram-Passagiere" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramPassengerScalar)),
                    "Ändert die maximale Zahl der **Straßenbahnpassagiere**.\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainPassengerScalar)), "Zug-Passagiere" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainPassengerScalar)),
                    "Ändert die **Passagiersitze in Personenzügen** (Lokomotiven und Wagen).\n" +
                    "Alle Prefabs vom Typ **Train** werden gemeinsam angepasst." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayPassengerScalar)), "U-Bahn-Passagiere" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayPassengerScalar)),
                    "Ändert die maximale Zahl der **U-Bahn-Passagiere**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ShipPassengerScalar)), "Schiff-Passagiere" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ShipPassengerScalar)),
                    "Ändert die Kapazität von **Passagierschiffen** (nicht Frachtschiffe)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FerryPassengerScalar)), "Fähren-Passagiere" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FerryPassengerScalar)),
                    "Ändert die maximale Zahl der **Fährpassagiere**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplanePassengerScalar)), "Flugzeug-Passagiere" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AirplanePassengerScalar)),
                    "Ändert die maximale Zahl der **Flugzeugpassagiere**." },

                // Passenger convenience + reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DoublePassengersButton)), "Verdoppeln" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DoublePassengersButton)),
                    "Setzt alle Passagiermultiplikatoren auf **2,0×** (200 %).\n" +
                    "Gilt für Busse, Straßenbahnen, Züge, U-Bahnen, Schiffe, Fähren und Flugzeuge." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetPassengerToVanillaButton)), "Alle Passagiere zurücksetzen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetPassengerToVanillaButton)),
                    "Setzt alle Passagiermultiplikatoren auf **1,0×** zurück (Standardkapazität des Spiels - Vanilla)." },

                // About tab: info
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),     "Anzeigename dieses Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),  "Aktuelle Mod-Version." },

                // About tab: links
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),
                    "Öffnet die Paradox-Mods-Seite der Mods des Autors." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Öffnet den Community-Discord im Browser." },

                // About tab: debug
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugLogging)), "Ausführliches Debug-Logging aktivieren" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugLogging)),
                    "Aktiviert = viele zusätzliche Details in AdjustTransitCapacity.log.\n" +
                    "Nützlich zum Debuggen, erzeugt aber viel Log.\n" +
                    "**Deaktivieren** (nicht ankreuzen) für normales Spielen.\n" +
                    "<Wenn Sie nicht wissen, was das ist, lassen Sie es **AUS**, und> \n" +
                    "<kreuzen Sie das Feld nicht an, da zu viel Logging die Performance beeinträchtigen kann.>"
                },

                // About tab: log button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLogButton)), "Logdatei öffnen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLogButton)),
                    "Öffnet die ATC-Logdatei im Standard-Texteditor." },
            };
        }

        public void Unload()
        {
        }
    }
}
