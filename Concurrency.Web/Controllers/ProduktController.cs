using Concurrency.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            _kontext.Produkte.Update(produkt);
            await _kontext.SaveChangesAsync();

            return RedirectToAction(nameof(Liste));
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
    }
}
