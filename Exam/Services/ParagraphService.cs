using Exam.Data;
using Exam.Entities;
using Exam.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Services
{
    public interface IParagraphService : IService<Paragraph>
    {
        List<Paragraph> GetParagraphList();
        Paragraph GetExamDetail(int id);
        Paragraph GetParagraphContent(int id);
    }

    public class ParagraphService : IParagraphService
    {
        private readonly ExamDbContext _context;

        public ParagraphService(ExamDbContext context)
        {
            _context = context;
        }

        public void Create(Paragraph model)
        {
            _context.Paragraphs.Add(model);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Paragraph entity = _context.Paragraphs.Find(id);
            _context.Paragraphs.Remove(entity);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public Paragraph GetExamDetail(int id)
        {
            return _context.Paragraphs
                 .Include(x => x.Questions)
                 .FirstOrDefault(x => x.Id == id);
        }

        public Paragraph GetParagraphContent(int id)
        {
            return _context.Paragraphs.FirstOrDefault(x => x.Id == id);
        }

        public List<Paragraph> GetParagraphList()
        {
            return _context.Paragraphs.ToList();
        }
    }
}
