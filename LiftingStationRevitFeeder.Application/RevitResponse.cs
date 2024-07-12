﻿using LiftingStationRevitFeeder.Domain;
using MeasurementUnits.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftingStationRevitFeeder.Application
{
    public class RevitResponse
    {
        //BaseData
        public ResponseData DesignPeakHourFlow { get; }
        public ResponseData Head { get; }

        public ResponseData Flow { get; private set; }

        public ResponseData DutyPumpsCount { get; }
        public ResponseData StandbyPumpsCount { get; }
        public ResponseData NumberOfPumps { get; private set; }
        public ResponseData PumpInletVelocity { get; }
        public ResponseData PressurizedPipeVelocity { get; }
        public ResponseData GravityPipeVelocity { get; }
        //Pipes
        public ResponseData DN1 { get; private set; }
        public ResponseData DN2 { get; private set; }
        public ResponseData DN3 { get; private set; }
        public ResponseData DN4 { get; private set; }
        public ResponseData DN5 { get; private set; }
        public ResponseData DNBreath { get; private set; }
        public ResponseData DNInlet { get; private set; }
        public ResponseData DNBackflow { get; private set; }
        //PumpGeometry
        public ResponseData DimA {get; private set; }
        public ResponseData DimB { get; private set; }
        public ResponseData DimC { get; private set; }
        public ResponseData DimD { get; private set; }
        public ResponseData DimE { get; private set; }
        public ResponseData DimF { get; private set; }
        public ResponseData DimG { get; private set; }
        public ResponseData DimH { get; private set; }
        public ResponseData DimI { get; private set; }
        public ResponseData DimJ { get; private set; }

        //Levels
        public ResponseData Freeboard { get; private set; }
        public ResponseData LevA { get; private set; }
        public ResponseData LevB { get; private set; }
        public ResponseData LevC { get; private set; }
        public ResponseData LevD { get; private set; }
        public ResponseData LevE { get; private set; }
        public ResponseData LevF { get; private set; }
        public ResponseData LevG { get; private set; }
        public ResponseData LevH { get; private set; }
        public ResponseData LevI { get; private set; }
        public ResponseData WetWellDepth { get; private set; }
        public ResponseData DimS { get; private set; }
        public ResponseData DimT { get; private set; }
        //PumpSumpArrangement

        public ResponseData DimK { get; private set; }
        public ResponseData DimL { get; private set; }
        public ResponseData DimM { get; private set; }
        public ResponseData DimN { get; private set; }
        public ResponseData DimO { get; private set; }
        public ResponseData DimP { get; private set; }
        public ResponseData DimQ { get; private set; }
        public ResponseData DimR { get; private set; }
        public ResponseData DimU { get; private set; }


        public RevitResponse()
        {
                
        }
        public RevitResponse(RevitFeed revitFeed)
        {
            //PumpSelection
            DesignPeakHourFlow = Mapper.MapFromMeasurementUnit("DesignPeakHourFlow", revitFeed.PumpSelector.DesignPeakHourFlow);
            Head = Mapper.MapFromMeasurementUnit("Head", revitFeed.PumpSelector.Head);
            Flow = Mapper.MapFromMeasurementUnit("Flow", revitFeed.PumpSelector.Flow);
            DutyPumpsCount = Mapper.MapFromInt("DutyPumpsCount", revitFeed.PumpSelector.DutyPumpsCount);
            StandbyPumpsCount = Mapper.MapFromInt("StandbyPumpsCount", revitFeed.PumpSelector.StandbyPumpsCount);
            NumberOfPumps = Mapper.MapFromInt("NumberOfPumps", revitFeed.PumpSelector.NumberOfPumps);
            PumpInletVelocity = Mapper.MapFromMeasurementUnit("PumpInletVelocity", revitFeed.PumpSelector.PumpInletVelocity);
            PressurizedPipeVelocity = Mapper.MapFromMeasurementUnit("PressurizedPipeVelocity", revitFeed.PumpSelector.PressurizedPipeVelocity);
            GravityPipeVelocity = Mapper.MapFromMeasurementUnit("GravityPipeVelocity", revitFeed.PumpSelector.GravityPipeVelocity);

            // PumpGeometry
            DimA = Mapper.MapFromMeasurementUnit("DimA", revitFeed.PumpGeometry.DimA);
            DimB = Mapper.MapFromMeasurementUnit("DimB", revitFeed.PumpGeometry.DimB);
            DimC = Mapper.MapFromMeasurementUnit("DimC",revitFeed.PumpGeometry.DimC);
            DimD = Mapper.MapFromMeasurementUnit("DimD", revitFeed.PumpGeometry.DimD);
            DimE = Mapper.MapFromMeasurementUnit("DimE", revitFeed.PumpGeometry.DimE);
            DimF = Mapper.MapFromMeasurementUnit("DimF", revitFeed.PumpGeometry.DimF);
            DimG = Mapper.MapFromMeasurementUnit("DimG", revitFeed.PumpGeometry.DimG);
            DimH = Mapper.MapFromMeasurementUnit("DimH", revitFeed.PumpGeometry.DimH);
            DimI = Mapper.MapFromMeasurementUnit("DimI", revitFeed.PumpGeometry.DimI);
            DimJ = Mapper.MapFromMeasurementUnit("DimJ", revitFeed.PumpGeometry.DimJ);

            //Levels

            LevA = Mapper.MapFromMeasurementUnit("LevA", revitFeed.Levels.LevA);
            LevB = Mapper.MapFromMeasurementUnit("LevB", revitFeed.Levels.LevB);
            LevC = Mapper.MapFromMeasurementUnit("LevC", revitFeed.Levels.LevC);
            LevD = Mapper.MapFromMeasurementUnit("LevD", revitFeed.Levels.LevD);
            LevE = Mapper.MapFromMeasurementUnit("LevE", revitFeed.Levels.LevE);
            LevF = Mapper.MapFromMeasurementUnit("LevF", revitFeed.Levels.LevF);
            LevG = Mapper.MapFromMeasurementUnit("LevG", revitFeed.Levels.LevG);
            LevH = Mapper.MapFromMeasurementUnit("LevG", revitFeed.Levels.LevH);
            LevI = Mapper.MapFromMeasurementUnit("LevG", revitFeed.Levels.LevI);
            WetWellDepth = Mapper.MapFromMeasurementUnit("WetWellDepth", revitFeed.Levels.WetWellDepth);
            DimS = Mapper.MapFromMeasurementUnit("DimS", revitFeed.Levels.DimS);
            DimT = Mapper.MapFromMeasurementUnit("DimT", revitFeed.Levels.DimT);

            //PumpSumpArrangement
            DimK = Mapper.MapFromMeasurementUnit("DimK", revitFeed.PumpSumpArrangement.DimK);
            DimL = Mapper.MapFromMeasurementUnit("DimL", revitFeed.PumpSumpArrangement.DimL);
            DimM = Mapper.MapFromMeasurementUnit("DimM", revitFeed.PumpSumpArrangement.DimM);
            DimN = Mapper.MapFromMeasurementUnit("DimN", revitFeed.PumpSumpArrangement.DimN);
            DimO = Mapper.MapFromMeasurementUnit("DimO", revitFeed.PumpSumpArrangement.DimO);
            DimP = Mapper.MapFromMeasurementUnit("DimP", revitFeed.PumpSumpArrangement.DimP);
            DimQ = Mapper.MapFromMeasurementUnit("DimQ", revitFeed.PumpSumpArrangement.DimQ);
            DimR = Mapper.MapFromMeasurementUnit("DimR", revitFeed.PumpSumpArrangement.DimR);
            DimU = Mapper.MapFromMeasurementUnit("DimU", revitFeed.PumpSumpArrangement.DimU);

            //Pipes
            DN1 = Mapper.MapFromMeasurementUnit("DN1", revitFeed.Pipes.DN1);
            DN2 = Mapper.MapFromMeasurementUnit("DN2", revitFeed.Pipes.DN2);
            DN3 = Mapper.MapFromMeasurementUnit("DN3", revitFeed.Pipes.DN3);
            DN4 = Mapper.MapFromMeasurementUnit("DN4", revitFeed.Pipes.DN4);
            DN5 = Mapper.MapFromMeasurementUnit("DN5", revitFeed.Pipes.DN5);
            DNBreath = Mapper.MapFromMeasurementUnit("DNBreath", revitFeed.Pipes.DNBreath);
            DNInlet = Mapper.MapFromMeasurementUnit("DNInlet", revitFeed.Pipes.DNInlet);
            DNBackflow = Mapper.MapFromMeasurementUnit("DNBackflow", revitFeed.Pipes.DNBackflow);

        }

    }

}
