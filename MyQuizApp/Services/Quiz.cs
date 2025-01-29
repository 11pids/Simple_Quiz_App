using System;
using System.Reflection;
using MyQuizApp.Models;

namespace MyQuizApp.Services
{
    internal class Quiz
    {
        public Questionnaire[] _question;
        private int _score;
        private int _questionNumber = 1;
        private int[] _userAnswers;

        public Quiz(Questionnaire[] question)
        {
            _score = 0;
            this._question = question;
            this._userAnswers = new int[question.Length];
        }

        public void StartQuiz()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("===================");
            Console.WriteLine(" QUIZ STARTS NOW!  ");
            Console.WriteLine("===================");
            Console.WriteLine("\n");
            Console.ResetColor();

            int index = 0;

            foreach (Questionnaire quest in _question)
            {
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{_questionNumber}. ");
                Console.ResetColor();
                DisplayQuestion(quest);
                int userOption = GetUserOption();
                //Checking for what the user entered
                _userAnswers[index] = userOption;

                if(quest.CorrectAnswerIndex == userOption)
                {
                    _score++;

                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"You entered option {userOption + 1}");
                Console.ResetColor();

                _questionNumber++;
                index++;
            }
            DisplayResult();
            ShowCorrection();
        }

        //THis method displays strings from the question object hence it takes it as the param
        public void DisplayQuestion(Questionnaire q)
        {
            Console.WriteLine(q.QuestionText);
            for(int options = 0; options < q.Answers.Length; options++)
            {
                //Numbering the options
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write($"{options + 1}. ");
                Console.WriteLine($"{q.Answers[options]}");
                Console.ResetColor();
            }
        }

        public int GetUserOption()
        {
            string uInput = Console.ReadLine();
            int userI;
            while(!int.TryParse(uInput, out userI) || userI < 1 || userI > 4)
            {
                Console.WriteLine("Entry not acceptable, enter option from 1 to 4");
                uInput = Console.ReadLine();
            }
            return userI - 1; 
        }

        public void DisplayResult()
        {
            Console.WriteLine($"You got {_score} out of {_question.Length}");
        }

        public void ShowCorrection()
        {
            Console.WriteLine("\nTo view corrections for missed questions, press 1. Otherwise, press any key to exit.");
            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCorrections for missed questions:");
                Console.ResetColor();

                bool hasMistakes = false; // Check if there are mistakes
                int index = 0;
                foreach (var quest in _question)
                {
                    //the index is placeholder of the user option value, so it loops each index of the user written value
                    if (_userAnswers[index] != quest.CorrectAnswerIndex)
                    {
                        hasMistakes = true;
                        Console.WriteLine($"{index + 1}. {quest.QuestionText}");
                        Console.WriteLine($"   ❌ Your Answer: {quest.Answers[_userAnswers[index]]}");
                        Console.WriteLine($"   ✅ Correct Answer: {quest.Answers[quest.CorrectAnswerIndex]}\n");
                    }
                    //hence index is incremented for as much individual value is in the _userAnswers array 
                    index++;
                }

                if (!hasMistakes)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n🎉 Congratulations! You got all the questions correct!");
                    Console.ResetColor();
                }
            }
        }

    }
}

