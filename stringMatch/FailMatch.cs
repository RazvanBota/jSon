using System;
using System.Collections.Generic;
using System.Text;

namespace stringMatch
{
    class FailMatch : IMatch
    {
        private string inputString;

        public FailMatch(string newString)
        {
            inputString = newString;
        }

        public bool IsSuccesful()
        {
            return false;
        }

        public string RemainingText()
        {
            return inputString;
        }
    }
}
