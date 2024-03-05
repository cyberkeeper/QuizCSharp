namespace Quiz
{
    /// <summary>
    /// Class which defines a true or false question. By default, all this type of question is worth 1 point.
    /// </summary>
    class TrueFalseQuestion : Question
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
        /// Override the Property that returns the question to make it specific for this type of class.
        /// </summary>
        public override string Quest
        {
            get
            {
                return base.Quest + "\n(Answer true or false)";
            }
        }
    }
}
