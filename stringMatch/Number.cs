using System;
using System.Collections.Generic;
using System.Text;

namespace stringMatch
{
    class Number : IPattern
    {
        private readonly IPattern digit;
        private readonly IPattern digitWithoutZero;
        private readonly IPattern e;
        private readonly IPattern naturalNumber;
        private readonly IPattern integerNumber;
        private readonly IPattern floatNumber;
        private readonly IPattern realNumber;

        public Number()
        {
            digit = new Range('0', '9');
            digitWithoutZero = new Range('1', '9');
            e = new Any("eE");
            naturalNumber = new Choice(new Character('0'), new Sequance(digitWithoutZero, new Many(digit)));
            integerNumber = new Sequance(new Optional(new Character('-')), naturalNumber);
            floatNumber = new Sequance(integerNumber, new Optional(new Sequance(new Character('.'), new OneOrMore(digit))));
            realNumber = new Sequance(floatNumber, new Optional(new Sequance(e, new Optional(new Any("+-")), new OneOrMore(digit))));
        }

    public IMatch Match(string inputText)
        {
            return realNumber.Match(inputText);
        }
    }
}
