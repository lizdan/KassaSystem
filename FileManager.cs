using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Windows.Forms.LinkLabel;

namespace KassaSystem
{
    /**
     * A class to handle the file with information about products (books, games and movies).
     * Responsible for loading and saving data from and to Binding Lists for each category of product.
     * 
     * @Author Liza Danielsson.
     */
    public class FileManager
    {
        private readonly String FilePath;

        //Constructor.
        public FileManager(string fileName)
        {
                //Gets the current working-folder path and adds the filename to get the filepath to the file.
            string folderPath = Directory.GetCurrentDirectory();
            this.FilePath = Path.Combine(folderPath, fileName);
        }

        /// <summary>
        /// Loads information and separates all products into books, games and movies. Then saves all information in strings
        /// before creating new instances of each product with strings got from file. Finally the products are added to 
        /// the approriate BindingList before all lists are returned.
        /// </summary>
        /// <param name="Books">BindningList with all books that are added from file.</param>
        /// <param name="Games">BindningList with all games that are added from file.</param>
        /// <param name="Movies">BindningList with all movies that are added from file.</param>
        /// <returns>A tuple of the three BindingLists - Books, Games, Movies.</returns>
        public (BindingList<Book>, BindingList<Game>, BindingList<Movie>) LoadData(BindingList<Book> Books, 
            BindingList<Game> Games, BindingList<Movie> Movies)
        {
                //Default value for al strings.
            int id;
            string name;
            int price;
            string author = "";
            string genre = "";
            string format = "";
            string language = "";
            string platform = "";
            int length = 0;
            int stockCnt;

                //If file is found.
            if (File.Exists(FilePath))
            {
                    //Save all lines from file in string array.
                string[] lines = File.ReadAllLines(FilePath);

                    //Loop trough all lines.
                foreach (var line in lines)
                {   
                        //Split each line at every ",", save in new string array.
                    string[] fields = line.Split(',');
                    string idCheck = fields[0];

                        //Check if id saved from first array position starts with 1.
                    if (idCheck.StartsWith("1"))
                    {
                            //If so, try to save all values from array in the strings.
                        try
                        {
                            id = int.Parse(idCheck);
                            name = fields[1];
                            price = int.Parse(fields[2]);
                            author = fields[3];
                            genre = fields[4];
                            format = fields[5];
                            language = fields[6];
                            stockCnt = int.Parse(fields[7]);
                        }
                        catch
                        {
                            id = 0;
                            name = "";
                            price = 0;
                            stockCnt = 0;
                        }
                            //Create new book with the strings as properties.
                        Book newBook = new Book(id,name,price,author,genre,format,language,stockCnt);
                            //Add the book to the BindingList of books.
                        Books.Add(newBook);
                    }
                        //Do the same with games.
                    else if (idCheck.StartsWith("2"))
                    {
                        try
                        {
                            id = int.Parse(idCheck);
                            name = fields[1];
                            price = int.Parse(fields[2]);
                            platform = fields[3];
                            stockCnt = int.Parse(fields[4]);
                        }
                        catch
                        {
                            id = 0;
                            name = "";
                            price = 0;
                            stockCnt = 0;
                        }
                        Game newGame = new Game(id,name,price, platform,stockCnt);
                        Games.Add(newGame);
                    }
                        //Do the same with movies.
                    else
                    {
                        try
                        {
                            id = int.Parse(idCheck);
                            name = fields[1];
                            price = int.Parse(fields[2]);
                            format = fields[3];
                            length = int.Parse(fields[4]);
                            stockCnt = int.Parse(fields[5]);
                        }
                        catch
                        {
                            id = 0;
                            name = "";
                            price = 0;
                            stockCnt = 0;
                        }
                        Movie newMovie = new Movie(id,name,price,format,length,stockCnt);
                        Movies.Add(newMovie);
                    }
                }
            }
                //Return all BindningLists.
            return (Books, Games, Movies);
        }

        /// <summary>
        /// Replaces/saves all information in all BindningLists of books, games and movies to the csv file.
        /// </summary>
        /// <param name="Books">BindningList of all book instances.</param>
        /// <param name="Games">BindningList of all game instances.</param>
        /// <param name="Movies">BindningList of all movie instances.</param>
        public void SaveData(BindingList<Book> Books, BindingList<Game> Games, BindingList<Movie> Movies)
        {
                //List of strings to save to file.
            var lines = new List<string>();

                //Iterate through all books in BindingList of books and save each property to an IEnumerable interface(list of strings).
            var bookLines = Books.Select(book => string.Join(",", book.Id, book.Name, book.Price, book.Author, 
                book.Genre, book.Format, book.Language, book.StockCount));
                //Add all books in booklines to lines list.
            lines.AddRange(bookLines);

                //Same with games.
            var gameLines = Games.Select(game => string.Join(",", game.Id, game.Name, game.Price, game.Platform, game.StockCount));
            lines.AddRange(gameLines);

                //Same with movies.
            var movieLines = Movies.Select(movie => string.Join(",", movie.Id, movie.Name, movie.Price, movie.Format, movie.getLength(), movie.StockCount));
            lines.AddRange(movieLines);
                //Save list of all lines to file.
            File.WriteAllLines(FilePath, lines);
        }

        public XmlDocument GetSyncProducts(XmlDocument doc)
        {
            WebClient client = new WebClient();
            var text = client.DownloadString("https://hex.cse.kau.se/~jonavest/csharp-api");
            doc.LoadXml(text);
            doc.Save("CentralWarehouseProducts.xml");
            return doc;
        }
    }
}
