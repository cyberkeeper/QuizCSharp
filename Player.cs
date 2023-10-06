using Useful;

namespace Quiz
{
    /// <summary>
    /// Player class keeps track of the name and scores of the player playing the quiz.
    /// </summary>
    public class Player : Person
    {
        private Stack<int> previousScores = new Stack<int>();

        /// <summary>
        /// Simple constructor takes first name and surname
        /// </summary>
        /// <param name="firstName">first name</param>
        /// <param name="surname">surname</param>
        public Player(string firstName, string surname) : base(firstName, surname) { }        

        /// <summary>
        /// Constructor which calls takes in the name and also a csv formatted string of previous scores. If there is a
        /// problem with the scores format then the stack will be populated with valid values.Badly formatted or wrong
        /// data types will be ignored.
        /// </summary>
        /// <param name="firstName">first name</param>
        /// <param name="surname">surname</param>
        /// <param name="scores">a string of integer scores separated by ; characters</param>
        public Player(string firstName, string surname, string scores) : base(firstName, surname)
        {
            string[] cvsScores = scores.Split(';');
            foreach (string score in cvsScores)
            {
                try
                {
                    int iVal = int.Parse(score);
                    previousScores.Push(iVal);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Problem parsing previous score information.");
                }
            }

        }

        /// <summary>
        /// Record the latest result.
        /// </summary>
        /// <param name="score">what the last score was</param>
        public void RecordScore(int score)
        {
            previousScores.Push(score);
        }

        /// <summary>
        /// Return what the last recorded score was. Returns 0 if there have been no scores recorded.
        /// Uses Peek so that nothing is removed from the stack.
        /// </summary>
        /// <returns></returns>
        public int GetLastScore()
        {
            if (previousScores.Count > 0)
            {
                return previousScores.Peek();
            }
            else
            {
                return 0;
            }

        }

        /// <summary>
        /// Return the highest recorded score. Checks the number of elements is greater than 0.
        /// </summary>
        /// <returns>The highest score achieved or 0.</returns>
        public int GetHighestScore()
        {
            if (previousScores.Count > 0)
            {
                int maxValue = previousScores.Max();
                return maxValue;
            }
            else
                return 0;
        }

        /// <summary>
        /// Returns player details and previous scores.
        /// </summary>
        /// <returns></returns>
        public override string? ToString()
        {
            string scores = string.Empty;

            if (previousScores.Count > 0)
            {
                foreach (int score in previousScores)
                {
                    scores = score + ", " + scores;
                }
                
                scores = scores.Substring(0, scores.Length - 2);
            }
            scores = "[" + scores + "]";
            
            return "Player: " + base.ToString() + " previousScores=" + scores;
        }
    }
}
