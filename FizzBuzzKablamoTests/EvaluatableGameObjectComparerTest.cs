using FizzBuzzKablamo;
using NUnit.Framework;

namespace FizzBuzzKablamoTests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class EvaluatableGameObjectComparerTest
    {
        private EvaluatableGameObjectComparer _comparer;
        private Divisor _fizzDivisor;
        private Divisor _buzzDivisor;
        private Digitizer _fizzDigitizer;
        private Digitizer _buzzDigitizer;

        [SetUp]
        public void SetUp()
        {
            _fizzDivisor = new Divisor(GameObject.Token.Fizz);
            _buzzDivisor = new Divisor(GameObject.Token.Buzz);
            _fizzDigitizer = new Digitizer(GameObject.Token.Fizz);
            _buzzDigitizer = new Digitizer(GameObject.Token.Buzz);

            _comparer = new EvaluatableGameObjectComparer();
        }

        [Test]
        public void ReturnsZero_IfTheSameInstance()
        {
            Assert.AreEqual(0, _comparer.Compare(_fizzDigitizer, _fizzDigitizer));
            Assert.AreEqual(0, _comparer.Compare(_buzzDivisor, _buzzDivisor));
        }

        [Test]
        public void DivisionComesBeforeDigit()
        {
            Assert.AreEqual(1, _comparer.Compare(_fizzDigitizer, _fizzDivisor));
            Assert.AreEqual(-1, _comparer.Compare(_fizzDivisor, _fizzDigitizer));
        }

        [Test]
        public void GivenEqualTypes_OrderByValueAscending()
        {
            Assert.AreEqual(-1, _comparer.Compare(_fizzDigitizer, _buzzDigitizer));
            Assert.AreEqual(1, _comparer.Compare(_buzzDigitizer, _fizzDigitizer));
        }
    }

    // ReSharper restore InconsistentNaming 
}