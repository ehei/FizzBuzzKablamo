using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzKablamo
{
    public class FizzBuzzEngine : IFizzBuzzEngineExtended
    { 
        private readonly HashSet<GameObject.Token> _supportedTokens = new HashSet<GameObject.Token>();
        private bool _digitMode;
        private bool _divisionMode;

        public bool Supports(GameObject.Token token)
        {
            return _supportedTokens.Contains(token);
        }

        public bool ChecksDigits()
        {
            return _digitMode;
        }

        public bool ChecksDivisible()
        {
            return _divisionMode;
        }

        public void SetDigitMode()
        {
            _digitMode = true;
        }

        public void SetDivisionMode()
        {
            _divisionMode = true;
        }

        public void Add(GameObject.Token token)
        {
            _supportedTokens.Add(token);
        }

        public void Remove(GameObject.Token token)
        {
            _supportedTokens.Remove(token);
        }

        public bool CheckDivisible(int number, GameObject.Token token)
        {
            if (token == GameObject.Token.Invalid)
                return false;

            return ((number/(int) token) > 0) && ((number % (int)token) == 0);
        }

        public bool CheckDigit(int number, GameObject.Token token)
        {
            if (token == GameObject.Token.Invalid)
                return false;

            return number == (int)token;
        }

        public string GetString(int number)
        {
            string fullReturn = null;

            if (_divisionMode)
            {
                string divisionReturn = _supportedTokens.Where(token => CheckDivisible(number, token)).Aggregate<GameObject.Token, string>(null, (current, token) => current + token.ToString());

                if (! string.IsNullOrEmpty(divisionReturn))
                    fullReturn += divisionReturn;
            }

            if (_digitMode)
            {
                List<GameObject.Token> list = new List<GameObject.Token>();

                var digitize = number.ToString().ToCharArray();

                var digitReturn = digitize.Aggregate<char, string>(null, (current1, digit) => 
                    _supportedTokens.Where(token => 
                        this.CheckDigit(Int32.Parse(digit.ToString()), token)).Aggregate(current1, (current, token) => current + token.ToString()));

                if (!string.IsNullOrEmpty(digitReturn))
                    fullReturn += digitReturn;
            }

            return string.IsNullOrEmpty(fullReturn) ? number.ToString() : fullReturn;
        }
    }
}
