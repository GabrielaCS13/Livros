using Microsoft.AspNetCore.Mvc;
using Livro.Models;
using Livro.Data;


namespace Livro.Controllers
{
    public class LivroController : Controller
    {
        readonly private ApplicationDBContext _db;
        public LivroController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<livro> livro = _db.Livro;
            return View(livro);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(livro livro)
        {
            if (ModelState.IsValid)
            {
                _db.Livro.Add(livro);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]

        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            livro livro = _db.Livro.FirstOrDefault(x => x.Id == id);

            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        [HttpPost]
        public IActionResult Editar(livro livro)
        {
            if (ModelState.IsValid)
            {
                _db.Livro.Update(livro);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(livro);
        }
        [HttpGet]

        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            livro livro = _db.Livro.FirstOrDefault(x => x.Id == id);

            if (livro == null)
            {
                return NotFound();
            }
            return View(livro);
        }
        [HttpPost]
        public IActionResult Excluir(livro livro)
        {
            if (livro == null)
            {
                return NotFound();
            }
            _db.Livro.Remove(livro);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
