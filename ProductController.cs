using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KassaSystem
{
    internal class ProductController
    {
        private FileManager FileManager;
        private BindingList<Book> Books;
        private BindingList<Game> Games;
        private BindingList<Movie> Movies;
        private List<Object> Cart;

        private BindingSource BookSource;
        private BindingSource GameSource;
        private BindingSource MovieSource;
        private BindingSource CartSource;

        public ProductController()
        {
            FileManager = new FileManager("data_from_store.csv");
            Books = new BindingList<Book>();
            Games = new BindingList<Game>();
            Movies = new BindingList<Movie>();
            Cart = new List<object>();

            BookSource = new BindingSource();
            GameSource = new BindingSource();
            MovieSource = new BindingSource();
            CartSource = new BindingSource();

            BookSource.DataSource = Books;
            GameSource.DataSource = Games;
            MovieSource.DataSource = Movies;
            CartSource.DataSource = Cart;

            var allLists = FileManager.LoadData(Books, Games, Movies);

            Books = allLists.Item1;
            Games = allLists.Item2;
            Movies = allLists.Item3;
        }
        
        public BindingList<Book> getBooks() { return Books; }
        public BindingSource getBookSource() { return BookSource; }

        public BindingList<Game> getGames() { return Games; }
        public BindingSource getGameSource() { return GameSource; }

        public BindingList<Movie> getMovies() { return Movies; }
        public BindingSource getMovieSource() { return MovieSource; }

        public BindingSource getCartSource() { return CartSource; }

        public delegate int StockCountGetter<T>(T item);

        public void RemoveProduct<T>(DataGridView dataGridView, StockCountGetter<T> getStockCount)
        {
            var selectedItem = dataGridView.SelectedRows[0].DataBoundItem;
            if (selectedItem is T)
            {
                var item = (T)selectedItem;
                int stockCount = getStockCount(item);
                if (stockCount > 0)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to remove the selected item?",
                                                           "The product is not out of stock", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (selectedItem is Book)
                        {
                            Books.Remove(selectedItem as Book);
                            BookSource.ResetBindings(false);
                        }
                        else if (selectedItem is Game)
                        {
                            Games.Remove(selectedItem as Game);
                            GameSource.ResetBindings(false);
                        }
                        else if (selectedItem is Movie)
                        {
                            Movies.Remove(selectedItem as Movie);
                            MovieSource.ResetBindings(false);
                        }
                    }
                }
                else
                {
                    if (selectedItem is Book)
                    {
                        Books.Remove(selectedItem as Book);
                        BookSource.ResetBindings(false);
                    }
                    else if (selectedItem is Game)
                    {
                        Games.Remove(selectedItem as Game);
                        GameSource.ResetBindings(false);
                    }
                    else if (selectedItem is Movie)
                    {
                        Movies.Remove(selectedItem as Movie);
                        MovieSource.ResetBindings(false);
                    }
                }
            }
        }


        public void AddProduct(DataGridView dataGridView, int id, string name, int price, string author,
            string genre, int stockCount, string format, string language, string platform, int length)
        {
            Random rand = new Random();
            if (id == 0)
            {
                do
                {
                    if(dataGridView.DataSource == BookSource) { id = rand.Next(1000, 2000); }
                    else if (dataGridView.DataSource == GameSource) { id = rand.Next(2000, 3000); }
                    else { id = rand.Next(3000, 4000); }
                } while (!CheckIfUniqueProdNr(id));
            }

            if (CheckIfUniqueProdNr(id))
            {
                if (dataGridView.DataSource == BookSource && id > 1000 && id < 2000)
                {
                    Book newBook = new Book(id, name, price, author, genre, format, language, stockCount);
                    Books.Add(newBook);
                    dataGridView.Refresh();
                    MessageBox.Show($"{newBook.Name} added successfully!");
                }
                else if (dataGridView.DataSource == GameSource && id > 2000 && id < 3000)
                {
                    Game newGame = new Game(id, name, price, platform, stockCount);
                    Games.Add(newGame);
                    dataGridView.Refresh();
                    MessageBox.Show($"{newGame.Name} added successfully!");
                }
                else if (dataGridView.DataSource == MovieSource && id > 3000 && id < 4000)
                {
                    Movie newMovie = new Movie(id, name, price, format, length, stockCount);
                    Movies.Add(newMovie);
                    dataGridView.Refresh();
                    MessageBox.Show($"{newMovie.Name} added successfully!");
                }
            }
            else
            {
                MessageBox.Show("Product number is already registered on another product. " +
                "Update the already registered one.");
            }
        }



        private bool CheckIfUniqueProdNr(int id)
        {
            foreach (var book in Books) { if (id == book.Id) { return false; } }
            foreach(var game in Games) { if (id == game.Id) { return false; } }
            foreach(var movie in Movies) { if (id == movie.Id) { return false; } }
            return true;
        }

      
        public void SaveChangesToProduct(DataGridView dataGridView, string name, int price, string author, 
            string genre, string format, string language, string platform, int length, int stockCount)
        {
            var selectedItem = dataGridView.SelectedRows[0].DataBoundItem;

            if (selectedItem is Book)
            {
                Book book = (Book)selectedItem;
                book.Name = name;
                book.Price = price;
                book.Author = author;
                book.Genre = genre;
                book.Format = format;
                book.Language = language;
                book.StockCount = stockCount;
            }
            else if (selectedItem is Game)
            {
                Game game = (Game)selectedItem;
                game.Name = name;
                game.Price = price;
                game.Platform = platform;
                game.StockCount = stockCount;
            }
            else
            {
                Movie movie = (Movie)selectedItem;
                movie.Name = name;
                movie.Price = price;
                movie.Format = format;
                movie.setLength(length);
                movie.StockCount = stockCount;
            }
            dataGridView.Refresh();
        }

        public List<Object> AddToCart(DataGridView dataGridViewCheckout)
        {
            var selectedItem = dataGridViewCheckout.SelectedRows[0].DataBoundItem;
            int nrInStock = 0;

            if (selectedItem is Book)
            {
                Book book = (Book)selectedItem;
                nrInStock = book.StockCount;
                if (nrInStock > 0)
                {
                    Cart.Add(book);
                    book.setStockCount(nrInStock - 1);
                }
                else { MessageBox.Show($"Sorry!\n{book.Name} is out of stock."); }

            }
            else if (selectedItem is Game)
            {
                Game game = (Game)selectedItem;
                nrInStock = game.StockCount;
                if (nrInStock > 0)
                {
                    Cart.Add(game);
                    game.setStockCount(nrInStock - 1);
                }
                else { MessageBox.Show($"Sorry!\n{game.Name} is out of stock."); }

            }
            else
            {
                Movie movie = (Movie)selectedItem;
                nrInStock = movie.StockCount;
                if (nrInStock > 0)
                {
                    Cart.Add(movie);
                    movie.setStockCount(nrInStock - 1);
                }
                else { MessageBox.Show($"Sorry!\n{movie.Name} is out of stock."); }

            }
            dataGridViewCheckout.Refresh();
            return Cart;
        }


        public int CalculateTotalAmount()
        {
            int sum = 0;
            if(Cart.Count > 0)
            {
                foreach (var product in Cart)
                {
                    if(product is Book)
                    {
                        Book book = (Book)product;
                        sum += book.Price;
                    }
                    else if(product is Game)
                    {
                        Game game = (Game)product;
                        sum += game.Price;
                    }
                    else
                    {
                        Movie movie = (Movie)product;
                        sum += movie.Price;
                    }
                }
            }
            return sum;
        }

        public void RemoveFromCart(ListBox cartListBox)
        {
            int selectedItemIndex = cartListBox.SelectedIndex;
            int nrInStock = 0;
            if(cartListBox.SelectedItems.Count > 0)
            {
                if (Cart[selectedItemIndex] is Book)
                {
                    Book book = (Book)Cart[selectedItemIndex];
                    nrInStock = book.StockCount;
                    book.setStockCount(nrInStock + 1);
                }
                else if (Cart[selectedItemIndex] is Game)
                {
                    Game game = (Game)Cart[selectedItemIndex];
                    nrInStock = game.StockCount;
                    game.setStockCount(nrInStock + 1);
                }
                else
                {
                    Movie movie = (Movie)Cart[selectedItemIndex];
                    nrInStock = movie.StockCount;
                    movie.setStockCount(nrInStock + 1);
                }
                Cart.RemoveAt(selectedItemIndex);
            }  
        }


        public void SellProducts()
        {
            string items = "Products sold:\n";
            foreach (var cart in Cart) { items += cart + "\n"; }
            MessageBox.Show($"{items}");
            Cart.Clear();
        }

        public void AddDelivery(DataGridView dataGridViewWarehouse, int amount)
        {
            var selecteditem = dataGridViewWarehouse.SelectedRows[0].DataBoundItem;
            int currentamount = 0;

            if (dataGridViewWarehouse.DataSource == BookSource)
            {
                Book book = (Book)selecteditem;
                currentamount = book.StockCount;
                book.StockCount = amount + currentamount;
                MessageBox.Show($"Delivery suceeded. New  amount in stock: {book.StockCount}");
            }
            else if(dataGridViewWarehouse.DataSource == GameSource)
            {
                Game game = (Game)selecteditem;
                currentamount = game.StockCount;
                game.StockCount = amount + currentamount;
                MessageBox.Show($"Delivery suceeded. New  amount in stock: {game.StockCount}");
            }
            else
            {
                Movie movie = (Movie)selecteditem;
                currentamount = movie.StockCount;
                movie.StockCount = amount + currentamount;
                MessageBox.Show($"Delivery suceeded. New  amount in stock: {movie.StockCount}");
            }
            dataGridViewWarehouse.Refresh();
        }
    }
}
