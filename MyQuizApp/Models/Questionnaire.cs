
namespace MyQuizApp.Models
{
    internal class Questionnaire
    {
        public string QuestionText { get; set; }
        public string[] Answers { get; set; }
        public int CorrectAnswerIndex { get; set; }

        public Questionnaire(string question, string[] answers, int correctAnswerIndex)
        {
            this.QuestionText = question;
            this.Answers = answers;
            this.CorrectAnswerIndex = correctAnswerIndex;
        }

        public bool isAnswerCorrect(int uI)
        {
            return CorrectAnswerIndex == uI;
        }
    }
}

