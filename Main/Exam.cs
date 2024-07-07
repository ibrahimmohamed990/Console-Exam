using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Exam
    {
        public int ExamTime { get; set; }
        public int NumberOfQuestions { get; set; }
        public Subject ExamSubject { get; set; }
        public int result = 0;
        public TimeSpan elapsedExamTime;
        public bool flag;
        public int StudentAnswer;
        public Dictionary<int, int> AnswersMarks;
        
        public Exam(int examTime, int numberOfQuestions, Subject subject)
        {
            ExamTime = examTime;
            NumberOfQuestions = numberOfQuestions;
            ExamSubject = subject;
            AnswersMarks = new Dictionary<int, int>();
        }
        public Exam()
        {
            AnswersMarks = new Dictionary<int, int>();
        }
        public virtual void ShowExam()
        {
            Console.WriteLine($"Time of Exam: {ExamTime}\n" +
                              $"Number of Questions: {NumberOfQuestions}\n" +
                              $"Subject Id: {ExamSubject.SubjectId}\n" +
                              $"Subject Name: {ExamSubject.SubjectName}");
        }
        public void ShowQuestionsForExam(int i)
        {
            Console.WriteLine($"Question {i + 1} Header : {ExamSubject.QuestionsSubject[i].Header}");
            Console.WriteLine($"Question {i + 1} Body : {ExamSubject.QuestionsSubject[i].Body}");
            Console.WriteLine();
            foreach (var answer in ExamSubject.QuestionsSubject[i].AnswerList)
                Console.WriteLine($"{answer}");
            Console.WriteLine($"Correct Answer : {ExamSubject.QuestionsSubject[i].CorrectAnswer}\n");
        }
        public void PrintExamBasedOnType(int i)
        {
            ExamSubject.QuestionsSubject[i].ShowQuestion();

            if (ExamSubject.QuestionsSubject[i] is TrueOrFalseQ)
            {
                do
                {
                    Console.Write("Enter your answer: ");
                    flag = int.TryParse(Console.ReadLine(), out StudentAnswer);
                } while (!flag || (StudentAnswer != 1 && StudentAnswer != 2));
            }
            else if (ExamSubject.QuestionsSubject[i] is MCQQ)
            {
                do
                {
                    Console.Write("Enter your answer: ");
                    flag = int.TryParse(Console.ReadLine(), out StudentAnswer);
                } while (!flag || (StudentAnswer < 1 || StudentAnswer > 3));
            }

            if (StudentAnswer == ExamSubject.QuestionsSubject[i].CorrectAnswer)
                AnswersMarks[i] = ExamSubject.QuestionsSubject[i].Mark;
            //result += ExamSubject.QuestionsSubject[i].Mark;
        }
        public void UpdateAnswer()
        {
            char c;
            while (true)
            {
                do
                {
                    Console.Write($"Are you want to update any answer of any question? (y | n): ");
                    flag = char.TryParse(Console.ReadLine(), out c);
                } while (!flag || !(c == 'y' || c == 'n'));
                if (c == 'y')
                {
                    Console.Clear();
                    int n;
                    do
                    {
                        Console.Write($"Enter Number of Question yoy want to update: (from 1 to {NumberOfQuestions}): ");
                        flag = int.TryParse(Console.ReadLine(), out n);

                    } while (!flag || !(n <= NumberOfQuestions && n >= 1));
                    ExamSubject.QuestionsSubject[n - 1].ShowQuestion();
                    if (ExamSubject.QuestionsSubject[n - 1] is TrueOrFalseQ)
                    {
                        do
                        {
                            Console.Write("Enter your updated answer: ");
                            flag = int.TryParse(Console.ReadLine(), out StudentAnswer);
                        } while (!flag || (StudentAnswer != 1 && StudentAnswer != 2));
                    }
                    else if (ExamSubject.QuestionsSubject[n - 1] is MCQQ)
                    {
                        do
                        {
                            Console.Write("Enter your updated answer: ");
                            flag = int.TryParse(Console.ReadLine(), out StudentAnswer);
                        } while (!flag || (StudentAnswer < 1 || StudentAnswer > 3));
                    }
                    if (StudentAnswer == ExamSubject.QuestionsSubject[n - 1].CorrectAnswer)
                        AnswersMarks[n - 1] = ExamSubject.QuestionsSubject[n - 1].Mark;
                    else
                        AnswersMarks[n - 1] = 0;
                }
                else
                    break;
            }
        }

    }
}
