using FrontEndWebApp.Helpers;
using FrontEndWebApp.Interfaces;
using FrontEndWebApp.Models;
using System.Net;
using System.Web.Mvc;

namespace FrontEndWebApp.Controllers
{
    public class StudentsController : Controller
    {
        private IActionController<Estudiante> _action;
        private IActionsMethods _actions;
        public StudentsController()
        {
            _action = new ActionController<Estudiante>();
            _actions = new ActionsMethods();
        }
        // GET: Students
        public ActionResult Index()
        {
            HttpWebRequest request = _actions.Action("GET", "Students");
            var req = _action.GetAll(request);
            return View(req);
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            HttpWebRequest request = _actions.Action("GET", "Students", id);
            var req = _action.GetByID(request);
            return View(req);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        public ActionResult Create(Estudiante Students)
        {
            try
            {
                HttpWebRequest request = _actions.Action("POST", "Students");
                var req = _action.Post(request, Students);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            HttpWebRequest request = _actions.Action("GET", "Students", id);
            var req = _action.GetByID(request);
            return View(req);
        }

        // POST: Students/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Estudiante Students)
        {
            try
            {
                HttpWebRequest request = _actions.Action("PUT", "Students", id);
                var req = _action.Put(request, Students);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            HttpWebRequest request = _actions.Action("GET", "Students", id);
            var req = _action.GetByID(request);
            return View(req);
        }

        // POST: Students/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Estudiante Students)
        {
            try
            {
                HttpWebRequest request = _actions.Action("DELETE", "Students", id);
                var req = _action.Delete(request, Students);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
