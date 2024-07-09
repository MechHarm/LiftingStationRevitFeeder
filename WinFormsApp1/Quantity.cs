using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitFeederUI
{
    public class VolumetricFlow : Quantity
    {
        public VolumetricFlow(double value) : base(value, "m3 h-1")
        {
        }
    }
    public class Length : Quantity
    {
        public Length(double value) : base(value, "mm")
        {
        }
    }
    public class LengthInMeter : Quantity
    {
        public LengthInMeter(double value) : base(value, "m")
        {
        }
    }
    public abstract class Quantity
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        protected Quantity(double value, string unit)
        {
            Value = value;
            Unit = unit;
        }
    }
}
