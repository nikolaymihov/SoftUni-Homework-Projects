using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ILieutenantGeneral : ISoldier
    {
        decimal Salary { get; }

        public List<IPrivate> Privates { get; }
    }
}
