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
            var designPeakHourFlow = new VolumetricFlow(500, "m3 h-1");
            var head = new Length(5, "m");
            var pumpInletVelocity = new Velocity(2, "m s-1");
            var dutyPumpsCount = 2;
            var standbyPumpsCount = 2;

            // act
            var sut = new RevitFeed(designPeakHourFlow, head, pumpInletVelocity,null, null, dutyPumpsCount, standbyPumpsCount, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);

            // assert
            sut.Should().NotBeNull();
            sut.Flow.GetValue().Should().BeApproximately(250, 0.1);
            sut.NumberOfPumps.Should().Be(4);
            sut.PumpInletVelocity.GetValue().Should().BeApproximately(2, 0.001);
            sut.DN1.GetValue().Should().Be(250);
            sut.DN2.GetValue().Should().Be(250);
            sut.DN3.GetValue().Should().Be(250);
            sut.DN4.GetValue().Should().Be(300);
            sut.DN5.GetValue().Should().Be(250);
            sut.DNBreath.GetValue().Should().Be(250);
            sut.DNInlet.GetValue().Should().Be(550);
            sut.DNBackflow.GetValue().Should().Be(250);
            sut.DimA.GetValue().Should().Be(250);
            sut.DimB.GetValue().Should().Be(1700);
            sut.DimC.GetValue().Should().Be(425);
            sut.DimD.GetValue().Should().Be(865);
            sut.DimE.GetValue().Should().Be(720);
            sut.DimF.GetValue().Should().Be(170);
            sut.DimG.GetValue().Should().Be(420);
            sut.DimH.GetValue().Should().Be(750);
            sut.DimI.GetValue().Should().Be(450);
            sut.DimJ.GetValue().Should().Be(150);
            sut.DimK.GetValue().Should().Be(800);
            sut.DimL.GetValue().Should().Be(800);
            sut.DimM.GetValue().Should().Be(375);
            sut.DimN.GetValue().Should().Be(1000);
            sut.DimO.GetValue().Should().Be(860);
            sut.DimP.GetValue().Should().Be(1220);
            sut.DimQ.GetValue().Should().Be(860);
            sut.DimR.GetValue().Should().Be(960);
            sut.DimS.GetValue().Should().Be(450);
            sut.DimT.GetValue().Should().Be(1110);
            sut.DimU.GetValue().Should().Be(400);
            sut.DimV.GetValue().Should().Be(400);
            sut.DimZ.GetValue().Should().Be(9300);
            sut.DimW.GetValue().Should().Be(5700);
            sut.MinLSWallDistanceX.GetValue().Should().Be(7000);
            sut.MinLSWallDistanceY.GetValue().Should().Be(2860);
        }
        [Test]
        public void LiftingStationRevitFeederTest_WhenBaseparametersWithoutOptionals_ExpectedValuesAreSet()
        {
            // arrange
            var designPeakHourFlow = new VolumetricFlow(100, "m3 h-1");
            var head = new Length(5, "m");

            // act
            var sut = new RevitFeed(designPeakHourFlow, head, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);

            // assert
            sut.Should().NotBeNull();
            sut.Flow.GetValue().Should().BeApproximately(100, 0.1);
            sut.NumberOfPumps.Should().Be(2);
            sut.PumpInletVelocity.GetValue().Should().BeApproximately(1.7, 0.001);
            sut.DN1.GetValue().Should().Be(150);
            sut.DN2.GetValue().Should().Be(150);
            sut.DN3.GetValue().Should().Be(150);
            sut.DN4.GetValue().Should().Be(150);
            sut.DN5.GetValue().Should().Be(125);
            sut.DNBreath.GetValue().Should().Be(150);
            sut.DNInlet.GetValue().Should().Be(250);
            sut.DNBackflow.GetValue().Should().Be(150);
            sut.DimA.GetValue().Should().Be(200);
            sut.DimB.GetValue().Should().Be(1200);
            sut.DimC.GetValue().Should().Be(325);
            sut.DimD.GetValue().Should().Be(585);
            sut.DimE.GetValue().Should().Be(520);
            sut.DimF.GetValue().Should().Be(120);
            sut.DimG.GetValue().Should().Be(270);
            sut.DimH.GetValue().Should().Be(600);
            sut.DimI.GetValue().Should().Be(325);
            sut.DimJ.GetValue().Should().Be(85);
            sut.DimK.GetValue().Should().Be(800);
            sut.DimL.GetValue().Should().Be(800);
            sut.DimM.GetValue().Should().Be(225);
            sut.DimN.GetValue().Should().Be(1000);
            sut.DimO.GetValue().Should().Be(720);
            sut.DimP.GetValue().Should().Be(440);
            sut.DimQ.GetValue().Should().Be(720);
            sut.DimR.GetValue().Should().Be(885);
            sut.DimS.GetValue().Should().Be(225);
            sut.DimT.GetValue().Should().Be(745);
            sut.DimU.GetValue().Should().Be(400);
            sut.DimV.GetValue().Should().Be(400);
            sut.DimZ.GetValue().Should().Be(4400);
            sut.DimW.GetValue().Should().Be(4565);
            sut.MinLSWallDistanceX.GetValue().Should().Be(3600);
            sut.MinLSWallDistanceY.GetValue().Should().Be(2240);
        }
    }
}