using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzKablamo
{
    public static class FizzBuzzEngineFactory
    {
        public static IFizzBuzzEngine Create(FizzBuzzRuleSet ruleSet)
        {
            var engine = new FizzBuzzEngine();

            var name = ruleSet.ToString();

            foreach (var validToken in Enum.GetValues(typeof (GameObject.Token))
                .Cast<GameObject.Token>()
                .Where(value => name.Contains(value.ToString())))
            {
                engine.Add(validToken);
            }

            if (ruleSet == FizzBuzzRuleSet.FizzBuzzDivisible ||
                ruleSet == FizzBuzzRuleSet.FizzBuzzBoomBangCrashDivisible ||
                ruleSet == FizzBuzzRuleSet.FizzBuzzDivisibleOrDigits)
            {
                engine.SetDivisionMode();
            }

            if (ruleSet == FizzBuzzRuleSet.FizzBuzzDigits ||
                ruleSet == FizzBuzzRuleSet.FizzBuzzDivisibleOrDigits)
            {
                engine.SetDigitMode();
            }

            return engine;
        }
    }
}
