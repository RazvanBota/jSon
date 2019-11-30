using Xunit;

namespace stringMatch
{
    public class ChoiceTest
    {
        [Fact]
        public void CheckAnCorrectInput()
        {
            var choice = new Choice(new Character('+'), new Range('0', '9'));
            Assert.True(choice.Match("+0abc").IsSuccesful());
        }

        [Fact]
        public void CheckIfMatchIfIsJustOneChoiceInText()
        {
            var choice = new Choice(new Character('+'), new Range('0', '9'));

            Assert.True(choice.Match("+abc").IsSuccesful());
            Assert.Equal("abc", choice.Match("+abc").RemainingText());

            Assert.True(choice.Match("1abc").IsSuccesful());
            Assert.Equal("abc", choice.Match("1abc").RemainingText());
        }

        [Fact]
        public void CheckForAnEmptyPatterArray()
        {
            var choice = new Choice();
            Assert.True(choice.Match("abc").IsSuccesful());
            Assert.Equal("abc", choice.Match("abc").RemainingText());
        }

        [Fact]
        public void CheckForAnEmptyInput()
        {
            var choice = new Choice(new Character('+'), new Range('0', '9'), new Any("ab"), new Text("xy"));
            Assert.False(choice.Match("").IsSuccesful());
            Assert.Equal("", choice.Match("").RemainingText());
        }

        [Fact]
        public void CheckRemainingTextForMultipleCase()
        {
            var choice = new Choice(new Character('+'), new Range('0', '9'), new Any("ab"), new Text("xy"));
            Assert.Equal("abc", choice.Match("+abc").RemainingText());
            Assert.Equal("abc", choice.Match("5abc").RemainingText());
            Assert.Equal("ac", choice.Match("bac").RemainingText());
            Assert.Equal("z", choice.Match("xyz").RemainingText());
            Assert.Equal("qw", choice.Match("qw").RemainingText());

        }

    }
}