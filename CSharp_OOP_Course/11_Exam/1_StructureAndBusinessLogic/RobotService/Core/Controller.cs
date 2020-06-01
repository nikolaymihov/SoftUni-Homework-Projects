namespace RobotService.Core
{
    using System;
    using System.Linq;

    using RobotService.Models.Robots;
    using RobotService.Core.Contracts;
    using RobotService.Models.Garages;
    using RobotService.Models.Procedures;
    using RobotService.Utilities.Messages;
    using RobotService.Models.Robots.Contracts;
    using RobotService.Models.Procedures.Contracts;

    public class Controller : IController
    {
        private readonly IProcedure chipProcedure;
        private readonly IProcedure techCheckProcedure;
        private readonly IProcedure restProcedure;
        private readonly IProcedure workProcedure;
        private readonly IProcedure chargeProcedure;
        private readonly IProcedure polishProcedure;

        private Garage garage;

        public Controller()
        {
            this.chipProcedure = new Chip();
            this.techCheckProcedure = new TechCheck();
            this.restProcedure = new Rest();
            this.workProcedure = new Work();
            this.chargeProcedure = new Charge();
            this.polishProcedure = new Polish();
            this.garage = new Garage();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot;

            if (robotType == nameof(HouseholdRobot))
            {
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == nameof(WalkerRobot))
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == nameof(PetRobot))
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);
            }
            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            this.garage.Manufacture(robot);

            string output = String.Format(OutputMessages.RobotManufactured, name);
            
            return output;
        }
        public string Chip(string robotName, int procedureTime)
        {
            IRobot robot = GetRobot(robotName);

            this.chipProcedure.DoService(robot, procedureTime);

            string output = String.Format(OutputMessages.ChipProcedure, robotName);

            return output;
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            IRobot robot = GetRobot(robotName);

            this.techCheckProcedure.DoService(robot, procedureTime);

            string output = String.Format(OutputMessages.TechCheckProcedure, robotName);

            return output;
        }

        public string Rest(string robotName, int procedureTime)
        {
            IRobot robot = GetRobot(robotName);

            this.restProcedure.DoService(robot, procedureTime);

            string output = String.Format(OutputMessages.RestProcedure, robotName);

            return output;
        }

        public string Work(string robotName, int procedureTime)
        {
            IRobot robot = GetRobot(robotName);

            this.workProcedure.DoService(robot, procedureTime);

            string output = String.Format(OutputMessages.WorkProcedure, robotName, procedureTime);

            return output;
        }

        public string Charge(string robotName, int procedureTime)
        {
            IRobot robot = GetRobot(robotName);

            this.chargeProcedure.DoService(robot, procedureTime);

            string output = String.Format(OutputMessages.ChargeProcedure, robotName);

            return output;
        }

        public string Polish(string robotName, int procedureTime)
        {
            IRobot robot = GetRobot(robotName);

            this.polishProcedure.DoService(robot, procedureTime);

            string output = String.Format(OutputMessages.PolishProcedure, robotName);

            return output;
        }

        public string Sell(string robotName, string ownerName)
        {
            IRobot robot = GetRobot(robotName);

            this.garage.Sell(robotName, ownerName);

            string output;

            if (robot.IsChipped)
            {
                output = String.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            else
            {
                output = String.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }

            return output;
        }

        public string History(string procedureType)
        {
            string output = null;

            if (procedureType == nameof(Charge))
            {
                output = this.chargeProcedure.History();
            }
            else if (procedureType == nameof(Chip))
            {
                output = this.chipProcedure.History();
            }
            else if (procedureType == nameof(Polish))
            {
                output = this.polishProcedure.History();
            }
            else if (procedureType == nameof(Rest))
            {
                output = this.restProcedure.History();
            }
            else if (procedureType == nameof(TechCheck))
            {
                output = this.techCheckProcedure.History();
            }
            else if (procedureType == nameof(Work))
            {
                output = this.workProcedure.History();
            }

            return output;
        }

        private void CheckIfRobotExists(string robotName)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
        }

        private IRobot GetRobot(string robotName)
        {
            CheckIfRobotExists(robotName);

            return this.garage.Robots.First(r => r.Key == robotName).Value;
        }
    }
}
