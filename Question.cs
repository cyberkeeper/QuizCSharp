using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    /// <summary>
    /// Class which defines a textual question. This is the base class for all question types.
    /// </summary>
    public abstract class Question
    {
        private string _question = string.Empty;

        private string _answer = string.Empty;

        private int _points = 0;

        /// <summary>
        /// Use this to set up the instance of a question. This is the only way to set the question and the
        /// answer. Makes the answer lowercase for ease of checking.
        /// </summary>
        /// <param name="question"></param>
        /// <param name="answer"></param>
        protected Question(string question, string answer)
        {
            _question = question;
            _answer = answer.ToLower();
        }

        /// <summary>
        /// Use this to set up the instance of a question. This is the only way to set the question and the
        /// answer. Makes the answer lowercase for ease of checking. Allows setting of points.
        /// </summary>
        /// <param name="question"></param>
        /// <param name="answer"></param>
        /// <param name="points"></param>
        protected Question(string question, string answer, int points) : this (question, answer)
        {            
            _points = points;
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
