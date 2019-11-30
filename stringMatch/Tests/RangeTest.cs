using System;
using Xunit;

namespace stringMatch
{
    public class RangeTest
    {
        [Fact]
        public void TestForAnCorectInput()
        {
            var patternForRange = new Range('0', '9');
            Assert.True(patternForRange.Match("0bc").IsSuccesful());
            Assert.Equal("bc", patternForRange.Match("0bc").RemainingText());
        }

        [Fact]
        public void TestIfTheStringIsOnlyFromDigits()
        {
            var patternForRange = new Range('0', '9');
            Assert.True(patternForRange.Match("123").IsSuccesful());
            Assert.Equal("23", patternForRange.Match("123").RemainingText());
        }

        [Fact]
        public void TheStringIsFormatedOnlyFromOneDigit()
        {
            var patternForRange = new Range('0', '9');
            Assert.True(patternForRange.Match("0").IsSuccesful());
            Assert.Equal("", patternForRange.Match("0").RemainingText());
        }

        [Fact]
        public void TheCharIsntInRange()
        {
            var patternForRange = new Range('2', '3');
            Assert.False(patternForRange.Match("5ab").IsSuccesful());
            Assert.Equal("5ab", patternForRange.Match("5ab").RemainingText());
        }

        [Fact]
        public void TheStringDontStartWithTheADigit()
        {
            var patternForRange = new Range('0', '9');
            Assert.False(patternForRange.Match("abc").IsSuccesful());
            Assert.Equal("abc", patternForRange.Match("abc").RemainingText());
        }

        [Fact]
        public void TheStringIsStartWithZeroOrNine()
        {
            var patternForRange = new Range('0', '9');
            Assert.True(patternForRange.Match("9bc").IsSuccesful());
            Assert.True(patternForRange.Match("0bc").IsSuccesful());
        }
        
        [Fact]
        public void RangeHaveLetter()
        {
            var patternForRange = new Range('a', 'z');
            Assert.True(patternForRange.Match("bc").IsSuccesful());
            Assert.Equal("c", patternForRange.Match("bc").RemainingText());
        }

        [Fact]
        public void NotConsumeCharConvertInAscii()
        {
            var patternForRange = new Range('a', 'z');
            Assert.False(patternForRange.Match("97").IsSuccesful());
            Assert.Equal("97", patternForRange.Match("97").RemainingText());
        }


    }
}
