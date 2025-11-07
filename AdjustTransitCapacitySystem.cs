// AdjustTransitCapacitySystem.cs
// Purpose: apply multipliers for depot max vehicles and passenger max riders
//          based on current settings. Avoids stacking by tracking last
//          applied percentages per transport type.

namespace AdjustTransitCapacity
{
    using Colossal.Serialization.Entities; // Purpose, GameMode
    using Game;
    using Game.Prefabs;
    using Unity.Collections;
    using Unity.Entities;

    public sealed partial class AdjustTransitCapacitySystem : GameSystemBase
    {
        // ---- QUERIES ----
        private EntityQuery m_DepotQuery;
        private EntityQuery m_VehicleQuery;

        // ---- LIFECYCLE: CREATE / DESTROY ----
        protected override void OnCreate()
        {
            base.OnCreate();

            // Query all transport depots (prefabs with TransportDepotData)
            m_DepotQuery = GetEntityQuery(new EntityQueryDesc
            {
                All = new[]
                {
                    ComponentType.ReadWrite<TransportDepotData>()
                }
            });

            // Query all public transport vehicles
            m_VehicleQuery = GetEntityQuery(new EntityQueryDesc
            {
                All = new[]
                {
                    ComponentType.ReadWrite<PublicTransportVehicleData>()
                }
            });

            RequireForUpdate(m_DepotQuery);
            RequireForUpdate(m_VehicleQuery);

            // Run only when explicitly enabled (OnGameLoadingComplete or Setting.Apply).
            Enabled = false;
        }

        /// <summary>
        /// Called after a save or new game has finished loading.
        /// Re-applies settings once in the newly loaded city.
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

            Enabled = true;
        }

