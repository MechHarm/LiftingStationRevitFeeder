using FluentAssertions;
using MeasurementUnits.NET;

namespace LiftingStationRevitFeeder.Domain.Test;

public class LengthExtensionTests
{
    [TestCase(100, 100)]
    [TestCase(99, 100)]
    [TestCase(90.0001, 100)]
    public void GetStandardDiameterTest_WhereValidInput_Expected100mm(double diameter, double expected)
    {
        //Arrange
        var rawDiameter = new Length(diameter, "mm");
        //Act
        var result = rawDiameter.GetStandardDiameter();
        //Assert
        result.Should().Be(new Length(expected, "mm"));
    }
    [TestCase(600.0001)]
    [TestCase(601)]
    [TestCase(1000)]
    public void GetStandardDiameterTest_WhereNotValidInput_ExpectedException(double diameter)
    {
        //Arrange
        var rawDiameter = new Length(1000, "mm");
        Action execute = () => rawDiameter.GetStandardDiameter();
        //Assert
        execute.Should().Throw<Exception>();
    }

    [TestCase(100, 90)]
    [TestCase(99, 90)]
    [TestCase(90.0001, 90)]
    public void GetLastSmallerDiameterTest_WhereValidInput_ExpectedAsInput(double diameter, double expected)
    {
        //Arrange
        var rawDiameter = new Length(diameter, "mm");
        //Act
        var result = rawDiameter.GetLastSmallerDiameter();
        //Assert
        result.Should().Be(new Length(expected, "mm"));
    }

}
