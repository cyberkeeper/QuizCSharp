using Quiz;
using System.Transactions;

namespace Quiz
{
    /// <summary>
    /// Class which defines a true or false question. By default, all this type of question is worth 1 point.
    /// </summary>
    internal class TrueFalseQuestion : Question
    {
        /// <summary>
        /// Constructor calls the super class construction with a score of 1 points.
        /// </summary>
        /// <param name="question">The question to answer</param>
        /// <param name="answer">The answer expected to be true or false</param>
        public TrueFalseQuestion(string question, bool answer) : base(question, answer.ToString(), 1)
        {
        }

        /// <summary>
        /// Returns the question for this instance.
        /// </summary>
        /// <returns>The question to be asked with a prompt for true/false.</returns>
        public string GetQuestion()
        {
            return base.Quest + "\n(Answer true or false)";
        }
    }
}
