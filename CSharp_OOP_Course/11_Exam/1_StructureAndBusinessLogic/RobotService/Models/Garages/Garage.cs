namespace RobotService.Models.Garages
{
    using System;
    using System.Collections.Generic;

    using RobotService.Utilities.Messages;
    using RobotService.Models.Robots.Contracts;
    using RobotService.Models.Garages.Contracts;

    public class Garage : IGarage
    {
        private const int CONSTANT_CAPACITY = 10;

        private readonly Dictionary<string, IRobot> robots;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
            this.Capacity = CONSTANT_CAPACITY;
            this.CountOfRobots = 0;
        }

        private int CountOfRobots { get; set; }

        public int Capacity { get; }

        public IReadOnlyDictionary<string, IRobot> Robots => this.robots;

        public void Manufacture(IRobot robot)
        {
            if (CountOfRobots == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if (this.robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }

            this.robots[robot.Name] = robot;
            this.CountOfRobots++;
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this.robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot), robotName);
            }
            else
            {
                this.robots[robotName].Owner = ownerName;
                this.robots[robotName].IsBought = true;
                this.robots.Remove(robotName);
                this.CountOfRobots--;
            }
        }
    }
}
