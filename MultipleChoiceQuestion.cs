using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization;

namespace Quiz
{
    /// <summary>
    /// Class which defines a multiple-choice question. The question is flexible and can a variety of different
    /// answers that the player can select from.The player selects their answer by entering the number associated 
    /// with the answer they wish to submit.The options are shuffled when the question is created.
    /// </summary>
    internal class MultipleChoiceQuestion : Question
    {
        /// <summary>
        /// Contains the correct answer and the wrong answers
        /// </summary>
        protected List<string> options = new List<string>();

        private int _correctIndex;

        public MultipleChoiceQuestion(string question, string answer, string[] wrongOptions, int points) : base(question, answer, points)
        {
            //populate list with all options and the correct answer, then randomise the list
            foreach (string option in wrongOptions)
            {
                options.Add(option);
            }
            options.Add(answer);
            Shuffle(options);

            //find index of correct answer and store for later
            _correctIndex = options.IndexOf(answer);
        }

        /// <summary>
        /// Returns the question for this instance.
        /// </summary>
        /// <returns>Question to be asked.</returns>
        protected string GetQuestion()
        {
            string output = base.Quest + "\n";

            //build up the options the user can pick from, allows multiple choice questions with more or less options.
            string userOptions = "(Answer ";

            //add on each option prefixed by a number
            for (int i = 0; i < options.Count; i++)
            {
                output += (i + 1) + ":" + options[i] + "\n";
                userOptions += (i + 1) + ",";
            }

            //finish up the user options, remove last comma and add closing bracket
            userOptions.Substring(0, userOptions.Length - 2);

            return output += userOptions;
        }

        /// <summary>
        /// Check if the supplied answer is the correct answer. Makes the supplied answer lowercase for checking.
        /// </summary>
        /// <param name="userSays">What ever the user answered in response to the question.</param>
        /// <returns> True is the user answered correctly, else returns false.</returns>
        override public bool IsCorrect(string userSays)
        {
            bool isCorrect = false;
            try
            {
                //change user answer to int and subtract 1 an index starts at zero.
                int userIndex = int.Parse(userSays) - 1;
                if (_correctIndex == userIndex)
                {
                    isCorrect = true;
                }
            }
            catch (Exception ex)
            {
                isCorrect = false;
            }
            return isCorrect;
        }

        public override string? ToString()
        {
            return "MultipleChoiceQuestion{" +
                base.ToString() +
                "options=" + options +
                "correct index=" + _correctIndex + "}";
        }
    }
}
