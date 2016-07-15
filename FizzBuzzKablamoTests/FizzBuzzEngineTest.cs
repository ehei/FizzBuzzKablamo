using System.Globalization;
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
        public void SetDigitMode_MakesChecksDigitsReturnTrue()
        {
            engine.SetDigitMode();

            Assert.IsTrue(engine.ChecksDigits());
            Assert.IsFalse(engine.ChecksDivisible());
        }

        [Test]
        public void SetDivisionMode_MakesChecksDivisibleReturnTrue()
        {
            engine.SetDivisionMode();

            Assert.IsFalse(engine.ChecksDigits());
            Assert.IsTrue(engine.ChecksDivisible());
        }

        [Test]
        public void Supports_ReturnsTrue_IfTokenWasAdded()
        {
            engine.Add(GameObject.Token.Bang);
            engine.Add(GameObject.Token.Crash);

            Assert.IsTrue(engine.Supports(GameObject.Token.Bang));
            Assert.IsTrue(engine.Supports(GameObject.Token.Crash));
        }

        [Test]
        public void Supports_ReturnsFalse_ForTokensNotAdded()
        {
            engine.Add(GameObject.Token.Bang);
            engine.Add(GameObject.Token.Crash);

            Assert.IsFalse(engine.Supports(GameObject.Token.Boom));
            Assert.IsFalse(engine.Supports(GameObject.Token.Buzz));
            Assert.IsFalse(engine.Supports(GameObject.Token.Fizz));
        }

        [Test]
        public void Supports_ReturnsFalse_ForTokensThatWereRemoved()
        {
            engine.Add(GameObject.Token.Bang);
            engine.Remove(GameObject.Token.Bang);

            Assert.IsFalse(engine.Supports(GameObject.Token.Bang));
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
        public void CheckDivisible_ReturnsTrue_IfValueIsDivisibleByTokenValue()
        {
            Assert.IsFalse(engine.CheckDivisible(1, GameObject.Token.Fizz));
            Assert.IsTrue(engine.CheckDivisible(9, GameObject.Token.Fizz));
            Assert.IsTrue(engine.CheckDivisible(3, GameObject.Token.Fizz));
            Assert.IsTrue(engine.CheckDivisible(150, GameObject.Token.Buzz));
        }

        [Test]
        public void CheckDigit_ReturnsTrue_IfValueIsThatDigit()
        {
            Assert.IsFalse(engine.CheckDigit(1, GameObject.Token.Fizz));
            Assert.IsTrue(engine.CheckDigit(3, GameObject.Token.Fizz));
            Assert.IsFalse(engine.CheckDigit(9, GameObject.Token.Fizz));
            Assert.IsFalse(engine.CheckDigit(150, GameObject.Token.Buzz));
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
        public void Test1()
        {
            Assert.IsFalse(engine.CheckDivisible(4, GameObject.Token.Fizz));
        } 

        [Test]
        public void Test2()
        {
            engine.SetDivisionMode();

            engine.Add(GameObject.Token.Fizz);
            engine.Add(GameObject.Token.Buzz);

            Assert.AreEqual("4", engine.GetString(4));
        }

        [Test]
        public void Test3()
        {
            engine.SetDivisionMode();

            engine.Add(GameObject.Token.Fizz);
            engine.Add(GameObject.Token.Buzz);

            Assert.AreEqual("FizzBuzz", engine.GetString(15));
        }
    }

    // ReSharper restore InconsistentNaming 
}