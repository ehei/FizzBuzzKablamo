using FizzBuzzKablamo;
using NUnit.Framework;

namespace FizzBuzzKablamoTests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class GameObjectTest
    {
        [Test]
        public void WrapsEnumsCorrectly()
        {
            Assert.AreEqual(GameObject.Token.Boom.ToString(), new TestableGameObject(GameObject.Token.Boom).AsString());
            Assert.AreEqual((int)GameObject.Token.Boom, new TestableGameObject(GameObject.Token.Boom).AsValue());
        }
    }

    internal class TestableGameObject : GameObject
    {
        public TestableGameObject(Token gameToken) : base(gameToken)
        {
        }
    }

    // ReSharper restore InconsistentNaming 
}