namespace FizzBuzzKablamo
{
    public interface IFizzBuzzEngineExtended : IFizzBuzzEngine
    {
        bool ChecksDigits();
        bool ChecksDivisible();
        bool Supports(GameObject.Token token);
    }
}