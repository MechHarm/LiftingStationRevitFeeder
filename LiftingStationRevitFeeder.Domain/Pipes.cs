using MeasurementUnits.NET;

namespace LiftingStationRevitFeeder.Domain;
public class Pipes
{
    public Length? DN1 { get; private set; }
    public Length? DN2 { get; private set; }
    public Length? DN3 { get; private set; }
    public Length? DN4 { get; private set; }
    public Length? DN5 { get; private set; }
    public Length? DNBreath { get; private set; }
    public Length? DNInlet { get; private set; }
    public Length? DNBackflow { get; private set; }

    public Pipes Create(
        PumpSelector pumpSelector,
        Length? dn1,
        Length? dn2,
        Length? dn3, 
        Length? dn4, 
        Length? dn5, 
        Length? dnBreath, 
        Length? dnInlet, 
        Length? dnBackflow)
    {
        return new Pipes(pumpSelector, dn1, dn2, dn3, dn4, dn5, dnBreath, dnInlet, dnBackflow); 
    }
    public static Pipes Create(PumpSelector pumpSelector)
    {
        return new Pipes(pumpSelector);
    }
    public Pipes(
        PumpSelector pumpSelector,
        Length? dn1 = default,
        Length? dn2 = default,
        Length? dn3 = default,
        Length? dn4 = default,
        Length? dn5 = default,
        Length? dnBreath = default,
        Length? dnInlet = default,
        Length? dnBackflow = default)
    {
        DN1 = dn1 ?? GetSuctionDiameter(pumpSelector);
        DN2 = dn2 ?? GetDischargeDiameter(DN1);
        DN3 = dn3 ?? GetFeederDiameter(pumpSelector);
        DN4 = dn4 ?? GetRisingMainDiameter(pumpSelector);
        DN5 = dn5 ?? GetFlowmeterDiameter();
        DNBreath = dnBreath ?? DN2;
        DNInlet = dnInlet ?? GetGravityMainDiameter(pumpSelector);
        DNBackflow = dnBackflow ?? DN2;
    }
    private Length GetSuctionDiameter(PumpSelector pumpSelector) =>
        new Length(new Length(Math.Max(0.065, Math.Sqrt((4 * pumpSelector.Flow.GetValue("m3 s-1")
        / pumpSelector.PumpInletVelocity.GetValue("m s-1") / Math.PI)))).CopyConvertTo("mm")).GetStandardDiameter();

    private static Length? GetDischargeDiameter(Length suctionDiameter) => 
        suctionDiameter < new Length(150, "mm")
        ? suctionDiameter.GetLastSmallerDiameter()
        : new Length(Math.Min(suctionDiameter.GetValue("mm"), 400), "mm");
    private Length GetFeederDiameter(PumpSelector pumpSelector) =>
        new Length(new Length(Math.Max(DN2.CopyConvertTo("m").Value, Math.Sqrt((4 * pumpSelector.Flow.GetValue("m3 s-1")
            / pumpSelector.PressurizedPipeVelocity.GetValue("m s-1") / Math.PI)))).CopyConvertTo("mm")).GetStandardDiameter();
    private Length GetRisingMainDiameter(PumpSelector pumpSelector) =>
        new Length(new Length(Math.Max(DN3.CopyConvertTo("m").Value, Math.Sqrt((4 * pumpSelector.DesignPeakHourFlow.GetValue("m3 s-1")
            / pumpSelector.PressurizedPipeVelocity.GetValue("m s-1") / Math.PI)))).CopyConvertTo("mm")).GetStandardDiameter();
    private Length GetFlowmeterDiameter() =>
       new Length(DN4).GetLastSmallerDiameter();
    private Length GetGravityMainDiameter(PumpSelector pumpSelector) =>
        new Length(new Length(Math.Min(0.6, Math.Max(0.05, Math.Sqrt((4 * pumpSelector.DesignPeakHourFlow.GetValue("m3 s-1")
            / pumpSelector.GravityPipeVelocity.GetValue("m s-1") / Math.PI))))).CopyConvertTo("mm")).GetStandardDiameter();

   
}


