namespace RobotService.Models.Procedures
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using RobotService.Utilities.Messages;
    using RobotService.Models.Robots.Contracts;
    using RobotService.Models.Procedures.Contracts;

    public abstract class Procedure : IProcedure
    {

        private readonly List<IRobot> robots;

        protected Procedure()
        {
            this.robots = new List<IRobot>();
        }

        protected IReadOnlyCollection<IRobot> Robots => this.robots.AsReadOnly();

        public virtual void DoService(IRobot robot, int procedureTime)
        {
            int robotProcedureTime = robot.ProcedureTime;

            if (robotProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }

            robot.ProcedureTime -= procedureTime;

            this.robots.Add(robot);
        }

        public string History()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}");

            foreach (IRobot robot in this.robots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
