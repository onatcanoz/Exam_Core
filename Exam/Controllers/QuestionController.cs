using Exam.Models;
using Exam.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IParagraphService _paragraphService;
        private readonly IQuestionService _questionService;

        public QuestionController(IParagraphService paragraphService, IQuestionService questionService)
        {
            _paragraphService = paragraphService;
            _questionService = questionService;
        }

        public IActionResult ExamDetail(int id)
        {
            var exam = _paragraphService.GetExamDetail(id);
            var model = new ParagraphModel()
            {
                Id = exam.Id,
                Title = exam.Title,
                Content = exam.Content,
                CreatedAt = exam.CreatedAt,
                QuestionModels = exam.Questions.Where(x => x.ParagraphId == exam.Id).Select(x => new QuestionModel
                {
                    Id = x.Id,
                    QuestionDescription = x.QuestionDescription,
                    OptionA=x.OptionA,
                    OptionB=x.OptionB,
                    OptionC=x.OptionC,
                    OptionD=x.OptionD,
                    TrueOption=x.TrueOption
                }).ToList()
            };

            return View(model);
        }

        public IActionResult ParagraphList()
        {
            var model = _paragraphService.GetParagraphList().Select(x => new ParagraphModel
            {
                Id = x.Id,
                Title = x.Title,
                CreatedAt = x.CreatedAt
            }).ToList();

            return View(model);
        }

        public IActionResult Create()
        {
            var paragraphList = _paragraphService.GetParagraphList().Select(x => new ParagraphModel
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content
            }).ToList();

            var model = new CreateExamModel()
            {
                ParagraphModel = paragraphList
            };

            return View(model);
        }


        //[HttpPost]
        //public IActionResult Create(CreateExamModel model)
        //{
        //    _questionService.CreateAll(model.QuestionModels.Select(x => new Entities.Question
        //    {
        //        ParagraphId = model.SelectedParagraphId,
        //        QuestionDescription = x.QuestionDescription,
        //        OptionA=x.OptionA,
        //        OptionB=x.OptionB,
        //        OptionC=x.OptionC,
        //        OptionD=x.OptionD,
        //        TrueOption=x.TrueOption
        //    }).ToList());


        //    return RedirectToAction("Question/ParagraphList");
        //}

        [HttpPost]
        public IActionResult CreateExam(CreateExamDto model)
        {
            _questionService.CreateAll(model.QuestionModels.Select(x => new Entities.Question
            {
                ParagraphId = model.SelectedParagraphId,
                QuestionDescription = x.QuestionDescription,
                OptionA = x.OptionA,
                OptionB = x.OptionB,
                OptionC = x.OptionC,
                OptionD = x.OptionD,
                TrueOption = x.TrueOption
            }).ToList());


            return RedirectToAction(nameof(ParagraphList));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _paragraphService.Delete(id.Value);


            return RedirectToAction("ParagraphList");
        }

        public IActionResult GetParagraphContent(int id)
        {
            var paragraph = _paragraphService.GetParagraphContent(id);

            return Json(paragraph);
        }
    }
}
