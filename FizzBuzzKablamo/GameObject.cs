namespace FizzBuzzKablamo
{
    public abstract class GameObject
    {
        public enum Token
        {
            Fizz = 3,
            Buzz = 5,
            Boom = 7,
            Bang = 11,
            Crash = 13,
            Invalid = 0
        }

        protected GameObject(Token gameToken)
        {
            GameToken = gameToken;
        }

        private Token GameToken { get; }

        public string AsString()
        {
            return GameToken.ToString();
        }

        public int AsValue()
        {
            return (int) GameToken;
        }
    }
}