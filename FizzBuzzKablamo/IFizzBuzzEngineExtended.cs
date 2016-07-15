using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzKablamo
{
    public interface IFizzBuzzEngineExtended : IFizzBuzzEngine
    {
        bool Supports(GameObject.Token token);
        bool ChecksDigits();
        bool ChecksDivisible();
    }
}
