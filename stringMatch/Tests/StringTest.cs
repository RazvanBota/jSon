using System;
using Xunit;

namespace stringMatch
{
    public class StringTest
    {
        [Fact]
        public void CheckForControlCharacter()
        {
            var strings = new String();
            Assert.True(strings.Match("\"\\\"\"").IsSuccesful());
            Assert.True(strings.Match("\"\\\\\"").IsSuccesful());
            Assert.True(strings.Match("\"\\/\"").IsSuccesful());
            Assert.True(strings.Match("\"\\b\"").IsSuccesful());
            Assert.True(strings.Match("\"\\f\"").IsSuccesful());
            Assert.True(strings.Match("\"\\n\"").IsSuccesful());
            Assert.True(strings.Match("\"\\r\"").IsSuccesful());
            Assert.True(strings.Match("\"\\t\"").IsSuccesful());
        }

        [Fact]
        public void CheckForHexadecimalDigit()
        {
            var strings = new String();
            Assert.True(strings.Match("\"\\u22AB\"").IsSuccesful());
            Assert.True(strings.Match("\"\\uABBB\"").IsSuccesful());
            Assert.True(strings.Match("\"\\uAAAA\"").IsSuccesful());
            Assert.True(strings.Match("\"\\u1234\"").IsSuccesful());
            Assert.True(strings.Match("\"\\u2222\"").IsSuccesful());
        }

        [Fact]
        public void CheckForManyControlChar()
        {
            var strings = new String();
            Assert.True(strings.Match("\"\\b\\f\"").IsSuccesful());
            Assert.Equal("", strings.Match("\"\\b\\f\"").RemainingText());
        }

        [Fact]
        public void CheckForChars()
        {
            var strings = new String();
            Assert.True(strings.Match("\"abcd\"").IsSuccesful());
            Assert.Equal("", strings.Match("\"abcd\"").RemainingText());
        }
        [Fact]
        public void CheckForBothInput()
        {
            var strings = new String();
            Assert.True(strings.Match("\"\\nabcd\\b\"").IsSuccesful());
            Assert.Equal("", strings.Match("\"\\nabcd\\b\"").RemainingText());
            Assert.True(strings.Match("\"abc\\n\\b\"").IsSuccesful());
            Assert.Equal("", strings.Match("\"abc\\n\\b\"").RemainingText());
        }

        [Fact]
        public void CheckForAnIncorectInput()
        {
            var strings = new String();
            Assert.False(strings.Match("abcd\"").IsSuccesful());
            Assert.Equal("abcd\"", strings.Match("abcd\"").RemainingText());
        }
    }
}
