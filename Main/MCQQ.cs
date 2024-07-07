using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class MCQQ : Question
    {
        public MCQQ(string header, string body, int mark, Answer[] answerList, int correctAnswer)
            : base(header, body, mark, answerList, correctAnswer)
        {

        }
    }
}
