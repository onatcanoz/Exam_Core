using Exam.Data;
using Exam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Services
{
    public interface IQuestionService : IService<Question>
    {
        void CreateAll(List<Question> questions);
    }
    public class QuestionService : IQuestionService
    {
        private readonly ExamDbContext _context;

        public QuestionService(ExamDbContext context)
        {
            _context = context;
        }

        public void Create(Question model)
        {
            _context.Questions.Add(model);
            _context.SaveChanges();
        }

        public void CreateAll(List<Question> questions)
        {
            _context.Questions.AddRange(questions);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
