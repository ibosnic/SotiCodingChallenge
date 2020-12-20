
namespace SotiChallengeApp
{
    /// <summary>
    /// Interface for implenting a spell checker 
    /// </summary>
    public interface ISpellChecker
    {
        /// <summary>
        /// Checkd whether the word is spelled correctly. 
        /// </summary>
        /// <param name="word">the word to check</param>
        bool IsWordSpelledCorrectly(string word);
    }
}
