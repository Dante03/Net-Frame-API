using FrontEndWebApp.Helpers;
using FrontEndWebApp.Interfaces;
using FrontEndWebApp.Models;
using System.Net;
using System.Web.Mvc;

namespace FrontEndWebApp.Controllers
{
    public class AutorsController : Controller
    {
        private IActionController<Autor> _action;
        private IActionsMethods _actions;
        public AutorsController()
        {
            _action = new ActionController<Autor>();
            _actions = new ActionsMethods();
        }
        // GET: Autors
        public ActionResult Index()
        {
            HttpWebRequest request = _actions.Action("GET", "Autors");
            var req = _action.GetAll(request);
            return View(req);
        }

        // GET: Autors/Details/5
        public ActionResult Details(int id)
        {
            HttpWebRequest request = _actions.Action("GET", "Autors", id);
            var req = _action.GetByID(request);
            return View(req);
        }

        // GET: Autors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Autors/Create
        [HttpPost]
        public ActionResult Create(Autor autor)
        {
            try
            {
                HttpWebRequest request = _actions.Action("POST", "Autors");
                var req = _action.Post(request, autor);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Autors/Edit/5
        public ActionResult Edit(int id)
        {
            HttpWebRequest request = _actions.Action("GET", "Autors", id);
            var req = _action.GetByID(request);
            return View(req);
        }

        // POST: Autors/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Autor autor)
        {
            try
            {
                HttpWebRequest request = _actions.Action("PUT", "Autors", id);
                var req = _action.Put(request, autor);
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
            HttpWebRequest request = _actions.Action("GET", "Autors", id);
            var req = _action.GetByID(request);
            return View(req);
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Autor autor)
        {
            try
            {
                HttpWebRequest request = _actions.Action("DELETE", "Autors", id);
                var req = _action.Delete(request, autor);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
