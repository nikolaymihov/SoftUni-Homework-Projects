using System.Text;

namespace MilitaryElite
{
    public abstract class SpecialisedSoldier : Soldier, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, CorpsEnum corps)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
            this.Corps = corps;
        }

        public decimal Salary { get; private set; }

        public CorpsEnum Corps { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString() + $" Salary: {this.Salary:F2}");
            sb.AppendLine($"Corps: {this.Corps}");

            return sb.ToString().TrimEnd();
        }
    }
}
