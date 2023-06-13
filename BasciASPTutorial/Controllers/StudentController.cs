using BasciASPTutorial.Data;
using BasciASPTutorial.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace BasciASPTutorial.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext db;

        public StudentController(ApplicationDBContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            // new command
            // Student s1 = new Student();
            // s1.Id = 1;
            // s1.Name = "Rus";
            // s1.Score = 77;

            // Type Interence
            // var s2 = new Student();
            // s2.Id = 2;
            // s2.Name = "Pong";
            // s2.Score = 45;

            // Function new()
            // Student s3 = new();
            // s3.Id = 3;
            // s3.Name = "Lin";
            // s3.Score = 100;

            // List<Student> allStudent = new List<Student>();

            IEnumerable <Student> allStudent = db.Students;

            return View(allStudent);
        }

        // default: GET METHOD
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            // data validation
            if (ModelState.IsValid)
            {
                db.Students.Add(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            // return user input data to form when format is incorrect
            return View(obj);
        }

        public IActionResult Edit(int? id)
        { 
            if (id==null || id==0)
            {
                return NotFound();
            }
            var obj = db.Students.Find(id);
            if (obj==null) 
            {
                return NotFound();
            }
            return View(obj);
        }

        // edit (update the database)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student obj)
        {
            // data validation
            if (ModelState.IsValid)
            {
                db.Students.Update(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            // return user input data to form when format is incorrect
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = db.Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            db.Students.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
