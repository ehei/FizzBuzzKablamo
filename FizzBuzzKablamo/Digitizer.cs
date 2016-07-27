namespace FizzBuzzKablamo
{
    public class Digitizer : GameObject, IEvaluatableGameObject
    {
        public Digitizer(Token token) : base(token)
        {
        }

        public bool Evaluate(int value)
        {
            return value == this.AsValue();
        }
    }
}
