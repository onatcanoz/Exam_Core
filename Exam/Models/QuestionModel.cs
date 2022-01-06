using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string QuestionDescription { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string TrueOption { get; set; }
    }
}
