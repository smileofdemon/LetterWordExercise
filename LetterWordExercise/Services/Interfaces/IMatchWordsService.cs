namespace LetterWordExercise.Services.Interfaces
{
    public interface IMatchWordsService
    {
        /// <summary>
        /// Get matched words
        /// </summary>
        /// <param name="count">count of short words in large word</param>
        /// <returns>matched words line by line</returns>
        public string GetMatchWords(int count);
        /// <summary>
        /// Add word to service
        /// </summary>
        /// <param name="word"></param>
        public void AddWord(string word);
    }
}
