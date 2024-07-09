using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitFeederUI
{
    public class RevitFeederDTO
    {
        public VolumetricFlow DesignPeakHourFlow { get; }
        public Length Head { get; }

        public int DutyPumpsCount { get; }
        public int StandbyPumpsCount { get; }
        public int NumberOfPumps { get; private set; }
        //public VolumetricFlow Flow { get; private set; }
        //public Velocity PumpInletVelocity { get; }
        //public Velocity PressurizedPipeVelocity { get; }
        //public Velocity GravityPipeVelocity { get; }
        public RevitFeederDTO(VolumetricFlow designPeakHourFlow, Length head, int dutyPumpsCount, int standbyPumpsCount, int numberOfPumps) // VolumetricFlow flow)
        {
            DesignPeakHourFlow = designPeakHourFlow;
            Head = head;
            DutyPumpsCount = dutyPumpsCount;
            StandbyPumpsCount = standbyPumpsCount;
            NumberOfPumps = numberOfPumps;
           // Flow = flow;
        }
        public RevitFeederDTO()
        {
               
        }
    }
}
