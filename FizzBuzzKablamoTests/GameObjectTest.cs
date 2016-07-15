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
            Assert.AreEqual(GameObject.Token.Boom.ToString(), new GameObject(GameObject.Token.Boom).AsString());
            Assert.AreEqual((int)GameObject.Token.Boom, new GameObject(GameObject.Token.Boom).AsValue());
        }
    }

    // ReSharper restore InconsistentNaming 
}