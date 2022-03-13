using FrontEndWebApp.Helpers;
using FrontEndWebApp.Interfaces;
using FrontEndWebApp.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace FrontEndWebApp.Controllers
{
    public class CountersController : Controller
    {
        private IActionController<Mostrador> _actionLoan;
        private IActionsMethods _actions;
        public CountersController()
        {
            _actionLoan = new ActionController<Mostrador>();
            _actions = new ActionsMethods();
        }
        // GET: Counters
        public ActionResult Index()
        {
            HttpWebRequest request = _actions.Action("GET", "Counters");
            var req = _actionLoan.GetAll(request);
            return View(req);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            HttpWebRequest request = _actions.Action("GET", "Counters", id);
            var req = _actionLoan.GetByID(request);
            return View(req);
        }

        // GET: Book/Create
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
            IActionController<Autor> Down = new ActionController<Autor>();
            List<SelectListItem> Autor = new List<SelectListItem>();
            HttpWebRequest reqDown = _actions.Action("GET", "Autors");

            foreach (var item in Down.GetAll(reqDown))
            {
                Autor.Add(new SelectListItem
                {
                    Text = item.Nombre,
                    Value = item.Id_Autor.ToString()
                });
            }
            ViewBag.Book = Book;
            ViewBag.Autor = Autor;
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Mostrador counter)
        {
            try
            {
                HttpWebRequest request = _actions.Action("Post", "Counters");
                var req = _actionLoan.Post(request, counter);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            HttpWebRequest request = _actions.Action("GET", "Counters", id);
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
            IActionController<Autor> Down = new ActionController<Autor>();
            List<SelectListItem> Autor = new List<SelectListItem>();
            HttpWebRequest reqDown = _actions.Action("GET", "Autors");

            foreach (var item in Down.GetAll(reqDown))
            {
                Autor.Add(new SelectListItem
                {
                    Text = item.Nombre,
                    Value = item.Id_Autor.ToString()
                });
            }
            ViewBag.Book = Book;
            ViewBag.Autor = Autor;
            return View(req);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Mostrador counter)
        {
            try
            {
                HttpWebRequest request = _actions.Action("PUT", "Counters", id);
                var req = _actionLoan.Put(request, counter);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            HttpWebRequest request = _actions.Action("GET", "Counters", id);
            var req = _actionLoan.GetByID(request);
            return View(req);
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Mostrador counter)
        {
            try
            {
                HttpWebRequest request = _actions.Action("DELETE", "Counters", id);
                var req = _actionLoan.Delete(request, counter);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
