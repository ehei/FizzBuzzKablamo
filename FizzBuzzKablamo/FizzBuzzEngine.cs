using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzKablamo
{
    public class FizzBuzzEngine : IFizzBuzzEngineExtended
    {
        private readonly List<IEvaluatableGameObject> _digitEvaluators = new List<IEvaluatableGameObject>();
        private readonly List<IEvaluatableGameObject> _divisionEvaluators = new List<IEvaluatableGameObject>();

        private bool _digitMode;
        private bool _divisionMode;

        public bool ChecksDigits()
        {
            return _digitEvaluators.Count > 0;
        }

        public bool ChecksDivisible()
        {
            return _divisionEvaluators.Count > 0;
        }

        public bool Supports(GameObject.Token token)
        {
            return _digitEvaluators.Exists(x => x.AsValue() == (int) token) ||
                _divisionEvaluators.Exists(x => x.AsValue() == (int)token);
        }

        public void SetDigitMode()
        {
            _digitMode = true;
        }

        public void SetDivisionMode()
        {
            _divisionMode = true;
        }

        public void Add(GameObject.Token token)
        {
            if (_digitMode)
                _digitEvaluators.Add(new Digitizer(token));

            if (_divisionMode)
                _divisionEvaluators.Add(new Divisor(token));
        }
        
        public string GetString(int number)
        {
            _digitEvaluators.Sort(new EvaluatableGameObjectComparer());
            _divisionEvaluators.Sort(new EvaluatableGameObjectComparer());

            string fullReturn = _divisionEvaluators.Where(evaluator => evaluator.Evaluate(number)).Aggregate<IEvaluatableGameObject, string>(null, (current, evaluator) => current + evaluator.AsString());

            if (!String.IsNullOrEmpty(fullReturn))
                return fullReturn;

            var digitize = number.ToString().ToCharArray();
            fullReturn = (from digit in digitize select Int32.Parse(digit.ToString()) into value from evaluator in _digitEvaluators where evaluator.Evaluate(value) select evaluator).Aggregate(fullReturn, (current, evaluator) => current + evaluator.AsString());

            return string.IsNullOrEmpty(fullReturn) ? number.ToString() : fullReturn;
        }
    }
}
