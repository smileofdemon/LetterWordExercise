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

            StringBuilder result = new StringBuilder("");
            foreach (var word in _largeWords)
            {
                result.Append(Match("", word, word, count));
            }

            return result.ToString();
        }

        private StringBuilder Match(string line, string word, string targetWord, int count)
        {
            count--;
            StringBuilder result = new StringBuilder("");
            for (int i = 1; i < word.Length; i++)
            {
                var firstPart = word.Substring(0, i);
                var lastPart = word.Substring(firstPart.Length);
                if (_collection.Contains(firstPart))
                {
                    if (count > 1)
                    {
                        result.Append(Match($"{line}{firstPart}+", lastPart, targetWord, count));
                    }
                    else
                    {
                        if (_collection.Contains(lastPart))
                        {
                            result.AppendLine($"{line}{firstPart}+{lastPart}={targetWord}");
                        }
                    }
                }
            }

            return result;
        }
    }
}
