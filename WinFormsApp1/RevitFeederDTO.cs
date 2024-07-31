using MeasurementUnits.NET;
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

        public VolumetricFlow DutyPumpsCount { get; }
        public VolumetricFlow StandbyPumpsCount { get; }
        public VolumetricFlow NumberOfPumps { get; private set; }
        public Length DN1 { get; }
        public Length DN2 { get; }
        public Length DN3 { get; }
        public Length DN4 { get; }
        public Length DN5 { get; }
        public Length DNInlet { get; }
        public Length DNBackflow { get; }
        public Length DNBreath { get; }
        public Length LevA { get; }
        public Length LevB { get; }
        public Length LevC { get; }
        public Length LevD { get; }
        public Length LevE { get; }
        public Length LevF { get; }
        public Length LevG { get; }
        public Length LevH { get; }
        public Length LevI { get; }
        public Length DimA { get; }
        public Length DimB { get; }
        public Length DimC { get; }
        public Length DimD { get; }
        public Length DimE { get; }
        public Length DimF { get; }
        public Length DimG { get; }
        public Length DimH { get; }
        public Length DimI { get; }
        public Length DimJ { get; }
        public Length DimK { get; }
        public Length DimL { get; }
        public Length DimM { get; }
        public Length DimN { get; }
        public Length DimO { get; }
        public Length DimP { get; }
        public Length DimQ { get; }
        public Length DimR { get; }
        public Length DimS { get; }
        public Length DimT { get; }
        public Length DimU { get; }
        public Length DimV { get; }
        public Length DimX { get; }
        public Length DimY { get; }
        public Length DimW { get; }
        public Length DimZ { get; }
        public Length WetWellDepth { get; private set; }
        public Length? ManholeX { get; private set; }
        public Length? ManholeY { get; private set; }
        public Length? SlopeStart { get; private set; }


        //public VolumetricFlow Flow { get; private set; }
        //public Velocity PumpInletVelocity { get; }
        //public Velocity PressurizedPipeVelocity { get; }
        //public Velocity GravityPipeVelocity { get; }
        public RevitFeederDTO(VolumetricFlow designPeakHourFlow, Length head, VolumetricFlow dutyPumpsCount, VolumetricFlow standbyPumpsCount, VolumetricFlow numberOfPumps, Length dn1, Length dn2, Length dn3, Length dn4, Length dn5, Length dnInlet, Length dnBackflow, Length dnBreath, Length levA, Length levB, Length levC, Length levD, Length levE, Length levF, Length levG, Length levH, Length levI, Length dimA, Length dimB, Length dimC, Length dimD, Length dimE, Length dimF, Length dimG, Length dimH, Length dimI, Length dimJ, Length dimK, Length dimL, Length dimM, Length dimN, Length dimO, Length dimP, Length dimQ, Length dimR, Length dimS, Length dimT, Length dimU, Length dimV, Length dimX, Length dimY, Length dimW, Length dimZ, Length wetWellDepth, Length manholeX, Length manholeY, Length slopeStart) // VolumetricFlow flow)
        {
            DesignPeakHourFlow = designPeakHourFlow;
            Head = head;
            DutyPumpsCount = dutyPumpsCount;
            StandbyPumpsCount = standbyPumpsCount;
            NumberOfPumps = numberOfPumps;
            DN1 = dn1;
            DN2 = dn2;
            DN3 = dn3;
            DN4 = dn4;
            DN5 = dn5;
            DNInlet = dnInlet;
            DNBackflow = dnBackflow;
            DNBreath = dnBreath;
            LevA = levA;
            LevB = levB;
            LevC = levC;
            LevD = levD;
            LevE = levE;
            LevF = levF;
            LevG = levG;
            LevH = levH;
            LevI = levI;
            DimA = dimA;
            DimB = dimB;
            DimC = dimC;
            DimD = dimD;
            DimE = dimE;
            DimF = dimF;
            DimG = dimG;
            DimH = dimH;
            DimI = dimI;
            DimJ = dimJ;
            DimK = dimK;
            DimL = dimL;
            DimM = dimM;
            DimN = dimN;
            DimO = dimO;
            DimP = dimP;
            DimQ = dimQ;
            DimR = dimR;
            DimS = dimS;
            DimT = dimT;
            DimU = dimU;
            DimV = dimV;
            DimW = dimW;
            DimX = dimX;
            DimY = dimY;
            DimZ = dimZ;
            WetWellDepth = wetWellDepth;
            ManholeX = manholeX;
            ManholeY = manholeY;
            SlopeStart = slopeStart;
            // Flow = flow;
        }
        public RevitFeederDTO()
        {

        }
    }
}