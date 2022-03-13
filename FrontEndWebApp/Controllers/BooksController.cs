using FrontEndWebApp.Helpers;
using FrontEndWebApp.Interfaces;
using FrontEndWebApp.Models;
using System.Net;
using System.Web.Mvc;

namespace FrontEndWebApp.Controllers
{
    public class BooksController : Controller
    {
        private IActionController<Libro> _actionLoan;
        private IActionsMethods _actions;
        public BooksController()
        {
            _actionLoan = new ActionController<Libro>();
            _actions = new ActionsMethods();
        }
        // GET: Book
        public ActionResult Index()
        {
            HttpWebRequest request = _actions.Action("GET", "Books");
            var req = _actionLoan.GetAll(request);
            return View(req);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            HttpWebRequest request = _actions.Action("GET", "Books", id);
            var req = _actionLoan.GetByID(request);
            return View(req);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Libro book)
        {
            try
            {
                HttpWebRequest request = _actions.Action("Post", "Books");
                var req = _actionLoan.Post(request, book);
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
            HttpWebRequest request = _actions.Action("GET", "Books", id);
            var req = _actionLoan.GetByID(request);
            return View(req);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Libro book)
        {
            try
            {
                HttpWebRequest request = _actions.Action("PUT", "Books", id);
                var req = _actionLoan.Put(request, book);
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
            HttpWebRequest request = _actions.Action("GET", "Books", id);
            var req = _actionLoan.GetByID(request);
            return View(req);
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Libro book)
        {
            try
            {
                HttpWebRequest request = _actions.Action("DELETE", "Books", id);
                var req = _actionLoan.Delete(request, book);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
