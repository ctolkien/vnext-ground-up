using Microsoft.AspNet.Mvc;
using System.Linq;

public class HomeController : Controller
{
    private readonly GroundUpDbContext _db;
    public HomeController(GroundUpDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var listOfTodos = _db.Todos.ToList();

        return View(listOfTodos);
    }
}
