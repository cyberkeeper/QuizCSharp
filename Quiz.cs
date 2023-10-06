using System;
using System.Collections;
using System.Linq;
using Useful;
using static System.Formats.Asn1.AsnWriter;

namespace Quiz
{
    /// <summary>
    /// Quiz program. Asks the user for their name, asks questions and then displays the total 
    /// score to the user.Questions can be of variety of types all of which are child classes of 
    /// Question class. The questions are loaded in from a csv file but code is present to allow
    /// connection to a MySQL database, this database access functionality is commented out by
    /// default but can be enabled when required.
    /// </summary>
    internal class Quiz
    {
        protected string DEFAULT_NAME = "Anon";

        protected string InputFilename = "./resources/scot-questions.csv";

        private int _maxPossibleScore = 0;

        /// <summary>
        /// Questions for the quiz will be held here.
        /// </summary>
        public List<Question> quizQuestions = new List<Question>();

        /// <summary>
        /// Constructor for the quiz. Set up the quiz. Create the instances of the questions. All
        /// question information is read in either from the csv file or database.
        /// </summary>
        public Quiz()
        {
            try
            {
                quizQuestions = LoadAndParseDataFromFile();

            }
            catch (Exception e)
            {
                Console.WriteLine("Aborting program!");
                Console.WriteLine("Exception thrown" + e.Message);
                //Show an exit code to indicate an error
                Environment.Exit(1);
            }
        }

        /// <summary>
        /// Open file. read all rows, parse into question objects and close file
        /// </summary>
        /// <returns></returns>
        private List<Question> LoadAndParseDataFromFile()
        {
            List<string> rows = UsefulFileAccess.ReadFromFile(InputFilename);
            List<Question> localQuestions = new List<Question>();

            //for each element in the arraylist split it into name and rating. Count those with a rating >= RATING_LIMIT
            foreach (String row in rows)
            {
                String[] details = row.Split(",");
                int typeOfQ = int.Parse(details[0]);
                int points = int.Parse(details[3]);

                switch (typeOfQ)
                {
                    case 1:
                        //text question                      
                        Question newQ = new TextQuestion(details[1], details[2], points);
                        localQuestions.Add(newQ);
                        break;
                    case 2:
                        //true/false question
                        bool answer = bool.Parse(details[2]);
                        Question newTF = new TrueFalseQuestion(details[1], answer);
                        localQuestions.Add(newTF);
                        break;
                    case 3:
                        string[] choices = details[4].Split(";");                        
                        Question newMC = new MultipleChoiceQuestion(details[1], details[2], choices, points);
                        localQuestions.Add(newMC);
                        break;
                    default:
                        Console.WriteLine("Question type not recognised.");
                        break;
                }
            }


            return localQuestions;
        }

        private List<Question> LoadAndParseDataFromDatabase()
        {
            List<Question> localQuestions = new List<Question>();
            return localQuestions;
        }

        /// <summary>
        ///  Start the quiz. Gets the username, asks the questions and keeps track of the current score and
        ///  maximum possible score.The loop to ask if the user wants to play again is here.The player
        ///  is asked if they are the same player retrying or if it is a different player attempting the quiz.
        /// </summary>
        public void Start()
        {
            bool firstRun = true;
            bool runAgain = true;

            Player livePlayer = new Player(GetUserDetails(), "");

            while (runAgain)
            {
                //check if rerunning the quiz or it is the first run
                if (firstRun)
                {
                    //running the quiz for the first time for this user
                    Console.WriteLine(String.Format("Welcome {0} to the quiz of the century!", livePlayer.FirstName));
                }
                else
                {
                    //running the quiz for another attempt
                    bool who = YesNoUserResponse(String.Format("Is {0} still playing?", livePlayer.FirstName));
                    if (who)
                    {
                        Console.WriteLine("Try and beat your previous score");
                    }
                    else
                    {
                        livePlayer = new Player(GetUserDetails(), "");
                        Console.WriteLine(String.Format("Welcome {0} to the quiz of the century!", livePlayer.FirstName));
                    }
                }
                // shuffle the questions before asking and reset the max possible score
                // Shuffle the list using the Fisher-Yates algorithm.
                Question.Shuffle(quizQuestions);
                _maxPossibleScore = 0;

                //ask the questions and keep track of the score
                int total = 0;
                for (int i = 0; i < quizQuestions.Count; i++)
                {
                    Console.Write("Q"+ (i + 1) + ": ");
                    total = total + AskQuestion(quizQuestions[i]);
                    Console.WriteLine();
                }

                //record latest score and print results
                livePlayer.RecordScore(total);                
                Console.WriteLine(String.Format("{0} you scored {1}/{2}", livePlayer.FirstName, livePlayer.GetLastScore(), _maxPossibleScore));

                //write results to file.
                // do you want to rerun?
                runAgain = YesNoUserResponse("Do you want to rerun the quiz?");
                firstRun = false;

                //print out all the results from the quiz
                Console.WriteLine("Thank you for playing " + livePlayer.FirstName);
                Console.WriteLine("Your last score: " + livePlayer.GetLastScore());
                Console.WriteLine("Your best score: " + livePlayer.GetHighestScore());
            }
        }

        /// <summary>
        /// The details of the person playing the quiz. If no name is supplied the detault name is used.
        /// </summary>
        /// <returns>The name of the player or the default name.</returns>
        private string GetUserDetails()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();

            if (String.IsNullOrEmpty(name))
            {
                name = DEFAULT_NAME;
            }
            return name;
        }

        /// <summary>
        /// Ask the user to respond to a question that will have a yes or no answer. If nothing is entered or 
        /// if the response starts with y or Y then it is assumed the player entered a positive response. Anything 
        /// not starting with a y is deemed to be a negative answer.
        /// </summary>
        /// <param name="query">A question that the user will answer yes or no to.</param>
        /// <returns> True to if response was yes, Yes, y or Y, false for anything else.</returns>
        private bool YesNoUserResponse(string query)
        {
            Console.WriteLine(query + "\n(yes/no)");
            string response = Console.ReadLine();

            if (!String.IsNullOrEmpty(response))
            {
                response = response.ToLower();
                return response.StartsWith("y");
            }
            return false;
        }

        /// <summary>
        /// Ask the user a question. Check the answer.
        /// </summary>
        /// <param name="q">Instance of the Question class. This contains the question and the correct answer</param>
        /// <returns>Integer value of 1 for correct answer else 0 for wrong answer.</returns>
        public int AskQuestion(Question q)
        {
            int score = 0;

            Console.WriteLine(q.Quest);

            //get the user input. 
            string? answer = Console.ReadLine();

            _maxPossibleScore = _maxPossibleScore + q.Points;

            if (String.IsNullOrEmpty(answer))
            {
                Console.WriteLine("No answer supplied. 0 points");
            }
            else
            {
                if (q.IsCorrect(answer))
                {
                    Console.WriteLine(answer + " is the correct answer. " + q.Points + " points.");
                    score = q.Points;
                }
                else
                {
                    Console.WriteLine(answer + " is the wrong answer. 0 points.");
                }
            }
            return score;
        }
    }
}
