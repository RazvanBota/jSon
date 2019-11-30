using System;
using System.Collections.Generic;
using System.Text;

namespace stringMatch
{
    class String : IPattern
    {
        private readonly IPattern stringFormat;

        public String()
        {
            IPattern hexadecimal = new Sequance(new Character('u'), new Many(new Any("123456789ABCDEFabcdef"), 4, 4));
            IPattern controlChar = new OneOrMore(new Sequance(new Character('\\'), new Choice(new Any("\"\\/bfnrt"), hexadecimal)));
            IPattern unicodeCharacter = new OneOrMore(new Choice(new Range(' ', '!'), new Range('#','['), new Range(']', Convert.ToChar(65535))));
            stringFormat = new Sequance(new Character('\"'), new Many(new Choice(controlChar, unicodeCharacter)), new Character('\"'));
        }

        public IMatch Match(string inputText)
        {
            return stringFormat.Match(inputText);
        }
    }
}
