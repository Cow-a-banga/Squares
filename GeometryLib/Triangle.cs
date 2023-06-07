using System;
using System.Linq;

namespace GeometryLib
{
    public class Triangle: GeometricFigure
    {
        private readonly float[] _sides;
        private readonly bool _isRight;
        public bool IsRight => _isRight;
        
        public Triangle(float a, float b, float c)
        {
            _sides = new[] {a, b, c};

            if (_sides.Any(x => x <= 0))
            {
                throw new ArgumentOutOfRangeException(nameof(a), "Sides must be positive");
            }

            Array.Sort(_sides);
            _isRight = IsTriangleRight();
        }
        
        public override double GetSquare()
        {
            if (_isRight)
            {
                return _sides[0] * _sides[1] / 2;
            }
            else
            {
                var p = Perimeter() / 2;
                return Math.Sqrt(p * (p - _sides[0]) * (p - _sides[1]) * (p - _sides[2]));
            }
        }

        private bool IsTriangleRight()
        {
            return Math.Abs(_sides[0] * _sides[0] + _sides[1] * _sides[1] - _sides[2] * _sides[2]) < 1e-6;
        }

        public float Perimeter()
        {
            return _sides.Sum();
        }
    }
}