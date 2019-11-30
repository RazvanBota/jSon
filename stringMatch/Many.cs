using System;
using System.Collections.Generic;
using System.Text;

namespace stringMatch
{
    class Many : IPattern
    {
        private readonly IPattern pattern;
        private readonly int min;
        private readonly int max;

        public Many(IPattern pattern, int min = 0, int max = 0)
        {
            this.pattern = pattern;
            this.min = min;
            this.max = max;
        }

        public IMatch Match(string inputText)
        {
            string aString = inputText;
            var match = pattern.Match(inputText);
            int countAppearances = 0;
            while (match.IsSuccesful())
            { 
                inputText = match.RemainingText();
                countAppearances++;
                if (countAppearances == max && max != 0)
                    return new SuccesMatch(inputText);
                match = pattern.Match(inputText);
            }
            if (countAppearances < min)
                return new FailMatch(aString);
            return new SuccesMatch(inputText);
        }
    }
}
