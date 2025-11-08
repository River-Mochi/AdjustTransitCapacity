// AdjustTransitCapacitySystem.cs
// Purpose: apply multipliers for depot max vehicles and passenger max riders
//          based on current settings. Uses per-entity vanilla baselines to
//          avoid stacking across reloads or settings changes.

namespace AdjustTransitCapacity
{
    using System.Collections.Generic;
    using Colossal.Serialization.Entities; // Purpose, GameMode
    using Game;
    using Game.Prefabs;
    using Unity.Collections;
    using Unity.Entities;

    public sealed partial class AdjustTransitCapacitySystem : GameSystemBase
    {
        // ---- CACHES ----
        // depot entity -> vanilla vehicle capacity
        private readonly Dictionary<Entity, int> m_OriginalDepotCapacity =
            new Dictionary<Entity, int>();

        // vehicle entity -> vanilla passenger capacity
        private readonly Dictionary<Entity, int> m_OriginalPassengerCapacity =
            new Dictionary<Entity, int>();

        // ---- QUERIES ----
        private EntityQuery m_DepotQuery;
        private EntityQuery m_VehicleQuery;

        // ---- LIFECYCLE: CREATE / DESTROY ----
        protected override void OnCreate()
        {
            base.OnCreate();

            // Query all transport depots (prefabs with TransportDepotData)
            m_DepotQuery = GetEntityQuery(
                ComponentType.ReadWrite<TransportDepotData>());

            // Query all public transport vehicles
            m_VehicleQuery = GetEntityQuery(
                ComponentType.ReadWrite<PublicTransportVehicleData>());

            RequireForUpdate(m_DepotQuery);
            RequireForUpdate(m_VehicleQuery);

            // Run only when explicitly enabled (OnGameLoadingComplete or Setting.Apply).
            Enabled = false;
        }

        /// <summary>
        /// Called after a save or new game has finished loading.
        /// Clears cached capacities because entity IDs & prefabs are rebuilt per city.
        /// </summary>
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

            m_OriginalDepotCapacity.Clear();
            m_OriginalPassengerCapacity.Clear();

            Enabled = true;
        }

        protected override void OnDestroy()
        {
            m_OriginalDepotCapacity.Clear();
            m_OriginalPassengerCapacity.Clear();
            base.OnDestroy();
        }

        // ---- MAIN UPDATE ----
        protected override void OnUpdate()
        {
            if (Mod.Settings == null)
            {
                Enabled = false;
                return;
            }

            var settings = Mod.Settings;
            bool debug = settings.EnableDebugLogging;

            // ---- DEPOTS (5 types: Bus / Taxi / Tram / Train / Subway) ----
            NativeArray<Entity> depots = m_DepotQuery.ToEntityArray(Allocator.Temp);
            try
            {
                for (int i = 0; i < depots.Length; i++)
                {
                    Entity depotEntity = depots[i];
                    TransportDepotData depotData =
                        EntityManager.GetComponentData<TransportDepotData>(depotEntity);

                    // Get scalar for this transport type (1.0–10.0, or 1.0 for others).
                    float scalar = GetDepotScalar(settings, depotData.m_TransportType);
                    if (scalar <= 0f)
                    {
                        scalar = 1f;
                    }

                    // Cache vanilla capacity once.
                    if (!m_OriginalDepotCapacity.TryGetValue(depotEntity, out int baseCapacity))
                    {
                        baseCapacity = depotData.m_VehicleCapacity;
                        if (baseCapacity < 1)
                        {
                            baseCapacity = 1;
                        }

                        m_OriginalDepotCapacity[depotEntity] = baseCapacity;

                        if (debug)
                        {
                            Mod.Log.Info(
                                $"{Mod.ModTag} [Depot Baseline] Type={depotData.m_TransportType}, " +
                                $"Entity={depotEntity.Index}, VanillaCapacity={baseCapacity}");
                        }
                    }

                    int newCapacity = (int)(baseCapacity * scalar);
                    if (newCapacity < 1)
                    {
                        newCapacity = 1;
                    }

                    if (debug)
                    {
                        Mod.Log.Info(
                            $"{Mod.ModTag} [Depot Apply] Type={depotData.m_TransportType}, " +
                            $"Entity={depotEntity.Index}, Base={baseCapacity}, Scalar={scalar:F2}, New={newCapacity}");
                    }

                    if (newCapacity != depotData.m_VehicleCapacity)
                    {
                        depotData.m_VehicleCapacity = newCapacity;
                        EntityManager.SetComponentData(depotEntity, depotData);
                    }
                }
            }
            finally
            {
                depots.Dispose();
            }

            // ---- PASSENGERS (no taxi capacity change) ----
            NativeArray<Entity> vehicles = m_VehicleQuery.ToEntityArray(Allocator.Temp);
            try
            {
                for (int i = 0; i < vehicles.Length; i++)
                {
                    Entity vehicleEntity = vehicles[i];
                    PublicTransportVehicleData vehicleData =
                        EntityManager.GetComponentData<PublicTransportVehicleData>(vehicleEntity);

                    float scalar = GetPassengerScalar(settings, vehicleData.m_TransportType);
                    if (scalar <= 0f)
                    {
                        scalar = 1f;
                    }

                    // Taxi is intentionally left as vanilla in GetPassengerScalar.
                    if (scalar == 1f && !IsHandledPassengerType(vehicleData.m_TransportType))
                    {
                        continue;
                    }

                    if (!m_OriginalPassengerCapacity.TryGetValue(vehicleEntity, out int basePassengers))
                    {
                        basePassengers = vehicleData.m_PassengerCapacity;
                        if (basePassengers < 1)
                        {
                            basePassengers = 1;
                        }

                        m_OriginalPassengerCapacity[vehicleEntity] = basePassengers;

                        if (debug)
                        {
                            Mod.Log.Info(
                                $"{Mod.ModTag} [Passenger Baseline] Type={vehicleData.m_TransportType}, " +
                                $"Entity={vehicleEntity.Index}, VanillaCapacity={basePassengers}");
                        }
                    }

                    int newPassengers = (int)(basePassengers * scalar);
                    if (newPassengers < 1)
                    {
                        newPassengers = 1;
                    }

                    if (debug)
                    {
                        Mod.Log.Info(
                            $"{Mod.ModTag} [Passenger Apply] Type={vehicleData.m_TransportType}, " +
                            $"Entity={vehicleEntity.Index}, Base={basePassengers}, Scalar={scalar:F2}, New={newPassengers}");
                    }

                    if (newPassengers != vehicleData.m_PassengerCapacity)
                    {
                        vehicleData.m_PassengerCapacity = newPassengers;
                        EntityManager.SetComponentData(vehicleEntity, vehicleData);
                    }
                }
            }
            finally
            {
                vehicles.Dispose();
            }

            // Run-once; either Setting.Apply() or city load will enable again.
            Enabled = false;
        }

