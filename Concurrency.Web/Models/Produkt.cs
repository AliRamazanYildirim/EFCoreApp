namespace Concurrency.Web.Models
{
    public class Produkt
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Preis { get; set; }
        public int Vorrat { get; set; }
        public byte[] RowVersion { get; set; } = new byte[0];

    }
}
