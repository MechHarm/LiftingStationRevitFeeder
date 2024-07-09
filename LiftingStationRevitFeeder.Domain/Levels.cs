using MeasurementUnits.NET;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftingStationRevitFeeder.Domain
{
    public class Levels
    {
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
        public Length? DimS { get; private set; }
        public Length? DimT { get; private set; }


        protected Levels(Pipes pipes, Length? dimS = default, Length? dimT = default)
        { 
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
            DimS = dimS ?? pipes.DN4 * 1.5;
            DimT = dimT ?? GetPumpDimensionT(pipes);
         
        }
        public static Levels Create(Pipes pipes, Length? dimS = default, Length? dimT = default)
        { 
            return new Levels(pipes, dimS, dimT);
        }
        private Length GetPumpDimensionT(Pipes pipes) => pipes.DN3.Value < 80 ? new Length(Math.Ceiling(pipes.DN3.Value / 4) * 10 + DimS.Value + 300, "mm")
                                           : pipes.DN3.Value < 125 ? new Length(Math.Ceiling(pipes.DN3.Value / 6) * 10 + DimS.Value + 300, "mm")
                                           : new Length(Math.Ceiling(pipes.DN3.Value / 7) * 10 + DimS.Value + 300, "mm");

    }
}
