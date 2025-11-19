// Localization/LocaleFR.cs
// French (fr-FR) strings for Options UI.

namespace AdjustTransitCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleFR : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleFR(Setting setting)
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
                { m_Setting.GetSettingsLocaleID(), "Capacité des transports [ATC]" },

                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "À propos" },

                { m_Setting.GetOptionGroupLocaleID(Setting.DepotGroup),
                    "Capacité des dépôts (véhicules maximum par dépôt)" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PassengerGroup),
                    "Capacité passagers (personnes maximum par véhicule)" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup), "Infos" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup), "Liens de support" },
                { m_Setting.GetOptionGroupLocaleID(Setting.DebugGroup), "Debug / Journal" },
                { m_Setting.GetOptionGroupLocaleID(Setting.LogGroup), "Fichier journal" },

                // DEPOT labels & descriptions (1.0–10.0x)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusDepotScalar)), "Dépôts de bus" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusDepotScalar)),
                    "Nombre de bus que chaque bâtiment **Dépôt de bus** peut entretenir / faire apparaître.\n" +
                    "Utiliser un multiplicateur entre **1,0×** (vanille) et **10,0×**.\n" +
                    "Multiplie le **bâtiment de base**, pas les extensions." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiDepotScalar)), "Dépôts de taxis" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TaxiDepotScalar)),
                    "Nombre de taxis que chaque **dépôt de taxis** peut entretenir.\n" +
                    "L’augmentation s’applique uniquement au bâtiment de dépôt principal." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramDepotScalar)), "Dépôts de trams" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramDepotScalar)),
                    "Nombre de trams que chaque **dépôt de trams** peut entretenir.\n" +
                    "L’augmentation s’applique uniquement au bâtiment de dépôt principal." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainDepotScalar)), "Dépôts de trains" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainDepotScalar)),
                    "Nombre de trains que chaque **dépôt de trains** peut entretenir.\n" +
                    "L’augmentation s’applique uniquement au bâtiment de dépôt principal." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayDepotScalar)), "Dépôts de métro" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayDepotScalar)),
                    "Nombre de rames que chaque **dépôt de métro** peut entretenir.\n" +
                    "L’augmentation s’applique uniquement au bâtiment de dépôt principal." },

                // Depot reset button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetDepotToVanillaButton)), "Réinitialiser tous les dépôts" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetDepotToVanillaButton)),
                    "Remet tous les dépôts à **1,0×** (capacité par défaut du jeu - vanille)." },

                // PASSENGER labels & descriptions (0.1–10.0x)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusPassengerScalar)), "Passagers bus" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusPassengerScalar)),
                    "Modifier la capacité en passagers des **bus**.\n" +
                    "**0,1×** = 10 % des sièges de base (réduction).\n" +
                    "**1,0×** = sièges vanille, valeur par défaut.\n" +
                    "**10,0×** = dix fois plus de sièges (augmentation)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramPassengerScalar)), "Passagers tram" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramPassengerScalar)),
                    "Modifier le nombre maximum de **passagers de trams**.\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainPassengerScalar)), "Passagers train" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainPassengerScalar)),
                    "Modifier les sièges des **trains de voyageurs** pour les locomotives et les voitures.\n" +
                    "Tous les prefabs de type **Train** sont ajustés ensemble." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayPassengerScalar)), "Passagers métro" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayPassengerScalar)),
                    "Modifier le maximum de **passagers du métro**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ShipPassengerScalar)), "Passagers bateaux" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ShipPassengerScalar)),
                    "Modifier la capacité des **bateaux de passagers** (pas les cargos)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FerryPassengerScalar)), "Passagers ferry" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FerryPassengerScalar)),
                    "Modifier le maximum de **passagers des ferrys**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplanePassengerScalar)), "Passagers avions" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AirplanePassengerScalar)),
                    "Modifier le maximum de **passagers des avions**." },

                // Passenger convenience + reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DoublePassengersButton)), "Doubler" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DoublePassengersButton)),
                    "Met tous les multiplicateurs de passagers à **2,0×** (200 %).\n" +
                    "S’applique aux bus, trams, trains, métros, bateaux, ferrys et avions." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetPassengerToVanillaButton)), "Réinitialiser tous les passagers" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetPassengerToVanillaButton)),
                    "Remet tous les multiplicateurs de passagers à **1,0×** (capacité par défaut du jeu - vanille)." },

                // About tab: info
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),     "Nom d’affichage de ce mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),  "Version actuelle du mod." },

                // About tab: links
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),
                    "Ouvrir la page Paradox Mods des mods de l’auteur." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Ouvrir le Discord de la communauté dans un navigateur." },

                // About tab: debug
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugLogging)), "Activer le journal de debug détaillé" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugLogging)),
                    "Activé = envoie beaucoup de détails supplémentaires dans AdjustTransitCapacity.log.\n" +
                    "Utile pour le dépannage, mais remplit le journal.\n" +
                    "**Désactiver** (ne pas cocher) pour une partie normale.\n" +
                    "<Si vous ne savez pas ce que c’est, laissez **DÉSACTIVÉ**, et> \n" +
                    "<ne cochez pas la case car un journal trop bavard peut affecter les performances.>"
                },

                // About tab: log button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLogButton)), "Ouvrir le journal" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLogButton)),
                    "Ouvrir le fichier journal ATC dans l’éditeur de texte par défaut." },
            };
        }

        public void Unload()
        {
        }
    }
}
