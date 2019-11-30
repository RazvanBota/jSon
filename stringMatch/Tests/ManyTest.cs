using System;
using Xunit;

namespace stringMatch
{
    
    public class ManyTest
    {
        [Fact]
        public void CheckForAnCorrectInput() { 
            var many = new Many(new Range('0', '9'));
            Assert.True(many.Match("123abc").IsSuccesful());
            Assert.Equal("abc", many.Match("123abc").RemainingText());
        }

        [Fact]
        public void CheckForEqualTextIfIsCorect()
        {
            var many = new Many(new Range('0', '9'));
            Assert.Equal("abc", many.Match("12345abc").RemainingText());
            Assert.Equal("xyz123abc", many.Match("xyz123abc").RemainingText());
        }

        [Fact]
        public void CheckForIfPassForMoreTextClass()
        {
            var many = new Many(new Text("ab"));
            Assert.Equal("xy", many.Match("ababxy").RemainingText());
            Assert.Equal("12ab", many.Match("abab12ab").RemainingText());
        }

        [Fact]
        public void CheckForClassAnyIfHaveAllCharInInput()
        {
            var many = new Many(new Any("abc"));
            Assert.Equal("", many.Match("abc").RemainingText());
            Assert.Equal("12ab", many.Match("abc12ab").RemainingText());
        }

        [Fact]
        public void CheckForAnEmptyString()
        {
            var many = new Many(new Character('a'));
            Assert.True(many.Match("").IsSuccesful());
            Assert.Equal("", many.Match("").RemainingText());
        }

        [Fact]
        public void CheckMaxAppearances()
        {
            var many = new Many(new Any("abc"), 0, 4);
            Assert.True(many.Match("aabcc").IsSuccesful());
            Assert.Equal("c", many.Match("aabcc").RemainingText());
        }

        [Fact]
        public void CheckMinAppearances()
        {
            var many = new Many(new Text("12"),3);
            Assert.True(many.Match("12121212").IsSuccesful());
            Assert.Equal("", many.Match("12121212").RemainingText());
        }

        [Fact]
        public void FailForMinAppareance()
        {
            var many = new Many(new Any("012"), 3);
            Assert.False(many.Match("1234").IsSuccesful());
            Assert.Equal("1234", many.Match("1234").RemainingText());
        }

        [Fact]
        public void CheckIfLastCharIsDouble()
        {
            var many = new Many(new Text("ab"), 1);
            Assert.True(many.Match("abba").IsSuccesful());
            Assert.Equal("ba", many.Match("abba").RemainingText());
        }

        [Fact]
        public void TextIsWrittenRevert()
        {
            var many = new Many(new Text("ab"), 1);
            Assert.False(many.Match("baba").IsSuccesful());
            Assert.Equal("baba", many.Match("baba").RemainingText());
        }


    }
}
