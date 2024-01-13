namespace PrincessBrideTrivia;

public class Program
{
    public static void Main(string[] args)
    {
        string questionsFilePath = GetQuestionsFilePath();
        Question[] questions = LoadQuestions(questionsFilePath);

        int numberCorrect = 0;
        for (int i = 0; i < questions.Length; i++)
        {
            bool result = AskQuestion(questions[i]);
            if (result)
            {
                numberCorrect++;
            }
        }
        string percentCorrect = GetPercentCorrect(numberCorrect, questions.Length);
        Console.WriteLine("You got " + percentCorrect + "% correct");

        string highPercentFilePath = GetHighestPercentFilePath();
        string highestPercent = GetHighestPercent(highPercentFilePath);
        int comparedPercent = PercentCompare(percentCorrect, highestPercent);
        if (comparedPercent > 0)
        {
            Console.WriteLine($"Congratulations! Your percentage score of {percentCorrect}% is the highest percent!");
        } else if (comparedPercent < 0)
        {
            Console.WriteLine($"You fell short of the highest percent scored. The highest percent scored is {highestPercent}%");
        } else
        {
            Console.WriteLine("Congratulations! You tied the highest percent!");
        }
        
    }

    public static string GetHighestPercent(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        decimal highPercent = decimal.Parse(lines[0].Trim());
        return Math.Ceiling(highPercent) + "";
    }

    public static int PercentCompare(string percentCorrect, string highestPercent)
    {
        int intPercentCorrect = int.Parse(percentCorrect);
        int intHighestPercent = int.Parse(highestPercent);
        if (intPercentCorrect > intHighestPercent) 
        { 
            return 1; 
        }
        else if (intPercentCorrect < intHighestPercent) 
        { 
            return -1;
        }
        else
        {
            return 0;
        }
    }

    public static string GetPercentCorrect(int numberCorrectAnswers, int numberOfQuestions)
    {
        decimal percentCorrect = (((decimal)numberCorrectAnswers / numberOfQuestions) * 100);
        return Math.Ceiling(percentCorrect) + "";
    }

    public static bool AskQuestion(Question question)
    {
        DisplayQuestion(question);

        string userGuess = GetGuessFromUser();
        return DisplayResult(userGuess, question);
    }

    public static string GetGuessFromUser()
    {
        return Console.ReadLine();
    }

    public static bool DisplayResult(string userGuess, Question question)
    {
        if (userGuess == question.CorrectAnswerIndex)
        {
            Console.WriteLine("Correct");
            return true;
        }

        Console.WriteLine("Incorrect");
        return false;
    }

    public static void DisplayQuestion(Question question)
    {
        Console.WriteLine("Question: " + question.Text);
        for (int i = 0; i < question.Answers.Length; i++)
        {
            Console.WriteLine((i + 1) + ": " + question.Answers[i]);
        }
    }

    public static string GetQuestionsFilePath()
    {
        return "Trivia.txt";
    }

    public static string GetHighestPercentFilePath()
    {
        return "HighScore.txt";
    }

    public static Question[] LoadQuestions(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);

        Question[] questions = new Question[lines.Length / 5];
        for (int i = 0; i < questions.Length; i++)
        {
            int lineIndex = i * 5;
            string questionText = lines[lineIndex];

            string answer1 = lines[lineIndex + 1];
            string answer2 = lines[lineIndex + 2];
            string answer3 = lines[lineIndex + 3];

            string correctAnswerIndex = lines[lineIndex + 4];

            Question question = new();
            question.Text = questionText;
            question.Answers = new string[3];
            question.Answers[0] = answer1;
            question.Answers[1] = answer2;
            question.Answers[2] = answer3;
            question.CorrectAnswerIndex = correctAnswerIndex;

            //new line
            questions[i] = question;
        }
        return questions;
    }
}
