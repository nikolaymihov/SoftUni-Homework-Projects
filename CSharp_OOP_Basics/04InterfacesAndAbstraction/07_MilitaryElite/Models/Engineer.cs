using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, CorpsEnum corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new Dictionary<string, int>();
        }

        public Dictionary<string, int> Repairs { get; private set; }

        public void AddRepair(string repairName, int workedHours)
        {
            this.Repairs.Add(repairName, workedHours);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");

            foreach (var kvp in this.Repairs)
            {
                sb.AppendLine($"  Part Name: {kvp.Key} Hours Worked: {kvp.Value}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
