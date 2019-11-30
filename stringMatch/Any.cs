using System;
using System.Collections.Generic;
using System.Text;

namespace stringMatch
{
    class Any : IPattern
    {
        private string stringOfChar;

        public Any(string inputText)
        {
            stringOfChar = inputText;
        }

        public IMatch Match(string inputText)
        {
            if(inputText.Length == 0)
                return new FailMatch(inputText);

            for (int i = 0; i < stringOfChar.Length; i++)
                if(stringOfChar[i] == inputText[0])
                    return new SuccesMatch(inputText.Substring(1));
            return new FailMatch(inputText);
        }
    }
}
