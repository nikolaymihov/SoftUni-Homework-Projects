namespace RobotService.Models.Procedures
{
    using System;

    using RobotService.Utilities.Messages;
    using RobotService.Models.Robots.Contracts;

    public class Chip : Procedure
    {
        public Chip()
        {
        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Happiness -= 5;

            if (robot.IsChipped)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.AlreadyChipped, robot.Name));
            }
            else
            {
                robot.IsChipped = true;
            }
        }
    }
}
