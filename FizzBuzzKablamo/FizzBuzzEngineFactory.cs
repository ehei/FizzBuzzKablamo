using System;
using System.Linq;

namespace FizzBuzzKablamo
{
    public static class FizzBuzzEngineFactory
    {
        public static IFizzBuzzEngine Create(FizzBuzzRuleSet ruleSet)
        {
            var engine = new FizzBuzzEngine();

            switch (ruleSet)
            {
                case FizzBuzzRuleSet.FizzBuzzDivisible:
                case FizzBuzzRuleSet.FizzBuzzBoomBangCrashDivisible:
                    engine.SetDivisionMode();
                    break;
                case FizzBuzzRuleSet.FizzBuzzDigits:
                    engine.SetDigitMode();
                    break;
                case FizzBuzzRuleSet.FizzBuzzDivisibleOrDigits:
                // intentional fall through
                default:
                    engine.SetDivisionMode();
                    engine.SetDigitMode();
                    break;
            }

            var name = ruleSet.ToString();

            foreach (var validToken in Enum.GetValues(typeof (GameObject.Token))
                .Cast<GameObject.Token>()
                .Where(value => name.Contains(value.ToString())))
            {
                engine.Add(validToken);
            }

            return engine;
        }
    }
}