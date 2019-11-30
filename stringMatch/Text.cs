using System;
using System.Collections.Generic;
using System.Text;

namespace stringMatch
{
    class Text : IPattern
    {
        private string stringForMatch;

        public Text(string inputText)
        {
            stringForMatch = inputText;
        }

        public IMatch Match(string inputText)
        {
            if (inputText.Length == 0 || stringForMatch.Length > inputText.Length)
                return new FailMatch(inputText);

            for (int i = 0; i < stringForMatch.Length; i++)
                if (stringForMatch[i] != inputText[i])
                    return new FailMatch(inputText);
            return new SuccesMatch(inputText.Substring(stringForMatch.Length));
        }
    }
}
