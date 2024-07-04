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
        public Length? DimW { get; private set; }
        public Length MinLSWallDistanceX { get; private set; }
        public Length MinLSWallDistanceY { get; private set; }


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
                            Length? minLSWallDistanceY
                        )
        {
            DesignPeakHourFlow = designPeakHourFlow;
            Head = head;
            PumpInletVelocity = pumpInletVelocity ?? new Velocity(1.7, "m s-1");
            //PressurizedPipeVelocity = pressurizedPipeVelocity ?? new Velocity(2, "m h-1");
            //GravityPipeVelocity = gravityPipeVelocity ?? new Velocity(0.6, "m h-1");
            DutyPumpsCount = dutyPumpsCount ?? 1;
            StandbyPumpsCount = standbyPumpsCount ?? 1;
            Flow = DesignPeakHourFlow / DutyPumpsCount.Value;
            NumberOfPumps = DutyPumpsCount.Value + StandbyPumpsCount.Value;
            DN1 = dn1 ?? GetSuctionDiameter();
            DN2 = dn2 ?? GetDischargeDiameter(DN1);
            //DN3 = dn3 ?? GetFeederDiameter();
            //DN4 = dn4 ?? GetRisingMainDiameter();
            //DN5 = dn5 ?? GetFlowmeterDiameter();
        }


        private Length GetSuctionDiameter() =>
            new Length(new Length(Math.Max(0.065, Math.Sqrt((4 * Flow.GetValue("m3 s-1")
                / PumpInletVelocity.GetValue("m s-1") / Math.PI)))).CopyConvertTo("mm")).GetStandardDiameter();
        
        private static Length? GetDischargeDiameter(Length suctionDiameter) => suctionDiameter < new Length(150, "mm")
                ? suctionDiameter.GetLastSmallerDiameter()
                : new Length(Math.Min(suctionDiameter.GetValue("mm"), 400), "mm");
        //private Length GetFeederDiameter() =>
        //    new Length(new Length(Math.Max(0.05, Math.Sqrt((4 * Flow.GetValue("m3 h-1") / 3600 / PressurizedPipeVelocity.GetValue("m s-1") / Math.PI)))).CopyConvertTo("mm")).GetStandardDiameter();
    }

}