using HydraulicLogic.Contract.DistributionChannelSizes.GetDistributionChannelSizes;
using MeasurementUnits.NET;
using System.Net;

namespace LiftingStationRevitFeeder.Domain
{
    public class RevitFeed
    {
        public PumpSelector PumpSelector { get; private set; }
        public Pipes Pipes { get; private set; }
        public PumpGeometry PumpGeometry { get; set; }
        
        public Length? Freeboard { get; private set; }
        public Length? LevA { get; private set; }
        public Length? LevB { get; private set; }
        public Length? LevC { get; private set; }
        public Length? LevD { get; private set; }
        public Length? LevE { get; private set; }
        public Length? LevF { get; private set; }
        public Length? LevG { get; private set; }
        public Length? LevH { get; private set; }
        public Length? LevI { get; private set; }
        public Length WetWellDepth { get; private set; }
    
        public Length? DimK { get; private set; }
        public Length? DimL { get; private set; }
        public Length? DimM { get; private set; }
        public Length? DimN { get; private set; }
        public Length? DimO { get; private set; }
        public Length? DimP { get; private set; }
        public Length? DimQ { get; private set; }
        public Length? DimR { get; private set; }
        public Length? DimS { get; private set; }
        public Length? DimT { get; private set; }
        public Length? DimU { get; private set; }
        public Length? DimV { get; private set; }
        public Length? DimX { get; private set; }
        public Length? DimY { get; private set; }
        public Length? DimZ { get; private set; }
        public Length? DimW { get; private set; }
        public Length MinLSWallDistanceX { get; private set; }
        public Length MinLSWallDistanceY { get; private set; }
        public string MeasurementRange { get; private set; }


