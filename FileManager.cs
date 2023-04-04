using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace KassaSystem
{
    public class FileManager
    {
        private readonly String filePath;

        public FileManager(string fileName)
        {
            string folderPath = Directory.GetCurrentDirectory();
            this.filePath = Path.Combine(folderPath, fileName);
        }

        public (BindingList<Book>, BindingList<Game>, BindingList<Movie>) LoadData(BindingList<Book> Books, 
            BindingList<Game> Games, BindingList<Movie> Movies)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    string[] fields = line.Split(',');
                    string id = fields[0];

                    if (id.StartsWith("1"))
                    {
                        Book newBook = new Book(
                            int.Parse(id),
                            fields[1],
                            int.Parse(fields[2]),
                            fields[3],
                            fields[4],
                            fields[5],
                            fields[6],
                            int.Parse(fields[7]));

                        Books.Add(newBook);
                    }
                    else if (id.StartsWith("2"))
                    {
                        Game newGame = new Game(
                            int.Parse(id),
                            fields[1],
                            int.Parse(fields[2]),
                            fields[3],
                            int.Parse(fields[4]));

                        Games.Add(newGame);
                    }
                    else
                    {
                        Movie newMovie = new Movie(
                            int.Parse(id),
                            fields[1],
                            int.Parse(fields[2]),
                            fields[3],
                            int.Parse(fields[4]),
                            int.Parse(fields[5]));

                        Movies.Add(newMovie);
                    }
                }
            }
            else
            {
                
            }
            return (Books, Games, Movies);
        }

        public void SaveData(BindingList<Book> Books, BindingList<Game> Games, BindingList<Movie> Movies)
        {
            var bookLines = Books.Select(product => product.ToString());
            File.WriteAllLines(filePath, bookLines);

            var gameLines = Books.Select(product => product.ToString());
            File.WriteAllLines(filePath, gameLines);

            var movieLines = Books.Select(product => product.ToString());
            File.WriteAllLines(filePath, movieLines);
        }
    }
}
