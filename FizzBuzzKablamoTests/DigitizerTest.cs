using FizzBuzzKablamo;
using NUnit.Framework;

namespace FizzBuzzKablamoTests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class DigitizerTest
    {
        private Digitizer fizzDigitizer;
        private Digitizer buzzDigitizer;

        [SetUp]
        public void SetUp()
        {
            fizzDigitizer = new Digitizer(GameObject.Token.Fizz);
            buzzDigitizer = new Digitizer(GameObject.Token.Buzz);
        }

        [Test]
        public void Evaluate_ReturnsTrue_IfValueIsEqualToTokenValue()
        {
            Assert.IsTrue(fizzDigitizer.Evaluate(3));
            Assert.IsTrue(buzzDigitizer.Evaluate(5));
        }

        [Test]
        public void Evaluate_ReturnsFalse_IfValueIsNotEqualToTokenValue()
        {
            Assert.IsFalse(fizzDigitizer.Evaluate(1));
            Assert.IsFalse(fizzDigitizer.Evaluate(9));
            Assert.IsFalse(buzzDigitizer.Evaluate(150));
        }
    }

    // ReSharper restore InconsistentNaming 
}