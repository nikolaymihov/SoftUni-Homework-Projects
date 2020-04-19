using System.Text;

namespace BoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length 
        { 
            get { return this.length; }

            private set
            {
                CommonValidator.ValidateRange(value, nameof(this.Length));

                this.length = value;
            }
        }

        public double Width 
        { 
            get { return this.width; } 

            private set 
            {
                CommonValidator.ValidateRange(value, nameof(this.Width));

                this.width = value;
            }
        }

        public double Height 
        {
            get { return this.height; }

            private set
            {
                CommonValidator.ValidateRange(value, nameof(this.Height));

                this.height = value;
            }
        }

        public double CalculateSurface()
        {
            return (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        }

        public double CalculateLateralSurface()
        {
            return (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        }

        public double CalculateVolume()
        {
            return this.Length * this.Width * this.Height;
        }

        public string Details()
        {
            return this.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {this.CalculateSurface():F2}")
              .AppendLine($"Lateral Surface Area - {this.CalculateLateralSurface():F2}")
              .AppendLine($"Volume - {this.CalculateVolume():F2}");

            return sb.ToString().TrimEnd();
        }
    }
}
