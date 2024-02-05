using Microsoft.AspNetCore.Mvc;
using Egzamin2024.Models;
using Egzamin2024.Interfaces;
using System;
/*Mikołaj Handzlik 14273*/
namespace Egzamin2024.Controllers
{
    public class ExamController : Controller
    {
        private readonly IDateProvider _dateProvider;
        private readonly NoteService _noteService;

        public ExamController(IDateProvider dateProvider, NoteService noteService)
        {
            _dateProvider = dateProvider ?? throw new ArgumentNullException(nameof(dateProvider));
            _noteService = noteService ?? throw new ArgumentNullException(nameof(noteService));
        }

        [HttpGet("/Exam/Index")]
        public IActionResult Index()
        {
            var importantNotes = _noteService.GetAll();
            return View("Index", importantNotes);
        }

        [HttpGet("/Exam/Create")]
        public IActionResult Create()
        {
            // Ustaw domyślną datę na bieżącą
            Note note = new Note
            {
                Deadline = _dateProvider.CurrentDate
            };

            return View("Create", note);
        }

        [HttpPost("/Exam/Create")]
        public IActionResult Create(Note note)
        {
            if (ModelState.IsValid)
            {
                // Sprawdź warunki z zadania
                if (note.Deadline <= _dateProvider.CurrentDate.AddHours(1))
                {
                    ModelState.AddModelError("Deadline", "Czas ważności musi być o godzinę późniejszy od bieżącego czasu!");
                    return View("Create", note);
                }

                // Dodaj notatkę do serwisu
                _noteService.Add(note);

                // Przekieruj do widoku z listą notatek
                return RedirectToAction("Index");
            }

            // Jeśli ModelState nie jest poprawny, wróć do widoku formularza z błędami
            return View("Create", note);
        }

        [HttpGet("/Exam/Details/{title}")]
        public IActionResult Details(string title)
        {
            var note = _noteService.GetById(title);
            if (note == null)
            {
                return NotFound(); // Notatka o podanym tytule nie została znaleziona
            }

            return View("Details", note);
        }
    }
}
