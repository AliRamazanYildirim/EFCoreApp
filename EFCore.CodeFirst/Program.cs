// See https://aka.ms/new-console-template for more information

using EFCore.CodeFirst;
using EFCore.CodeFirst.DZS;
using Microsoft.EntityFrameworkCore;

Initialisierer.Build();
using (var _kontext = new AppDBKontext())
{
    //var neuesProdukt = new Produkt { Name = "Rotring 0.5mm ", Preis = 40, Vorrat = 100, Strichcode = 777 };

    _kontext.Update(new Produkt() { ID = 5, Name = "Rotring 500 0.7mm", Preis = 100, Vorrat=100, Strichcode = 777 });
    
    await _kontext.SaveChangesAsync();
    //Console.WriteLine($"Zustand nach Änderungen speichern:{ _kontext.Entry(produkt).State}");
    //_kontext.Entry(neuesProdukt).State = EntityState.Added;
    //await _kontext.AddAsync(neuesProdukt);


    //var produkte = await _kontext.Produkte.ToListAsync();

    //produkte.ForEach(produkte =>
    //{
    //    var zustand = _kontext.Entry(produkte).State;

    //    Console.WriteLine($"{produkte.ID}:{produkte.Name} - {produkte.Preis} - {produkte.Vorrat} zustand:{zustand}");
    //});
}
