using System;
using System.Collections.Generic;
using System.Text;

namespace stringMatch
{
    class Character : IPattern
    {
        private char character;

        public Character(char character)
        {
            this.character = character;
        }

        public IMatch Match(string inputText)
        {
            if (inputText.Length == 0)
                return new FailMatch(inputText);

            if (inputText[0] == character)
                return new SuccesMatch(inputText.Substring(1));

            return new FailMatch(inputText);
        }
    }
}
