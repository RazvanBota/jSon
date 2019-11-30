using System;
using Xunit;

namespace stringMatch
{
    public class AnyTest
    {
        [Fact]
        public void ForAnCorrectInput()
        {
            var patterForAny = new Any("abc");
            Assert.True(patterForAny.Match("acd").IsSuccesful());
            Assert.Equal("cd", patterForAny.Match("acd").RemainingText());
        }

        [Fact]
        public void CheckIfStringTestAllCharFromAny()
        {
            var patterForAny = new Any("abc");
            Assert.True(patterForAny.Match("axy").IsSuccesful());
            Assert.True(patterForAny.Match("bxy").IsSuccesful());
            Assert.True(patterForAny.Match("cxy").IsSuccesful());
        }

        [Fact]
        public void CheckRemainingTextForAllCharFromAny()
        {
            var patterForAny = new Any("abc");
            Assert.Equal("xy", patterForAny.Match("axy").RemainingText());
            Assert.Equal("xy", patterForAny.Match("bxy").RemainingText());
            Assert.Equal("xy", patterForAny.Match("cxy").RemainingText());
        }

        [Fact]
        public void CheckForAnEmptyStringOfChar()
        {
            var patterForAny = new Any("");
            Assert.False(patterForAny.Match("axy").IsSuccesful());
            Assert.Equal("abc", patterForAny.Match("abc").RemainingText());
        }

        [Fact]
        public void CheckForAnEmptyInput()
        {
            var patternForAny = new Any("abc");
            Assert.False(patternForAny.Match("").IsSuccesful());
            Assert.Equal("", patternForAny.Match("").RemainingText());
        }

        [Fact]
        public void CheckRemainingInput()
        {
            var patternForAny = new Any("abc");
            Assert.Equal("bc", patternForAny.Match("abc").RemainingText());
        }

        [Fact]
        public void CheckIfDoNotMatchForAnyCharFromInput()
        {
            var patternForAny = new Any("abc");
            Assert.False(patternForAny.Match("xyz").IsSuccesful());
            Assert.Equal("xyz", patternForAny.Match("xyz").RemainingText());
        }
    }
}
