using System;
using Xunit;

namespace GeometryLib.Test
{
    public class TriangleTests
    {
        [Theory]
        [InlineData(1, 1, 1, 0.433012702)]
        [InlineData(2, 3, 4, 2.90473751)]
        public void SquareNotRightTriangles(float a, float b, float c, float square)
        {
            var triangle = new Triangle(a,b,c);
            var result = Math.Abs(triangle.GetSquare() - square);
            const double eps = 1e-6;
            
            Assert.False(triangle.IsRight);
            Assert.True(result < eps, triangle.GetSquare().ToString());
            
        }
        
        [Theory]
        [InlineData(3, 4, 5, 6)]
        [InlineData(5, 12, 13, 30)]
        public void SquareRightTriangles(float a, float b, float c, float square)
        {
            var triangle = new Triangle(a,b,c);
            var result = Math.Abs(triangle.GetSquare() - square);
            const double eps = 1e-6;
            
            Assert.True(triangle.IsRight);
            Assert.True(result < eps);
        }
        
        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(-1, 1, 1)]
        public void SquareNegativeRadius(float a, float b, float c)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var triangle = new Triangle(a, b, c);
            });
        }
    }
}