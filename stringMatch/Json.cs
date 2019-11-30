using System;
using System.Collections.Generic;
using System.Text;

namespace stringMatch
{
    class Json : IPattern
    {
        private static IPattern json;

        public Json()
        {
            IPattern whiteSpace = new Many(new Any("\n\t\r\f "));
            IPattern aTrueText = new Text("true");
            IPattern aFalseText = new Text("false");
            IPattern aNullText = new Text("null");

            var value = new Choice(new String(), new Number(), aTrueText, aFalseText, aNullText);

            IPattern objectMiddle = new Sequance(whiteSpace, new String(), whiteSpace, new Character(':'), whiteSpace, value, whiteSpace);
            IPattern objectList = new List(objectMiddle, new Character(','));
            IPattern objectJson = new Sequance(new Character('{'), whiteSpace, new Optional(objectList), whiteSpace, new Character('}'));
            value.AddChoice(objectJson);

            IPattern arrayList = new List(value, new Character(','));
            IPattern array = new Sequance(new Character('['), whiteSpace, new Optional(arrayList), whiteSpace, new Character(']'));
            value.AddChoice(array);

            json = value;
        }

        public IMatch Match(string inputText)
        {
            return json.Match(inputText);
        }
    }
}