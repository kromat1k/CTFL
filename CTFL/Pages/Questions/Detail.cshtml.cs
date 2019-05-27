using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTFL.Data;
using CTFL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTFL.Pages.Questions
{
    public class DetailModel : PageModel
    {
        private readonly IQuestionData questionData;
        public Question Question { get; set; }

        [TempData]
        public string Message { get; set; }

        public DetailModel(IQuestionData questionData)
        {
            this.questionData = questionData;
        }

        public IActionResult OnGet(int questionID)
        {
            Question = questionData.GetByID(questionID);

            if(Question == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}