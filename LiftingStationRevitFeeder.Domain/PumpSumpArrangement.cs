using MeasurementUnits.NET;

namespace LiftingStationRevitFeeder.Domain
{
    public class PumpSumpArrangement
    {
        public Length? DimK { get; private set; }
        public Length? DimL { get; private set; }
        public Length? DimM { get; private set; }
        public Length? DimN { get; private set; }
        public Length? DimO { get; private set; }
        public Length? DimP { get; private set; }
        public Length? DimQ { get; private set; }
        public Length? DimR { get; private set; }
        public Length? DimU { get; private set; }
        public Length DimX { get; private set; }
        public Length DimY { get; private set; }
        public Length? CivL { get; private set; }
        public Length? CivM { get; private set; }
        public Length? CivI { get; private set; }
        public Length? CivN { get; private set; }
        public Length? CivO { get; private set; }
        public Length? CivP { get; private set; }
        public Length? CivQ { get; private set; }
        public Length? CivF { get; private set; }
        public Length? CivH { get; private set; }
        public Length? CivG { get; private set; }
        public Length? CivJ { get; private set; }
        public Length? CivK { get; private set; }
        public Length? CivS { get; private set; }
        public Length? CivR { get; private set; }
        public Length? CivT { get; private set; }
        public Length? InletLocation { get; private set; }

