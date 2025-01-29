using System;
using MyQuizApp.Models; 

namespace MyQuizApp.Services
{
	internal class QuizQuestions
	{
		public static Questionnaire[] GetQuizQuestions()
		{
            return new Questionnaire[]
            {
                //each objects 
                new Questionnaire("Which continent is Ghana in?",
               new String[]{"Asia", "Europe", "Africa", "America"},
               2),
               new Questionnaire("Which of these AutoMobil Company is located in Germany?",
               new String[]{"Volskwagen", "Ferrari", "Mazda", "Toyota"},
               0),
               new Questionnaire("Which of these zodiac sign belongs to President John F Kenedy?",
               new String[]{"Taurus","Virgo","Pisces","Gemini"},
               3),
               new Questionnaire("Which is the national currency of Peru",
               new String[]{"lira","Pesos","Dollar","Sol"},
               3),
               new Questionnaire("Gravitational force measures?",
               new String[]{"9.8ms^-2", "6.8ms^-2", "7.8ms^-2", "8.8ms^-2"},
               0)
            };
		}
	}
}

