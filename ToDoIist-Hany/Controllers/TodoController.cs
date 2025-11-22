using Microsoft.AspNetCore.Mvc;
using System.Linq;                 // for Any(), Max()
using System.Collections.Generic;  // if implicit usings are off
using ToDolist_Hany.Models;

namespace ToDolist_Hany.Controllers
{
    public class TodoController : Controller
    {
        public IActionResult Index()
        {
            // pass list to the view
            return View(_items);
        }

        // fake in-memory "database" for now
        private static readonly List<TodoItem> _items = new()
        {
            new TodoItem { Id = 1, Title = "Learn MVC basics", IsDone = false },
            new TodoItem { Id = 2, Title = "Build first action", IsDone = true },
            new TodoItem { Id = 3, Title = "Create views", IsDone = false },
            new TodoItem { Id = 4, Title = "Understand model binding", IsDone = true },
            new TodoItem { Id = 5, Title = "Testing CI/CD Pipeline", IsDone = false },
            new TodoItem { Id = 6, Title = "Deploy to Azure", IsDone = false },
        };

        // GET: /Todo/Create
        public IActionResult Create()
        {
            // just show the empty form
            return View();
        }

        // POST: /Todo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TodoItem item)
        {
            if (string.IsNullOrWhiteSpace(item.Title))
            {
                ModelState.AddModelError(nameof(item.Title), "Title is required.");
                return View(item);
            }

            item.Id = _items.Any() ? _items.Max(i => i.Id) + 1 : 1;
            item.IsDone = false;
            _items.Add(item);

            return RedirectToAction(nameof(Index));
        }


        // POST: /Todo/Toggle/1
        [HttpPost]
        public IActionResult Toggle(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                item.IsDone = !item.IsDone; // flip the status
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: /Todo/Delete/1
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _items.Remove(item);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