        protected PumpSumpArrangement(
            PumpSelector pumpSelector,
            Pipes pipes,
            PumpGeometry pumpGeometry,
            PumpSumpGeometry pumpSumpGeometry,
            Levels levels,
            Length? dimK = default,
            Length? dimL = default,
            Length? dimM = default,
            Length? dimN = default,
            Length? dimO = default,
            Length? dimP = default,
            Length? dimQ = default,
            Length? dimR = default,
            Length? dimU = default,
            Length? dimX = default,
            Length? dimY = default,
            Length? civL = default,
            Length? civM = default,
            Length? civI = default,
            Length? civN = default,
            Length? civO = default,
            Length? civP = default,
            Length? civQ = default,
            Length? civF = default,
            Length? civH = default,
            Length? civG = default,
            Length? civJ = default,
            Length? civK = default,
            Length? civS = default,
            Length? civR = default,
            Length? civT = default,
            Length? inletLocation = default
            )
        {
            DimK = dimK ?? new Length(800, "mm");
            DimL = dimL ?? new Length(800, "mm");
            DimM = dimM ?? pipes.DN3 * 1.5;
            DimN = dimN ?? new Length(1000, "mm");
            DimO = dimO ?? GetPumpDimensionO(pipes);
            DimP = dimP ?? GetPumpDimensionP(pipes);
            DimQ = dimQ ?? DimO;
            DimR = dimR ?? GetPumpDimensionR(pipes);
            DimU = dimU ?? new Length(400, "mm");
            CivF = GetBafflePosition(pipes);
            DimX = GetMinimumLSWallDistanceX(pumpSelector, pumpGeometry); // To be considered as minimum value, Total volume needs to be checked
            DimY = GetMinimumLSWallDistanceY(pumpGeometry); // To be considered as minimum value, Total volume needs to be checked
            CivL = GetManholeX(pumpGeometry);
            CivM = GetManholeY(pumpGeometry);
            CivI = GetSlopeStart(pumpGeometry);
            CivN = GetManholePosition(pumpGeometry);
            CivO = GetValveManholeX(pipes);
            CivP = GetValveManholeY();
            CivQ = GetValveManholePosition();
            CivH = GetCivHDimension();
            CivG = GetCivGDimension(levels, pipes);
            CivJ = GetBaffleWallOpening(pipes);
            CivK = GetBaffleWallOpening(pipes);
            CivS = GetFlowmeterManholeY(pipes);
            CivR = GetFlowmeterManholeX(pipes);
            CivT = GetFlowmeterManholePosition(pipes);
            InletLocation = GetInletPosition();
        }
        public static PumpSumpArrangement Create(
            PumpSelector pumpSelector,
            Pipes pipes,
            PumpGeometry pumpGeometry,
            PumpSumpGeometry pumpSumpGeometry,
            Levels levels,
            Length? dimK = default,
            Length? dimL = default,
            Length? dimM = default,
            Length? dimN = default,
            Length? dimO = default,
            Length? dimP = default,
            Length? dimQ = default,
            Length? dimR = default,
            Length? dimU = default,
            Length? dimX = default,
            Length? dimY = default,
            Length? civL = default,
            Length? civM = default,
            Length? civI = default,
            Length? civN = default,
            Length? civO = default,
            Length? civP = default,
            Length? civQ = default,
            Length? civF = default,
            Length? civH = default,
            Length? civG = default,
            Length? civJ = default,
            Length? civK = default,
            Length? civS = default,
            Length? civR = default,
            Length? civT = default,
            Length? inletLocation = default)
        {
            return new PumpSumpArrangement(
             pumpSelector, pipes, pumpGeometry, pumpSumpGeometry, levels, dimK, dimL, dimM, dimN, dimO, dimP, dimQ, dimR, dimU, dimX, dimY, civL, civM, civI, civN, civO, civP, civQ, civF, civH, civG, civJ, civK, civS, civR, civT, inletLocation);
        }
        private Length GetPumpDimensionO(Pipes pipes) => pipes.DN3.Value < 80 ? new Length(500 + Math.Ceiling(pipes.DN3.Value / 4) * 10, "mm")
                                          : pipes.DN3.Value < 125 ? new Length(500 + Math.Ceiling(pipes.DN3.Value / 6) * 10, "mm")
                                          : new Length(500 + Math.Ceiling(pipes.DN3.Value / 7) * 10, "mm");
        private Length GetPumpDimensionP(Pipes pipes) => pipes.DN3.Value < 80 ? new Length(500 + Math.Ceiling(pipes.DN3.Value / 4) * 20, "mm")
                                            : pipes.DN3.Value < 125 ? new Length(500 + Math.Ceiling(pipes.DN3.Value / 6) * 20, "mm")
                                            : new Length(500 + Math.Ceiling(pipes.DN3.Value / 7) * 20, "mm");
        private Length GetPumpDimensionR(Pipes pipes) =>
            new Length(Math.Round((pipes.DN4.Value / 2 + 810) / 5) * 5, "mm");
        private Length GetBafflePosition(Pipes pipes) =>
           new Length(Math.Max(500, pipes.DNInlet.Value * 1.5), "mm");
        private Length GetMinimumLSWallDistanceX(PumpSelector pumpSelector, PumpGeometry pumpGeometry) =>
         new Length(2 * DimK.Value + pumpSelector.NumberOfPumps * pumpGeometry.DimH.Value + (pumpSelector.NumberOfPumps - 1) * DimL.Value, "mm");
        private Length GetMinimumLSWallDistanceY(PumpGeometry pumpGeometry) =>
            new Length((Math.Round((DimM.Value + pumpGeometry.DimE.Value + pumpGeometry.DimF.Value + pumpGeometry.DimG.Value + pumpGeometry.DimH.Value / 2) / 10) * 10) + Math.Max(200 + CivF.Value, 800), "mm");
        private Length GetManholeY(PumpGeometry pumpGeometry) =>
           new Length((Math.Round((pumpGeometry.DimE.Value + pumpGeometry.DimF.Value + pumpGeometry.DimH.Value + pumpGeometry.DimJ.Value) / 100) * 100) + 100, "mm");
        private Length GetManholeX(PumpGeometry pumpGeometry) =>
           new Length(Math.Round(((2 * pumpGeometry.DimI.Value) / 100) * 100) + 200, "mm");
        private Length GetManholePosition(PumpGeometry pumpGeometry) =>
           new Length(DimM.Value + pumpGeometry.DimG.Value - pumpGeometry.DimJ.Value, "mm");
        private Length GetValveManholePosition() =>
           new Length(DimO.Value / 2, "mm");
        private Length GetValveManholeY() =>
           new Length(DimO.Value / 2 + DimP.Value + DimQ.Value / 2, "mm");
        private Length GetValveManholeX(Pipes pipes) =>
           new Length(Math.Max(400, pipes.DN1.Value / 2), "mm");
        private Length GetSlopeStart(PumpGeometry pumpGeometry) =>
           new Length((Math.Round((DimM.Value + pumpGeometry.DimE.Value + pumpGeometry.DimF.Value + pumpGeometry.DimG.Value + pumpGeometry.DimH.Value / 2) / 10) * 10) + 200, "mm");
        private Length GetInletPosition() =>
           new Length(DimY.Value - (CivF.Value / 2), "mm");
        private Length GetCivHDimension() =>
           new Length(Math.Round(((DimY.Value - CivI.Value + CivF.Value) * Math.Tan(10 * Math.PI / 180) + 500) / 10) * 10, "mm");
        private Length GetCivGDimension(Levels levels, Pipes pipes) =>
           new Length(levels.WetWellDepth.Value - CivH.Value - levels.LevA.Value + pipes.DNInlet.Value, "mm");
        private Length GetBaffleWallOpening(Pipes pipes) =>
           new Length(Math.Min(Math.Max(300, Math.Ceiling((pipes.DN1.Value * 1.5) / 100) * 100), CivF.Value), "mm");
        private Length GetFlowmeterManholeY(Pipes pipes) =>
           new Length(Math.Max(300, Math.Ceiling((pipes.DN5.Value * 3) / 100) * 100), "mm");
        private Length GetFlowmeterManholeX(Pipes pipes) => pipes.DN5.Value < 200 ? new Length(500, "mm")
                                            : pipes.DN5.Value < 300 ? new Length(800, "mm")
                                            : new Length(1000, "mm");
        private Length GetFlowmeterManholePosition(Pipes pipes) =>
          new Length(pipes.DN4.Value * 5, "mm");
    }
}
