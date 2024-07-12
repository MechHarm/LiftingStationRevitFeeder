using MeasurementUnits.NET;

namespace LiftingStationRevitFeeder.Application
{
    public static class Mapper
    {
        public static ResponseData MapFromMeasurementUnit(string denomination, Quantity? measurementUnit)
            => measurementUnit is null
                ? throw new ArgumentNullException()
                : ResponseData.CreateMeasurementUnit(denomination, measurementUnit.Value.ToString(), measurementUnit.GetUnit(), measurementUnit.GetType().Name.ToString());
        public static ResponseData MapFromInt(string denomination, int q)
            => ResponseData.CreateNotMeasurementUnit(denomination, q.ToString(), q.GetType().Name.ToString());
    }
}
