using Quiz;

namespace Quiz
{
    /// <summary>
    /// Text question class. Has the same functionality as the Question class but was added to 
    /// make the structure of the code better. 
    /// </summary>
    internal class TextQuestion : Question
    {
        /// <summary>
        /// Constructor. Use this to set up the instance of a question. This is the only way to set the question and 
        /// the answer.Makes the answer lowercase for ease of checking.
        /// </summary>
        /// <param name="question">A text based question</param>
        /// <param name="answer">A text based answer</param>
        /// <param name="points">The number of points if the question is answered correctly</param>
        public TextQuestion(string question, string answer, int points) : base(question, answer, points)
        {
        }
    }
}
