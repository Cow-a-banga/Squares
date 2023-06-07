using System;
using Xunit;

namespace GeometryLib.Test
{
    public class CircleTests
    {
        [Theory]
        [InlineData(1, Math.PI)]
        [InlineData(2, 4 * Math.PI)]
        public void SquareSimple(float radius, float square)
        {
            var circle = new Circle(radius);
            var result = Math.Abs(circle.GetSquare() - square);
            const double eps = 1e-6;
            
            Assert.True(result < eps);
        }
        
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void SquareNegativeRadius(float radius)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var circle = new Circle(-1);
            });
        }
    }
}