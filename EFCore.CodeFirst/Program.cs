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

    //var produkt = await _kontext.Produkte.FirstAsync(p => p.ID == 6);
    //produkt.Name = "Rotring Visumax 0.5 mm";
    //await _kontext.SaveChangesAsync();



    //Console.WriteLine($"Zustand nach Änderungen speichern:{_kontext.Entry(produkt).State}");



    //var produkte = await _kontext.Produkte.AsNoTracking().ToListAsync();

    //produkte.ForEach(produkt =>
    //{
    //    Console.WriteLine($"{produkt.ID}:{produkt.Name} - {produkt.Preis} - {produkt.Vorrat} ");
    //});

    //_kontext.Produkte.Add(new() { Name = "Rotring Versatil", Preis = 70, Vorrat = 100, Strichcode = 1453});
    //_kontext.Produkte.Add(new() { Name = "Rotring 500", Preis = 50, Vorrat = 100, Strichcode = 1753 });
    //_kontext.Produkte.Add(new() { Name = "Rotring Rapid", Preis = 40, Vorrat = 100, Strichcode = 1553 });

    //Console.WriteLine($"Kontext ID: {_kontext.ContextId}");

    //_kontext.Database.MigrateAsync();

    //_kontext.SaveChanges();

    #region DbSet Methoden mit Beispiele verwenden
    //DbSet Methoden

    //var produkte =  _kontext.Produkte.FirstOrDefault(p => p.ID == 17);//damit bekommt man leere Folge

    //var produkte = _kontext.Produkte.First(p => p.ID == 17);//damit bekommt man eine Ausnahme

    //Wenn man mit einer bestimmten Datei arbeiten wird, ist das besser, falls man SingleAsync Methode verwendet
    //var produkt = await _kontext.Produkte.SingleAsync(p => p.ID > 7);//damit findet man die Datei


    //Console.WriteLine($"{produkt.ID}:{produkt.Name} - {produkt.Preis} - {produkt.Vorrat} ");

    //var produkt = await _kontext.Produkte.Where(p => p.ID > 7 && p.Preis>100).ToListAsync();

    //var produkt = await _kontext.Produkte.FirstAsync(p => p.ID == 7);

    ////In diesem Fall ist Status von ID=7 detached. Also es wird nicht verfolgt
    //var produkt = await _kontext.Produkte.AsNoTracking().FirstAsync(p => p.ID == 7);

    //var produkt1 = await _kontext.Produkte.SingleAsync(p => p.Preis == 100);
    //var produkt2 = await _kontext.Produkte.FindAsync(7);

    //Mit First Async Methode kann man eine Variable ändern, dann wird Status Modified.
    //produkt.Vorrat = 300;
    //Console.WriteLine($"Zustand:{_kontext.Entry(produkt).State}");
    #region Datei hinzufügen
    var kategorie = new Kategorie()
    {
        Name = "Bücher"

    };
    var produkt = new Produkt()
    {
        Name = "Aspekte Neu C1",
        Preis = 55,
        Vorrat = 100,
        Strichcode = 1457,
        Kategorie = kategorie,
    };
    kategorie.Produkte.Add(new()
    {
        Name="Aspekte Neu B2",
        Preis=45,
        Vorrat=100,
        Strichcode=1452,
        Kategorie=kategorie //Ohne Kategorie zu schreiben,kann man ein Produkt hinzufügen

    });
    _kontext.Produkte.Add(produkt);
    _kontext.SaveChanges();
    Console.WriteLine("Die Datei wurde gespeichert!");
    #endregion
}
#endregion
#region EF Core Configuration


#endregion

