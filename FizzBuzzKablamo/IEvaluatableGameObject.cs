namespace FizzBuzzKablamo
{
    public interface IEvaluatableGameObject
    {
        bool Evaluate(int value);
        string AsString();
        int AsValue();
    }
}