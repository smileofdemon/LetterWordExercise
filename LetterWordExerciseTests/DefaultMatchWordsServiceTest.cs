using LetterWordExercise.Services;
using Xunit;

namespace LetterWordExerciseTests
{
    public class DefaultMatchWordsServiceTest
    {
        private DefaultMatchWordsService _matchWordsService = new DefaultMatchWordsService();

        [Fact]
        public void AddWordTest()
        {
            string[] words = { "testtt", "te" };
            foreach (var word in words)
            {
                _matchWordsService.AddWord(word);
            }

            var result = _matchWordsService.GetMatchWords(2);
            Assert.True("" == result, "There is not matching words for 2 combination");

            _matchWordsService.AddWord("sttt");
            result = _matchWordsService.GetMatchWords(2);
            Assert.True("te+sttt=testtt\r\n" == result, "Matching should have 1 matching result");
        }

        [Fact]
        public void GetMatchWordsTest()
        {
            string[] words = { "testtt", "tes", "t" };
            foreach (var word in words)
            {
                _matchWordsService.AddWord(word);
            }

            var result = _matchWordsService.GetMatchWords(2);
            Assert.True("" == result, "There is not matching words for 2 combination");

            result = _matchWordsService.GetMatchWords(3);
            Assert.True("" == result, "There is not matching words for 3 combination");

            result = _matchWordsService.GetMatchWords(4);
            Assert.True("tes+t+t+t=testtt\r\n" == result, "Matching should have 1 matching result");

            result = _matchWordsService.GetMatchWords(5);
            Assert.True("" == result, "There is not matching words for 4 combination");

            result = _matchWordsService.GetMatchWords(6);
            Assert.True("" == result, "There is not matching words for 5 combination");

            _matchWordsService.AddWord("tt");
            result = _matchWordsService.GetMatchWords(3);
            Assert.True("tes+t+tt=testtt\r\ntes+tt+t=testtt\r\n" == result, "Matching should have 2 matching result");

            _matchWordsService.AddWord("te");
            _matchWordsService.AddWord("s");
            result = _matchWordsService.GetMatchWords(4);
            Assert.True("te+s+t+tt=testtt\r\nte+s+tt+t=testtt\r\ntes+t+t+t=testtt\r\n" == result, "Matching should have 3 matching result");

            result = _matchWordsService.GetMatchWords(5);
            Assert.True("te+s+t+t+t=testtt\r\n" == result, "Matching should have 1 matching result");

            _matchWordsService.AddWord("e");
            result = _matchWordsService.GetMatchWords(6);
            Assert.True("t+e+s+t+t+t=testtt\r\n" == result, "Matching should have 1 matching result");

            _matchWordsService.AddWord("ttt");
            result = _matchWordsService.GetMatchWords(2);
            Assert.True("tes+ttt=testtt\r\n" == result, "Matching should have 1 matching result");
        }
    }
}
