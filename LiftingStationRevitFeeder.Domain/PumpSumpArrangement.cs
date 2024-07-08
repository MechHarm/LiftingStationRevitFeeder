using MeasurementUnits.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public Length MinLSWallDistanceX { get; private set; }
        public Length MinLSWallDistanceY { get; private set; }
        protected PumpSumpArrangement(
            PumpSelector pumpSelector,
            Pipes pipes,
            PumpGeometry pumpGeometry,
            Length? dimK = default,
            Length? dimL = default,
            Length? dimM = default,
            Length? dimN = default,
            Length? dimO = default,
            Length? dimP = default,
            Length? dimQ = default,
            Length? dimR = default,
            Length? dimU = default
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
            MinLSWallDistanceX = GetMinimumLSWallDistanceX(pumpSelector,pumpGeometry);
            MinLSWallDistanceY = GetMinimumLSWallDistanceY(pumpGeometry);
        }
        public static PumpSumpArrangement Create(
            PumpSelector pumpSelector,
            Pipes pipes,
            PumpGeometry pumpGeometry,
            Length? dimK = default,
            Length? dimL = default,
            Length? dimM = default,
            Length? dimN = default,
            Length? dimO = default,
            Length? dimP = default,
            Length? dimQ = default,
            Length? dimR = default,
            Length? dumU = default)
        {
            return new PumpSumpArrangement(
             pumpSelector, pipes, pumpGeometry, dimK, dimL, dimM, dimN, dimO, dimP, dimQ, dimR, dumU);
        }
        private Length GetPumpDimensionO(Pipes pipes) => pipes.DN3.Value < 80 ? new Length(500 + Math.Ceiling(pipes.DN3.Value / 4) * 10, "mm")
                                          : pipes.DN3.Value < 125 ? new Length(500 + Math.Ceiling(pipes.DN3.Value / 6) * 10, "mm")
                                          : new Length(500 + Math.Ceiling(pipes.DN3.Value / 7) * 10, "mm");
        private Length GetPumpDimensionP(Pipes pipes) => pipes.DN3.Value < 80 ? new Length(500 + Math.Ceiling(pipes.DN3.Value / 4) * 20, "mm")
                                            : pipes.DN3.Value < 125 ? new Length(500 + Math.Ceiling(pipes.DN3.Value / 6) * 20, "mm")
                                            : new Length(500 + Math.Ceiling(pipes.DN3.Value / 7) * 20, "mm");
        private Length GetPumpDimensionR(Pipes pipes) =>
            new Length(Math.Round((pipes.DN4.Value / 2 + 810)/5) * 5, "mm");
        private Length GetMinimumLSWallDistanceX(PumpSelector pumpSelector, PumpGeometry pumpGeometry) =>
         new Length(2 * DimK.Value + pumpSelector.NumberOfPumps * pumpGeometry.DimH.Value + (pumpSelector.NumberOfPumps - 1) * DimL.Value, "mm");
        private Length GetMinimumLSWallDistanceY(PumpGeometry pumpGeometry) =>
            new Length((Math.Round((DimM.Value + pumpGeometry.DimE.Value + pumpGeometry.DimF.Value + pumpGeometry.DimG.Value + pumpGeometry.DimH.Value / 2) / 10) * 10) + 800, "mm");

    }
}
