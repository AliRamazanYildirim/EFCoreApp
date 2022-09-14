// See https://aka.ms/new-console-template for more information

using EFCore.CodeFirst;
using EFCore.CodeFirst.DZS;
using Microsoft.EntityFrameworkCore;

Initialisierer.Build();
using (var _kontext = new AppDBKontext())
{
    //var neuesProdukt = new Produkt { Name = "Rotring 0.5mm ", Preis = 40, Vorrat = 100, Strichcode = 777 };
    //_kontext.Entry(neuesProdukt).State = EntityState.Added;
    //await _kontext.AddAsync(neuesProdukt);



    //var produkt = await _kontext.Produkte.FirstAsync();
    //Console.WriteLine($"Erster Zustand:{_kontext.Entry(produkt).State}");
    //_kontext.Entry(produkt).State= EntityState.Detached;
    //Console.WriteLine($"Letzter Zustand:{_kontext.Entry(produkt).State}");

    //var produkt = await _kontext.Produkte.FirstAsync();
    //produkt.Name = "Rotring 800 mm";
    //_kontext.Remove(produkt);
    //produkt.Vorrat = 1000;

    //Aktualisieren eines Objekts mit Update Methode, das nicht im Speicher verfolgt wird und nicht von EF Core verfolgt wird
    //_kontext.Update(new Produkt() { ID = 6, Name = "Rotring 500 0.7mm", Preis = 100, Vorrat = 100, Strichcode = 777 });

    var produkt = await _kontext.Produkte.FirstAsync(p => p.ID == 6);
    produkt.Name = "Rotring Visumax 0.5 mm";
    await _kontext.SaveChangesAsync();

    

    //Console.WriteLine($"Zustand nach Änderungen speichern:{_kontext.Entry(produkt).State}");



    //var produkte = await _kontext.Produkte.ToListAsync();

    //produkte.ForEach(produkte =>
    //{
    //    var zustand = _kontext.Entry(produkte).State;

    //    Console.WriteLine($"{produkte.ID}:{produkte.Name} - {produkte.Preis} - {produkte.Vorrat} zustand:{zustand}");
    //});
}
