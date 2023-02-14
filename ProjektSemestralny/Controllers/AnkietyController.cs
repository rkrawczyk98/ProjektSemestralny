using Microsoft.AspNetCore.Mvc;
using ProjektSemestralny.Data;
using ProjektSemestralny.Models;

namespace ProjektSemestralny.Controllers
{
    public class AnkietyController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AnkietyController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Ankiety> objAnkietyList = _db.Ankiety;
            return View(objAnkietyList);
        }
    }
}
