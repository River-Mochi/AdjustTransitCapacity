// Localization/LocaleES.cs
// Spanish (es-ES) strings for Options UI.

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
                // Mod Title / Tabs / Groups
                { m_Setting.GetSettingsLocaleID(), "Capacidad del transporte [ATC]" },

                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Acciones" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "Acerca de" },

                { m_Setting.GetOptionGroupLocaleID(Setting.DepotGroup),
                    "Capacidad de depósitos (vehículos máximos por depósito)" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PassengerGroup),
                    "Capacidad de pasajeros (personas máximas por vehículo)" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup), "Información" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup), "Enlaces de soporte" },
                { m_Setting.GetOptionGroupLocaleID(Setting.DebugGroup), "Depuración / Registro" },
                { m_Setting.GetOptionGroupLocaleID(Setting.LogGroup), "Archivo de registro" },

                // DEPOT labels & descriptions (1.0–10.0x)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusDepotScalar)), "Depósitos de autobús" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusDepotScalar)),
                    "Cuántos autobuses puede mantener/spawnear cada edificio de **Depósito de autobuses**.\n" +
                    "Usa un multiplicador entre **1,0×** (vanilla) y **10,0×**.\n" +
                    "Multiplica el **edificio base**, no las ampliaciones." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiDepotScalar)), "Depósitos de taxi" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TaxiDepotScalar)),
                    "Cuántos taxis puede mantener cada **depósito de taxis**.\n" +
                    "El aumento se aplica solo al edificio base del depósito." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramDepotScalar)), "Depósitos de tranvía" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramDepotScalar)),
                    "Cuántos tranvías puede mantener cada **depósito de tranvías**.\n" +
                    "El aumento se aplica solo al edificio base del depósito." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainDepotScalar)), "Depósitos de tren" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainDepotScalar)),
                    "Cuántos trenes puede mantener cada **depósito de trenes**.\n" +
                    "El aumento se aplica solo al edificio base del depósito." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayDepotScalar)), "Depósitos de metro" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayDepotScalar)),
                    "Cuántos trenes de **metro** puede mantener cada depósito.\n" +
                    "El aumento se aplica solo al edificio base del depósito." },

                // Depot reset button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetDepotToVanillaButton)), "Restablecer todos los depósitos" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetDepotToVanillaButton)),
                    "Restablece todos los depósitos a **1,0×** (capacidad predeterminada del juego - vanilla)." },

                // PASSENGER labels & descriptions (0.1–10.0x)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusPassengerScalar)), "Pasajeros autobús" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusPassengerScalar)),
                    "Cambiar la capacidad de **pasajeros de autobús**.\n" +
                    "**0,1×** = 10 % de los asientos vanilla (disminuir).\n" +
                    "**1,0×** = asientos vanilla, valor por defecto.\n" +
                    "**10,0×** = diez veces más asientos (aumentar)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramPassengerScalar)), "Pasajeros tranvía" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramPassengerScalar)),
                    "Cambiar el máximo de **pasajeros de tranvía**.\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainPassengerScalar)), "Pasajeros tren" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainPassengerScalar)),
                    "Cambiar los asientos de **trenes de pasajeros** (locomotoras y vagones).\n" +
                    "Todos los prefabs de tipo **Train** se ajustan juntos." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayPassengerScalar)), "Pasajeros metro" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayPassengerScalar)),
                    "Cambiar los máximos de **pasajeros de metro**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ShipPassengerScalar)), "Pasajeros barco" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ShipPassengerScalar)),
                    "Cambiar la capacidad de los **barcos de pasajeros** (no de carga)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FerryPassengerScalar)), "Pasajeros ferry" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FerryPassengerScalar)),
                    "Cambiar el máximo de **pasajeros de ferrys**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplanePassengerScalar)), "Pasajeros avión" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AirplanePassengerScalar)),
                    "Cambiar el máximo de **pasajeros de avión**." },

                // Passenger convenience + reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DoublePassengersButton)), "Doblar" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DoublePassengersButton)),
                    "Pone todos los multiplicadores de pasajeros en **2,0×** (200 %).\n" +
                    "Se aplica a autobuses, tranvías, trenes, metros, barcos, ferrys y aviones." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetPassengerToVanillaButton)), "Restablecer todos los pasajeros" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetPassengerToVanillaButton)),
                    "Restablece todos los multiplicadores de pasajeros a **1,0×** (capacidad predeterminada del juego - vanilla)." },

                // About tab: info
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),     "Nombre visible de este mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Versión" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),  "Versión actual del mod." },

                // About tab: links
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),
                    "Abrir la página de Paradox Mods de los mods del autor." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Abrir el Discord de la comunidad en el navegador." },

                // About tab: debug
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugLogging)), "Activar registro de depuración detallado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugLogging)),
                    "Activado = envía muchos detalles extra a AdjustTransitCapacity.log.\n" +
                    "Útil para solucionar problemas, pero llena el registro.\n" +
                    "**Desactivar** (no marcar) para juego normal.\n" +
                    "<Si no sabe qué es esto, déjelo **DESACTIVADO**, y> \n" +
                    "<no marque la casilla porque el exceso de registros afecta al rendimiento.>"
                },

                // About tab: log button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLogButton)), "Abrir registro" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLogButton)),
                    "Abrir el archivo de registro de ATC en el editor de texto predeterminado." },
            };
        }

        public void Unload()
        {
        }
    }
}
