/**
     * Class that represent a game, with essential properties and an override for ToString().
     * 
     * @author Liza Danielsson, lizadani101.
     * */

namespace KassaSystem
{
    public class Game 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Platform { get; set; }
        public int StockCount { get; set; }

        public Game(int id, string name, int price, string platform, int stockCount)
        {
            Id = id;
            Name = name;
            Price = price;
            Platform = platform;
            StockCount = stockCount;
        }


        public override string ToString()
        {
            return $"Game: {Name}, {Price} kr";
        }
    }
}
