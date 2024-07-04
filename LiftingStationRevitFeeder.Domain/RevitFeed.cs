using HydraulicLogic.Contract.DistributionChannelSizes.GetDistributionChannelSizes;
using MeasurementUnits.NET;
using System.Net;

namespace LiftingStationRevitFeeder.Domain
{
    public class RevitFeed
    {
        public VolumetricFlow DesignPeakHourFlow { get; private set; }
        public int? DutyPumpsCount { get; private set; }
        public int? StandbyPumpsCount { get; private set; }
        public int NumberOfPumps { get; private set; }
        public VolumetricFlow Flow { get; private set; }
        public Length Head { get; private set; }
        public Velocity? PumpInletVelocity { get; private set; }
        public Velocity? PressurizedPipeVelocity { get; private set; }
        public Velocity? GravityPipeVelocity { get; private set; }
        public Length? DN1 { get; private set; }
        public Length? DN2 { get; private set; }
        public Length? DN3 { get; private set; }
        public Length? DN4 { get; private set; }
        public Length? DN5 { get; private set; }
        public Length? DNBreath { get; private set; }
        public Length? DNInlet { get; private set; }
        public Length? DNBackflow { get; private set; }
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


        public RevitFeed(
                            VolumetricFlow designPeakHourFlow,
                            Length head,
                            Velocity? pumpInletVelocity,
                            Velocity? pressurizedPipeVelocity,
                            Velocity? gravityPipeVelocity,
                            int? dutyPumpsCount,
                            int? standbyPumpsCount,
                            Length? dn1,
                            Length? dn2,
                            Length? dn3,
                            Length? dn4,
                            Length? dn5,
                            Length? dnBreath,
                            Length? dnInlet,
                            Length? dnBackflow,
                            Length? freeboard,
                            Length? levA,
                            Length? levB,
                            Length? levC,
                            Length? levD,
                            Length? levE,
                            Length? levF,
                            Length? levG,
                            Length? levH,
                            Length? levI,
                            Length? dimA,
                            Length? dimB,
                            Length? dimC,
                            Length? dimD,
                            Length? dimE,
                            Length? dimF,
                            Length? dimG,
                            Length? dimH,
                            Length? dimI,
                            Length? dimJ,
                            Length? dimK,
                            Length? dimL,
                            Length? dimM,
                            Length? dimN,
                            Length? dimO,
                            Length? dimP,
                            Length? dimQ,
                            Length? dimR,
                            Length? dimS,
                            Length? dimT,
                            Length? dimU,
                            Length? dimV,
                            Length? dimX,
                            Length? dimY,
                            Length? dimZ,
                            Length? dimW,
                            Length? minLSWallDistanceX,
                            Length? minLSWallDistanceY,
                            string measurementRange
                        )
        {
            DesignPeakHourFlow = designPeakHourFlow;
            Head = head;
            PumpInletVelocity = pumpInletVelocity ?? new Velocity(1.7, "m s-1");
            PressurizedPipeVelocity = pressurizedPipeVelocity ?? new Velocity(2, "m s-1");
            GravityPipeVelocity = gravityPipeVelocity ?? new Velocity(0.6, "m s-1");
            DutyPumpsCount = dutyPumpsCount ?? 1;
            StandbyPumpsCount = standbyPumpsCount ?? 1;
            Flow = DesignPeakHourFlow / DutyPumpsCount.Value;
            NumberOfPumps = DutyPumpsCount.Value + StandbyPumpsCount.Value;
            DN1 = dn1 ?? GetSuctionDiameter();
            DN2 = dn2 ?? GetDischargeDiameter(DN1);
            DN3 = dn3 ?? GetFeederDiameter();
            DN4 = dn4 ?? GetRisingMainDiameter();
            DN5 = dn5 ?? GetFlowmeterDiameter();
            DNBreath = dnBreath ?? DN2;
            DNInlet = dnInlet ?? GetGravityMainDiameter();
            DNBackflow = dnBackflow ?? DN2;
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
            DimA = dimA ?? GetPumpDimensionA();
            DimB = dimB ?? GetPumpDimensionB();
            DimC = dimC ?? GetPumpDimensionC();
            DimD = dimD ?? GetPumpDimensionD();
            DimF = dimF ?? GetPumpDimensionF();
            DimG = dimG ?? DimF + DN2;
            DimH = dimH ?? GetPumpDimensionH();
            DimI = dimI ?? GetPumpDimensionI();
            DimE = dimE ?? DimI * 1.6;
            DimJ = dimJ ?? GetPumpDimensionJ();
            DimK = dimK ?? new Length(800, "mm");
            DimL = dimL ?? new Length(800, "mm");
            DimM = dimM ?? DN3 * 1.5;
            DimN = dimN ?? new Length(1000, "mm");
            DimO = dimO ?? GetPumpDimensionO();
            DimP = dimP ?? GetPumpDimensionP();
            DimQ = dimQ ?? DimO;
            DimR = dimR ?? GetPumpDimensionR();
            DimS = dimS ?? DN4 * 1.5;
            DimT = dimT ?? GetPumpDimensionT();
            DimU = dimU ?? new Length(400, "mm");
            DimV = dimV ?? new Length(400, "mm");
            MinLSWallDistanceX = GetMinimumLSWallDistanceX();
            MinLSWallDistanceY = GetMinimumLSWallDistanceY();
            //DimX = dimX ?? Civil Requirement > MinLSWallDistanceX
            //DimY = dimY ?? Civil Requirement > MinLSWallDistanceY
            DimZ = dimZ ?? GetPumpDimensionZ();
            DimW = dimW ?? DimN + DimO + DimP + DimQ + DimU + DimV + DimR;
            MeasurementRange = new String($"0 - {(Flow.GetValue("m3 h-1") * 1.1):F0} CMH");
        }


