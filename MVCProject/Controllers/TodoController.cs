using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;
using System.Data.Entity;

namespace MVCProject.Controllers
{
    public class TodoController : Controller
    {
        private ApplicationDbContext _context;

        public TodoController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: todo
        public ActionResult Index()
        {
            if(User.IsInRole("CanManageLists"))
            {
                return View("TodoList");
            }

            return View("ReadOnlyTodoList");
        }

        public JsonResult GetTodoList()
        {
            var todolists = _context.TodoLists.Include(m => m.Status).ToList();

            return Json(todolists, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStatusType()
        {
            var statusTypes = _context.Statuses.ToList();

            return Json(statusTypes, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddTask(TodoLIst task)
        {
            _context.TodoLists.Add(task);
            _context.SaveChanges();

            var todolists = _context.TodoLists.Include(m => m.Status).ToList();

            return Json(todolists, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult updateTask(TodoLIst task)
        {
            var tempTask = _context.TodoLists.Find(task.Id);

            tempTask.Content = task.Content;
            tempTask.StatusId = task.StatusId;
            tempTask.Progress = task.Progress;

            _context.SaveChanges();

            var todolists = _context.TodoLists.Include(m => m.Status).ToList();

            return Json(todolists, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult deleteTask(TodoLIst task)
        {
            _context.TodoLists.Remove(_context.TodoLists.Find(task.Id));
            _context.SaveChanges();

            var todolists = _context.TodoLists.Include(m => m.Status).ToList();

            return Json(todolists, JsonRequestBehavior.AllowGet);
        }

    }
}