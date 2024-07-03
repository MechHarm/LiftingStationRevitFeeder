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
            var designPeakHourFlow = new VolumetricFlow(100, "m3 h-1");
            var head = new Length(5, "m");
            var pumpIntakeVelocity = new Velocity(2, "m s-1");
            var dutyPumpsCount = 2;
            var standbyPumpsCount = 2;

            // act
            var sut = new RevitFeed(designPeakHourFlow, head, pumpIntakeVelocity, dutyPumpsCount, standbyPumpsCount);

            // assert
            sut.Should().NotBeNull();
            sut.Flow.GetValue().Should().BeApproximately(50, 0.1);
            sut.NumberOfPumps.Should().Be(4);
            sut.PumpIntakeVelocity.GetValue().Should().BeApproximately(2, 0.001);
            sut.DN1.GetValue().Should().Be(65);
            sut.DN2.GetValue().Should().Be(50);
        }
        [Test]
        public void LiftingStationRevitFeederTest_WhenBaseparametersWithoutOptionals_ExpectedValuesAreSet()
        {
            // arrange
            var designPeakHourFlow = new VolumetricFlow(100, "m3 h-1");
            var head = new Length(5, "m");

            // act
            var sut = new RevitFeed(designPeakHourFlow, head, null, null, null);

            // assert
            sut.Should().NotBeNull();
            sut.Flow.GetValue().Should().BeApproximately(100, 0.1);
            sut.NumberOfPumps.Should().Be(2);
            sut.PumpIntakeVelocity.GetValue().Should().BeApproximately(1.7, 0.001);
            sut.DN1.GetValue().Should().Be(65);
            sut.DN2.GetValue().Should().Be(50);
        }
    }
}