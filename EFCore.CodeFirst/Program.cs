// See https://aka.ms/new-console-template for more information

using EFCore.CodeFirst;
using EFCore.CodeFirst.DZS;
using Microsoft.EntityFrameworkCore;

Initialisierer.Build();
using (var _kontext = new AppDBKontext())
{
    var neuesProdukt = new Produkt { Name = "Rotring 0.5mm ", Preis = 40, Vorrat = 100, Strichcode = 777 };

    Console.WriteLine($"Erster Zustand:{ _kontext.Entry(neuesProdukt).State}");

    _kontext.Entry(neuesProdukt).State = EntityState.Added;
    //await _kontext.AddAsync(neuesProdukt);

    Console.WriteLine($"Letzter Zustand:{ _kontext.Entry(neuesProdukt).State}");

    await _kontext.SaveChangesAsync();
    Console.WriteLine($"Zustand nach Änderungen speichern:{ _kontext.Entry(neuesProdukt).State}");
    //var produkte = await _kontext.Produkte.ToListAsync();

    //produkte.ForEach(produkte =>
    //{
    //    var zustand = _kontext.Entry(produkte).State;

    //    Console.WriteLine($"{produkte.ID}:{produkte.Name} - {produkte.Preis} - {produkte.Vorrat} zustand:{zustand}");
    //});
}
