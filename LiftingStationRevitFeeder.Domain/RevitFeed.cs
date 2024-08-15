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


        public static RevitFeed CreateBase(VolumetricFlow designPeakHourFlow, Length head, int dutyPumpsCount, int standbyPumpsCount, String measurementSystem)
        {
            var pumpSelection = PumpSelector.Create(designPeakHourFlow, head, dutyPumpsCount, standbyPumpsCount, null, null, null, null, null, null, measurementSystem);
            return new RevitFeed(designPeakHourFlow, head, dutyPumpsCount, standbyPumpsCount, measurementSystem);
        }
        protected RevitFeed(VolumetricFlow designPeakHourFlow, Length head, int dutyPumpsCount, int standbyPumpsCount, String measurementSystem)
        {
            PumpSelector = PumpSelector.Create(designPeakHourFlow, head, dutyPumpsCount, standbyPumpsCount, null, null, null, null, null, null, measurementSystem);
            Pipes = Pipes.Create(PumpSelector);
            PumpGeometry = PumpGeometry.Create(Pipes);
            Levels = Levels.Create(Pipes);
            PumpSumpGeometry = PumpSumpGeometry.Create();
            PumpSumpArrangement = PumpSumpArrangement.Create(PumpSelector, Pipes, PumpGeometry, PumpSumpGeometry, Levels);
            ValvePitGeometry = ValvePitGeometry.Create(PumpSelector, Pipes, PumpGeometry, PumpSumpArrangement);
            //MeasurementSystem = new String("Metric");
            MeasurementRange = new String($"0 - {(PumpSelector.Flow.GetValue("m3 h-1") * 1.1):F0} CMH");
        }
        public RevitFeed(
                            VolumetricFlow designPeakHourFlow,
                            VolumetricFlow flow,
                            Length head,
                            Velocity? pumpInletVelocity,
                            Velocity? pressurizedPipeVelocity,
                            Velocity? gravityPipeVelocity,
                            int dutyPumpsCount,
                            int standbyPumpsCount,
                            int numberOfPumps,
                            Power? installedPower = default,
                            Power? powerConsumption = default,
                            string? measurementSystem = default,
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
                            Length? inletLocation = default,
                            string measurementRange = default
                        ) : this(designPeakHourFlow, head, dutyPumpsCount, standbyPumpsCount, measurementSystem)
        {

            PumpSelector = PumpSelector.Create(designPeakHourFlow, head, dutyPumpsCount, standbyPumpsCount, pumpInletVelocity, gravityPipeVelocity, pressurizedPipeVelocity, flow, installedPower, powerConsumption, measurementSystem);
            Pipes = Pipes.Create(PumpSelector, dn1, dn2, dn3, dn4, dn5, dnBreath, dnInlet, dnBackflow);
            PumpGeometry = PumpGeometry.Create(Pipes, dimA, dimB, dimC, dimD, dimE, dimF, dimG, dimH, dimI, dimJ);
            Levels = Levels.Create(Pipes, dimS, dimT);
            PumpSumpArrangement = PumpSumpArrangement.Create(PumpSelector, Pipes, PumpGeometry, PumpSumpGeometry, Levels, dimK, dimL, dimM, dimN, dimO, dimP, dimQ, dimR, dimU, dimX, dimY, civL, civM, civI, civN, civO, civP, civQ, civF, civH, civG, civJ, civK, civS, civR, inletLocation);
            PumpSumpGeometry = PumpSumpGeometry.Create();
            ValvePitGeometry = ValvePitGeometry.Create(PumpSelector, Pipes, PumpGeometry, PumpSumpArrangement, dimV, dimZ, dimW);
            //MeasurementSystem = new String("Metric");
            MeasurementRange = new String($"0 - {(PumpSelector.Flow.GetValue("m3 h-1") * 1.1):F0} CMH");
        }

    }

}


