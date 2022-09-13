// See https://aka.ms/new-console-template for more information

using EFCoreApp.DBFirst.DZS;
using Microsoft.EntityFrameworkCore;

DBKontextInitialisierer.Build();
using (var _kontext= new AppDBKontext())//Mit using Schlüsselwort wird AppDbKontext nur ein mal verwendet und von Zwischenspeicher gelöscht 
{
    var produkte = await _kontext.Produkte.ToListAsync();

    produkte.ForEach(produkte =>
    {
        Console.WriteLine($"{produkte.ID}:{produkte.Name} - {produkte.Preis} - {produkte.Vorrat}");
    });
}
