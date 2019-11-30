using System;
using System.Collections.Generic;
using System.Text;

namespace stringMatch
{
    class Optional : IPattern
    {
        private IPattern pattern;

        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string inputText)
        {
            var match = pattern.Match(inputText);
            return new SuccesMatch(match.RemainingText());
        }
    }
}
