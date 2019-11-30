using System;
using System.Collections.Generic;
using System.Text;

namespace stringMatch
{
    class Range : IPattern
    {
        private char start, end;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public IMatch Match(string inputText)
        {
            if (inputText.Length == 0)
                return new FailMatch(inputText);

            if (inputText[0] >= start && inputText[0] <= end)
                return new SuccesMatch(inputText.Substring(1));

            return new FailMatch(inputText);
        }
    }
}