        // ---- HELPERS: DEPOT SCALAR ----

        /// <summary>
        /// Depot multipliers: 1.0–10.0 (direct scalar).
        /// Any other depot type is left at vanilla (1.0).
        /// Targets 5 depot types.
        /// </summary>
        private static float GetDepotScalar(Setting settings, TransportType type)
        {
            float scalar;
            switch (type)
            {
                case TransportType.Bus:
                    scalar = settings.BusDepotScalar;
                    break;
                case TransportType.Taxi:
                    scalar = settings.TaxiDepotScalar;
                    break;
                case TransportType.Tram:
                    scalar = settings.TramDepotScalar;
                    break;
                case TransportType.Train:
                    scalar = settings.TrainDepotScalar;
                    break;
                case TransportType.Subway:
                    scalar = settings.SubwayDepotScalar;
                    break;
                default:
                    return 1f;
            }

            if (scalar < Setting.MinScalar)
            {
                scalar = Setting.MinScalar;
            }
            else if (scalar > Setting.MaxScalar)
            {
                scalar = Setting.MaxScalar;
            }

            return scalar;
        }

        // ---- HELPERS: PASSENGER SCALAR ----

        /// <summary>
        /// Passenger multipliers: 1.0–10.0 (direct scalar).
        /// Taxi is intentionally skipped (game keeps 4 seats).
        /// </summary>
        private static float GetPassengerScalar(Setting settings, TransportType type)
        {
            float scalar;
            switch (type)
            {
                case TransportType.Bus:
                    scalar = settings.BusPassengerScalar;
                    break;
                case TransportType.Tram:
                    scalar = settings.TramPassengerScalar;
                    break;
                case TransportType.Train:
                    scalar = settings.TrainPassengerScalar;
                    break;
                case TransportType.Subway:
                    scalar = settings.SubwayPassengerScalar;
                    break;
                case TransportType.Ship:
                    scalar = settings.ShipPassengerScalar;
                    break;
                case TransportType.Ferry:
                    scalar = settings.FerryPassengerScalar;
                    break;
                case TransportType.Airplane:
                    scalar = settings.AirplanePassengerScalar;
                    break;
                default:
                    // Includes Taxi → leave at vanilla value.
                    return 1f;
            }

            if (scalar < Setting.MinScalar)
            {
                scalar = Setting.MinScalar;
            }
            else if (scalar > Setting.MaxScalar)
            {
                scalar = Setting.MaxScalar;
            }

            return scalar;
        }

        private static bool IsHandledPassengerType(TransportType type)
        {
            switch (type)
            {
                case TransportType.Bus:
                case TransportType.Tram:
                case TransportType.Train:
                case TransportType.Subway:
                case TransportType.Ship:
                case TransportType.Ferry:
                case TransportType.Airplane:
                    return true;
                default:
                    return false;
            }
        }
    }
}
