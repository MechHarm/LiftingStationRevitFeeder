using FluentAssertions;
using MeasurementUnits.NET;

namespace LiftingStationRevitFeeder.Domain.Test
{
    public class LiftingStationRevitFeederTest
    {

        [Test]
        public void LiftingStationRevitFeederTest_WhenBaseparameters_ExpectedValuesAreSet()
        {
            // arrange
            var designPeakHourFlow = new VolumetricFlow(250, "m3 h-1");
            var head = new Length(5, "m");

            // act
            var sut = RevitFeed.CreateBase(designPeakHourFlow, head);

            // assert
            sut.Should().NotBeNull();
            sut.PumpSelector.Flow.GetValue().Should().BeApproximately(250, 0.1);
            sut.PumpSelector.NumberOfPumps.Should().Be(2);
            sut.PumpSelector.PumpInletVelocity.GetValue().Should().BeApproximately(1.7, 0.001);
            sut.Pipes.DN1.GetValue().Should().Be(250);
            sut.Pipes.DN2.GetValue().Should().Be(250);
            sut.Pipes.DN3.GetValue().Should().Be(250);
            sut.Pipes.DN4.GetValue().Should().Be(250);
            sut.Pipes.DN5.GetValue().Should().Be(200);
            sut.Pipes.DNBreath.GetValue().Should().Be(250);
            sut.Pipes.DNInlet.GetValue().Should().Be(400);
            sut.Pipes.DNBackflow.GetValue().Should().Be(250);
            sut.PumpGeometry.DimA.GetValue().Should().Be(250);
            sut.PumpGeometry.DimB.GetValue().Should().Be(1700);
            sut.PumpGeometry.DimC.GetValue().Should().Be(425);
            sut.PumpGeometry.DimD.GetValue().Should().Be(865);
            sut.PumpGeometry.DimE.GetValue().Should().Be(720);
            sut.PumpGeometry.DimF.GetValue().Should().Be(170);
            sut.PumpGeometry.DimG.GetValue().Should().Be(420);
            sut.PumpGeometry.DimH.GetValue().Should().Be(750);
            sut.PumpGeometry.DimI.GetValue().Should().Be(450);
            sut.PumpGeometry.DimJ.GetValue().Should().Be(150);
            sut.PumpSumpArrangement.DimK.GetValue().Should().Be(800);
            sut.PumpSumpArrangement.DimL.GetValue().Should().Be(800);
            sut.PumpSumpArrangement.DimM.GetValue().Should().Be(375);
            sut.PumpSumpArrangement.DimN.GetValue().Should().Be(1000);
            sut.PumpSumpArrangement.DimO.GetValue().Should().Be(860);
            sut.PumpSumpArrangement.DimP.GetValue().Should().Be(1220);
            sut.PumpSumpArrangement.DimQ.GetValue().Should().Be(860);
            sut.PumpSumpArrangement.DimR.GetValue().Should().Be(935);
            sut.Levels.DimS.GetValue().Should().Be(375);
            sut.Levels.DimT.GetValue().Should().Be(1035);
            sut.PumpSumpArrangement.DimU.GetValue().Should().Be(400);
            sut.ValvePitGeometry.DimV.GetValue().Should().Be(400);
            sut.ValvePitGeometry.DimZ.GetValue().Should().Be(5650);
            sut.ValvePitGeometry.DimW.GetValue().Should().Be(5675);
            sut.PumpSumpArrangement.DimX.GetValue().Should().Be(3900);
            sut.PumpSumpArrangement.DimY.GetValue().Should().Be(2860);
        }
        [Test]
        public void LiftingStationRevitFeederTest_WhenBaseparametersWithoutOptionals_ExpectedValuesAreSet()
        {
            // arrange
            var designPeakHourFlow = new VolumetricFlow(100, "m3 h-1");
            var flow = new VolumetricFlow(100, "m3 h-1");
            var head = new Length(5, "m");

            // act
            var sut = new RevitFeed(designPeakHourFlow, flow, head, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);

            // assert
            sut.Should().NotBeNull();
            sut.PumpSelector.Flow.GetValue().Should().BeApproximately(100, 0.1);
            sut.PumpSelector.NumberOfPumps.Should().Be(2);
            sut.PumpSelector.PumpInletVelocity.GetValue().Should().BeApproximately(1.7, 0.001);
            sut.Pipes.DN1.GetValue().Should().Be(150);
            sut.Pipes.DN2.GetValue().Should().Be(150);
            sut.Pipes.DN3.GetValue().Should().Be(150);
            sut.Pipes.DN4.GetValue().Should().Be(150);
            sut.Pipes.DN5.GetValue().Should().Be(125);
            sut.Pipes.DNBreath.GetValue().Should().Be(150);
            sut.Pipes.DNInlet.GetValue().Should().Be(250);
            sut.Pipes.DNBackflow.GetValue().Should().Be(150);
            sut.PumpGeometry.DimA.GetValue().Should().Be(200);
            sut.PumpGeometry.DimB.GetValue().Should().Be(1200);
            sut.PumpGeometry.DimC.GetValue().Should().Be(325);
            sut.PumpGeometry.DimD.GetValue().Should().Be(585);
            sut.PumpGeometry.DimE.GetValue().Should().Be(520);
            sut.PumpGeometry.DimF.GetValue().Should().Be(120);
            sut.PumpGeometry.DimG.GetValue().Should().Be(270);
            sut.PumpGeometry.DimH.GetValue().Should().Be(600);
            sut.PumpGeometry.DimI.GetValue().Should().Be(325);
            sut.PumpGeometry.DimJ.GetValue().Should().Be(85);
            sut.PumpSumpArrangement.DimK.GetValue().Should().Be(800);
            sut.PumpSumpArrangement.DimL.GetValue().Should().Be(800);
            sut.PumpSumpArrangement.DimM.GetValue().Should().Be(225);
            sut.PumpSumpArrangement.DimN.GetValue().Should().Be(1000);
            sut.PumpSumpArrangement.DimO.GetValue().Should().Be(720);
            sut.PumpSumpArrangement.DimP.GetValue().Should().Be(940);
            sut.PumpSumpArrangement.DimQ.GetValue().Should().Be(720);
            sut.PumpSumpArrangement.DimR.GetValue().Should().Be(885);
            sut.Levels.DimS.GetValue().Should().Be(225);
            sut.Levels.DimT.GetValue().Should().Be(745);
            sut.PumpSumpArrangement.DimU.GetValue().Should().Be(400);
            sut.ValvePitGeometry.DimV.GetValue().Should().Be(400);
            sut.ValvePitGeometry.DimZ.GetValue().Should().Be(4400);
            sut.ValvePitGeometry.DimW.GetValue().Should().Be(5065);
            sut.PumpSumpArrangement.DimX.GetValue().Should().Be(3600);
            sut.PumpSumpArrangement.DimY.GetValue().Should().Be(2240);
        }
    }
}