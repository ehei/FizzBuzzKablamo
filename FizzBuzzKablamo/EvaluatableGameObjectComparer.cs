using System.Collections.Generic;

namespace FizzBuzzKablamo
{
    public class EvaluatableGameObjectComparer : IComparer<IEvaluatableGameObject>
    {
        public int Compare(IEvaluatableGameObject first, IEvaluatableGameObject second)
        {
            if (first == second)
                return 0;

            if (first is Divisor && second is Digitizer)
                return -1;

            if (first is Digitizer && second is Divisor)
                return 1;

            return first.AsValue().CompareTo(second.AsValue());
        }
    }
}