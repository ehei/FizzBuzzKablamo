using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzzKablamo;
using NUnit.Framework;

namespace FizzBuzzKablamoTests
{
    [TestFixture]
    public class FizzBuzzEngineFactoryTest
    {
        [Test]
        public void Create_ReturnsExtendedFizzBuzzEngine()
        {
            Assert.IsInstanceOf<IFizzBuzzEngineExtended>(FizzBuzzEngineFactory.Create(FizzBuzzRuleSet.FizzBuzzDigits));
        } 

        [Test]
        public void FizzBuzzDigits_ShouldAddToEngine_FizzAndBuzz()
        {
            var engine = FizzBuzzEngineFactory.Create(FizzBuzzRuleSet.FizzBuzzDigits) as IFizzBuzzEngineExtended;

            Assert.IsTrue(engine.Supports(GameObject.Token.Fizz));
            Assert.IsTrue(engine.Supports(GameObject.Token.Buzz));

            Assert.IsFalse(engine.Supports(GameObject.Token.Invalid));

            Assert.IsFalse(engine.ChecksDivisible());
            Assert.IsTrue(engine.ChecksDigits());
        }

        [Test]
        public void SupportsRuleSet_ReturnsTrueFor_FizzBuzzDivisible()
        {
            var engine = FizzBuzzEngineFactory.Create(FizzBuzzRuleSet.FizzBuzzDivisible) as IFizzBuzzEngineExtended;

            Assert.IsTrue(engine.Supports(GameObject.Token.Fizz));
            Assert.IsTrue(engine.Supports(GameObject.Token.Buzz));

            Assert.IsFalse(engine.Supports(GameObject.Token.Invalid));

            Assert.IsTrue(engine.ChecksDivisible());
            Assert.IsFalse(engine.ChecksDigits());
        }

        [Test]
        public void SupportsRuleSet_ReturnsTrueFor_FizzBuzzBoomBangCrashDivisible()
        {
            var engine = FizzBuzzEngineFactory.Create(FizzBuzzRuleSet.FizzBuzzBoomBangCrashDivisible) as IFizzBuzzEngineExtended;

            Assert.IsTrue(engine.Supports(GameObject.Token.Fizz));
            Assert.IsTrue(engine.Supports(GameObject.Token.Buzz));
            Assert.IsTrue(engine.Supports(GameObject.Token.Boom));
            Assert.IsTrue(engine.Supports(GameObject.Token.Bang));
            Assert.IsTrue(engine.Supports(GameObject.Token.Crash));

            Assert.IsFalse(engine.Supports(GameObject.Token.Invalid));

            Assert.IsTrue(engine.ChecksDivisible());
            Assert.IsFalse(engine.ChecksDigits());
        }

        [Test]
        public void SupportsRuleSet_ReturnsTrueFor_FizzBuzzDivisibleOrDigits()
        {
            var engine = FizzBuzzEngineFactory.Create(FizzBuzzRuleSet.FizzBuzzDivisibleOrDigits) as IFizzBuzzEngineExtended;

            Assert.IsTrue(engine.Supports(GameObject.Token.Fizz));
            Assert.IsTrue(engine.Supports(GameObject.Token.Buzz));

            Assert.IsFalse(engine.Supports(GameObject.Token.Invalid));

            Assert.IsTrue(engine.ChecksDivisible());
            Assert.IsTrue(engine.ChecksDigits());
        }
    }
}
