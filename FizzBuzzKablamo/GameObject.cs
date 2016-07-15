namespace FizzBuzzKablamo
{
    public class GameObject
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

        private Token GameToken { get; set; }

        public GameObject(Token gameToken)
        {
            GameToken = gameToken;
        }

        public string AsString()
        {
            return this.GameToken.ToString();
        }

        public int AsValue()
        {
            return (int)this.GameToken;
        }
    }
}
