using System;
using Xunit;

namespace stringMatch
{
    public class OptionalTest
    {
        [Fact]
        public void CheckForAnSimpleInput() {
            var optional = new Optional(new Character('+'));
            Assert.True(optional.Match("+abc").IsSuccesful());
            Assert.Equal("abc", optional.Match("+abc").RemainingText());
        }

        [Fact]
        public void CheckRemainingTextForAllInput()
        {
            var optional = new Optional(new Range('1', '9'));
            Assert.True(optional.Match("abc").IsSuccesful());

            optional = new Optional(new Character('-'));
            Assert.True(optional.Match("abc").IsSuccesful());
            Assert.Equal("abc", optional.Match("abc").RemainingText());

        }
        [Fact]
        public void CheckForEmtryStrings()
        {
            var optional = new Optional(new Text(""));
            Assert.True(optional.Match("abc").IsSuccesful());
            Assert.True(optional.Match("").IsSuccesful());
        }

        [Fact]
        public void CheckRemainingText()
        {
            var optional = new Optional(new Any("abc"));
            Assert.Equal("123", optional.Match("b123").RemainingText());
            Assert.Equal("xyz", optional.Match("cxyz").RemainingText());
        }

    }
}
