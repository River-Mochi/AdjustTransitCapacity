// AdjustTransitCapacitySystem.cs
// Purpose: apply multipliers for depot max vehicles and passenger max riders
//          based on current settings. PrefabSystem + PrefabBase are used to
//          read vanilla capacities so values never stack and never depend on
//          other runtime changes.

namespace AdjustTransitCapacity
{
    using Colossal.Serialization.Entities; // Purpose, GameMode
    using Game;
    using Game.Prefabs;
    using Unity.Entities;

    public sealed partial class AdjustTransitCapacitySystem : GameSystemBase
    {
        // PrefabSystem provides PrefabBase, which exposes the original
        // (vanilla) component values for each prefab.
        private PrefabSystem m_PrefabSystem = null!;

        // Lifecycle

        protected override void OnCreate()
        {
            base.OnCreate();

            m_PrefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();

            var depotQuery = SystemAPI.QueryBuilder()
                                      .WithAll<TransportDepotData>()
                                      .Build();

            var vehicleQuery = SystemAPI.QueryBuilder()
                                        .WithAll<PublicTransportVehicleData>()
                                        .Build();

            RequireForUpdate(depotQuery);
            RequireForUpdate(vehicleQuery);

            // Run only when explicitly enabled (game load or settings Apply).
            Enabled = false;
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            bool isRealGame =
                mode == GameMode.Game &&
                (purpose == Purpose.NewGame || purpose == Purpose.LoadGame);

            if (!isRealGame)
            {
                return;
            }

            Mod.Log.Info($"{Mod.ModTag} AdjustTransitCapacitySystem: GameLoadingComplete → reapply settings");

            Enabled = true;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        // Main update

        protected override void OnUpdate()
        {
            if (Mod.Settings == null)
            {
                Enabled = false;
                return;
            }

            Setting settings = Mod.Settings;
            bool debug = settings.EnableDebugLogging;

            // Depots (Bus / Taxi / Tram / Train / Subway)
            foreach (var (depotRef, entity) in SystemAPI
                         .Query<RefRW<TransportDepotData>>()
                         .WithEntityAccess())
            {
                ref TransportDepotData depotData = ref depotRef.ValueRW;

                float scalar = GetDepotScalar(settings, depotData.m_TransportType);

                // Get vanilla base from PrefabBase via PrefabSystem.
                int baseCapacity;
                if (!TryGetDepotBaseCapacity(entity, out baseCapacity))
                {
                    if (debug)
                    {
                        Mod.Log.Warn(
                            $"{Mod.ModTag} Depot: failed to get base capacity " +
                            $"for entity={entity.Index}:{entity.Version}, type={depotData.m_TransportType}. " +
                            "Falling back to current component value.");
                    }

                    baseCapacity = depotData.m_VehicleCapacity;
                }

                if (baseCapacity < 1)
                {
                    baseCapacity = 1;
                }

                int newCapacity = (int)(baseCapacity * scalar);
                if (newCapacity < 1)
                {
                    newCapacity = 1;
                }

                if (newCapacity != depotData.m_VehicleCapacity)
                {
                    if (debug)
                    {
                        Mod.Log.Info(
                            $"{Mod.ModTag} Depot apply: entity={entity.Index}:{entity.Version} " +
                            $"type={depotData.m_TransportType} base={baseCapacity} scalar={scalar:F2} " +
                            $"old={depotData.m_VehicleCapacity} new={newCapacity}");
                    }

                    depotData.m_VehicleCapacity = newCapacity;
                }
            }

            // Passengers (affect vehicle capacity only; taxi seats unchanged)
            foreach (var (vehicleRef, entity) in SystemAPI
                         .Query<RefRW<PublicTransportVehicleData>>()
                         .WithEntityAccess())
            {
                ref PublicTransportVehicleData vehicleData = ref vehicleRef.ValueRW;

                float scalar = GetPassengerScalar(settings, vehicleData.m_TransportType);

                // Get vanilla base from PrefabBase via PrefabSystem.
                int basePassengers;
                if (!TryGetPassengerBaseCapacity(entity, out basePassengers))
                {
                    if (debug)
                    {
                        Mod.Log.Warn(
                            $"{Mod.ModTag} Vehicle: failed to get base passenger capacity " +
                            $"for entity={entity.Index}:{entity.Version}, type={vehicleData.m_TransportType}. " +
                            "Falling back to current component value.");
                    }

                    basePassengers = vehicleData.m_PassengerCapacity;
                }

                if (basePassengers < 1)
                {
                    basePassengers = 1;
                }

                int newPassengers = (int)(basePassengers * scalar);
                if (newPassengers < 1)
                {
                    newPassengers = 1;
                }

                if (newPassengers != vehicleData.m_PassengerCapacity)
                {
                    if (debug)
                    {
                        Mod.Log.Info(
                            $"{Mod.ModTag} Vehicle apply: entity={entity.Index}:{entity.Version} " +
                            $"type={vehicleData.m_TransportType} base={basePassengers} scalar={scalar:F2} " +
                            $"old={vehicleData.m_PassengerCapacity} new={newPassengers}");
                    }

                    vehicleData.m_PassengerCapacity = newPassengers;
                }
            }

            // Run-once; either Setting.Apply() or city load will enable again.
            Enabled = false;
        }

        // Prefab helpers: read vanilla from PrefabBase

        private bool TryGetDepotBaseCapacity(Entity entity, out int baseCapacity)
        {
            baseCapacity = 0;

            if (m_PrefabSystem == null)
            {
                return false;
            }

            if (!m_PrefabSystem.TryGetPrefab(entity, out PrefabBase prefabBase))
            {
                return false;
            }

            if (!prefabBase.TryGet(out TransportDepot depotComponent))
            {
                return false;
            }

            baseCapacity = depotComponent.m_VehicleCapacity;
            return true;
        }

        private bool TryGetPassengerBaseCapacity(Entity entity, out int basePassengers)
        {
            basePassengers = 0;

            if (m_PrefabSystem == null)
            {
                return false;
            }

            if (!m_PrefabSystem.TryGetPrefab(entity, out PrefabBase prefabBase))
            {
                return false;
            }

            if (!prefabBase.TryGet(out PublicTransport publicTransport))
            {
                return false;
            }

            basePassengers = publicTransport.m_PassengerCapacity;
            return true;
        }

        // Depot / passenger scalar helpers
        // Settings store percent (100–1000); runtime scalar uses percent / 100f.

        private static float GetDepotScalar(Setting settings, TransportType type)
        {
            float percent;

            switch (type)
            {
                case TransportType.Bus:
                    percent = settings.BusDepotScalar;
                    break;
                case TransportType.Taxi:
                    percent = settings.TaxiDepotScalar;
                    break;
                case TransportType.Tram:
                    percent = settings.TramDepotScalar;
                    break;
                case TransportType.Train:
                    percent = settings.TrainDepotScalar;
                    break;
                case TransportType.Subway:
                    percent = settings.SubwayDepotScalar;
                    break;
                default:
                    return 1f;
            }

            if (percent < Setting.MinPercent)
            {
                percent = Setting.MinPercent;
            }
            else if (percent > Setting.MaxPercent)
            {
                percent = Setting.MaxPercent;
            }

            return percent / 100f;
        }

        private static float GetPassengerScalar(Setting settings, TransportType type)
        {
            float percent;

            switch (type)
            {
                case TransportType.Bus:
                    percent = settings.BusPassengerScalar;
                    break;
                case TransportType.Tram:
                    percent = settings.TramPassengerScalar;
                    break;
                case TransportType.Train:
                    percent = settings.TrainPassengerScalar;
                    break;
                case TransportType.Subway:
                    percent = settings.SubwayPassengerScalar;
                    break;
                case TransportType.Ship:
                    percent = settings.ShipPassengerScalar;
                    break;
                case TransportType.Ferry:
                    percent = settings.FerryPassengerScalar;
                    break;
                case TransportType.Airplane:
                    percent = settings.AirplanePassengerScalar;
                    break;
                default:
                    // Includes Taxi → leave passenger seats at vanilla.
                    return 1f;
            }

            if (percent < Setting.MinPercent)
            {
                percent = Setting.MinPercent;
            }
            else if (percent > Setting.MaxPercent)
            {
                percent = Setting.MaxPercent;
            }

            return percent / 100f;
        }
    }
}
