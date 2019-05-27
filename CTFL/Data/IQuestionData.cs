using CTFL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTFL.Data
{
    public interface IQuestionData
    {
        IEnumerable<Question> GetByQuestionText(string text);
        Question GetByID(int id);

        Question Update(Question updatedQuestion);

        int Commit();
    }

    public class InMemoryQuestionData : IQuestionData
    {
        List<Question> questions;

        public InMemoryQuestionData()
        {
            questions = new List<Question>()
            {
                new Question { ID = 1, Text = "True or False?", Answers = new List<String> { "True", "False" }, CorrectAnswer = "True" },
                new Question { ID = 2, Text = "Yes or No?", Answers = new List<String> { "Yes", "No" }, CorrectAnswer = "No" },
                new Question { ID = 3, Text = "1, 2, 3, or 4?", Answers = new List<String> { "1", "2", "3", "4" }, CorrectAnswer = "3" }
            };
        }

        public int Commit()
        {
            return 0;
        }

        public Question GetByID(int id)
        {
            return questions.SingleOrDefault(q => q.ID == id);
        }

        public IEnumerable<Question> GetByQuestionText(string text = null)
        {
            return from q in questions
                   where string.IsNullOrEmpty(text) || q.Text.Contains(text)
                   select q;
        }

        public Question Update(Question updatedQuestion)
        {
            var question = questions.SingleOrDefault(q => q.ID == updatedQuestion.ID);

            if (question != null)
            {
                question.Text = updatedQuestion.Text;
                question.Answers = updatedQuestion.Answers;
                question.CorrectAnswer = updatedQuestion.CorrectAnswer;
            }

            return question;
        }
    }

}
