using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ClassBoxData
{
    public class Box
    {
		private const string ArgumentExceptionMessage = "{0} cannot be zero or negative.";
		private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
		{
			get { return length; }
			private set
			{
				if (value <= 0)
				{
					throw new ArgumentException(string.Format(ArgumentExceptionMessage, nameof(Length)));
				}

				length = value; 
			}
		}
		public double Width
		{
			get { return width; }
			private set 
			{
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ArgumentExceptionMessage, nameof(Width)));
                }

                width = value; 
			}
		}
		public double Height
		{
			get { return height; }
			private set 
			{
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ArgumentExceptionMessage, nameof(Height)));
                }

                height = value; 
			}
		}

		public double SurfaceArea()
		{
			return 2 * Width * Length + 2 * Height * Width + 2 * Height * Length;
		}
		public double LateralSurfaceArea()
		{
			return 2 * Height * Width + 2 * Height * Length;

        }
		public double Volume()
		{
			return Length * Width * Height;
		}
	}
}
