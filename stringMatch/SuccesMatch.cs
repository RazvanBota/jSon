using System;
using System.Collections.Generic;
using System.Text;

namespace stringMatch
{
    class SuccesMatch : IMatch
    {
        private readonly string inputString;

        public SuccesMatch(string newString)
        {
            inputString = newString;
        }

        public bool IsSuccesful()
        {
            return true;
        }

        public string RemainingText()
        {
            return inputString;
        }
    }
}
