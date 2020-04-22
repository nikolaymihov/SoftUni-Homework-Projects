using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, CorpsEnum corps)
           : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new Dictionary<string, MissionStateEnum>();
        }

        public Dictionary<string, MissionStateEnum> Missions { get; private set; }

        public void AddMission (string missionName, MissionStateEnum missionState)
        {
            this.Missions.Add(missionName, missionState);
        }

        public void CompleteMission(string missionName)
        {
            this.Missions[missionName] = MissionStateEnum.Finished;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");

            if (this.Missions.Count > 0)
            { 
                foreach (var kvp in this.Missions)
                {
                    sb.AppendLine($"  Code Name: {kvp.Key} State: {kvp.Value}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
