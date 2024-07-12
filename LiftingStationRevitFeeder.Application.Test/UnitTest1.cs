using FluentAssertions;
using MeasurementUnits.NET;
using System.ComponentModel.DataAnnotations;

namespace LiftingStationRevitFeeder.Application.Test
{
    public class MapperTests
    {
       
        [Test]
        public void MapFromMeasurementUnitTest_Length_ExpectedNormal()
        {
            //Arrange
            var a = new Length(1, "m");
            //Act
            var result = Mapper.MapFromMeasurementUnit("DimA",a);
            //Assert
            result.Name.Should().Be("DimA");
            result.Value.Should().Be("1");
            result.Unit.Should().Be("m");
            result.DataType.Should().Be("Length");

        }
    }
}