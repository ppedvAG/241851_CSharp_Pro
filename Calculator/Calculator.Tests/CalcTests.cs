using System.Reflection;

namespace Calculator.Tests
{
    public class CalcTests
    {
        [Fact]
        public void Sum_2_and_6_result_9()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(3, 6);

            //Assert
            Assert.Equal(9, result);
        }

        [Theory]
        [InlineData(3, 6, 9)]
        [InlineData(1, 1, 2)]
        [InlineData(-1, -1, -2)]
        [InlineData(-2, 3, 1)]
        [InlineData(0, 0, 0)]
        public void Sum_with_result(int a, int b, int exp)
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(a, b);

            //Assert
            Assert.Equal(exp, result);
        }


        [Fact]
        public void Sum_MAX_and_1_throw_OverflowException()
        {
            var calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(int.MaxValue, 1));
            Assert.Throws<OverflowException>(() => calc.Sum(int.MinValue, -1));
        }
    }
}