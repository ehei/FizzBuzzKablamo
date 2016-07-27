using FizzBuzzKablamo;
using NUnit.Framework;

namespace FizzBuzzKablamoTests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class FizzBuzzEngineTest
    {
        private FizzBuzzEngine engine;

        [SetUp]
        public void SetUp()
        {
            engine = new FizzBuzzEngine();
        }

        [Test]
        public void ChecksNothing_ByDefault()
        {
            Assert.IsFalse(engine.ChecksDigits());
            Assert.IsFalse(engine.ChecksDivisible());
        }

        [Test]
        public void SetDigitMode_WillCauseDigitEvaluatorsToBeAddedForToken()
        {
            engine.SetDigitMode();
            engine.Add(GameObject.Token.Crash);

            Assert.IsTrue(engine.ChecksDigits());
            Assert.IsFalse(engine.ChecksDivisible());
        }

        [Test]
        public void SetDivisionMode_WillCauseDivisorEvaluatorsToBeAddedForToken()
        {
            engine.SetDivisionMode();
            engine.Add(GameObject.Token.Crash);

            Assert.IsFalse(engine.ChecksDigits());
            Assert.IsTrue(engine.ChecksDivisible());
        }

        [Test]
        public void Supports_ReturnsTrue_IfTokenWasAdded()
        {
            engine.SetDivisionMode();
            engine.Add(GameObject.Token.Bang);
            engine.Add(GameObject.Token.Crash);

            Assert.IsTrue(engine.Supports(GameObject.Token.Bang));
            Assert.IsTrue(engine.Supports(GameObject.Token.Crash));
        }

        [Test]
        public void Supports_ReturnsFalse_ForTokensNotAdded()
        {
            engine.SetDivisionMode();
            engine.Add(GameObject.Token.Bang);
            engine.Add(GameObject.Token.Crash);

            Assert.IsFalse(engine.Supports(GameObject.Token.Boom));
            Assert.IsFalse(engine.Supports(GameObject.Token.Buzz));
            Assert.IsFalse(engine.Supports(GameObject.Token.Fizz));
        }

        [Test]
        public void GetString_ReturnsFizz_DivisibleBy3()
        {
            engine.SetDivisionMode();
            engine.Add(GameObject.Token.Fizz);

            Assert.AreEqual("Fizz", engine.GetString(6));
            Assert.AreEqual("Fizz", engine.GetString(9));
            Assert.AreEqual("Fizz", engine.GetString(3333));
            Assert.AreEqual("Fizz", engine.GetString(3));
        }

        [Test]
        public void GetString_CheckingDivisible_ReturnsTheNumber_IfNotDivisibleByTokens()
        {
            Assert.AreEqual("42", engine.GetString(42));
        }

        [Test]
        public void GetString_ReturnsTheNumber_IfInDigitMode_AndDigitsDoNotMatchTokenValues()
        {
            engine.SetDigitMode();

            engine.Add(GameObject.Token.Fizz);
            engine.Add(GameObject.Token.Buzz);

            Assert.AreEqual("42", engine.GetString(42));
        }

        [Test]
        public void GetString_ReturnsTokens_IfInDigitMode_AndDigitsMatchTokenValues()
        {
            engine.SetDigitMode();

            engine.Add(GameObject.Token.Fizz);
            engine.Add(GameObject.Token.Buzz);

            Assert.AreEqual("BuzzFizzBuzz", engine.GetString(535));
        }

        [Test]
        public void TestDivisionWithFizzAndBuzz_UndivisibleValue()
        {
            engine.SetDivisionMode();

            engine.Add(GameObject.Token.Fizz);
            engine.Add(GameObject.Token.Buzz);

            Assert.AreEqual("4", engine.GetString(4));
        }

        [Test]
        public void TestDivisionWithFizzAndBuzz_DivisibleByBoth()
        {
            engine.SetDivisionMode();

            engine.Add(GameObject.Token.Fizz);
            engine.Add(GameObject.Token.Buzz);

            Assert.AreEqual("FizzBuzz", engine.GetString(15));
        }

        [Test]
        public void TestBothModesWithFizzAndBuzz_Divisible()
        {
            engine.SetDivisionMode();
            engine.SetDigitMode();

            engine.Add(GameObject.Token.Fizz);
            engine.Add(GameObject.Token.Buzz);

            Assert.AreEqual("FizzBuzz", engine.GetString(15));
            Assert.AreEqual("Buzz", engine.GetString(50));
            Assert.AreEqual("Fizz", engine.GetString(33));
        }

        [Test]
        public void TestBothModesWithFizzAndBuzz_NotDivisible_FallsBackToDigits()
        {
            engine.SetDivisionMode();
            engine.SetDigitMode();

            engine.Add(GameObject.Token.Fizz);
            engine.Add(GameObject.Token.Buzz);

            Assert.AreEqual("BuzzFizz", engine.GetString(53));
            Assert.AreEqual("FizzBuzzFizz", engine.GetString(353));
            Assert.AreEqual("BuzzBuzzBuzzBuzzFizzFizzFizz", engine.GetString(5555333));
        }
    }

    // ReSharper restore InconsistentNaming 
}