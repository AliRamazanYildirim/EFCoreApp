// See https://aka.ms/new-console-template for more information

using EFCore.DBFirstZurScaffold.Models;
using Microsoft.EntityFrameworkCore;

using (var _kontext = new EFCoreDBFirstDbKontext())
{
    var produkte = await _kontext.Produkte.ToListAsync();

    produkte.ForEach(produkte =>
    {
        Console.WriteLine($"{produkte.ID}:{produkte.Name} - {produkte.Preis} - {produkte.Vorrat}");
    });
}

