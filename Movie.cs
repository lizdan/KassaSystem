/**
     * Class that represent a movie, with essential properties and an override for ToString().
     * 
     * @author Liza Danielsson, lizadani101.
     * */

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
            if(LengthAsInt == 0) { Length = ""; }
            else { Length = LengthAsInt.ToString() + " min"; }
            StockCount = stockCount;
        }


        //To set length when changing information of a movie.
        public void setLength(int length) 
        { 
            LengthAsInt = length;
            if (LengthAsInt == 0) { Length = ""; }
            else { Length = LengthAsInt.ToString() + " min"; }
        }

        public int getLength() { return LengthAsInt; }

        public override string ToString()
        {
            return $"Movie: {Name}, {Price} kr";
        }
    }
}