        protected override void OnDestroy()
        {
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

            Setting settings = Mod.Settings;

            // ---- DEPOTS (5 types: Bus / Taxi / Tram / Train / Subway) ----
            NativeArray<Entity> depots = m_DepotQuery.ToEntityArray(Allocator.Temp);
            try
            {
                for (int i = 0; i < depots.Length; i++)
                {
                    Entity depotEntity = depots[i];
                    TransportDepotData depotData =
                        EntityManager.GetComponentData<TransportDepotData>(depotEntity);

                    float currentScalar;
                    float lastScalar;
                    if (!GetDepotScalars(settings, depotData.m_TransportType, out currentScalar, out lastScalar))
                    {
                        // Not a handled depot type → leave vanilla
                        continue;
                    }

                    int currentCapacity = depotData.m_VehicleCapacity;
                    if (currentCapacity < 1)
                    {
                        currentCapacity = 1;
                    }

                    // Undo previous multiplier, then apply the new one.
                    // base ≈ current / lastScalar
                    float baseCapacity = currentCapacity / lastScalar;
                    int newCapacity = (int)(baseCapacity * currentScalar);

                    if (newCapacity < 1)
                    {
                        newCapacity = 1;
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

                    float currentScalar;
                    float lastScalar;
                    if (!GetPassengerScalars(settings, vehicleData.m_TransportType, out currentScalar, out lastScalar))
                    {
                        // Not a handled passenger type → leave vanilla
                        continue;
                    }

                    int currentPassengers = vehicleData.m_PassengerCapacity;
                    if (currentPassengers < 1)
                    {
                        currentPassengers = 1;
                    }

                    float basePassengers = currentPassengers / lastScalar;
                    int newPassengers = (int)(basePassengers * currentScalar);

                    if (newPassengers < 1)
                    {
                        newPassengers = 1;
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

            // ---- UPDATE LAST PERCENTS ----
            SyncLastDepotPercents(settings);
            SyncLastPassengerPercents(settings);

            // Run-once; either Setting.Apply() or city load will enable again.
            Enabled = false;
        }

        // ---- HELPERS: COMMON ----

        private static float PercentToScalar(int percent)
        {
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

        // ---- HELPERS: DEPOT SCALARS ----

        /// <summary>
        /// Returns current and last scalars for depot capacity.
        /// true = handled type, false = leave vanilla.
        /// </summary>
        private static bool GetDepotScalars(
            Setting settings,
            TransportType type,
            out float currentScalar,
            out float lastScalar)
        {
            int currentPercent;
            int lastPercent;

            switch (type)
            {
                case TransportType.Bus:
                    currentPercent = settings.BusDepotPercent;
                    lastPercent = settings.BusDepotLastPercent;
                    break;
                case TransportType.Taxi:
                    currentPercent = settings.TaxiDepotPercent;
                    lastPercent = settings.TaxiDepotLastPercent;
                    break;
                case TransportType.Tram:
                    currentPercent = settings.TramDepotPercent;
                    lastPercent = settings.TramDepotLastPercent;
                    break;
                case TransportType.Train:
                    currentPercent = settings.TrainDepotPercent;
                    lastPercent = settings.TrainDepotLastPercent;
                    break;
                case TransportType.Subway:
                    currentPercent = settings.SubwayDepotPercent;
                    lastPercent = settings.SubwayDepotLastPercent;
                    break;
                default:
                    currentScalar = 1f;
                    lastScalar = 1f;
                    return false;
            }

            currentScalar = PercentToScalar(currentPercent);

            // First-run or bad save → treat last as same as current
            if (lastPercent <= 0)
            {
                lastScalar = currentScalar;
            }
            else
            {
                lastScalar = PercentToScalar(lastPercent);
            }

            return true;
        }

        private static void SyncLastDepotPercents(Setting settings)
        {
            settings.BusDepotLastPercent = settings.BusDepotPercent;
            settings.TaxiDepotLastPercent = settings.TaxiDepotPercent;
            settings.TramDepotLastPercent = settings.TramDepotPercent;
            settings.TrainDepotLastPercent = settings.TrainDepotPercent;
            settings.SubwayDepotLastPercent = settings.SubwayDepotPercent;
        }

        // ---- HELPERS: PASSENGER SCALARS ----

        /// <summary>
        /// Returns current and last scalars for passenger capacity.
        /// Taxi is intentionally skipped (game keeps 4 seats).
        /// </summary>
        private static bool GetPassengerScalars(
            Setting settings,
            TransportType type,
            out float currentScalar,
            out float lastScalar)
        {
            int currentPercent;
            int lastPercent;

            switch (type)
            {
                case TransportType.Bus:
                    currentPercent = settings.BusPassengerPercent;
                    lastPercent = settings.BusPassengerLastPercent;
                    break;
                case TransportType.Tram:
                    currentPercent = settings.TramPassengerPercent;
                    lastPercent = settings.TramPassengerLastPercent;
                    break;
                case TransportType.Train:
                    currentPercent = settings.TrainPassengerPercent;
                    lastPercent = settings.TrainPassengerLastPercent;
                    break;
                case TransportType.Subway:
                    currentPercent = settings.SubwayPassengerPercent;
                    lastPercent = settings.SubwayPassengerLastPercent;
                    break;
                case TransportType.Ship:
                    currentPercent = settings.ShipPassengerPercent;
                    lastPercent = settings.ShipPassengerLastPercent;
                    break;
                case TransportType.Ferry:
                    currentPercent = settings.FerryPassengerPercent;
                    lastPercent = settings.FerryPassengerLastPercent;
                    break;
                case TransportType.Airplane:
                    currentPercent = settings.AirplanePassengerPercent;
                    lastPercent = settings.AirplanePassengerLastPercent;
                    break;
                default:
                    // Includes Taxi → leave at vanilla value.
                    currentScalar = 1f;
                    lastScalar = 1f;
                    return false;
            }

            currentScalar = PercentToScalar(currentPercent);

            if (lastPercent <= 0)
            {
                lastScalar = currentScalar;
            }
            else
            {
                lastScalar = PercentToScalar(lastPercent);
            }

            return true;
        }

        private static void SyncLastPassengerPercents(Setting settings)
        {
            settings.BusPassengerLastPercent = settings.BusPassengerPercent;
            settings.TramPassengerLastPercent = settings.TramPassengerPercent;
            settings.TrainPassengerLastPercent = settings.TrainPassengerPercent;
            settings.SubwayPassengerLastPercent = settings.SubwayPassengerPercent;
            settings.ShipPassengerLastPercent = settings.ShipPassengerPercent;
            settings.FerryPassengerLastPercent = settings.FerryPassengerPercent;
            settings.AirplanePassengerLastPercent = settings.AirplanePassengerPercent;
        }
    }
}
