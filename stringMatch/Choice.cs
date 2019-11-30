using System;
using System.Collections.Generic;
using System.Text;

namespace stringMatch
{
    class Choice : IPattern
    {
        private IPattern[] array;

        public Choice(params IPattern[] array)
        {
            this.array = array;
        }

        public void AddChoice(IPattern newPattern)
        {
            IPattern[] tempPattern = new IPattern[array.Length+1];
            for(int i = 0; i < array.Length; i++)            
                tempPattern[i] = array[i];
            tempPattern[array.Length] = newPattern;
            array = tempPattern;
        }

        public IMatch Match(string inputText)
        {
            if (array.Length == 0)
                return new SuccesMatch(inputText);

            foreach(IPattern pattern in array) { 
                var match = pattern.Match(inputText);
                if (match.IsSuccesful())
                    return match;
            }
            return new FailMatch(inputText);
        }
    }
}
