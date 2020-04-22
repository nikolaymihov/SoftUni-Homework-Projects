using System.Collections.Generic;

namespace MilitaryElite
{
    public interface IEngineer : ISpecialisedSoldier
    {
        Dictionary<string, int> Repairs { get; }
    }
}
