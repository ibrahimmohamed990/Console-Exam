using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class TrueOrFalseQ : Question
    {
        public TrueOrFalseQ(string header, string body, int mark, Answer[] answerList, int correctAnswer)
            : base(header, body, mark, answerList, correctAnswer) 
        {
            
        }

    }
}
