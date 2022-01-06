using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class CreateExamModel
    {
        public List<ParagraphModel> ParagraphModel { get; set; }
        public List<QuestionModel> QuestionModels { get; set; }
        public int SelectedParagraphId { get; set; }
    }
}
