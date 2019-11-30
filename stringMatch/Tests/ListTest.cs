using System;
using Xunit;

namespace stringMatch
{
    public class ListTest
    {
        [Fact]
        public void CheckAnCorectInput()
        {
            var list = new List(new Range('0', '9'), new Character(','));
            Assert.True(list.Match("1,3,4,33,00,22").IsSuccesful());
            Assert.True(list.Match("a,1,3,4,33,00,22").IsSuccesful());
            Assert.Equal("", list.Match("1,3,5").RemainingText());
            Assert.Equal(",a,3", list.Match("1,2,a,3").RemainingText());
        }

        [Fact]
        public void CheckOnlyForIncorectInput()
        {
            var list = new List(new Range('0', '9'), new Character(','));
            Assert.True(list.Match("a,b,c").IsSuccesful());
            Assert.Equal("a,b,c", list.Match("a,b,c").RemainingText());
        }

        [Fact]
        public void CheckForAnTextClass()
        {
            var list = new List(new Text("abc"), new Character(','));
            Assert.True(list.Match("abc,ab").IsSuccesful());
            Assert.True(list.Match("acbca").IsSuccesful());
            Assert.Equal(",ab", list.Match("abc,ab").RemainingText());
        }

        [Fact]
        public void CheckForEmptyInputs()
        {
            var list = new List(new Character('+'), new Character('-'));
            Assert.True(list.Match("").IsSuccesful());
            Assert.Equal("", list.Match("").RemainingText());
        }

        [Fact]
        public void CheckForListWithOnlyOneElemOfList()
        {
            var list = new List(new Any("+-="), new Character('.'));

            Assert.True(list.Match("+").IsSuccesful());
            Assert.Equal("", list.Match("+").RemainingText());

            Assert.True(list.Match("-").IsSuccesful());
            Assert.Equal("", list.Match("-").RemainingText());

            Assert.True(list.Match("=").IsSuccesful());
            Assert.Equal("", list.Match("=").RemainingText());
        }

        [Fact]
        public void CheckForMoreCharsWithoutSepparator()
        {
            var list = new List(new Text("abc"), new Character('.'));
            Assert.True(list.Match("abcabc").IsSuccesful());
            Assert.Equal("abc", list.Match("abcabc").RemainingText());
        }

        [Fact]
        public void CheckForOneOrMoreDigitsInARow() {
            var list = new List(new OneOrMore(new Range('0', '9')), new Character(','));
            Assert.True(list.Match("1,11,111,1111").IsSuccesful());
            Assert.Equal("", list.Match("1,11,111,1111").RemainingText());
        }

        [Fact]
        public void CheckForManyDigitsInARow()
        {
            var list = new List(new Many(new Range('0', '9')), new Character(','));
            Assert.True(list.Match(",1,11,111,1111").IsSuccesful());
            Assert.True(list.Match(",1,,11,,111,,,1111").IsSuccesful());
            Assert.Equal(",1,,11,,111,,,1111", list.Match(",1,,11,,111,,,1111").RemainingText());
            Assert.True(list.Match(",,,").IsSuccesful());
            Assert.Equal("a,11", list.Match("1a,11").RemainingText());
            Assert.True(list.Match("1a,11").IsSuccesful());
            Assert.Equal(",,,1", list.Match(",,,1").RemainingText());
        }
    }
}
