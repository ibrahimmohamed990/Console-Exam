using System.Diagnostics;

namespace Main
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool flag;
            char c;
            Subject subject = new Subject(1, "Math");
            subject.CreateExam();
            Console.Clear();
            do
            {
                Console.Write("Do you want to start the exam? (y | n)- ");
                flag = char.TryParse(Console.ReadLine(), out c);
                c = char.ToLower(c);
            } while (!flag || (c != 'y' && c != 'n'));
            if (char.ToLower(c) == 'y' && flag)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                subject.Exam.ShowExam();
                Console.WriteLine($"The Elapsed Time = {sw.Elapsed}");
            }
            while (flag)
            {
                do
                {
                    Console.Write("Do you want to Create another Exam? (y | n): ");
                    flag = char.TryParse(Console.ReadLine(), out c);
                    c = char.ToLower(c);
                } while (!flag || (c != 'y' && c != 'n'));
                if (char.ToLower(c) == 'y' && flag)
                {
                    subject.QuestionsSubject = new List<Question>();
                    subject.CreateExam();
                }
                do
                {
                    Console.Write("Do You want to Start Exam again? (y | n): ");
                    flag = char.TryParse(Console.ReadLine(), out c);
                    c = char.ToLower(c);
                } while (!flag || (c != 'y' && c != 'n'));
                if (char.ToLower(c) == 'y' && flag)
                {
                    Stopwatch sw = new Stopwatch();
                    //subject.Exam.AnswersMarks = new Dictionary<int, int>();
                    subject.Exam = new Exam();
                    sw.Start();
                    subject.Exam.ShowExam();
                    Console.WriteLine($"The Elapsed Time = {sw.Elapsed}");
                }
                else if (char.ToLower(c) == 'n')
                    break;
            }
        }
    }
}
