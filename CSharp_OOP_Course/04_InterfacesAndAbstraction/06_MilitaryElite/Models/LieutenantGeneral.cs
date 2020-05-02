using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Soldier, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
            this.Privates = new List<IPrivate>();
        }

        public decimal Salary { get; private set; }

        public List<IPrivate> Privates { get; private set; }

        public void AddPrivate(IPrivate newPrivate)
        {
            this.Privates.Add(newPrivate);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString() + $" Salary: {this.Salary:F2}");
            sb.AppendLine("Privates:");

            foreach (Private privateX in this.Privates)
            {
                sb.AppendLine($"  {privateX}");
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}
