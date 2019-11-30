using System;
using Xunit;

namespace stringMatch
{

    public class OneOrMoreTest
    {
        [Fact]
        public void CheckForAnCorrectInput()
        {
            var oneOrMore = new OneOrMore(new Character('a'));
            Assert.True(oneOrMore.Match("abc").IsSuccesful());
            Assert.False(oneOrMore.Match("bc").IsSuccesful());
        }

        [Fact]
        public void CheckIfWorkWithMoreCharInARow()
        {
            var oneOrMore = new OneOrMore(new Character('a'));
            Assert.True(oneOrMore.Match("aabc").IsSuccesful());
            Assert.Equal("bc", oneOrMore.Match("aabc").RemainingText());
        }

        [Fact]
        public void CheckForEmptyString()
        {
            var oneOrMore = new OneOrMore(new Character('a'));
            Assert.False(oneOrMore.Match("").IsSuccesful());
            Assert.Equal("", oneOrMore.Match("").RemainingText());
        }

        [Fact]
        public void CheckIfWorkForText()
        {
            var oneOrMore = new OneOrMore(new Text("ab"));
            Assert.True(oneOrMore.Match("ababc").IsSuccesful());
            Assert.Equal("c", oneOrMore.Match("abc").RemainingText());
        }

        [Fact]
        public void CheckIfWorkForMoreText()
        {
            var oneOrMore = new OneOrMore(new Text("ab"));
            Assert.Equal("c", oneOrMore.Match("ababc").RemainingText());
            Assert.Equal("c", oneOrMore.Match("abababc").RemainingText());
        }

        [Fact]
        public void NotContaintTheChar()
        {
            var oneOrMore = new OneOrMore(new Character('a'));
            Assert.False(oneOrMore.Match("zx").IsSuccesful());
            Assert.Equal("zx", oneOrMore.Match("zx").RemainingText());
        }

        [Fact]
        public void TheTextNotMatchExactly ()
        {
            var oneOrMore = new OneOrMore(new Text("ab"));
            Assert.False(oneOrMore.Match("acb").IsSuccesful());
            Assert.Equal("acb", oneOrMore.Match("acb").RemainingText());
        }

    }
}
