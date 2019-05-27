using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTFL.Data;
using CTFL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CTFL.Pages.Questions
{
    public class EditModel : PageModel
    {
        private readonly IQuestionData questionData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Question Question { get; set; }

        public EditModel(IQuestionData questionData, IHtmlHelper htmlHelper )
        {
            this.questionData = questionData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int questionID)
        {
            Question = questionData.GetByID(questionID);

            if (Question == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(string action)
        {
            if (!ModelState.IsValid) {
                //TODO
            }

            if (action == "add-answer")
            {
                Question.Answers.Add("Please enter answer text...");
            }
            else if (action.Contains("remove-answer"))
            {
                var answerIndex = Convert.ToInt32(action.Replace("remove-answer-", ""));
                var answerToRemove = Question.Answers[answerIndex];

                Question.Answers.Remove(answerToRemove);

                if (answerToRemove == Question.CorrectAnswer)
                {
                    Question.CorrectAnswer = Question.Answers[0];
                }
            }

            Question = questionData.Update(Question);
            questionData.Commit();

            ModelState.Clear();

            if(action == "save")
            {
                TempData["Message"] = "Question saved!";
                return RedirectToPage("./Detail");
            }

            return Page();
        }

        public IEnumerable<SelectListItem> GetAnswersSelectList(Question question)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            for(int i = 0; i < question.Answers.Count(); i++)
            {
                var answer = question.Answers.ElementAt(i);
                SelectListItem item = new SelectListItem(answer, answer, answer == question.CorrectAnswer, false);
                selectList.Add(item);
            }

            return selectList;
        }
    }
}