using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CTFL.Models
{
    public class Question 
    {
        public int ID { get; set; }

        public String Text { get; set; }

        public List<String> Answers { get; set; }

        public String CorrectAnswer { get; set; }
    }
}
