using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class Engine
    {
        private const string INVALID_CORPS_MSG = "The corps unit can be set only to Airforces or Marines and nothing else.";
        private HashSet<Soldier> soldiers;

        public Engine(IReader reader, IWriter writer)
        {
            this.Reader = reader;
            this.Writer = writer;
            this.soldiers = new HashSet<Soldier>();
        }

        public IReader Reader { get; private set; }

        public IWriter Writer { get; private set; }

        public void Run()
        {
            string soldierInput = this.Reader.ReadLine();

            while (soldierInput.ToLower() != "end")
            {
                string[] soldierArgs = soldierInput.Split(' ').ToArray();
                string soldierType = soldierArgs[0];
                string[] soldierParams = soldierArgs.Skip(1).ToArray();

                try
                { 
                    if (soldierType == "Private")
                    {
                        Private newPrivate = CreatePrivate(soldierParams);
                        soldiers.Add(newPrivate);
                    }
                    else if (soldierType == "LieutenantGeneral")
                    {
                        LieutenantGeneral lieutenantGeneral = CreateLieutenantGeneral(soldierParams);
                        soldiers.Add(lieutenantGeneral);
                    }
                    else if (soldierType == "Engineer")
                    {
                        Engineer engineer = CreateEngineer(soldierParams);
                        soldiers.Add(engineer);
                    }
                    else if (soldierType == "Commando")
                    {
                        Commando commando = CreateCommando(soldierParams);
                        soldiers.Add(commando);
                    }
                    else if (soldierType == "Spy")
                    {
                        Spy spy = CreateSpy(soldierParams);
                        soldiers.Add(spy);
                    }
                }
                catch (InvalidCastException)
                {
                }

                soldierInput = this.Reader.ReadLine();
            }

            foreach (Soldier soldier in soldiers)
            {
                this.Writer.WriteLine(soldier.ToString());
            }
        }

        private Private CreatePrivate(string[] soldierParams)
        {
            //"Private <id> <firstName> <lastName> <salary>"
            string id = soldierParams[0];
            string firstName = soldierParams[1];
            string lastName = soldierParams[2];
            decimal salary = decimal.Parse(soldierParams[3]);

            Private newPrivate = new Private(id, firstName, lastName, salary);

            return newPrivate;
        }

        private LieutenantGeneral CreateLieutenantGeneral(string[] soldierParams)
        {
            // LieutenantGeneral<id> < firstName > < lastName > < salary > < private1Id > < private2Id > … < privateNId >
            string id = soldierParams[0];
            string firstName = soldierParams[1];
            string lastName = soldierParams[2];
            decimal salary = decimal.Parse(soldierParams[3]);

            LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

            for (int i = 4; i < soldierParams.Length; i++)
            {
                string newPrivateId = soldierParams[i];
                Private newPrivate = (Private) this.soldiers.Where(s => s.Id == newPrivateId).FirstOrDefault();
                lieutenantGeneral.AddPrivate(newPrivate);
            }

            return lieutenantGeneral;
        }

        private Engineer CreateEngineer(string[] soldierParams)
        {
            //Engineer<id> < firstName > < lastName > < salary > < corps > < repair1Part > < repair1Hours > … < repairNPart > < repairNHours >
            string id = soldierParams[0];
            string firstName = soldierParams[1];
            string lastName = soldierParams[2];
            decimal salary = decimal.Parse(soldierParams[3]);
            string corpsAsString = soldierParams[4];

            CorpsEnum corps;

            if (corpsAsString == "Airforces")
            {
                corps = CorpsEnum.Airforces;
            }
            else if (corpsAsString == "Marines")
            {
                corps = CorpsEnum.Marines;
            }
            else 
            {
                throw new InvalidCastException(INVALID_CORPS_MSG);
            }

            Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);

            for (int i = 5; i < soldierParams.Length; i += 2)
            {
                string repairName = soldierParams[i];
                int workerHours = int.Parse(soldierParams[i + 1]);

                engineer.AddRepair(repairName, workerHours);
            }

            return engineer;
        }

        private Commando CreateCommando(string[] soldierParams)
        {
            //Commando <id> <firstName> <lastName> <salary> <corps> <mission1CodeName>  <mission1state> … <missionNCodeName> <missionNstate>" 
            string id = soldierParams[0];
            string firstName = soldierParams[1];
            string lastName = soldierParams[2];
            decimal salary = decimal.Parse(soldierParams[3]);
            string corpsAsString = soldierParams[4];

            CorpsEnum corps;

            if (corpsAsString == "Airforces")
            {
                corps = CorpsEnum.Airforces;
            }
            else if (corpsAsString == "Marines")
            {
                corps = CorpsEnum.Marines;
            }
            else
            {
                throw new InvalidCastException(INVALID_CORPS_MSG);
            }

            Commando commando = new Commando(id, firstName, lastName, salary, corps);

            for (int i = 5; i < soldierParams.Length; i += 2)
            {
                string missionName = soldierParams[i];
                string missionStateAsString = soldierParams[i + 1];

                MissionStateEnum missionState;

                if (missionStateAsString == "inProgress")
                {
                    missionState = MissionStateEnum.inProgress;
                }
                else if (missionStateAsString == "Finished")
                {
                    missionState = MissionStateEnum.Finished;
                }
                else
                {
                    missionState = MissionStateEnum.Invalid;
                }

                if (missionState == MissionStateEnum.inProgress || missionState == MissionStateEnum.Finished)
                {
                    commando.AddMission(missionName, missionState);
                }
            }

            return commando;
        }

        private Spy CreateSpy(string[] soldierParams)
        {
            //Spy <id> <firstName> <lastName> <codeNumber>"
            string id = soldierParams[0];
            string firstName = soldierParams[1];
            string lastName = soldierParams[2];
            int codeNumber = int.Parse(soldierParams[3]);

            Spy spy = new Spy(id, firstName, lastName, codeNumber);

            return spy;
        }
    }
}
