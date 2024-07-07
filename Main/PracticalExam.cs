using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class PracticalExam : Exam
    {
        public PracticalExam(int examTime, int numberOfQuestions, Subject subject)
            : base(examTime, numberOfQuestions, subject) { }
        public override void ShowExam()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StartExam();
            elapsedExamTime = TimeSpan.FromMinutes(ExamTime);
            if (sw.ElapsedMilliseconds <= elapsedExamTime.TotalMilliseconds)
            {
                Console.Clear();
                base.ShowExam();
                Console.WriteLine("Questions and Answers for the Practical Exam.");
                for (int i = 0; i < NumberOfQuestions; i++)
                    ShowQuestionsForExam(i);
                
                result = AnswersMarks.Values.Sum();

                //foreach (var kvp in AnswersMarks)
                //    Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");

                Console.WriteLine("\n===================\n");
                Console.WriteLine($"Total Marks: {result}");
                Console.WriteLine("\n===================\n");
            }
            else
                Console.WriteLine("Time of Exam is out, Try again Later.");
        }
        public void StartExam()
        {
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.Clear();
                Console.WriteLine($"Question {i + 1}");
                PrintExamBasedOnType(i);
                Console.WriteLine();
            }
            UpdateAnswer();
        }
    }
}
