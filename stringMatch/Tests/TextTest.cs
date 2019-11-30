using System;
using Xunit;

namespace stringMatch
{
    public class TextTest
    {
        [Fact]
        public void ForAnCorrectInput()
        {
            var text = new Text("abc");
            Assert.True(text.Match("abcxy").IsSuccesful());
            Assert.Equal("xy", text.Match("abcxy").RemainingText());

            Assert.False(text.Match("abxy").IsSuccesful());
            Assert.Equal("abxy", text.Match("abxy").RemainingText());
        }

        [Fact]
        public void CheckIfRemainingTextIsValid()
        {
            var text = new Text("ab");
            Assert.True(text.Match("abcd").IsSuccesful());
            Assert.Equal("cd", text.Match("abcd").RemainingText());
        }

        [Fact]
        public void CheckForAnEmptyInput()
        {
            var text = new Text("ab");
            Assert.False(text.Match("").IsSuccesful());
            Assert.Equal("", text.Match("").RemainingText());
        }

        [Fact]
        public void CheckIfHaveAnEmptyStringToCheck()
        {
            var text = new Text("");
            Assert.True(text.Match("abc").IsSuccesful());
            Assert.Equal("abc", text.Match("abc").RemainingText());
        }
    }
}
