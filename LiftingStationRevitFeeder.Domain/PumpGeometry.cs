using MeasurementUnits.NET;

namespace LiftingStationRevitFeeder.Domain
{
    public class PumpGeometry
    {
        public Length? DimA { get; private set; }
        public Length? DimB { get; private set; }
        public Length? DimC { get; private set; }
        public Length? DimD { get; private set; }
        public Length? DimE { get; private set; }
        public Length? DimF { get; private set; }
        public Length? DimG { get; private set; }
        public Length? DimH { get; private set; }
        public Length? DimI { get; private set; }
        public Length? DimJ { get; private set; }

        public static PumpGeometry Create(Pipes pipes)
        {
            return new PumpGeometry(pipes);   
        }
        public static PumpGeometry Create(
            Pipes pipes,
            Length? dimA = default,
            Length? dimB = default,
            Length? dimC = default,
            Length? dimD = default,
            Length? dimE = default,
            Length? dimF = default,
            Length? dimG = default,
            Length? dimH = default,
            Length? dimI = default,
            Length? dimJ = default
            )
        {
            return new PumpGeometry(pipes, dimA, dimB, dimC, dimD, dimE, dimF, dimG, dimH, dimI, dimJ);
        }
        protected PumpGeometry(Pipes pipes)
        {
            DimA = GetPumpDimensionA(pipes);
            DimB = GetPumpDimensionB(pipes);
            DimC = GetPumpDimensionC(pipes);
            DimD = GetPumpDimensionD(pipes);
            DimF = GetPumpDimensionF(pipes);
            DimG = DimF + pipes.DN2;
            DimH = GetPumpDimensionH(pipes);
            DimI = GetPumpDimensionI(pipes);
            DimE = DimI * 1.6;
            DimJ = GetPumpDimensionJ(pipes);
        }
        protected PumpGeometry(
            Pipes pipes,
            Length? dimA = default,
            Length? dimB = default,
            Length? dimC = default,
            Length? dimD = default,
            Length? dimE = default,
            Length? dimF = default,
            Length? dimG = default,
            Length? dimH = default,
            Length? dimI = default,
            Length? dimJ = default 
            )
        {
            DimA = dimA ?? GetPumpDimensionA(pipes);
            DimB = dimB ?? GetPumpDimensionB(pipes);
            DimC = dimC ?? GetPumpDimensionC(pipes);
            DimD = dimD ?? GetPumpDimensionD(pipes);
            DimF = dimF ?? GetPumpDimensionF(pipes);
            DimG = dimG ?? DimF + pipes.DN2;
            DimH = dimH ?? GetPumpDimensionH(pipes);
            DimI = dimI ?? GetPumpDimensionI(pipes);
            DimE = dimE ?? DimI * 1.6;
            DimJ = dimJ ?? GetPumpDimensionJ(pipes);
        }
        private Length GetPumpDimensionA(Pipes pipes) => pipes.DN1.Value == 150 ? new Length(200, "mm")
          : new Length(Math.Min(400, Math.Max(100, pipes.DN1.Value)), "mm");
        // private Length GetPumpDimensionB() =>
        //    new Length(Math.Min(2400, 8 * DN1.Value), "mm");
        private Length GetPumpDimensionB(Pipes pipes) => Math.Floor(pipes.DN1.Value / 100) == 2 ? new Length(pipes.DN1.Value * 8 - 300, "mm")
                                            : pipes.DN1.Value < 200 ? new Length(pipes.DN1.Value * 8, "mm")
                                            : new Length(2400, "mm");
        private Length GetPumpDimensionC(Pipes pipes) =>
            new Length(pipes.DN2.Value / 2 + DimA.Value + 50, "mm");
        private Length GetPumpDimensionD(Pipes pipes) =>
            new Length(DimC.Value + Math.Round(pipes.DN2.Value * 0.35) * 5, "mm");
        private Length GetPumpDimensionF(Pipes pipes) =>
            new Length(Math.Round(((pipes.DN2.Value + 90)/2)/5) * 5, "mm");
        private Length GetPumpDimensionH(Pipes pipes) => pipes.DN1.Value < 100 ? new Length(pipes.DN1.Value * 5, "mm")
                                            : pipes.DN1.Value < 175 ? new Length(pipes.DN1.Value * 4, "mm")
                                            : pipes.DN1.Value < 250 ? new Length(Math.Round(pipes.DN1.Value * 3.5), "mm")
                                            : new Length(pipes.DN1.Value * 3, "mm");
        private Length GetPumpDimensionI(Pipes pipes) => pipes.DN1.Value < 125 ? new Length(Math.Round(DimH.Value / 2 + 12.5), "mm")
                                            : pipes.DN1.Value < 175 ? new Length(Math.Round(DimH.Value / 2 + 25), "mm")
                                            : pipes.DN1.Value < 250 ? new Length(Math.Round(DimH.Value / 2 + 57.5), "mm")
                                            : new Length(Math.Round(DimH.Value / 2 + 75), "mm");
        private Length GetPumpDimensionJ(Pipes pipes) => pipes.DN1.Value < 250 ? new Length(85, "mm")
                                            : new Length(150, "mm");
    }
}
