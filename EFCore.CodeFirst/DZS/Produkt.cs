using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DZS
{
    #region Mit Data Annotations Attributes Index Erstellen
    //[Index(nameof(Name),nameof(Preis))] -> Composite Index
    #endregion

    #region Tabelle benennen
    //[Table("ProduktTbl", Schema="produkte")]
    #endregion
    public class Produkt
    {

        public int ID { get; set; }
        public string Name { get; set; }
        [Precision(9, 2)]
        public decimal Preis { get; set; }
        [Precision(9,2)]
        public decimal RabattPreis { get; set; }
        public int Vorrat { get; set; }
        public int Strichcode { get; set; }
        public string Url { get; set; }
        public int KategorieID { get; set; }
        //public virtual Kategorie Kategorie { get; set; }
        //public virtual ProduktEigenschaft ProduktEigenschaft { get; set; }

        #region Spalte umbenennen
        //[Column(Order = 1)]//Dies ist erforderlich, wenn Sie eine neue Tabelle erstellen, um eine Spaltensortierung durchzuführen. Andernfalls ist diese Operation für eine vorhandene Tabelle nicht gültig.
        #endregion

        #region Spalte umbenennen
        //[Column("markenName", TypeName ="nvarchar(50) oder decimal(18,2)", Order = 2)]
        //[Required]
        //[StringLength(150,MinimumLength =150)] //Wenn man sowohl bei der Datenbank auch als
        //bei  FluentValidation Zeichenlänge verwenden möchte, soll hier es definieren
        //public string Name { get; set; }
        #endregion

        #region DatabaseGeneratedOption.None
        //Dieses Attribut kann verwendet werden, wenn der ID-Wert nicht erhöht werden soll.
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int ID { get; set; }
        #endregion

        #region DatabaseGenerated Attribute
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public decimal MwStPreis { get; set; }
        //public int MwSt { get; set; }
        //public DateTime ErstellungsDatum { get; set; } = DateTime.Now;
        #endregion

        #region 3.Weise mit ForeignKey Attribute FK erstellen
        //public int Kategorie_ID { get; set; }
        ////Navigation property
        //[ForeignKey("Kategorie_ID")]
        //public Kategorie Kategorie { get; set; }
        #endregion

        #region Setnull-Verhalten 
        //Um das Setnull-Verhalten zu verwenden, muss die Kategorie-ID ein Fragezeichen haben, damit sie leer sein kann
        //public int? KategorieID { get; set; }
        //public Kategorie? Kategorie { get; set; }
        //public ProduktEigenschaft ProduktEigenschaft { get; set; }
        #endregion

        #region Lazy Loading definieren
        //public virtual Kategorie Kategorie { get; set; }
        //public virtual ProduktEigenschaft ProduktEigenschaft { get; set; }
        #endregion

        #region Entity Properties(Model)
        #region Unicode
        //[Unicode(false)]//varchar
        //public string Name { get; set; }
        #endregion

        #region NotMapped
        //[NotMapped]
        //public int Strichcode { get; set; }
        #endregion

        #region Column
        //[Column("UrlName",TypeName ="nvarchar(200)",Order=7)]
        //public string Url { get; set; }
        #endregion
        #endregion


    }
}
