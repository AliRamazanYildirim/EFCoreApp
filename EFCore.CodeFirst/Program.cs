// See https://aka.ms/new-console-template for more information

using EFCore.CodeFirst;
using EFCore.CodeFirst.DZS;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

Initialisierer.Build();
using (var _kontext = new AppDBKontext())
{

    #region EF Core Methoden
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
    #endregion

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
    #endregion

    #region One-To-Many Datei hinzufügen
    //var kategorie = new Kategorie()
    //{
    //    Name = "Bücher"

    //};
    //var produkt = new Produkt()
    //{
    //    Name = "Aspekte Neu C1",
    //    Preis = 55,
    //    Vorrat = 100,
    //    Strichcode = 1457,
    //    Kategorie = kategorie,
    //};
    //kategorie.Produkte.Add(new()
    //{
    //    Name="Aspekte Neu B2",
    //    Preis=45,
    //    Vorrat=100,
    //    Strichcode=1452,
    //    Kategorie=kategorie //Ohne Kategorie zu schreiben,kann man ein Produkt hinzufügen

    //});
    //_kontext.Produkte.Add(produkt);
    //_kontext.SaveChanges();
    //Console.WriteLine("Die Datei wurde gespeichert!");
    #endregion

    #region One-To-One Datei hinzufügen
    //Produkt -->Parent(Principal)
    //ProduktEigenschaft -->Childed(Dependent)
    #region 1.Weise

    //var kategorie = _kontext.Kategorien.First(k => k.Name == " Druckbleistift");
    //var produkt = new Produkt()
    //{
    //    Name = "Rotring 600",
    //    Preis = 35,
    //    Vorrat = 100,
    //    Strichcode = 1246,
    //    Kategorie=kategorie,

    //    ProduktEigenschaft= new()
    //    {
    //        Farbe="Rot",
    //        Grösse=10,
    //        Breite=10
    //    }
    //};
    #endregion
    #region 2.Weise

    //var kategorie = _kontext.Kategorien.First(k => k.Name == " Druckbleistift");
    //var produkt = new Produkt()
    //{
    //    Name = "Rotring 600",
    //    Preis = 35,
    //    Vorrat = 100,
    //    Strichcode = 1246,
    //    Kategorie = kategorie
    //};
    //ProduktEigenschaft produktEigenschaft = new ProduktEigenschaft()
    //{
    //    Farbe = "Schwarz",
    //    Grösse = 10,
    //    Breite = 2,
    //    Produkt = produkt
    //};
    //_kontext.ProduktEigenschaften.Add(produktEigenschaft);

    //_kontext.SaveChanges();

    //Console.WriteLine("Die Datei wurde gespeichert!");
    #endregion
    #endregion

    #region Many-To-Many Datei hinzufügen

    #region 1.Weise
    //var student = new Student()
    //{
    //    Name = "Ali",
    //    Alter = 20
    //};
    //student.Lehrer.Add(new()
    //{
    //    Name = "Elif"
    //});
    //_kontext.Add(student);
    //_kontext.SaveChanges();
    //Console.WriteLine("Die Datei wurde gespeichert!");
    #endregion
    #region 2.Weise
    //Wir können das obige Beispiel auch so durch Reverse Engineering spezifizieren.
    //var lehrer=new Lehrer()
    //{
    //    Name="Sare",
    //    Studenten=new List<Student>()
    //    { 
    //        new Student(){Name="Alparslan",Alter=22}
    //    }
    //};
    //lehrer.Studenten.Add(new Student
    //{
    //    Name="Erkam",
    //    Alter=21
    //});
    //_kontext.Add(lehrer);
    //_kontext.SaveChanges();
    //Console.WriteLine("Die Datei wurde gespeichert!");
    #endregion
    #region Aktualisierung eines bestehenden Lehrers
    //var lehrer = _kontext.Lehrer.First(l => l.Name == "Elif");

    //lehrer.Studenten.AddRange(new List<Student> {

    //    new() { Name = "Osman", Alter = 23 },
    //    new() { Name = "Ebrar", Alter = 23 }
    //});

    //_kontext.SaveChanges();
    //Console.WriteLine("Die Datei wurde gespeichert!");
    #endregion
    #endregion

    #region Relationships Delete Behaviors
    #region Cascade
    //var kategorie =new Kategorie() { Name="Druckbleistift",Produkte=new List<Produkt>()
    //{
    //    new Produkt(){Name="Rotring 500",Preis=65,Strichcode=12478},
    //     new Produkt(){Name="Rotring 600",Preis=65,Strichcode=12478}
    //}
    //};
    //_kontext.Add(kategorie);
    //_kontext.SaveChanges();
    //Console.WriteLine("Die Datei wurde gespeichert!");

    //var kategorie = _kontext.Kategorien.First();
    //_kontext.Kategorien.Remove(kategorie);
    //_kontext.SaveChanges();
    //Console.WriteLine("Die Datei wurde gelöscht!");
    #endregion
    #region Restrict
    //var kategorie = new Kategorie()
    //{
    //    Name = "Druckbleistift",
    //    Produkte = new List<Produkt>()
    //{
    //    new Produkt(){Name="Rotring 500",Preis=65,Strichcode=12478},
    //     new Produkt(){Name="Rotring 600",Preis=65,Strichcode=12478}
    //}
    //};
    //_kontext.Add(kategorie);
    //_kontext.SaveChanges();
    //Console.WriteLine("Die Datei wurde gespeichert!");

    //Der folgende Code wird geschrieben, um die Kategorie und Produkte, die sich auf diese Kategorie beziehen, zu löschen.

    //var kategorie = _kontext.Kategorien.First();
    //var produkts=_kontext.Produkte.Where(p=>p.KategorieID==kategorie.ID).ToList();
    //_kontext.RemoveRange(produkts);
    //_kontext.Kategorien.Remove(kategorie);
    //_kontext.SaveChanges();
    //Console.WriteLine("Die Datei wurde gelöscht!");
    #endregion
    #region NoAction
    //
    #endregion
    #region SetNull
    //var kategorie = new Kategorie()
    //{
    //    Name = "Druckbleistift",
    //    Produkte = new List<Produkt>()
    //    {
    //        new Produkt() { Name = "Rotring 800", Preis = 55, Vorrat = 100, Strichcode = 1456987 },
    //        new Produkt() { Name = "Rotring 600", Preis = 45, Vorrat = 100, Strichcode = 1476587 }
    //    }
    //};
    //_kontext.Add(kategorie);
    //_kontext.SaveChanges();
    //Console.WriteLine("Datei wurde gespeichert!");

    //var kategorie = _kontext.Kategorien.First();

    //_kontext.Kategorien.Remove(kategorie);
    //_kontext.SaveChanges();
    //Console.WriteLine("Datei wurde gelöscht!");
    #endregion
    #endregion

    #region DatabaseGenerated Attribute
    //_kontext.Produkte.Add(new()
    //{
    //    Name="Rotring 500",
    //    Preis=46,
    //    Strichcode=1456987,
    //    Vorrat=100
    //});
    //_kontext.SaveChanges();
    //Console.WriteLine("Das Produkt wurde gespeichert!");
    #endregion

    #region Related Data Load
    #region Eager Loading

    //var kategorie = new Kategorie() { Name = "Aspekte" };
    //kategorie.Produkte.Add(new()
    //{
    //    Name = "Aspekte Neu B1",
    //    Preis = 40,
    //    Vorrat = 100,
    //    Strichcode = 158831,
    //    ProduktEigenschaft = new() { Farbe = "Rot", Grösse = 30, Breite = 15 }

    //});
    //kategorie.Produkte.Add(new()
    //{
    //    Name = "Aspekte Neu B2",
    //    Preis = 45,
    //    Vorrat = 100,
    //    Strichcode = 1454331,
    //    ProduktEigenschaft = new() { Farbe = "Blau", Grösse = 30, Breite = 15 }

    //});
    //await _kontext.AddAsync(kategorie);
    //await _kontext.SaveChangesAsync();
    //Console.WriteLine("Das Buch wurde gespeichert!");

    //var kategorieMitProdukte=_kontext.Kategorien.Include(k=>k.Produkte).ThenInclude(p=>p.ProduktEigenschaft).First();

    // kategorieMitProdukte.Produkte.ForEach(produkt =>
    //{
    //    Console.WriteLine($"{kategorieMitProdukte.Name}{produkt.Name}{produkt.ProduktEigenschaft.Farbe } ");
    //});

    //Eager Loading ermöglicht es uns, bestehende Tabellen zusammenzuführen.

    //var produkt = _kontext.Produkte.Include(pro=>pro.ProduktEigenschaft).Include(proEig=>proEig.Kategorie).First();

    //Console.WriteLine("Das Buch wurde gespeichert!");
    #endregion
    #region Explicit Loading

    //One-To-Many (Collection)

    //var kategorie = _kontext.Kategorien.First();
    //if (kategorie != null)
    //{
    //    _kontext.Entry(kategorie).Collection(p => p.Produkte).Load();
    //    kategorie.Produkte.ForEach(produkt =>
    //    {
    //        Console.WriteLine($"{produkt.Name}-{produkt.Preis}-{produkt.Vorrat}");
    //    });
    //}

    //One-To-One (Reference)

    //var produkt = _kontext.Produkte.First();
    //if (produkt != null)
    //{
    //    //1.Weise
    //    _kontext.ProduktEigenschaften.Where(p => p.ID == produkt.ID).First();
    //    //2.Weise (Best practice)
    //    _kontext.Entry(produkt).Reference(p => p.ProduktEigenschaft).Load();

    //        Console.WriteLine($"{produkt.Name}-{produkt.Preis}-{produkt.Vorrat}");

    //}
    #endregion
    #region Lazy Loading 
    //Navigationseigenschaften müssen virtuell sein, um die Lazy Loading-Funktion verwenden zu können.

    //var kategorie = await _kontext.Kategorien.FirstAsync();
    //Console.WriteLine("Kategorie wurde aufgerufen");
    //var produkte=kategorie.Produkte;


    //foreach(var produkt in produkte)
    //{
    //    //N+1 Problem
    //    var produktEigenschaft = produkt.ProduktEigenschaft;
    //}
    //Console.WriteLine("Die Transaktion ist vorbei");
    #endregion
    #endregion

    #region Inheritance(Übernahme)
    #region TPH(Table-Per-Hierarchy)

    //Die Datei aufrufen

    //var manager = _kontext.Manager.ToList();
    //var arbeiter = _kontext.Arbeiter.ToList();
    //var personal = _kontext.BasisPersonal.ToList();

    //personal.ForEach(a =>
    //{
    //    switch(a)
    //    {
    //        case Manager manager:
    //            Console.WriteLine($"Manager Einheit:{manager.Grad}");
    //            break;
    //            case Arbeiter arbeiter:
    //            Console.WriteLine($"Arbeiter Einheit:{arbeiter.Gehalt}");

    //            break;
    //        default:
    //            break;
    //    }
    //});
    //Die Datei hinzufügen

    //_kontext.BasisPersonal.Add(new Manager() { VorName = "Ali", NachName = "Bozkurt", Alter = 23, Grad = 1 } );
    //_kontext.BasisPersonal.Add(new Arbeiter() { VorName = "Alparslan", NachName = "Osmanoglu", Alter = 23, Gehalt=4500 });
    // _kontext.SaveChanges();
    #endregion
    #region TPT(Table-Per-Type)

    //Die Datei aufrufen

    //var manager = _kontext.Manager.ToList();
    //var arbeiter = _kontext.Arbeiter.ToList();
    //var personal = _kontext.BasisPersonal.ToList();

    //personal.ForEach(a =>
    //{
    //    switch (a)
    //    {
    //        case Manager manager:
    //            Console.WriteLine($"Manager Einheit:{manager.Grad}");
    //            break;
    //        case Arbeiter arbeiter:
    //            Console.WriteLine($"Arbeiter Einheit:{arbeiter.Gehalt}");

    //            break;
    //        default:
    //            break;
    //    }
    //});

    //_kontext.Manager.Add(new Manager() { VorName = "Ali", NachName = "Bozkurt", Alter = 23, Grad = 1 } );
    //_kontext.Arbeiter.Add(new Arbeiter() { VorName = "Alparslan", NachName = "Bozkurt", Alter = 23, Gehalt=4500 });

    //Man kann sowohl mit obene Klassen als auch mit BasisPersonal Klasse Datei hinzufügen

    //_kontext.BasisPersonal.Add(new Manager() { VorName = "Elif", NachName = "Bozkurt", Alter = 23, Grad = 1 });
    //_kontext.BasisPersonal.Add(new Arbeiter() { VorName = "Sare", NachName = "Bozkurt", Alter = 23, Gehalt = 4500 });


    //_kontext.SaveChanges();
    #endregion
    #endregion

    #region Convention Coding
    //var kategorie = new Kategorie()
    //{
    //    Name = "Bücher"

    //};

    //kategorie.Produkte.Add(new()
    //{
    //    Name = "Aspekte Neu B2",
    //    Preis = 45,
    //    Vorrat = 100,
    //    Strichcode = 1452,
    //    ProduktEigenschaft = new() { Farbe = "Rot", Grösse = 10, Breite = 10 },
    //});
    //kategorie.Produkte.Add(new()
    //{
    //    Name = "Aspekte Neu B1",
    //    Preis = 40,
    //    Vorrat = 100,
    //    Strichcode = 1453,
    //    ProduktEigenschaft = new() { Farbe = "Grün", Grösse = 10, Breite = 10 },
    //});

    //_kontext.Kategorien.Add(kategorie);
    //_kontext.SaveChanges();
    //Console.WriteLine("Die Datei wurde gespeichert!");
    #endregion

    #region Keyless mit RawSql
    // Mit Keyless keyword kann man nicht CRUD Transaktionen ausführen
    //_kontext.Personal.Add(new Personal() { VorName = "Ali", NachName = "Bozkurt", Alter = 22 });
    //var speziellesProdukte = _kontext.SpeziellesProdukte.FromSqlRaw(@"select p.ID 'Produkt_ID', k.Name 'KategorieName',
    //p.Name,p.Preis,pe.Grösse from Produkte p 
    //join ProduktEigenschaften pe on p.ID=pe.ID
    //join Kategorien k on p.KategorieID=k.ID").ToList();
    //Console.WriteLine("Die Datei wurde gespeichert!");

    #endregion

    #region Mit Check Constraints Preis Behandlung leiten
    //_kontext.Produkte.Add(new()
    //{
    //    Name = "Aspekte Neu B2",
    //    Preis = 50,
    //    RabattPreis = 10,
    //    Vorrat = 100,
    //    Strichcode = 158831,
    //    Url = "adfsafdlkslfkdsf"


    //});
    //_kontext.SaveChanges();
    //Console.WriteLine("Das Buch wurde gespeichert!");
    #endregion

    #region  Mit Index Datei aufrufen

    //Produkt produkt = (new()
    //{
    //    Name = "Aspekte Neu B2",
    //    Preis = 40,
    //    RabattPreis = 100,
    //    Vorrat = 100,
    //    Strichcode = 158831,
    //    Url = "adfsafdlkslfkdsf"


    //});
    //if (produkt.RabattPreis > produkt.Preis)
    //{
    //    throw new Exception("RabattPreis soll nicht größer als Preis sein");
    //}

    //_kontext.Produkte.Where(ind => ind.Name == "Aspekte Neu B2").Select(ind => new
    //{
    //    name = ind.Name,
    //    preis = ind.Preis,
    //    vorrat = ind.Vorrat,
    //    strichCode = ind.Strichcode
    //});
    //_kontext.SaveChanges();
    //Console.WriteLine($"{produkt.Name}-{produkt.Preis}-{produkt.Vorrat}");

    #endregion

    #region Query (Abfrage)

    #region Query (Client - Server Evaluation)
    //Wie unten geschrieben kann man nicht Abfrage machen, weil Ef Core kann nicht wahrnehmen,ob es eine Abfrage ist.
    //var leiter = _kontext.Leiter.Where(l => NummerFormat(l.Nummer) == "05054147898").ToList();

    //var leiter = _kontext.Leiter.ToList().Where(l => NummerFormat(l.Nummer) == "5054147898").ToList();

    //Local Function kann man nur als Client wie unten geschrieben verwenden.

    //var leiter = _kontext.Leiter.ToList().Select(l => new { LeiterName = l.Name,
    //    LeiterNummer = NummerFormat(l.Nummer) }).ToList();


    //_kontext.Leiter.Add(new Leiter() { Name = "Ali", Nummer = "05054147898" });
    //_kontext.Leiter.Add(new Leiter() { Name = "Elif", Nummer = "05354147898" });
    //_kontext.SaveChanges();
    //Console.WriteLine("Der Personal wurde gespeichert");
    #endregion

    #region Inner Join

    //1.Weise(Zu Dritt Table erstellen)

    //Method Syntax

    //var resultat = _kontext.Kategorien.Join(_kontext.Produkte, k => k.ID, p => p.KategorieID, (k, p) => new { k, p })
    //    .Join(_kontext.ProduktEigenschaften, p => p.p.ID, pe => pe.ID, (k, pe) => new
    //    {
    //        KategorieName = k.k.Name,
    //        ProduktName = k.p.Name,
    //        ProduktEigenschaftFarbe = pe.Farbe
    //    });

    //var resultat2 = (from k in _kontext.Kategorien
    //                 join p in _kontext.Produkte
    //                 on k.ID equals p.KategorieID      //**Best practice
    //                 select p).ToList();

    //var resultat3 = (from k in _kontext.Kategorien
    //                 join p in _kontext.Produkte on k.ID equals p.KategorieID
    //                 join pe in _kontext.ProduktEigenschaften on p.ID equals pe.ID
    //                 select new { k, p, pe }).ToList();                              //**Best practice 

    //resultat3.ForEach(p =>
    //{
    //    p.p.Name = "Aspekte Neu B1";
    //    p.k.Name = "Bücher";
    //    p.pe.Farbe = "Rot";
    //});

    //Console.WriteLine("");

    //2.Weise(Zu Zweit Tabelle erstellen)

    //var resultat = _kontext.Kategorien.Join(_kontext.Produkte, k => k.ID, p => p.KategorieID, (k, p) => new
    //{
    //    KategorieName = k.Name,
    //    ProduktName = p.Name,
    //    ProduktPreis = p.Preis
    //}).ToList();


    //var resultat2 = _kontext.Kategorien.Join(_kontext.Produkte, k => k.ID, p => p.KategorieID, (k, p) => p).ToList();

    //var resultat3 = (from k in _kontext.Kategorien
    //                 join p in _kontext.Produkte
    //                 on k.ID equals p.KategorieID
    //                 select new
    //                 {
    //                     KategorieName = k.Name,
    //                     ProduktName = p.Name,
    //                     ProduktPreis = p.Preis
    //                 }).ToList();
    //Console.WriteLine("");

    #endregion

    #region Left+Right Join (Full Outer Join)
    //Query Syntax

    //var link =await (from p in _kontext.Produkte
    //         join pe in _kontext.ProduktEigenschaften on p.ID equals pe.ID into peList
    //         from pe in peList.DefaultIfEmpty()
    //         select new
    //         {
    //             ID=p.ID,
    //             ProduktName=p.Name,
    //             ProduktFarbe=pe.Farbe
    //         }).ToListAsync();

    //var rechts = await (from pe in _kontext.ProduktEigenschaften
    //                   join p in _kontext.Produkte on pe.ID equals p.ID into plist
    //                   from p in plist.DefaultIfEmpty()
    //                   select new
    //                   {
    //                       ID = p.ID,
    //                       ProduktName = p.Name,
    //                       ProduktFarbe = pe.Farbe
    //                   }).ToListAsync();

    //var outerJoin = link.Union(rechts);

    //outerJoin.ToList().ForEach(o =>
    //{
    //    Console.WriteLine($"{o.ID} - {o.ProduktName} - {o.ProduktFarbe}");
    //});
    #endregion

    #region Raw Sql Query (Rohe SQL-Abfrage)

    #region 1.Weise mit FromSqlRaw
    //var produkte = await _kontext.Produkte.FromSqlRaw("Select * From Produkte").ToListAsync();

    //var wert = String.Format("produkte:{0}-{1}", 1, "Ali"); wie unten verwendet wurde

    //Mit Parameter

    //var id = 1;
    //decimal preis = 30;
    //var produkt = await _kontext.Produkte.FromSqlRaw("Select * From Produkte Where id={0}",id).FirstAsync();
    //var produkte = await _kontext.Produkte.FromSqlRaw("Select * From Produkte Where preis>{0}", preis).ToListAsync();
    //Console.WriteLine("");
    #endregion

    #region 2.Weise mit FromSqlInterpolated

    //var id = 1;
    //decimal preis = 30;
    //var produkt = await _kontext.Produkte.FromSqlInterpolated($"Select * From Produkte Where id={id}").FirstAsync();
    //var produkte = await _kontext.Produkte.FromSqlInterpolated($"Select * From Produkte Where preis>{preis}").ToListAsync();

    //Console.WriteLine("");
    #endregion

    #region 3.Weise mit FromSqlInterpolated spezielle Abfrage schreiben

    //var produkt = await _kontext.WesentlichProdukte.FromSqlInterpolated($"Select  Name, Preis From Produkte ").ToListAsync();
    //var produkte = await _kontext.ProduktMitProEigenschaften.FromSqlInterpolated
    //    ($"Select p.ID,p.Name,p.Preis,pe.Farbe,pe.Grösse From Produkte p inner join ProduktEigenschaften pe on p.ID=pe.ID").ToListAsync();
    //Console.WriteLine("");
    #endregion

    #region ToSqlQuery Methode(Spezille Abfrage)
    var produkte = _kontext.WesentlichProdukte.Where(p=>p.Preis>30).ToList();
    Console.WriteLine("");
    #endregion

    #endregion

    #endregion
}
#region Benutzerdefinierte Methode für Abfrage(Client)
//string NummerFormat(string nummer)
//{
//    return nummer.Substring(1, nummer.Length - 1);
//}
#endregion
