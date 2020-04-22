using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ICommando : ISpecialisedSoldier
    {
        Dictionary<string, MissionStateEnum> Missions { get; }
    }
}
