using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class ParagraphModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Content { get; set; }
        public List<QuestionModel> QuestionModels { get; set; }


    }
}
