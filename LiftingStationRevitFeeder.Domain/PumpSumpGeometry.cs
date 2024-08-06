using MeasurementUnits.NET;

namespace LiftingStationRevitFeeder.Domain
{
    public class PumpSumpGeometry
    {
        public Length? DimU { get; private set; }

        protected PumpSumpGeometry
            (
            Length? dimU = default
            )
        {
            
            DimU = dimU ?? new Length(400, "mm");
        }
        public static PumpSumpGeometry Create(
            Length? dimU = default)
        {
            return new PumpSumpGeometry(dimU);
        }
    }
}
