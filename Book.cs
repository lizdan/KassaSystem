using System.ComponentModel;


namespace KassaSystem
{
    /**
     * Class that represent a book, with essential properties and an override for ToString().
     * 
     * @author Liza Danielsson, lizadani101.
     * */
    public class Book
    {
        [DisplayName("Product Nr")]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Format {get;set;}
        public string Language {get;set;}

        [DisplayName("Stock Count")]
        public int StockCount { get; set; }



        public Book(int id, string name, int price, string author, string genre, string format, string language, int stockCount)
        {
            Id = id;
            Name = name;
            Price = price;
            Author = author;
            Genre = genre;
            Format = format;
            Language = language;
            StockCount = stockCount;
        }


        public override string ToString() { return $"Book: {Name}, {Price} kr"; }
    }
}
