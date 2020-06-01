namespace RobotService.Models.Procedures
{
    using RobotService.Models.Robots.Contracts;

    public class Polish : Procedure
    {
        public Polish()
        {
        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Happiness -= 7;
        }
    }
}
