using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace KassaSystem
{
    public class Book
    {
        [DisplayName("Product Nr")]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public String Author { get; set; }
        public String Genre { get; set; }
        public String Format {get;set;}
        public String Language {get;set;}

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

        public int getStockCount() { return StockCount; }

        public void setStockCount(int stockCount) { StockCount = stockCount; }

        public override string ToString()
        {
            return $"Book: {Name}, {Price} kr";
        }
    }
}
