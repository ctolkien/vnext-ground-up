using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

namespace part4.Controllers
{
    public class TodoController : Controller
    {
        private GroundUpDbContext db = new GroundUpDbContext();

        // GET: Todo
        public IActionResult Index()
        {
            return View(db.Todos.ToList());
        }

        // GET: Todo/Details/5
        public IActionResult Details(System.Int32? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            TodoItem todoItem = db.Todos.Single(m => m.Id == id);
            if (todoItem == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(todoItem);
        }

        // GET: Todo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Todo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                db.Todos.Add(todoItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todoItem);
        }

        // GET: Todo/Edit/5
        public IActionResult Edit(System.Int32? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            TodoItem todoItem = db.Todos.Single(m => m.Id == id);
            if (todoItem == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(todoItem);
        }

        // POST: Todo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                //db.ChangeTracker.Entry(todoItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todoItem);
        }

        // GET: Todo/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(System.Int32? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            TodoItem todoItem = db.Todos.Single(m => m.Id == id);
            if (todoItem == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(todoItem);
        }

        // POST: Todo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(System.Int32 id)
        {
            TodoItem todoItem = db.Todos.Single(m => m.Id == id);
            db.Todos.Remove(todoItem);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
