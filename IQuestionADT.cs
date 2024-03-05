using System;

namespace Quiz
{
    /// <summary>
    /// Interface for Question, any class that wants to work as a question needs to implement this interface.
    /// </summary>
    internal interface IQuestionADT
    {
        /// <summary>
        /// Gets the question.
        /// </summary>
        public string Quest { get; }

        /// <summary>
        /// Gets the answer.
        /// </summary>
        public string Answer { get; }

        /// <summary>
        /// Get the number of points allocated to this question.
        /// </summary>
        public int Points { get; }

        /// <summary>
        /// Check if the supplied answer is the correct answer. Makes the supplied answer lowercase for checking.
        /// </summary>
        /// <param name="userSays">What ever the user answered in response to the question</param>
        /// <returns>True is the user answered correctly, else returns false</returns>
        public bool IsCorrect(string userSays);

    }
}