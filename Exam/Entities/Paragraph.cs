﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Entities
{
    public class Paragraph
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Question> Questions { get; set; }


    }
}
