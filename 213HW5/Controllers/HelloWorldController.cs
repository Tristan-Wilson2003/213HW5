using _213HW5.Data;
using _213HW5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _213HW5.Controllers;

public class HelloWorldController : Controller
{
    private readonly _213HW5Context _context2;
    public HelloWorldController(_213HW5Context context)
    {
        _context2 = context;
    }

    public async Task<IActionResult> Index(string musicGenre, string searchString)
    {
        if (_context2.Music == null)
        {
            return Problem("Entity set '_213HW5Context.Movie'  is null.");
        }

        // Use LINQ to get list of genres.
        IQueryable<string> genreQuery = from m in _context2.Music
                                        orderby m.Genre
                                        select m.Genre;
        var mus = from m in _context2.Music
                  select m;

        if (!string.IsNullOrEmpty(searchString))
        {
            mus = mus.Where(s => s.Title!.Contains(searchString));
        }

        if (!string.IsNullOrEmpty(musicGenre))
        {
            mus = mus.Where(x => x.Genre == musicGenre);
        }

        var movieGenreVM = new MusicGenreViewModel
        {
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
            Musics = await mus.ToListAsync()
        };

        return View(movieGenreVM);


    }

    // GET: Musics/Details/5
    public async Task<IActionResult> Welcome(int? id)
    {
        if (id == null || _context2.Music == null)
        {
            return NotFound();
        }

        var music = await _context2.Music
            .FirstOrDefaultAsync(m => m.Id == id);
        if (music == null)
        {
            return NotFound();
        }

        return View(music);
    }
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context2.Music == null)
        {
            return NotFound();
        }

        var music = await _context2.Music
            .FirstOrDefaultAsync(m => m.Id == id);
        if (music == null)
        {
            return NotFound();
        }

        return View(music);
    }

    // GET: Musics/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Musics/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Music music)
    {
        if (ModelState.IsValid)
        {
            _context2.Add(music);
            await _context2.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(music);
    }

}


