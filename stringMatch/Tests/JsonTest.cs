using System;
using Xunit;

namespace stringMatch
{
    public class JsonTest
    {
        [Fact]
        public void CheckForAnStringInput() { 
            var json = new Json();
            Assert.True(json.Match("\"abcd\"").IsSuccesful());
            Assert.Equal("", json.Match("\"abcd\"").RemainingText());
        }

        [Fact]
        public void CheckForNumberInput()
        {
            var json = new Json();
            Assert.True(json.Match("1234").IsSuccesful());
            Assert.Equal("", json.Match("1234").RemainingText());
        }
        [Fact]
        public void CheckForAnEmptyObject()
        {
            var json = new Json();
            Assert.True(json.Match("{}").IsSuccesful());
            Assert.Equal("", json.Match("{}").RemainingText());
        }

        [Fact]
        public void CheckForAnObjectWithOneElement()
        {
            var json = new Json();
            Assert.True(json.Match("{\"abcd\":\"esb\"}").IsSuccesful());
            Assert.Equal("", json.Match("{\"abcd\":\"esb\"}").RemainingText());
        }

        [Fact]
        public void CheckForAnObjectWithMoreElements()
        {
            var json = new Json();
            Assert.True(json.Match("{\"abcd\":1234,\"ared\":12,\"equal\":1234}").IsSuccesful());
            Assert.Equal("", json.Match("{\"abcd\":1234,\"ared\":12,\"equal\":1234}").RemainingText());
        }

        [Fact]
        public void CheckForAnEmptyArray()
        {
            var json = new Json();
            Assert.True(json.Match("[]").IsSuccesful());
            Assert.Equal("", json.Match("[]").RemainingText());
        }

        [Fact]
        public void CheckForAnArrayWithString()
        {
            var json = new Json();
            Assert.True(json.Match("[\"abcd\"]").IsSuccesful());
            Assert.Equal("", json.Match("[\"abcd\"]").RemainingText());
        }

        [Fact]
        public void CheckForAnArrayWithMoreItems()
        {
            var json = new Json();
            Assert.True(json.Match("[\"abcd\",1234,5678]").IsSuccesful());
            Assert.Equal("", json.Match("[\"abcd\",1234,5678]").RemainingText());
        }

        [Fact]
        public void ValueWithTrueChoice()
        {
            var json = new Json();
            Assert.True(json.Match("true").IsSuccesful());
            Assert.Equal("", json.Match("true").RemainingText());
        }

        [Fact]
        public void ValueWithFalseChoice()
        {
            var json = new Json();
            Assert.True(json.Match("false").IsSuccesful());
            Assert.Equal("", json.Match("false").RemainingText());
        }

        [Fact]
        public void ValueWithNullChoice()
        {
            var json = new Json();
            Assert.True(json.Match("null").IsSuccesful());
            Assert.Equal("", json.Match("null").RemainingText());
        }
    }
}
