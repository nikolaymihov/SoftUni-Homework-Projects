namespace DefiningClasses
{
	using System;
	public class Engine
	{
		private int engineSpeed;
		private int enginePower;

		public Engine(int engineSpeed, int enginePower)
		{
			this.EngineSpeed = engineSpeed;
			this.EnginePower = enginePower;
		}
		public int EngineSpeed 
		{
			get { return this.engineSpeed; } 
			
			set
			{
				if (value < 0)
				{
					throw new InvalidOperationException("The engine speed cannot be lower than 0.");
				}
				else
				{
					this.engineSpeed = value;
				}
			}
		}

		public int EnginePower
		{
			get { return this.enginePower; }

			set
			{
				if (value < 0)
				{
					throw new InvalidOperationException("The engine power cannot be lower than 0.");
				}
				else
				{
					this.enginePower = value;
				}
			}
		}
	}
}
