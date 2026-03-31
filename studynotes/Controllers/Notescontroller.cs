using Microsoft.AspNetCore.Mvc;
using StudyNotes.Models;
using System.Linq;

namespace StudyNotes.Controllers
{
    public class NotesController : Controller
    {
        private readonly NotesDbContext _context;

        public NotesController(NotesDbContext context)
        {
            _context = context;
        }

        // 🔎 LISTAR + BUSCA
        public IActionResult Index(string search)
        {
            var notes = _context.Notes.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                notes = notes.Where(n =>
                    n.Titulo.Contains(search) ||
                    n.Categoria.Contains(search));
            }

            return View(notes.ToList());
        }

        // 📄 FORMULÁRIO
        public IActionResult Create()
        {
            return View();
        }

        // 💾 SALVAR NO BANCO
        [HttpPost]
        public IActionResult Create(Note note)
        {
            note.DataCriacao = DateTime.Now;

            _context.Notes.Add(note);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}