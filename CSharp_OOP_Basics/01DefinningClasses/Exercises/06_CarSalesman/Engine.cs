namespace DefiningClasses
{
	using System;
    using System.Text;

	public class Engine
	{
		private string model;
		private int power;
		private int? displacement;
		private string? efficiency;

		public Engine(string model, int power)
		{
			this.Model = model;
			this.Power = power;
		}

		public Engine(string model, int power, int displacement)
			: this(model, power)
		{
			this.Displacement = displacement;
		}

		public Engine(string model, int power, string efficiency)
			: this(model, power)
		{
			this.Efficiency = efficiency;
		}

		public Engine(string model, int power, int displacement, string efficiency)
			: this(model, power)
		{
			this.Displacement = displacement;
			this.Efficiency = efficiency;
		}

		public string Model
		{
			get { return this.model; }

			set
			{
				this.model = value;
			}
		}

		public int Power
		{
			get { return this.power; }

			set 
			{ 
				if (value < 0)
				{
					throw new InvalidOperationException("The power of the engine cannot be less than 0.");
				}
				else
				{
					this.power = value;
				}
			}
		}

		public int? Displacement
		{
			get { return this.displacement; }

			set
			{
				this.displacement = value;
			}
		}

		public string? Efficiency
		{
			get { return this.efficiency; }

			set
			{
				this.efficiency = value;
			}
		}

		public override string ToString()
		{
			string displacementStr = this.Displacement.HasValue ? this.Displacement.ToString() : "n/a";
			string efficiencyStr = this.Efficiency != null ? this.Efficiency : "n/a";
			
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"  {this.Model}:");
			sb.AppendLine($"    Power: {this.Power}");
			sb.AppendLine($"    Displacement: {displacementStr}");
			sb.AppendLine($"    Efficiency: {efficiencyStr}");

			return sb.ToString().Trim();
		}
	}
}
