using System;
using MyQuizApp.Models;
using MyQuizApp.Services;

namespace MyQuizApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Fetch the array of Questionnaire Object 
            Questionnaire[] debate = QuizQuestions.GetQuizQuestions();

            //Initializing  and kickstarting our quiz class by creating its object. See Quiz Class 
            Quiz ElementaryQuiz = new Quiz(debate);

            ElementaryQuiz.StartQuiz();
            Console.ReadKey();
        }
    }
}
