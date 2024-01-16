﻿namespace PrincessBrideTrivia;

public class Program
{
    public static void Main(string[] args)
    {
        string filePath = GetFilePath();
        Question[] questions = LoadQuestions(filePath);

        int numberCorrect = 0;
        for (int i = 0; i < questions.Length; i++)
        {
            bool result = AskQuestion(questions[i]);
            if (result)
            {
                numberCorrect++;
            }
        }
        Console.WriteLine("You got " + GetPercentCorrect(numberCorrect, questions.Length) + " correct");
    }

    public static string GetPercentCorrect(int numberCorrectAnswers, int numberOfQuestions)
    {
        double correctCalc = ((double)numberCorrectAnswers / (double)numberOfQuestions * 100);
        if (correctCalc > 0)
        {
            return correctCalc.ToString("##.#") + "%";
        }
        return correctCalc + "%";
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

    //public static bool AreYouSure(String answer)
    //{
    //    Console.WriteLine("Are you sure about your answer? Y OR N");
    //    if(Console.ReadLine() == "Y")
    //    {
    //        return true;
    //    }
    //    return false;
    //}
    public static bool DisplayResult(string userGuess, Question question)
    {
        //if(AreYouSure(userGuess) == false)
        //{
        //    Console.WriteLine("Choose Again: ");
        //    userGuess = Console.ReadLine();
        //}
        if (userGuess == question.CorrectAnswerIndex)
        {
            Console.WriteLine("Correct\n");
            return true;
        }

        Console.WriteLine("Incorrect\n");
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

    public static string GetFilePath()
    {
        return "Trivia.txt";
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
            questions[i] = question;
        }
        return questions;
    }
}
