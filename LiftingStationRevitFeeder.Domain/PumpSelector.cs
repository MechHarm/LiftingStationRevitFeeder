using MeasurementUnits.NET;

namespace LiftingStationRevitFeeder.Domain
{
    public class PumpSelector
    {
        public string MeasurementSystem { get; }
        public VolumetricFlow DesignPeakHourFlow { get; }
        public Length Head { get; }
        public int DutyPumpsCount { get; }
        public int StandbyPumpsCount { get; }
        public int NumberOfPumps { get; private set; }
        public VolumetricFlow Flow { get; private set; }
        public Velocity PumpInletVelocity { get; }
        public Velocity PressurizedPipeVelocity { get; }
        public Velocity GravityPipeVelocity { get; }
        public Power InstalledPower { get; }
        public Power PowerConsumption { get; }


        protected PumpSelector(
            VolumetricFlow designPeakHourFlow,
            Length head,
            int dutyPumpsCount = 1,
            int standbyPumpsCount = 1,
            Velocity? pumpInletVelocity = default,
            Velocity? gravityPipeVelocity = default,
            Velocity? pressurizedPipeVelocity = default,
            VolumetricFlow? flow = default,
            Power installedPower = default,
            Power powerConsumption = default,
            string measurementSystem = default)
        {
            MeasurementSystem = measurementSystem;
            DesignPeakHourFlow = designPeakHourFlow;
            Head = head;
            DutyPumpsCount = dutyPumpsCount;
            StandbyPumpsCount = standbyPumpsCount;
            PumpInletVelocity = pumpInletVelocity ?? new Velocity(1.7, "m s-1");
            GravityPipeVelocity = gravityPipeVelocity ?? new Velocity(0.6, "m s-1");
            PressurizedPipeVelocity = pressurizedPipeVelocity ?? new Velocity(2, "m s-1");
            Flow = designPeakHourFlow / DutyPumpsCount;
            NumberOfPumps = DutyPumpsCount + StandbyPumpsCount;
            InstalledPower = new Power(10, "kW");
            PowerConsumption = new Power(8.5, "kW");
        }
        public static PumpSelector Create(
            VolumetricFlow designPeakHourFlow,
            Length head,
            int? dutyPumpsCount = 1,
            int? standbyPumpsCount = 1,
            Velocity? pumpInletVelocity = null,
            Velocity? gravityPipeVelocity = null,
            Velocity? pressurizedPipeVelocity = null,
            VolumetricFlow? flow = null,
            Power? installedPower = null,
            Power? powerConsumption = null,
            string? measurementSystem = null)
        {
            var result = new PumpSelector(
            designPeakHourFlow,
            head,
            dutyPumpsCount ?? 1,
            standbyPumpsCount ?? 1,
            pumpInletVelocity,
            gravityPipeVelocity,
            pressurizedPipeVelocity,
            flow,
            installedPower,
            powerConsumption,
            measurementSystem
            );
            return result;
        }
    }
}
