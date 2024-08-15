// See https://aka.ms/new-console-template for more information
using LiftingStationRevitFeeder.Application;
using LiftingStationRevitFeeder.Domain;
using MeasurementUnits.NET;

const int numberOfStepsInFlow = 20;

Random random = new Random();
var flowMin = 20d;
var flowMax = 1000d;
var head = new Length(10, "m");

var flowList = new List<VolumetricFlow>();
var flowStep = (flowMax - flowMin) / numberOfStepsInFlow;
for (int i = 0; i <= numberOfStepsInFlow; i++)
{
    var v = flowMin + i * flowStep;
    flowList.Add(new VolumetricFlow(v, "m3 h-1"));
}

var measurementSystemList = new List<String> { "Metric", "Imperial" };

var s = 0;
foreach (var currentFlow in flowList)
{
    // Generate random values for duty and standby pumps for each flow step
    int dutyPumpsCount = random.Next(1, 7);
    int standbyPumpsCount = random.Next(1, 5);

    foreach (var currentMeasurementSystem in measurementSystemList)
    {
        s++;
        var revitFeed = RevitFeed.CreateBase(currentFlow, head, dutyPumpsCount, standbyPumpsCount, currentMeasurementSystem);
        var output = new RevitResponse(revitFeed);
        JsonHelper<RevitResponse>.WriteToJsonFile($"c:\\Temp\\BaseInput-Flow{currentFlow.Value}-{currentMeasurementSystem}.json", output);
    }
}