        public static RevitFeed CreateBase(VolumetricFlow designPeakHourFlow, Length head)
        {
            var pumpSelection = PumpSelector.Create(designPeakHourFlow, head);
            return new RevitFeed(designPeakHourFlow, head);
        }
        protected RevitFeed(VolumetricFlow designPeakHourFlow, Length head)
        {
            PumpSelector = PumpSelector.Create(designPeakHourFlow, head);
            Pipes = Pipes.Create(PumpSelector);
            PumpGeometry = PumpGeometry.Create(Pipes);
            Freeboard = new Length(500, "mm");
            LevA = new Length(1000, "mm");
            LevB = new Length(500, "mm");
            LevC = new Length(500, "mm");
            LevD = new Length(500, "mm");
            LevE = new Length(500, "mm");
            LevF = new Length(500, "mm");
            LevG = new Length(500, "mm");
            LevH = new Length(500, "mm");
            LevI = new Length(500, "mm");
            WetWellDepth = LevA + LevB + LevC + LevD + LevE + LevF + LevG + LevH + LevI;
            
            DimK = new Length(800, "mm");
            DimL = new Length(800, "mm");
            DimM = Pipes.DN3 * 1.5;
            DimN = new Length(1000, "mm");
            DimO = GetPumpDimensionO();
            DimP = GetPumpDimensionP();
            DimQ = DimO;
            DimR = GetPumpDimensionR();
            DimS = Pipes.DN4 * 1.5;
            DimT = GetPumpDimensionT();
            DimU = new Length(400, "mm");
            DimV = new Length(400, "mm");
            MinLSWallDistanceX = GetMinimumLSWallDistanceX();
            MinLSWallDistanceY = GetMinimumLSWallDistanceY();
            //DimX = dimX ?? Civil Requirement > MinLSWallDistanceX
            //DimY = dimY ?? Civil Requirement > MinLSWallDistanceY
            DimZ = GetPumpDimensionZ();
            DimW = DimN + DimO + DimP + DimQ + DimU + DimV + DimR;
            MeasurementRange = new String($"0 - {(PumpSelector.Flow.GetValue("m3 h-1") * 1.1):F0} CMH");
        }
        public RevitFeed(
                            VolumetricFlow designPeakHourFlow,
                            Length head,
                            Velocity? pumpInletVelocity,
                            Velocity? pressurizedPipeVelocity,
                            Velocity? gravityPipeVelocity,
                            int? dutyPumpsCount = 1,
                            int? standbyPumpsCount = 1,
                            Length? dn1 = default,
                            Length? dn2 = default,
                            Length? dn3 = default,
                            Length? dn4 = default,
                            Length? dn5 = default,
                            Length? dnBreath = default,
                            Length? dnInlet = default,
                            Length? dnBackflow = default,
                            Length? freeboard = default,
                            Length? levA = default,
                            Length? levB = default,
                            Length? levC = default,
                            Length? levD = default,
                            Length? levE = default,
                            Length? levF = default,
                            Length? levG = default,
                            Length? levH = default,
                            Length? levI = default,
                            Length? dimA = default,
                            Length? dimB = default,
                            Length? dimC = default,
                            Length? dimD = default,
                            Length? dimE = default,
                            Length? dimF = default,
                            Length? dimG = default,
                            Length? dimH = default,
                            Length? dimI = default,
                            Length? dimJ = default,
                            Length? dimK = default,
                            Length? dimL = default,
                            Length? dimM = default,
                            Length? dimN = default,
                            Length? dimO = default,
                            Length? dimP = default,
                            Length? dimQ = default,
                            Length? dimR = default,
                            Length? dimS = default,
                            Length? dimT = default,
                            Length? dimU = default,
                            Length? dimV = default,
                            Length? dimX = default,
                            Length? dimY = default,
                            Length? dimZ = default,
                            Length? dimW = default,
                            Length? minLSWallDistanceX = default,
                            Length? minLSWallDistanceY = default,
                            string measurementRange = default
                        ) : this(designPeakHourFlow, head)
        {

            PumpSelector = PumpSelector.Create(designPeakHourFlow, head, dutyPumpsCount, standbyPumpsCount, pumpInletVelocity, gravityPipeVelocity, pressurizedPipeVelocity);
            Pipes = Pipes.Create(PumpSelector, dn1, dn2, dn3, dn4, dn5, dnBreath, dnInlet, dnBackflow );
            PumpGeometry = PumpGeometry.Create(Pipes, dimA, dimB, dimC, dimD, dimE, dimF, dimG, dimH, dimI, dimJ);

            Freeboard = freeboard ?? new Length(500, "mm");
            LevA = levA ?? new Length(1000, "mm");
            LevB = levB ?? new Length(500, "mm");
            LevC = levC ?? new Length(500, "mm");
            LevD = levD ?? new Length(500, "mm");
            LevE = levE ?? new Length(500, "mm");
            LevF = levF ?? new Length(500, "mm");
            LevG = levG ?? new Length(500, "mm");
            LevH = levH ?? new Length(500, "mm");
            LevI = levI ?? new Length(500, "mm");
            WetWellDepth = LevA + LevB + LevC + LevD + LevE + LevF + LevG + LevH + LevI;
            
            DimK = dimK ?? new Length(800, "mm");
            DimL = dimL ?? new Length(800, "mm");
            DimM = dimM ?? Pipes.DN3 * 1.5;
            DimN = dimN ?? new Length(1000, "mm");
            DimO = dimO ?? GetPumpDimensionO();
            DimP = dimP ?? GetPumpDimensionP();
            DimQ = dimQ ?? DimO;
            DimR = dimR ?? GetPumpDimensionR();
            DimS = dimS ?? Pipes.DN4 * 1.5;
            DimT = dimT ?? GetPumpDimensionT();
            DimU = dimU ?? new Length(400, "mm");
            DimV = dimV ?? new Length(400, "mm");
            MinLSWallDistanceX = GetMinimumLSWallDistanceX();
            MinLSWallDistanceY = GetMinimumLSWallDistanceY();
            //DimX = dimX ?? Civil Requirement > MinLSWallDistanceX
            //DimY = dimY ?? Civil Requirement > MinLSWallDistanceY
            DimZ = dimZ ?? GetPumpDimensionZ();
            DimW = dimW ?? DimN + DimO + DimP + DimQ + DimU + DimV + DimR;
            MeasurementRange = new String($"0 - {(PumpSelector.Flow.GetValue("m3 h-1") * 1.1):F0} CMH");
        }


      
        private Length GetPumpDimensionO() => Pipes.DN3.Value < 80 ? new Length(500 + Math.Ceiling(Pipes.DN3.Value / 4) * 10, "mm")
                                            : Pipes.DN3.Value < 125 ? new Length(500 + Math.Ceiling(Pipes.DN3.Value / 6) * 10, "mm")
                                            : new Length(500 + Math.Ceiling(Pipes.DN3.Value / 7) * 10, "mm");
        private Length GetPumpDimensionP() => Pipes.DN3.Value < 80 ? new Length(500 + Math.Ceiling(Pipes.DN3.Value / 4) * 20, "mm")
                                            : Pipes.DN3.Value < 125 ? new Length(500 + Math.Ceiling(Pipes.DN3.Value / 6) * 20, "mm")
                                            : new Length(500 + Math.Ceiling(Pipes.DN3.Value / 7) * 20, "mm");
        private Length GetPumpDimensionR() =>
            new Length(Math.Round((Pipes.DN4.Value / 2 + 810)/5) * 5, "mm");
        private Length GetPumpDimensionT() => Pipes.DN3.Value < 80 ? new Length(Math.Ceiling(Pipes.DN3.Value / 4) * 10 + DimS.Value + 300, "mm")
                                            : Pipes.DN3.Value < 125 ? new Length(Math.Ceiling(Pipes.DN3.Value / 6) * 10 + DimS.Value + 300, "mm")
                                            : new Length(Math.Ceiling(Pipes.DN3.Value / 7) * 10 + DimS.Value + 300, "mm");
        private Length GetMinimumLSWallDistanceX() =>
            new Length(2 * DimK.Value + PumpSelector.NumberOfPumps * PumpGeometry.DimH.Value + (PumpSelector.NumberOfPumps - 1) * DimL.Value, "mm");
        private Length GetMinimumLSWallDistanceY() =>
            new Length((Math.Round((DimM.Value + PumpGeometry.DimE.Value + PumpGeometry.DimF.Value + PumpGeometry.DimG.Value + PumpGeometry.DimH.Value / 2) / 10) * 10) + 800, "mm");
        private Length GetPumpDimensionZ() =>
            new Length(DimK.Value + (PumpSelector.NumberOfPumps - 1) * (PumpGeometry.DimH.Value + DimL.Value) + (Pipes.DN4.Value + 50) * 11, "mm");
    }
       
         
        }
    
    