        private Length GetSuctionDiameter() =>
            new Length(new Length(Math.Max(0.065, Math.Sqrt((4 * Flow.GetValue("m3 s-1")
                / PumpInletVelocity.GetValue("m s-1") / Math.PI)))).CopyConvertTo("mm")).GetStandardDiameter();

        private static Length? GetDischargeDiameter(Length suctionDiameter) => suctionDiameter < new Length(150, "mm")
                ? suctionDiameter.GetLastSmallerDiameter()
                : new Length(Math.Min(suctionDiameter.GetValue("mm"), 400), "mm");
        private Length GetFeederDiameter() =>
            new Length(new Length(Math.Max(DN2.CopyConvertTo("m").Value, Math.Sqrt((4 * Flow.GetValue("m3 s-1")
                / PressurizedPipeVelocity.GetValue("m s-1") / Math.PI)))).CopyConvertTo("mm")).GetStandardDiameter();
        private Length GetRisingMainDiameter() =>
            new Length(new Length(Math.Max(DN3.CopyConvertTo("m").Value, Math.Sqrt((4 * DesignPeakHourFlow.GetValue("m3 s-1")
                / PressurizedPipeVelocity.GetValue("m s-1") / Math.PI)))).CopyConvertTo("mm")).GetStandardDiameter();
        private Length GetFlowmeterDiameter() =>
           new Length(DN4).GetLastSmallerDiameter();
        private Length GetGravityMainDiameter() =>
            new Length(new Length(Math.Min(0.6, Math.Max(0.05, Math.Sqrt((4 * DesignPeakHourFlow.GetValue("m3 s-1")
                / GravityPipeVelocity.GetValue("m s-1") / Math.PI))))).CopyConvertTo("mm")).GetStandardDiameter();
        private Length GetPumpDimensionA() => DN1.Value == 150 ? new Length(200, "mm")
            : new Length(Math.Min(400, Math.Max(100, DN1.Value)), "mm");
        // private Length GetPumpDimensionB() =>
        //    new Length(Math.Min(2400, 8 * DN1.Value), "mm");
        private Length GetPumpDimensionB() => Math.Floor(DN1.Value / 100) == 2 ? new Length(DN1.Value * 8 - 300, "mm")
                                            : DN1.Value < 200 ? new Length(DN1.Value * 8, "mm")
                                            : new Length(2400, "mm");
        private Length GetPumpDimensionC() =>
            new Length(DN2.Value / 2 + DimA.Value + 50, "mm");
        private Length GetPumpDimensionD() =>
            new Length(DimC.Value + Math.Round(DN2.Value * 0.35) * 5, "mm");
        private Length GetPumpDimensionF() =>
            new Length(Math.Round(((DN2.Value + 90)/2)/5) * 5, "mm");
        private Length GetPumpDimensionH() => DN1.Value < 100 ? new Length(DN1.Value * 5, "mm")
                                            : DN1.Value < 175 ? new Length(DN1.Value * 4, "mm")
                                            : DN1.Value < 250 ? new Length(Math.Round(DN1.Value * 3.5), "mm")
                                            : new Length(DN1.Value * 3, "mm");
        private Length GetPumpDimensionI() => DN1.Value < 125 ? new Length(Math.Round(DimH.Value / 2 + 12.5), "mm")
                                            : DN1.Value < 175 ? new Length(Math.Round(DimH.Value / 2 + 25), "mm")
                                            : DN1.Value < 250 ? new Length(Math.Round(DimH.Value / 2 + 57.5), "mm")
                                            : new Length(Math.Round(DimH.Value / 2 + 75), "mm");
        private Length GetPumpDimensionJ() => DN1.Value < 250 ? new Length(85, "mm")
                                            : new Length(150, "mm");
        private Length GetPumpDimensionO() => DN3.Value < 80 ? new Length(500 + Math.Ceiling(DN3.Value / 4) * 10, "mm")
                                            : DN3.Value < 125 ? new Length(500 + Math.Ceiling(DN3.Value / 6) * 10, "mm")
                                            : new Length(500 + Math.Ceiling(DN3.Value / 7) * 10, "mm");
        private Length GetPumpDimensionP() => DN3.Value < 80 ? new Length(500 + Math.Ceiling(DN3.Value / 4) * 20, "mm")
                                            : DN3.Value < 125 ? new Length(500 + Math.Ceiling(DN3.Value / 6) * 20, "mm")
                                            : new Length(500 + Math.Ceiling(DN3.Value / 7) * 20, "mm");
        private Length GetPumpDimensionR() =>
            new Length(Math.Round((DN4.Value / 2 + 810)/5) * 5, "mm");
        private Length GetPumpDimensionT() => DN3.Value < 80 ? new Length(Math.Ceiling(DN3.Value / 4) * 10 + DimS.Value + 300, "mm")
                                            : DN3.Value < 125 ? new Length(Math.Ceiling(DN3.Value / 6) * 10 + DimS.Value + 300, "mm")
                                            : new Length(Math.Ceiling(DN3.Value / 7) * 10 + DimS.Value + 300, "mm");
        private Length GetMinimumLSWallDistanceX() =>
            new Length(2 * DimK.Value + NumberOfPumps * DimH.Value + (NumberOfPumps - 1) * DimL.Value, "mm");
        private Length GetMinimumLSWallDistanceY() =>
            new Length((Math.Round((DimM.Value + DimE.Value + DimF.Value + DimG.Value + DimH.Value / 2) / 10) * 10) + 800, "mm");
        private Length GetPumpDimensionZ() =>
            new Length(DimK.Value + (NumberOfPumps - 1) * (DimH.Value + DimL.Value) + (DN4.Value + 50) * 11, "mm");
    }
    
}