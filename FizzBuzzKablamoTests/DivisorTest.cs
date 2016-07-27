using FizzBuzzKablamo;
using NUnit.Framework;

namespace FizzBuzzKablamoTests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class DivisorTest
    {
        private Divisor fizzDivisor;
        private Divisor buzzDivisor;

        [SetUp]
        public void SetUp()
        {
            fizzDivisor = new Divisor(GameObject.Token.Fizz);
            buzzDivisor = new Divisor(GameObject.Token.Buzz);
        }

        [Test]
        public void Evaluate_ReturnsFalse_IfValueIsLessThanTheTokenValue()
        {
            Assert.IsFalse(fizzDivisor.Evaluate(0));
            Assert.IsFalse(fizzDivisor.Evaluate(1));
            Assert.IsFalse(fizzDivisor.Evaluate(2));

            Assert.IsFalse(buzzDivisor.Evaluate(0));
            Assert.IsFalse(buzzDivisor.Evaluate(1));
            Assert.IsFalse(buzzDivisor.Evaluate(2));
            Assert.IsFalse(buzzDivisor.Evaluate(3));
            Assert.IsFalse(buzzDivisor.Evaluate(4));
        }

        [Test]
        public void Evaluate_ReturnsFalse_IfValueIsNotDivisibleByTokenValue()
        {
            Assert.IsFalse(fizzDivisor.Evaluate(4));
            Assert.IsFalse(fizzDivisor.Evaluate(22));

            Assert.IsFalse(buzzDivisor.Evaluate(7));
            Assert.IsFalse(buzzDivisor.Evaluate(81));
        }

        [Test]
        public void Evaluate_ReturnsTrue_IfValueIsDivisibleByTokenValue()
        {
            Assert.IsTrue(fizzDivisor.Evaluate(3));
            Assert.IsTrue(fizzDivisor.Evaluate(9));

            Assert.IsTrue(buzzDivisor.Evaluate(5));
            Assert.IsTrue(buzzDivisor.Evaluate(150));
        }
    }

    // ReSharper restore InconsistentNaming 
}
