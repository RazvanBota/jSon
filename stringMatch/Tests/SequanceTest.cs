using System;
using Xunit;

namespace stringMatch
{
    public class SequanceTest
    {
        [Fact]
        public void CheckAnCorrectInput()
        {
            var sequance = new Sequance(new Character('+'), new Range('0', '9'));
            Assert.True(sequance.Match("+0abc").IsSuccesful());
            Assert.False(sequance.Match("abc").IsSuccesful());
        }

        [Fact]
        public void CheckForASinglePattern()
        {
            var sequance = new Sequance(new Character('+'));
            Assert.True(sequance.Match("+123").IsSuccesful());
            Assert.False(sequance.Match("123").IsSuccesful());
            Assert.Equal("ab", sequance.Match("+ab").RemainingText());
        }

        [Fact]
        public void CheckForAnEmptyPattern()
        {
            var sequance = new Sequance();
            Assert.True(sequance.Match("1234").IsSuccesful());
            Assert.True(sequance.Match("+abc").IsSuccesful());
            Assert.True(sequance.Match("abcd").IsSuccesful());
        }

        [Fact]
        public void CheckForAnEmptyString()
        {
            var sequance = new Sequance(new Character('+'), new Range('0', '9'));
            Assert.False(sequance.Match("").IsSuccesful());
            Assert.Equal("", sequance.Match("").RemainingText());
        }

        [Fact]
        public void CheckIfContainJustOneInstance()
        {
            var sequance = new Sequance(new Character('+'), new Range('0', '9'));
            Assert.False(sequance.Match("+abc").IsSuccesful());
            Assert.False(sequance.Match("1abc").IsSuccesful());
        }

        [Fact]
        public void CheckForClassText() {
            var sequance = new Sequance(new Text("abc"), new Range('0', '9'));
            Assert.True(sequance.Match("abc123").IsSuccesful());
            Assert.Equal("23", sequance.Match("abc123").RemainingText());
        }

        [Fact]
        public void CheckForFailMatchRemainingText()
        {
            var sequance = new Sequance(new Any("abc"), new Text("12a"));
            Assert.False(sequance.Match("a12bc").IsSuccesful());
            Assert.Equal("a12bc", sequance.Match("a12bc").RemainingText());
        }
    }
}
