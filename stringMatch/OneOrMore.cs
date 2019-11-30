using System;
using System.Collections.Generic;
using System.Text;

namespace stringMatch
{
    class OneOrMore : IPattern
    {
        private IPattern pattern;

        public OneOrMore(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string inputText)
        {
            bool existOnePattern = false;
            var match = pattern.Match(inputText);
            while(match.IsSuccesful())
            {
                existOnePattern = true;
                inputText = match.RemainingText();
                match = pattern.Match(inputText);
            }

            if (existOnePattern)
                return new SuccesMatch(inputText);
            else
                return new FailMatch(inputText);
        }
    }
}
