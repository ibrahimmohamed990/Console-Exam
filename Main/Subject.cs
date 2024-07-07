using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Main
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public List<Question> QuestionsSubject { get; set; }
        public Exam Exam { get; set; }
        private bool flag = false;
        private int examType, numberOfQuestions, examTime, mark, answer, QType;
        private string body, temp;
        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
            QuestionsSubject = new List<Question>();
        }
        public void CreateExam()
        {
            Console.Clear();
            // 1 means Practical , 2 means Final
            do
            {
                Console.Write("Please Enter The Type of Exam You Want to Create: [1 for Practical and 2 for Final]: ");
                flag = int.TryParse(Console.ReadLine() , out examType);
            } while (!flag || !(examType == 1 || examType == 2));
            Console.WriteLine();
            do
            {
                Console.Write("Please Enter The Time of Exam in Minutes: ");
                flag = int.TryParse(Console.ReadLine(), out examTime);
            } while (!flag || examTime <= 0);
            Console.WriteLine();
            do
            {
                Console.Write("Please Enter The Number of Questions You Want to Create: ");
                flag = int.TryParse(Console.ReadLine(), out numberOfQuestions);
            } while (!flag || numberOfQuestions <= 0);
            Console.WriteLine();

            for(int i = 0; i < numberOfQuestions; ++i)
            {
                Console.Clear();
                if (examType == 1) // Practical Exam 
                {
                    InputBody(i);
                    Console.WriteLine();
                    InputMark(i);
                    string header = "MCQ Question";
                    Answer[] answers = new Answer[3];
                    Console.WriteLine($"The Choises of Question {i+1}: ");
                    for (int x = 1; x <= 3; ++x)
                    {
                        InputChoises(x);
                        answers[x - 1] = new Answer(x, temp);
                    }
                    Console.WriteLine();
                    InputCorrectAnswerForMCQ("Choose 1 , 2 or 3");
                    QuestionsSubject.Add(new MCQQ(header, body, mark, answers, answer));
                    Exam = new PracticalExam(examTime , numberOfQuestions , this);
                }
                else if (examType == 2) // Final Exam >> has two type of questions.[True or False , MCQ]
                {
                    do
                    {
                        Console.Write($"Please Enter The Type of Question {i+1} (1 for True or False || 2 for MCQ): ");
                        flag = int.TryParse(Console.ReadLine(), out QType);
                    } while (!flag || !(QType == 1 || QType == 2));
                    Console.WriteLine();

                    InputBody(i);
                    InputMark(i);

                    if (QType == 1) // True of False
                    {
                        InputCorrectAnswerForTrueOrFalse("Choose 1 for True or 2 for False");
                        string header = "True or False Question.";
                        Answer[] answers = new Answer[2];
                        answers[0] = new Answer(1, "True");
                        answers[1] = new Answer(2, "False");

                        QuestionsSubject.Add(new TrueOrFalseQ(header, body, mark, answers, answer));
                    }
                    else if (QType== 2) // MCQ
                    {
                        string header = "MCQ Question.";
                        Answer[] answers = new Answer[3];
                        Console.WriteLine("The Choises of Question: ");
                        for (int x = 1; x <= 3; ++x)
                        {
                            InputChoises(x);
                            answers[x - 1] = new Answer(x, temp);
                        }
                        InputCorrectAnswerForMCQ("Choose 1 , 2 or 3");
                        QuestionsSubject.Add(new MCQQ(header, body, mark, answers, answer));
                    }
                    Exam = new FinalExam(examTime, numberOfQuestions, this);
                }
            }            
        }

        public void InputBody(int i)
        {
            do
            {
                Console.Write($"Please Enter the Body of Question {i + 1}: ");
                body = Console.ReadLine() ?? string.Empty;
            } while (string.IsNullOrEmpty(body) || string.IsNullOrWhiteSpace(body));
        }
        public void InputMark(int i)
        {
            do
            {
                Console.Write($"Please Enter the mark of Question {i + 1}: ");
                flag = int.TryParse(Console.ReadLine(), out mark);
                //if(mark <= 0 && flag == true) flag = false;
            } while (!flag || mark <= 0);
        }
        public void InputChoises(int i)
        {
            do
            {
                Console.Write($"Please Enter the choise Number {i}: ");
                temp = Console.ReadLine() ?? string.Empty;
            } while (string.IsNullOrEmpty(temp) || string.IsNullOrWhiteSpace(temp));
        }
        public void InputCorrectAnswerForTrueOrFalse(string print)
        {
            do
            {
                Console.Write($"Please Enter the right answer of this Question: [{print}]:");
                flag = int.TryParse(Console.ReadLine(), out answer);
            } while (!flag || !(answer == 1 || answer == 2));
        }
        public void InputCorrectAnswerForMCQ(string print)
        {
            do
            {
                Console.Write($"Please Enter the right answer of this Question: [{print}]:");
                flag = int.TryParse(Console.ReadLine(), out answer);
            } while (!flag || !(answer >= 1 && answer <= 3));
        }
    }
}
