using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KassaSystem
{
    public class Movie 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Format { get; set; }
        private int LengthAsInt { get; set; }
        public string Length { get; set; }
        public int StockCount { get; set; }

        public Movie(int id, string name, int price, string format, int length, int stockCount)
        {
            Id = id;
            Name = name;
            Price = price;
            Format = format;
            LengthAsInt = length;
            Length = LengthAsInt.ToString() + " min";
            StockCount = stockCount;
        }

        public void setLength(int length) { LengthAsInt = length; }

        public int getStockCount() { return StockCount; }

        public void setStockCount(int stockCount) { StockCount = stockCount; }

        public override string ToString()
        {
            return $"Movie: {Name}, {Price} kr";
        }
    }
}
