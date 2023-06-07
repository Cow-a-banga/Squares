using System;

namespace GeometryLib
{
    public class Circle:GeometricFigure
    {
        public double Radius { get; private set; }
        
        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be positive");
            
            Radius = radius;
        }
        
        public override double GetSquare()
        {
            return Math.PI * Radius * Radius;
        }
    }
}