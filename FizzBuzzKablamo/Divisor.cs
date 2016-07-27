namespace FizzBuzzKablamo
{
    public class Divisor : GameObject, IEvaluatableGameObject
    {
        public Divisor(Token token) : base(token)
        {
        }

        public bool Evaluate(int value)
        {
            return (value / this.AsValue() > 0) && (value % this.AsValue() == 0);
        }
    }
}
