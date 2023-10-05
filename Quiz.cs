using System.Collections;

namespace Quiz
{
    internal class Quiz
    {
        protected string DEFAULT_NAME = "Anon";

        protected string inputFilename = "/resources/scot-questions.csv";

        private int maxPossibleScore = 0;

        /// <summary>
        /// Questions for the quiz will be held here.
        /// </summary>
        public ArrayList quizQuestions = new ArrayList();

        /// <summary>
        /// Constructor for the quiz. Set up the quiz. Create the instances of the questions. All
        /// question information is read in either from the csv file or database.
        /// </summary>
        public Quiz()
        {
            try
            {
                quizQuestions = loadAndParseDataFromFile();

            }
            catch (Exception e)
            {
                Console.WriteLine("Aborting program!");
                Console.WriteLine("Exception thrown" + e.Message);
                //Show an exit code to indicate an error
            }
        }


        private ArrayList loadAndParseDataFromFile()
        {
            ArrayList localQuestions = new ArrayList();
            return localQuestions;
        }

        private ArrayList LoadAndParseDataFromDatabase()
        {
            ArrayList localQuestions = new ArrayList();
            return localQuestions;
        }
    }
}
