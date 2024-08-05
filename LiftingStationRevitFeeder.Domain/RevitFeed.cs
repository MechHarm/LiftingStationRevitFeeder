using MeasurementUnits.NET;

namespace LiftingStationRevitFeeder.Domain
{
    public class RevitFeed
    {
        public PumpSelector PumpSelector { get; private set; }
        public Pipes Pipes { get; private set; }
        public PumpGeometry PumpGeometry { get; private set; }
        public Levels Levels { get; private set; }
        public PumpSumpArrangement PumpSumpArrangement { get; private set; }
        public PumpSumpGeometry PumpSumpGeometry { get; private set; }

        public ValvePitGeometry ValvePitGeometry { get; private set; }

        public string MeasurementRange { get; private set; }
        public string MeasurementSystem { get; private set; }


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
            Levels = Levels.Create(Pipes);
            PumpSumpArrangement = PumpSumpArrangement.Create(PumpSelector, Pipes, PumpGeometry);
            PumpSumpGeometry = PumpSumpGeometry.Create();
            ValvePitGeometry = ValvePitGeometry.Create(PumpSelector, Pipes, PumpGeometry, PumpSumpArrangement);
            //DimX = dimX ?? Civil Requirement > MinLSWallDistanceX
            //DimY = dimY ?? Civil Requirement > MinLSWallDistanceY
            MeasurementSystem = new String("Metric");
            MeasurementRange = new String($"0 - {(PumpSelector.Flow.GetValue("m3 h-1") * 1.1):F0} CMH");
        }
        public RevitFeed(                
                            VolumetricFlow designPeakHourFlow,
                            VolumetricFlow flow,
                            Length head,
                            Velocity? pumpInletVelocity,
                            Velocity? pressurizedPipeVelocity,
                            Velocity? gravityPipeVelocity,
                            int? dutyPumpsCount = 1,
                            int? standbyPumpsCount = 1,
                            int? numberOfPumps = 2,
                            Power? installedPower = default,
                            Power? powerConsumption = default,
                            string? measurementSystem = "Metric",
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
                            Length? civL = default,
                            Length? civM = default,
                            Length? civI = default,
                            Length? civN = default,
                            Length? civO = default,
                            Length? civP = default,
                            Length? civQ = default,
                            string measurementRange = default
                        ) : this(designPeakHourFlow, head)
        {

            PumpSelector = PumpSelector.Create(designPeakHourFlow, head, dutyPumpsCount, standbyPumpsCount, pumpInletVelocity, gravityPipeVelocity, pressurizedPipeVelocity, flow, installedPower, powerConsumption, measurementSystem);
            Pipes = Pipes.Create(PumpSelector, dn1, dn2, dn3, dn4, dn5, dnBreath, dnInlet, dnBackflow);
            PumpGeometry = PumpGeometry.Create(Pipes, dimA, dimB, dimC, dimD, dimE, dimF, dimG, dimH, dimI, dimJ);
            Levels = Levels.Create(Pipes, dimS, dimT);
            PumpSumpArrangement = PumpSumpArrangement.Create(PumpSelector, Pipes, PumpGeometry, dimK, dimL, dimM, dimN, dimO, dimP, dimQ, dimR, dimU, civL, civM, civI, civN, civO, civP, civQ);
            PumpSumpGeometry = PumpSumpGeometry.Create();
            ValvePitGeometry = ValvePitGeometry.Create(PumpSelector, Pipes, PumpGeometry, PumpSumpArrangement, dimV, dimZ, dimW);

            //DimX = dimX ?? Civil Requirement > MinLSWallDistanceX
            //DimY = dimY ?? Civil Requirement > MinLSWallDistanceY
            MeasurementSystem = new String("Metric"); 
            MeasurementRange = new String($"0 - {(PumpSelector.Flow.GetValue("m3 h-1") * 1.1):F0} CMH");
        }

    }

}


