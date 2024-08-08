// See https://aka.ms/new-console-template for more information
using LiftingStationRevitFeeder.Application;
using LiftingStationRevitFeeder.Domain;
using MeasurementUnits.NET;
const int numberOfStepsInFlow = 20;
//const int numberOfStepsInHead = 1;

var flowMin = 20d;
var flowMax = 1000d;
var head = new Length(10, "m");
//var headMin = 10d;
//var headMax = 20d;

var flowList = new List<VolumetricFlow>();
var flowStep = (flowMax - flowMin) / numberOfStepsInFlow;
for (int i = 0; i <= numberOfStepsInFlow; i++)
{
    var v = flowMin + i * flowStep;
    flowList.Add(new VolumetricFlow(v, "m3 h-1"));
}
var measurementSystemList = new List<String>();
measurementSystemList.Add(new String("Metric"));
measurementSystemList.Add(new String("Imperial"));

//var headList = new List<Length>();
//var headStep = (headMax - headMin) / numberOfStepsInHead;
//for (int i = 0; i<= numberOfStepsInHead; i++)
//{
//    var v = headMin + i*headStep;
//    headList.Add(new Length(v, "m"));
//}

var s = 0;
foreach (var currentFlow in flowList)
{
    foreach (/*var currentHead in headList*/ var currentMeasurementSystem in measurementSystemList)
    {
        s++;
        var revitFeed = RevitFeed.CreateBase(currentFlow, head,/*currentHead*/currentMeasurementSystem);
        var output = new RevitResponse(revitFeed);
        JsonHelper<RevitResponse>.WriteToJsonFile($"c:\\Temp\\BaseInput-Flow{currentFlow.Value}-{currentMeasurementSystem}.json ", output);
        // JsonHelper<RevitResponse>.WriteToJsonFile($"c:\\Temp\\BaseInput-Flow{currentFlow.Value}-Head{currentHead.Value}.json ", output);
    }
}


