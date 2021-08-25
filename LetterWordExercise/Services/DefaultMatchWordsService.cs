using LetterWordExercise.Services.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace LetterWordExercise.Services
{
    public class DefaultMatchWordsService : IMatchWordsService
    {
        private const short LARGE_WORDS_LENGTH = 6;

        private readonly HashSet<string> _collection = new HashSet<string>();
        private readonly HashSet<string> _largeWords = new HashSet<string>();

        public void AddWord(string word)
        {
            if (word.Length == LARGE_WORDS_LENGTH)
            {
                _largeWords.Add(word);
            }
            else
            {
                _collection.Add(word);
            }
        }

        public string GetMatchWords(int count)
        {
            if (count > LARGE_WORDS_LENGTH)
            {
                return "";
            }

            return GetMatchedWords().ToString();
        }

        private StringBuilder GetMatchedWords()
        {
            StringBuilder result = new StringBuilder("");
            foreach (var word in _largeWords)
            {
                for (int i = 1; i < word.Length; i++)
                {
                    var firstPart = word.Substring(0, i);
                    var lastPart = word.Substring(firstPart.Length);
                    if (_collection.Contains(firstPart) && _collection.Contains(lastPart))
                    {
                        result.AppendLine($"{firstPart}+{lastPart}={word}");
                    }
                }
            }

            return result;
        }
    }
}
