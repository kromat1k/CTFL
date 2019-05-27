using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTFL.Data;
using CTFL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace CTFL.Pages.Questions
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IQuestionData questionData;

        public IEnumerable<Question> Questions { get; set; }

        [BindProperty(SupportsGet = true)]
        public String SearchTerm { get; set; }

        public ListModel(IConfiguration config, IQuestionData questionData)
        {
            this.config = config;
            this.questionData = questionData;
        }

        public void OnGet(string searchTerm)
        {
            Questions = questionData.GetByQuestionText(searchTerm);
        }
    }
}