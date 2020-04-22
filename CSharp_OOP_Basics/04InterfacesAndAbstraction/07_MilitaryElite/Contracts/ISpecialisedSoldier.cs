namespace MilitaryElite
{
    public interface ISpecialisedSoldier : ISoldier
    {
        decimal Salary { get; }

        CorpsEnum Corps { get; }
    }
}
