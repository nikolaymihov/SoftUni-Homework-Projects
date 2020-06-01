namespace RobotService.Models.Procedures
{
    using RobotService.Models.Robots.Contracts;

    public class TechCheck : Procedure
    {
        public TechCheck()
        {
        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Energy -= 8;

            if (robot.IsChecked)
            {
                robot.Energy -= 8;
            }
            else
            {
                robot.IsChecked = true;
            }
        }
    }
}
