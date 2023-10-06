namespace Quiz
{
    /// <summary>
    /// Class which defines a textual question. This is the base class for all question types.
    /// </summary>
    internal abstract class Question
    {
        private readonly string _quest = string.Empty;

        private readonly string _answer = string.Empty;

        private int _points = 0;

        /// <summary>
        /// Use this to set up the instance of a question. This is the only way to set the question and the
        /// answer. Makes the answer lowercase for ease of checking.
        /// </summary>
        /// <param name="question"></param>
        /// <param name="answer"></param>
        protected Question(string question, string answer)
        {
            _quest = question;
            _answer = answer.ToLower();
        }

        /// <summary>
        /// Use this to set up the instance of a question. This is the only way to set the question and the
        /// answer. Makes the answer lowercase for ease of checking. Allows setting of points.
        /// </summary>
        /// <param name="question"></param>
        /// <param name="answer"></param>
        /// <param name="points"></param>
        protected Question(string question, string answer, int points) : this(question, answer)
        {
            _points = points;
        }

        /// <summary>
        /// Gets the question.
        /// </summary>
        virtual public string Quest { get => _quest + "?"; }

        /// <summary>
        /// Gets the answer.
        /// </summary>
        public string Answer { get => _answer; }

        /// <summary>
        /// Get the number of points allocated to this question.
        /// </summary>
        public int Points { get => _points; }

        /// <summary>
        /// Check if the supplied answer is the correct answer. Makes the supplied answer lowercase for checking.
        /// </summary>
        /// <param name="userSays">What ever the user answered in response to the question</param>
        /// <returns>True is the user answered correctly, else returns false</returns>
        virtual public bool IsCorrect(string userSays)
        {
            //check that some sort of answer was supplied, some text changed
            if (userSays != null && userSays.Length > 0)
            {
                //make user's answer lowercase and compare with the correct answer
                userSays = userSays.ToLower();
                if (userSays.Equals(Answer))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Return the question, answer and points value.
        /// </summary>
        /// <returns>Formatted string for debug purposes.</returns>
        public override string? ToString()
        {
            return "Question{" +
                    "question='" + Quest + '\'' +
                    ", answer='" + Answer + '\'' +
                    ", points=" + Points +
                    '}';
        }

        /// <summary>
        /// This will shuffle the contents of a list. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void Shuffle<T>(List<T> list)
        {
            Random random = new Random();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                int j = random.Next(i + 1);
                T temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
    }
}
