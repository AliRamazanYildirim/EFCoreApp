using Concurrency.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Concurrency.Web.Controllers
{
    public class ProduktController : Controller
    {
        private readonly AppDbKontext _kontext;

        public ProduktController(AppDbKontext kontext)
        {
            _kontext = kontext;
        }
        public async Task<IActionResult> Liste()
        {
            return View(await _kontext.Produkte.ToListAsync());
        }
        public async Task<IActionResult> Aktualisieren(int ID)
        {
            var produkt = await _kontext.Produkte.FindAsync(ID);

            return View(produkt);
        }
        [HttpPost]
        public async Task<IActionResult> Aktualisieren(Produkt produkt)
        {
            try
            {
                _kontext.Produkte.Update(produkt);
                await _kontext.SaveChangesAsync();

                return RedirectToAction(nameof(Liste));
            }
            catch(DbUpdateConcurrencyException ex)
            {
                var exceptionEntry = ex.Entries.First();
                var currentProdukt = exceptionEntry.Entity as Produkt;
                var databaseValues = exceptionEntry.GetDatabaseValues();
                //var databaseProdukt = databaseValues.ToObject() as Produkt;
                var clientValues = exceptionEntry.CurrentValues;

                if (databaseValues==null)
                {
                    ModelState.AddModelError(string.Empty, "Dieses Produkt wurde von einer anderen Person gelöscht.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Dieses Produkt wurde von einer anderen Person verändert.");
                    var databaseProdukt = databaseValues.ToObject() as Produkt;
                    if (databaseProdukt != null)
                    {
                        ModelState.AddModelError(string.Empty, $"Aktualisierte Produkte: Name {databaseProdukt.Name} - Preis {databaseProdukt.Preis} - Vorrat {databaseProdukt.Vorrat}");
                    }
                }
            }
            return View(produkt);

        }
        [HttpGet]
        public IActionResult Addieren()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Addieren(Produkt produkt)
        {
            if(ModelState.IsValid)
            {
                await _kontext.Produkte.AddAsync(produkt);
                await _kontext.SaveChangesAsync();

                return RedirectToAction(nameof(Liste));
            }
            return View(produkt);
        }
        public async Task<IActionResult> Löschen(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var produkt = await _kontext.Produkte
                .FirstOrDefaultAsync(m => m.ID == ID);

            if (produkt == null)
            {
                return NotFound();
            }

            return View(produkt);
        }

        [HttpPost, ActionName("Löschen")]
        public async Task<IActionResult> LöschenBestätigen(int ID)
        {
            var produkt = await _kontext.Produkte.FindAsync(ID);
            _kontext.Produkte.Remove(produkt);
            await _kontext.SaveChangesAsync();
            return RedirectToAction(nameof(Liste));
        }
    }
}
