using FrontEndWebApp.Helpers;
using FrontEndWebApp.Interfaces;
using FrontEndWebApp.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace FrontEndWebApp.Controllers
{
    public class LoansController : Controller
    {
        private IActionController<Prestamo> _actionLoan;
        private IActionsMethods _actions;
        public LoansController()
        {
            _actionLoan = new ActionController<Prestamo>();
            _actions = new ActionsMethods();
        }
        // GET: Loan
        public ActionResult Index()
        {
            HttpWebRequest request = _actions.Action("GET", "Loans");
            var req = _actionLoan.GetAll(request);
            return View(req);
        }

        // GET: Loan/Details/5
        public ActionResult Details(int id)
        {
            HttpWebRequest request = _actions.Action("GET", "Loans", id);
            var req = _actionLoan.GetByID(request);
            return View(req);
        }

        // GET: Loan/Create
        public ActionResult Create()
        {
            IActionController<Libro> Drop = new ActionController<Libro>();
            List<SelectListItem> Book = new List<SelectListItem>();
            HttpWebRequest reqDrop = _actions.Action("GET", "Books");

            foreach (var item in Drop.GetAll(reqDrop))
            {
                Book.Add(new SelectListItem
                {
                    Text = item.Titulo,
                    Value = item.Id_Libro.ToString()
                });
            }
            IActionController<Estudiante> Down = new ActionController<Estudiante>();
            List<SelectListItem> student = new List<SelectListItem>();
            HttpWebRequest reqDown = _actions.Action("GET", "Students");

            foreach (var item in Down.GetAll(reqDown))
            {
                student.Add(new SelectListItem
                {
                    Text = item.Nombre + " " + item.Apellido,
                    Value = item.Id_Lector.ToString()
                });
            }
            ViewBag.Book = Book;
            ViewBag.student = student;
            return View();
        }

        // POST: Loan/Create
        [HttpPost]
        public ActionResult Create(Prestamo Prestamo)
        {
            try
            {
                HttpWebRequest request = _actions.Action("POST", "Loans");
                var req = _actionLoan.Post(request, Prestamo);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Loan/Edit/5
        public ActionResult Edit(int id)
        {
            HttpWebRequest request = _actions.Action("GET", "Loans", id);
            var req = _actionLoan.GetByID(request);


            IActionController<Libro> Drop = new ActionController<Libro>();
            List<SelectListItem> Book = new List<SelectListItem>();
            HttpWebRequest reqDrop = _actions.Action("GET", "Books");

            foreach (var item in Drop.GetAll(reqDrop))
            {
                Book.Add(new SelectListItem
                {
                    Text = item.Titulo,
                    Value = item.Id_Libro.ToString()
                });
            }
            IActionController<Estudiante> Down = new ActionController<Estudiante>();
            List<SelectListItem> student = new List<SelectListItem>();
            HttpWebRequest reqDown = _actions.Action("GET", "Students");

            foreach (var item in Down.GetAll(reqDown))
            {
                student.Add(new SelectListItem
                {
                    Text = item.Nombre + " " + item.Apellido,
                    Value = item.Id_Lector.ToString()
                });
            }
            ViewBag.Book = Book;
            ViewBag.student = student;
            return View(req);
        }
        // POST: Loan/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Prestamo prestamo)
        {
            try
            {
                HttpWebRequest request = _actions.Action("PUT", "Loans", id);
                var req = _actionLoan.Put(request, prestamo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Loan/Delete/5
        public ActionResult Delete(int id)
        {
            HttpWebRequest request = _actions.Action("GET", "Loans", id);
            var req = _actionLoan.GetByID(request);
            return View(req);
        }

        // POST: Loan/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Prestamo prestamo)
        {
            try
            {
                HttpWebRequest request = _actions.Action("DELETE", "Loans", id);
                var req = _actionLoan.Delete(request, prestamo);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
