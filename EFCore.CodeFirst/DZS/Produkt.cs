﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DZS
{
    //[Table("ProduktTb", Schema="produkte")]
    public class Produkt
    {
        #region Spalte umbenennen
        //[Column(Order = 1)]//Dies ist erforderlich, wenn Sie eine neue Tabelle erstellen, um eine Spaltensortierung durchzuführen. Andernfalls ist diese Operation für eine vorhandene Tabelle nicht gültig.
        #endregion
        #region
        //Bu öznitelik, kimlik değerinin artırılmaması gerektiğinde kullanılabilir.
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        #endregion
        public int ID { get; set; }

        #region Spalte umbenennen
        //[Column("markenName", Order = 2)]
        //[Required]
        //[StringLength(150,MinimumLength =150)] //Wenn man sowohl bei der Datenbank auch als bei  FluentValidation Zeichenlänge verwenden möchte, soll hier es definieren
        #endregion

        public string Name { get; set; }
        public decimal Preis { get; set; }
        public int Vorrat { get; set; }
        public int Strichcode { get; set; }
        public int MwSt { get; set; }
        
        #region DatabaseGenerated Attribute
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal MwStPreis { get; set; }
        //public DateTime ErstellungsDatum { get; set; } = DateTime.Now;
        #endregion
        #region 3.Weise mit ForeignKey Attribute FK erstellen
        //public int Kategorie_ID { get; set; }
        ////Navigation property
        //[ForeignKey("Kategorie_ID")]
        //public Kategorie Kategorie { get; set; }
        #endregion

        //Um das Setnull-Verhalten zu verwenden, muss die Kategorie-ID ein Fragezeichen haben, damit sie leer sein kann
        //public int? KategorieID { get; set; }
        //public Kategorie? Kategorie { get; set; }
        //public ProduktEigenschaft ProduktEigenschaft { get; set; }
    }
}
