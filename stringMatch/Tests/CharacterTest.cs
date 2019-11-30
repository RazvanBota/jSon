using System;
using Xunit;

namespace stringMatch
{
    public class CharacterTest
    {
        [Fact]
        public void IfIsCorectInput()
        {
            var patternForA = new Character('a');
            Assert.True(patternForA.Match("abc").IsSuccesful());
            Assert.Equal("bc", patternForA.Match("abc").RemainingText());
        }

        [Fact]
        public void CheckIfTheCharacterIsNotInTheText()
        {
            var patternForA = new Character('a');
            Assert.False(patternForA.Match("xbc").IsSuccesful());
            Assert.Equal("xbc", patternForA.Match("xbc").RemainingText());
        }

        [Fact]
        public void InputIsEmpty()
        {
            var patternForA = new Character('a');
            Assert.False(patternForA.Match("").IsSuccesful());
            Assert.Equal("", patternForA.Match("").RemainingText());
        }

        [Fact]
        public void CheckIfIsMatchingOnTheNumber()
        {
            var patternForA = new Character('1');
            Assert.True(patternForA.Match("123").IsSuccesful());
            Assert.Equal("23", patternForA.Match("123").RemainingText());
        }

        [Fact]
        public void CheckForUpperCase()
        {
            var patternForA = new Character('A');
            Assert.True(patternForA.Match("ABC").IsSuccesful());
            Assert.Equal("BC", patternForA.Match("ABC").RemainingText());
        }
    }
}
