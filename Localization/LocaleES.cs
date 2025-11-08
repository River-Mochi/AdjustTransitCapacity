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
                // ---- MOD TITLE / TABS / GROUPS ----
                { m_Setting.GetSettingsLocaleID(), "Adjust Transit Capacity [ATC]" },

                { m_Setting.GetOptionTabLocaleID(Setting.MainTab),  "Principal" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "Acerca de" },

                { m_Setting.GetOptionGroupLocaleID(Setting.DepotGroup),
                    "Capacidad del depósito (vehículos máx. por depósito)" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PassengerGroup),
                    "Capacidad de pasajeros (máx. pasajeros por vehículo)" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup),
                    "Información" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup),
                    "Enlaces de soporte" },
                { m_Setting.GetOptionGroupLocaleID(Setting.DebugGroup),
                    "Depuración / Registros" },

                // ---- DEPÓSITOS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusDepotScalar)), "Depósitos de autobuses" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusDepotScalar)),
                    "Cantidad de autobuses que cada depósito puede mantener.\n" +
                    "Usa un multiplicador entre **1,0×** (vanilla) y **10,0×**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiDepotScalar)), "Depósitos de taxis" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TaxiDepotScalar)),
                    "Cantidad de taxis que cada depósito puede mantener (1,0× – 10,0×)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramDepotScalar)), "Depósitos de tranvías" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramDepotScalar)),
                    "Cantidad de tranvías que cada depósito puede mantener (1,0× – 10,0×)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainDepotScalar)), "Depósitos de trenes" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainDepotScalar)),
                    "Cantidad de trenes que cada depósito puede mantener (1,0× – 10,0×)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayDepotScalar)), "Depósitos de metro" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayDepotScalar)),
                    "Cantidad de trenes de metro que cada depósito puede mantener (1,0× – 10,0×)." },

                // ---- PASAJEROS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusPassengerScalar)), "Pasajeros – autobús" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusPassengerScalar)),
                    "Multiplicador para la capacidad de pasajeros del autobús.\n" +
                    "**1,0×** = capacidad vanilla, **10,0×** = diez veces más asientos." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramPassengerScalar)), "Pasajeros – tranvía" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramPassengerScalar)),
                    "Multiplicador para la capacidad de pasajeros del tranvía (1,0× – 10,0×)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainPassengerScalar)), "Pasajeros – tren" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainPassengerScalar)),
                    "Multiplicador para la capacidad de pasajeros del tren (1,0× – 10,0×)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayPassengerScalar)), "Pasajeros – metro" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayPassengerScalar)),
                    "Multiplicador para la capacidad de pasajeros del metro (1,0× – 10,0×)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ShipPassengerScalar)), "Pasajeros – barco" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ShipPassengerScalar)),
                    "Multiplicador para barcos **de pasajeros** solamente (no cargueros)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FerryPassengerScalar)), "Pasajeros – ferry" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FerryPassengerScalar)),
                    "Multiplicador para la capacidad de pasajeros del ferry." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplanePassengerScalar)), "Pasajeros – avión" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AirplanePassengerScalar)),
                    "Multiplicador para la capacidad de pasajeros del avión." },

                // ---- ACERCA DE: INFO ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),     "Nombre mostrado de este mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Versión" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),  "Versión actual del mod." },

                // ---- ACERCA DE: ENLACES ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),
                    "Abrir este mod en el sitio Paradox Mods en el navegador." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Abrir el servidor de Discord de la comunidad en el navegador." },

                // ---- DEPURACIÓN ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugLogging)), "Activar registro de depuración" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugLogging)),
                    "Cuando está activado, el mod escribe más detalles sobre las capacidades " +
                    "en el registro del juego.\n" +
                    "Útil para depurar, pero puede llenar el registro." },
            };
        }

        public void Unload()
        {
        }
    }
}
