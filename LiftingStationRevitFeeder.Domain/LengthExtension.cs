using MeasurementUnits.NET;

namespace LiftingStationRevitFeeder.Domain
{

    public static class LengthExtension
    {
        private static readonly List<Length> _diameters = new()
    {
         new(15,"mm"),
         new(20,"mm"),
         new(25,"mm"),
         new(32,"mm"),
         new(40,"mm"),
         new(50,"mm"),
         new(65,"mm"),
         new(80,"mm"),
         new(90,"mm"),
         new(100,"mm"),
         new(125,"mm"),
         new(150,"mm"),
         new(200,"mm"),
         new(250,"mm"),
         new(300,"mm"),
         new(350,"mm"),
         new(400,"mm"),
         new(450,"mm"),
         new(500,"mm"),
         new(550,"mm"),
         new(600,"mm"),
    };
        public static Length GetStandardDiameter(this Length rawDiameter) 
            => _diameters.FirstOrDefault(d => d>=rawDiameter) is null ? throw new Exception("Diameter not found") : _diameters.First(d => d>=rawDiameter);
        
        public static Length GetLastSmallerDiameter(this Length rawDiameter)
                     => _diameters.Last(d=>d<GetStandardDiameter(rawDiameter));

    }
}
