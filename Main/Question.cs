using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }   
        public Answer[] AnswerList { get; set; }
        public int CorrectAnswer { get; set; }

        public Question(string header, string body, int mark, Answer[] answerList, int correctAnswer)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answerList;
            CorrectAnswer = correctAnswer;
        }
        public override string ToString()
        {
            foreach(Answer answer in AnswerList)
                Console.WriteLine($"{Header}\t{Mark}\n{Body}\n{answer}");
            return "";
        }
        public void ShowQuestion()
        {
            Console.WriteLine($"{Body}");
            foreach(var ans in AnswerList)
                Console.WriteLine(ans);
        }

    }
}
