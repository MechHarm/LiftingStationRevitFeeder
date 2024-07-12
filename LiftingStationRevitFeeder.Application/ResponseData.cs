namespace LiftingStationRevitFeeder.Application
{
    public class ResponseData
    {
        public string Name { get; set; }

        public string Value {get;set;}

        public string? Unit { get; set; }

        public string DataType { get; set; }

        protected ResponseData(string name, string value, string dataType, string? unit = null)
        {
            Name = name;
            Value = value;
            Unit = unit;
            DataType = dataType;
        }
        public static ResponseData CreateNotMeasurementUnit(string name, string value, string dataType)
        {
            return new ResponseData(name, value, dataType);
        }

        public static ResponseData CreateMeasurementUnit(string name, string value, string unit, string dataType)
        {
            return new ResponseData(name, value, dataType, unit);
        }
    }
}
