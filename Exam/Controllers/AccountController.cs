using Exam.Data;
using Exam.Filter;
using Exam.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Controllers
{
    public class AccountController : Controller
    {
        private readonly ExamDbContext _context;

        public AccountController(ExamDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("id").HasValue)
            {
                return Redirect("/Home/Index");
            }
            return View();
        }

        public IActionResult Login(string email, string pass)
        {
            var user = _context.AppUsers.FirstOrDefault(w => w.Email.Equals(email) && w.Password.Equals(pass));
            if(user != null)
            {
                HttpContext.Session.SetInt32("id",user.Id);
                HttpContext.Session.SetString("fullname",user.Name+" "+user.SurName);
                return Redirect("/Question/Create");
            }

            return Redirect("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return Redirect("Index");
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public async Task<IActionResult> Register(AppUser model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();

            return Redirect("Index");
        }
    }
}
