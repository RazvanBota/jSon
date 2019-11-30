using System;
using Xunit;

namespace stringMatch
{
    public class NumberTest
    {
        [Fact]
        public void Zero()
        {
            var number = new Number();
            Assert.True(number.Match("0").IsSuccesful());
            Assert.Equal("", number.Match("0").RemainingText());
        }

        [Fact]
        public void NumberFromOneToNine()
        {
            var number = new Number();
            Assert.True(number.Match("5").IsSuccesful());
            Assert.Equal("", number.Match("5").RemainingText());
        }

        [Fact]
        public void NumberSmallerThanOneHundred()
        {
            var number = new Number();
            Assert.True(number.Match("54").IsSuccesful());
            Assert.Equal("", number.Match("54").RemainingText());
        }

        [Fact]
        public void NumberBiggerThanOneHundred()
        {
            var number = new Number();
            Assert.True(number.Match("543").IsSuccesful());
            Assert.Equal("", number.Match("543").RemainingText());
        }

        [Fact]
        public void NegativeNumber()
        {
            var number = new Number();
            Assert.True(number.Match("-5").IsSuccesful());
            Assert.Equal("", number.Match("-5").RemainingText());
        }

        [Fact]
        public void NegativeNumberWithMoreDigits()
        {
            var number = new Number();
            Assert.True(number.Match("-5421").IsSuccesful());
            Assert.Equal("", number.Match("-5421").RemainingText());
        }

        [Fact]
        public void ZeroPointNumber()
        {
            var number = new Number();
            Assert.True(number.Match("0.123").IsSuccesful());
            Assert.Equal("", number.Match("0.123").RemainingText());
        }

        [Fact]
        public void NumberPointNumber()
        {
            var number = new Number();
            Assert.True(number.Match("542.123").IsSuccesful());
            Assert.Equal("", number.Match("542.123").RemainingText());
        }

        [Fact]
        public void DoNotConsumeIfCommit()
        {
            var number = new Number();
            Assert.True(number.Match("542,123").IsSuccesful());
            Assert.Equal(",123", number.Match("542,123").RemainingText());
        }

        [Fact]
        public void NumberWithCharE()
        {
            var number = new Number();
            Assert.True(number.Match("542E6").IsSuccesful());
            Assert.True(number.Match("542e6").IsSuccesful());

            Assert.Equal("", number.Match("542E6").RemainingText());
            Assert.Equal("", number.Match("542e6").RemainingText());
        }

        [Fact]
        public void NumberWithPointAndCharE()
        {
            var number = new Number();
            Assert.True(number.Match("542.2e2").IsSuccesful());
            Assert.Equal("", number.Match("542.2e2").RemainingText());
        }

        [Fact]
        public void SignAfterCharE()
        {
            var number = new Number();
            Assert.True(number.Match("542.2e+25").IsSuccesful());
            Assert.True(number.Match("542.2e-25").IsSuccesful());

            Assert.Equal("", number.Match("542.2e+25").RemainingText());
            Assert.Equal("", number.Match("542.2e-25").RemainingText());
        }

        [Fact]
        public void FailIfNotE()
        {
            var number = new Number();
            Assert.True(number.Match("542.2c2").IsSuccesful());
            Assert.Equal("c2", number.Match("542.2c2").RemainingText());
        }

        [Fact]
        public void NegativeNumberWithE()
        {
            var number = new Number();
            Assert.True(number.Match("-542.2e2").IsSuccesful());
            Assert.Equal("", number.Match("-542.2e2").RemainingText());
        }

    }
}
