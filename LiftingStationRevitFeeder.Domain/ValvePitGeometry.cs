using MeasurementUnits.NET;

namespace LiftingStationRevitFeeder.Domain
{
    public class ValvePitGeometry
    {
        public Length? DimZ { get; private set; }
        public Length? DimW { get; private set; }
        public Length? DimV { get; private set; }

        protected ValvePitGeometry(PumpSelector pumpSelector, Pipes pipes, PumpGeometry pumpGeometry, PumpSumpArrangement pumpSumpArrangement, Length? dimV = default, Length? dimZ = default, Length? dimW = default)
        {
            DimV = dimV ?? new Length(400, "mm");
            DimZ = dimZ ?? GetPumpDimensionZ(pumpSelector, pipes, pumpGeometry, pumpSumpArrangement);
            DimW = dimW ?? pumpSumpArrangement.DimO + pumpSumpArrangement.DimP + pumpSumpArrangement.DimQ + pumpSumpArrangement.DimR;

        }
        public static ValvePitGeometry Create(PumpSelector pumpSelector, Pipes pipes, PumpGeometry pumpGeometry, PumpSumpArrangement pumpSumpArrangement, Length? dimV = default, Length? dimZ = default, Length? dimW = default)
        {
            return new ValvePitGeometry(pumpSelector, pipes, pumpGeometry, pumpSumpArrangement, dimV, dimZ);
        }
        private Length GetPumpDimensionZ(PumpSelector pumpSelector, Pipes pipes, PumpGeometry pumpGeometry, PumpSumpArrangement pumpSumpArrangement) =>
          new Length(pumpSumpArrangement.DimK.Value + (pumpSelector.NumberOfPumps - 1) * (pumpGeometry.DimH.Value + pumpSumpArrangement.DimL.Value) + (pipes.DN4.Value + 50) * 11, "mm");
    }
}
