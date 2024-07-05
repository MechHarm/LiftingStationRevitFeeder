using FluentAssertions;
using MeasurementUnits.NET;

namespace LiftingStationRevitFeeder.Domain.Test
{
    public class PumpSelectorTests
    {
       
        [Test]
        public void Create_WithAllParametersDefined_ShouldReturnPumpSelector()
        {
            // Arrange
            var designPeakHourFlow = new VolumetricFlow(1, "m3 s-1");
            var head = new Length(1, "m");
            var dutyPumpsCount = 2;
            var standbyPumpsCount = 2;
            var pumpInletVelocity = new Velocity(2, "m s-1");
            var gravityPipeVelocity = new Velocity(1, "m s-1");
            var pressurizedPipeVelocity = new Velocity(1, "m s-1");

            // Act
            var result = PumpSelector.Create(designPeakHourFlow, head, dutyPumpsCount, standbyPumpsCount, pumpInletVelocity, gravityPipeVelocity, pressurizedPipeVelocity);

            // Assert
            result.DesignPeakHourFlow.Should().BeEquivalentTo(designPeakHourFlow);
            result.Head.Should().BeEquivalentTo(head);
            result.NumberOfPumps.Should().Be(4);
            result.DutyPumpsCount.Should().Be(2);
            result.StandbyPumpsCount.Should().Be(2);
            result.Flow.Should().BeEquivalentTo(new VolumetricFlow(0.5, "m3 s-1"));
            result.PumpInletVelocity.Should().BeEquivalentTo(pumpInletVelocity);
            result.PressurizedPipeVelocity.Should().BeEquivalentTo(pressurizedPipeVelocity);
            result.GravityPipeVelocity.Should().BeEquivalentTo(gravityPipeVelocity);
        }
        [Test]
        public void Create_OnlyMandatoryParametersDefined_ShouldReturnPumpSelector()
        {
            // Arrange
            var designPeakHourFlow = new VolumetricFlow(1, "m3 s-1");
            var head = new Length(1, "m");

            // Act
            var result = PumpSelector.Create(designPeakHourFlow, head);

            // Assert
            result.DesignPeakHourFlow.Should().BeEquivalentTo(designPeakHourFlow);
            result.Head.Should().BeEquivalentTo(head);
            result.NumberOfPumps.Should().Be(2);
            result.DutyPumpsCount.Should().Be(1);
            result.StandbyPumpsCount.Should().Be(1);
            result.Flow.Should().BeEquivalentTo(designPeakHourFlow);
            result.PumpInletVelocity.Should().BeEquivalentTo(new Velocity(1.7, "m s-1"));
            result.PressurizedPipeVelocity.Should().BeEquivalentTo(new Velocity(2, "m s-1"));
            result.GravityPipeVelocity.Should().BeEquivalentTo(new Velocity(0.6, "m s-1"));
        }
    }
}
