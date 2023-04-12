using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

/**
 * This class manages the data and operations related to all products in the store.
 * This class is responsible for loading and saving data from Filemanager class, managing the inventory and informations
 * of books, games, and movies in the store, as well as handling cart and delivery operations.
 * 
 * @Author Liza Danielson, lizadani101.
 * */

namespace KassaSystem
{
    public class ProductController
    {
        private FileManager FileManager;

        private BindingList<Book> Books;
        private BindingList<Game> Games;
        private BindingList<Movie> Movies;
        private List<object> Cart;
        private List<object> Deliveries;

        private BindingSource BookSource = new BindingSource();
        private BindingSource GameSource = new BindingSource();
        private BindingSource MovieSource = new BindingSource();
        private BindingSource CartSource = new BindingSource();
        private BindingSource DeliverySource = new BindingSource();


        //Constructor.
        public ProductController()
        {
            FileManager = new FileManager("data_from_store.csv");

            Books = new BindingList<Book>();
            Games = new BindingList<Game>();
            Movies = new BindingList<Movie>();
            Cart = new List<object>();
            Deliveries = new List<object>();

            BookSource.DataSource = Books;
            GameSource.DataSource = Games;
            MovieSource.DataSource = Movies;
            CartSource.DataSource = Cart;
            DeliverySource.DataSource = Deliveries;

                //Save all BindningLists into one variable that holds all Bindninglists returned from Filemanager.
            var allLists = FileManager.LoadData(Books, Games, Movies);

                //Separates all BidningLists into three separate BindingLists.
            Books = allLists.Item1;
            Games = allLists.Item2;
            Movies = allLists.Item3;
        }




        /// <summary>
        /// Displays the DataGridView with products based on the type of product, which is decided by an id sent to method.
        /// </summary>
        /// <param name="dataGridView">The DataGridView to populate.</param>
        /// <param name="typeOfProduct">The type of product to load.</param>
        public void LoadDataIntoGridView(DataGridView dataGridView, int typeOfProduct)
        {
            if(typeOfProduct == 0) 
            { 
                dataGridView.DataSource = BookSource;
                dataGridView.Columns["Id"].DisplayIndex = 0;
                dataGridView.Columns["Name"].DisplayIndex = 1;
                dataGridView.Columns["Price"].DisplayIndex = 2;
                dataGridView.Columns["Author"].DisplayIndex = 3;
                dataGridView.Columns["Genre"].DisplayIndex = 4;
                dataGridView.Columns["Format"].DisplayIndex = 5;
                dataGridView.Columns["Language"].DisplayIndex = 6;
                dataGridView.Columns["StockCount"].DisplayIndex = 7;
            }
            else if(typeOfProduct == 1) 
            { 
                dataGridView.DataSource = GameSource;
                dataGridView.Columns["Id"].DisplayIndex = 0;
                dataGridView.Columns["Name"].DisplayIndex = 1;
                dataGridView.Columns["Price"].DisplayIndex = 2;
                dataGridView.Columns["Platform"].DisplayIndex = 3;
                dataGridView.Columns["StockCount"].DisplayIndex = 4;
            }
            else 
            { 
                dataGridView.DataSource = MovieSource;
                dataGridView.Columns["Id"].DisplayIndex = 0;
                dataGridView.Columns["Name"].DisplayIndex = 1;
                dataGridView.Columns["Price"].DisplayIndex = 2;
                dataGridView.Columns["Format"].DisplayIndex = 3;
                dataGridView.Columns["Length"].DisplayIndex = 4;
                dataGridView.Columns["StockCount"].DisplayIndex = 5;
            }
        }




        /// <summary>
        /// Gets selected product in dataGridView and saves each property of the product in strings, which are added to a list.
        /// </summary>
        /// <param name="dataGridView">The dataGridView to get selected product from.</param>
        /// <returns>List<string> with properties of the selected product.</string></returns>
        public List<String> FillTextBoxesWhenSelected(DataGridView dataGridView)
        {
                //Set all strings to default value (empty).
            List<String> AllInformation = new List<String>();
            string prodNr = "";
            string name = "";
            string price = "";
            string author = "";
            string genre = "";
            string format = "";
            string language = "";
            string platform = "";
            string length = "";
            string stockCount = "";

            if (dataGridView.SelectedRows.Count > 0)
            {
                    //Get the selected product from the dataGridView.
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                
                    //Check if book.
                if (selectedRow.DataBoundItem is Book book)
                {
                        //Save the selected products properties in all strings.
                    prodNr = book.Id.ToString();
                    name = book.Name;
                    price = book.Price.ToString();
                    author = book.Author;
                    genre = book.Genre;
                    format = book.Format;
                    language = book.Language;
                    stockCount = book.StockCount.ToString();
                }
                    //Check if game.
                else if (selectedRow.DataBoundItem is Game game)
                {
                    prodNr = game.Id.ToString();
                    name = game.Name;
                    price = game.Price.ToString();
                    platform = game.Platform;
                    stockCount = game.StockCount.ToString();
                }
                    //Check if movie.
                else if (selectedRow.DataBoundItem is Movie movie)
                {
                    prodNr = movie.Id.ToString();
                    name = movie.Name;
                    price = movie.Price.ToString();
                    format = movie.Format;
                    string[] lengthMin = movie.Length.Split();
                    length = lengthMin[0];
                    stockCount = movie.StockCount.ToString();
                }
                    //Add each string to the list of strings.
                AllInformation.Add(prodNr);
                AllInformation.Add(name);
                AllInformation.Add(price);
                AllInformation.Add(author);
                AllInformation.Add(genre);
                AllInformation.Add(format);
                AllInformation.Add(language);
                AllInformation.Add(platform);
                AllInformation.Add(length);
                AllInformation.Add(stockCount);
            }
            return AllInformation;
        }




        /// <summary>
        /// Checks if product is out of stock, prompts user to remove or not and removes the product from the appropriate list.
        /// Also resets the bindings for the appropriate data source.
        /// </summary>
        /// <param name="dataGridView">The datagridview from where the product is chosen by user.</param>
        /// <returns>bool, true if product removed and false if not.</returns>
        public bool RemoveProduct(DataGridView dataGridView)
        {
                // Get the selected item from the data grid view.
            var selectedItem = dataGridView.SelectedRows[0].DataBoundItem;
            int stockCount;
                //Set answer default to no.
            DialogResult result = DialogResult.No;

               
            if (dataGridView.DataSource == BookSource)
            {
                Book book = (Book)selectedItem;
                    //Get stock count for selected book. Show prompt if not out of stock.
                stockCount = book.StockCount;
                if (stockCount > 0)
                {
                    result = MessageBox.Show($"It's still {book.StockCount} in stock.",
                                                           $"Remove {book.Name}?.", MessageBoxButtons.YesNo);
                }
                    //Remove if out of stock or user clicks yes.
                if (stockCount == 0 || result == DialogResult.Yes)
                {
                    Books.Remove(book);
                    BookSource.ResetBindings(false);
                    return true;
                }
            }
                //Same if source is games.
            else if (dataGridView.DataSource == GameSource)
            {
                Game game = (Game)selectedItem;
                stockCount = game.StockCount;
                if (stockCount > 0)
                {
                    result = MessageBox.Show($"It's still {game.StockCount} in stock.",
                                                           $"Remove {game.Name}?.", MessageBoxButtons.YesNo);
                }
                if (stockCount == 0 || result == DialogResult.Yes)
                {
                    Games.Remove(game);
                    GameSource.ResetBindings(false);
                    return true;
                }
            }
                //Same with movies. 
            else
            {
                Movie movie = (Movie)selectedItem;
                stockCount = movie.StockCount;
                if (stockCount > 0)
                {
                    result = MessageBox.Show($"It's still {movie.StockCount} in stock.",
                                                           $"Remove {movie.Name}?.", MessageBoxButtons.YesNo);
                }
                if (stockCount == 0 || result == DialogResult.Yes)
                {
                    Movies.Remove(movie);
                    MovieSource.ResetBindings(false);
                    return true;
                } 
            }
            return false;
        }



        
        /// <summary>
        /// Adds a new product (book, game, or movie) to the corresponding list and DataGridView.
        /// DataGridView: The DataGridView to update.
        /// Id: Unique product ID; if 0, generate a random unique ID.
        /// </summary>
        /// Name, price, author, genre, stockCount, format, language, platform, length: Product attributes.
        /// <returns> Bool: true if product added successfully, false otherwise. </returns>
        public bool AddProduct(DataGridView dataGridView, int id, string name, int price, string author,
            string genre, int stockCount, string format, string language, string platform, int length)
        {
                // Generate a unique product ID if id is 0
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

                // Set stockCount to 0 if it's -1
            if (stockCount == -1) { stockCount = 0; }

                // Check if the product ID is unique
            if (CheckIfUniqueProdNr(id))
            {
                    //Add a new book.
                if (dataGridView.DataSource == BookSource && id >= 1000 && id < 2000)
                {
                    Book newBook = new Book(id, name, price, author, genre, format, language, stockCount);
                    Books.Add(newBook);
                    dataGridView.Refresh();
                    MessageBox.Show($"{newBook.Name} was added successfully with product number {newBook.Id}!",
                        "Confirmation.",MessageBoxButtons.OK);
                    return true;
                }
                    //Add a new game.
                else if (dataGridView.DataSource == GameSource && id >= 2000 && id < 3000)
                {
                    Game newGame = new Game(id, name, price, platform, stockCount);
                    Games.Add(newGame);
                    dataGridView.Refresh();
                    MessageBox.Show($"{newGame.Name} was added successfully with product number {newGame.Id}!", 
                        "Confirmation.", MessageBoxButtons.OK);
                    return true;
                }
                    //Add a new movie.
                else if (dataGridView.DataSource == MovieSource && id >= 3000 && id < 4000)
                {
                    Movie newMovie = new Movie(id, name, price, format, length, stockCount);
                    Movies.Add(newMovie);
                    dataGridView.Refresh();
                    MessageBox.Show($"{newMovie.Name} was added successfully with product number {newMovie.Id}!",
                        "Confirmation.", MessageBoxButtons.OK);
                    return true;
                }
            }
                // Show error message if product ID is not unique
            else
            {
                MessageBox.Show("Product number is already registered on another product. " +
                "Update the already registered one.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return false;
        }




        /// <summary>
        /// Checks if id that is sent to method (users input) already excists amoungst excisting products.
        /// </summary>
        /// <param name="id">Uniqe id that user enters.</param>
        /// <returns>Bool: true if the id is uniqe, false if not.</returns>
        private bool CheckIfUniqueProdNr(int id)
        {
            foreach (var book in Books) { if (id == book.Id) { return false; } }
            foreach(var game in Games) { if (id == game.Id) { return false; } }
            foreach(var movie in Movies) { if (id == movie.Id) { return false; } }
            return true;
        }




        /// <summary>
        /// Updates each property of a specific product with information entered by user.  
        /// </summary>
        /// Name, Price, Author, Genre, Format, Language, Platform, Length: Properties of a product.
        public void SaveChangesToProduct(DataGridView dataGridView, string name, int price, string author, 
            string genre, string format, string language, string platform, int length)
        {
            var selectedItem = dataGridView.SelectedRows[0].DataBoundItem;
                // Update the attributes of a selected book, if book.
            if (selectedItem is Book)
            {
                Book book = (Book)selectedItem;
                book.Name = name;
                book.Price = price;
                book.Author = author;
                book.Genre = genre;
                book.Format = format;
                book.Language = language;
            }
                // Update the attributes of a selected game, if game.
            else if (selectedItem is Game)
            {
                Game game = (Game)selectedItem;
                game.Name = name;
                game.Price = price;
                game.Platform = platform;
            }
             // Else, update the attributes of a selected movie.
            else
            {
                Movie movie = (Movie)selectedItem;
                movie.Name = name;
                movie.Price = price;
                movie.Format = format;
                movie.setLength(length);
            }
            dataGridView.Refresh();
        }




        /// <summary>
        /// Adds a selected product to a list "Cart" and updates the ListBox to show each product in "Cart".
        /// Also decreases the stock count of the product when added to cart.
        /// </summary>
        /// <param name="dataGridViewCheckout">The DataGridView to get selected item from. </param>
        /// <param name="cartListbox">The ListBox to show selected products in.</param>
        public void AddToCart(DataGridView dataGridViewCheckout, ListBox cartListbox)
        {
                //Get the selected product.
            var selectedItem = dataGridViewCheckout.SelectedRows[0].DataBoundItem;
            int nrInStock;

                //If product is a book, add to Cart and decrease stock count if > 0.
            if (selectedItem is Book)
            {
                Book book = (Book)selectedItem;
                nrInStock = book.StockCount;
                if (nrInStock > 0)
                {
                    Cart.Add(book);
                    book.StockCount = nrInStock - 1;
                }
                    //Show error message if book is out of stock.
                else { MessageBox.Show($"Sorry!\n{book.Name} is out of stock.", "Failed to add product", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information); }

            }
                //If product is a game, add to Cart and decrease stock count if > 0.
            else if (selectedItem is Game)
            {
                Game game = (Game)selectedItem;
                nrInStock = game.StockCount;
                if (nrInStock > 0)
                {
                    Cart.Add(game);
                    game.StockCount = nrInStock - 1;
                }
                    //Show error message if game is out of stock.
                else { MessageBox.Show($"Sorry!\n{game.Name} is out of stock.","Failed to add product",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
                //Add movie to Cart and decrease stock count if > 0.
            else
            {
                Movie movie = (Movie)selectedItem;
                nrInStock = movie.StockCount;
                if (nrInStock > 0)
                {
                    Cart.Add(movie);
                    movie.StockCount = nrInStock - 1;
                }
                    //Show error message if movie is out of stock.
                else { MessageBox.Show($"Sorry!\n{movie.Name} is out of stock.","Failed to add product",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            dataGridViewCheckout.Refresh();
                //Set source to null and then CartSource again to update the ListBox.
            cartListbox.DataSource = null;
            cartListbox.DataSource = CartSource;
        }




        /// <summary>
        /// Sums up the prices of all current products in cart and shows the total amount to user.
        /// </summary>
        /// <returns>Sum: The total amount/cost of all current products in cart.</returns>
        public int CalculateTotalAmount()
        {
            int sum = 0;
            if(Cart.Count > 0)
            {
                    //Loops through Cart to add price of each product to sum.
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




        /// <summary>
        /// Removes a selected product from the list "Cart" and updates the ListBox to show current products in "Cart".
        /// Also increases the stock count of the product when removed from cart. 
        /// </summary>
        /// <param name="cartListBox"></param>
        public void RemoveFromCart(ListBox cartListBox)
        {
                //Get the index of the selected product in ListBox.
            int selectedItemIndex = cartListBox.SelectedIndex;
            int nrInStock;
                
            if(cartListBox.SelectedItems.Count > 0)
            {
                    //Remove book from the selected index in Cart, if book, and increase stock count.
                if (Cart[selectedItemIndex] is Book)
                {
                    Book book = (Book)Cart[selectedItemIndex];
                    nrInStock = book.StockCount;
                    book.StockCount = nrInStock + 1;
                }
                    // Remove game from the selected index in Cart, if game, and increase stock count.
                else if (Cart[selectedItemIndex] is Game)
                {
                    Game game = (Game)Cart[selectedItemIndex];
                    nrInStock = game.StockCount;
                    game.StockCount = nrInStock + 1;
                }
                    //Remove movie from the selected index in Cart, and increase stock count.
                else
                {
                    Movie movie = (Movie)Cart[selectedItemIndex];
                    nrInStock = movie.StockCount;
                    movie.StockCount = nrInStock + 1;
                }
                Cart.RemoveAt(selectedItemIndex);
                cartListBox.DataSource = null;
                cartListBox.DataSource = CartSource;
            }  
        }




        /// <summary>
        /// Sells all products currently added in Cart. Shows confirmation message of products sold.
        /// </summary>
        /// <param name="cartListbox">The ListBox to clear after selling.</param>
        public void SellProducts(ListBox cartListbox)
        {
                //Get total costs of all products.
            int sellProfit = CalculateTotalAmount();
            string items = "Products sold:\n";

                //Save each item in string "items".
            foreach (var cart in Cart) { items += cart + "\n"; }

                //Show messagebox with products sold and profit.
            MessageBox.Show($"{items}\nProfit from selling: {sellProfit}:-", "Confirmation.", MessageBoxButtons.OK);

            cartListbox.DataSource = null;
            Cart.Clear();
        }




        /// <summary>
        /// Main method to add a delivery to a product. Calls for two different private methods depending on
        /// numbers of selected items in the delivery ListBox.
        /// </summary>
        /// <param name="dataGridViewWarehouse">DataGridView to send to method.</param>
        /// <param name="deliveryListBox">ListBox to send to method.</param>
        /// <param name="amount">Amount entered by user to send to method.</param>
        public void AddDelivery(DataGridView dataGridViewWarehouse, ListBox deliveryListBox, int amount)
        {
            if (deliveryListBox.Items.Count == 1 && deliveryListBox.SelectedItems.Count == 0) { deliveryListBox.SetSelected(0, true); }

            if (deliveryListBox.SelectedItems.Count == 1)
            {
                OneDelivery(dataGridViewWarehouse, deliveryListBox, amount);
            }
            else
            {
                SeveralDeliveries(dataGridViewWarehouse,deliveryListBox,amount);
            }
        }




        /// <summary>
        /// Gets the product selected by user in delivery ListBox and updates the stock count with amount entered by user.
        /// </summary>
        /// <param name="dataGridViewWarehouse">DataGridView to check which type of product the user selected.</param>
        /// <param name="deliveryListBox">ListBox to select specific product to add a delivery to.</param>
        /// <param name="amount">The amount in the delivery to increase stock count with.</param>
        private void OneDelivery(DataGridView dataGridViewWarehouse, ListBox deliveryListBox, int amount)
        {
                //Get the selected product.
            var selecteditem = deliveryListBox.SelectedItem;;

                //Check which type of product the user had selected by checking the current BindingSource.
                //Increase stock count with amount on selected product.
            if (dataGridViewWarehouse.DataSource == BookSource)
            {
                Book book = (Book)selecteditem;
                book.StockCount += amount;
                MessageBox.Show($"Delivery of {book.Name} succeeded.\nNew stock count: {book.Name}: {book.StockCount}", "Confirmation.",
                    MessageBoxButtons.OK);
            }
            else if (dataGridViewWarehouse.DataSource == GameSource)
            {
                Game game = (Game)selecteditem;
                game.StockCount += amount;
                MessageBox.Show($"Delivery of {game.Name} succeeded.\nNew stock count: {game.StockCount}", "Confirmation.",
                    MessageBoxButtons.OK);
            }
            else
            {
                Movie movie = (Movie)selecteditem;
                movie.StockCount += amount;
                MessageBox.Show($"Delivery of {movie.Name} succeeded.\nNew stock count: {movie.StockCount}", "Confirmation.",
                    MessageBoxButtons.OK);
            }
                //Remove the item from list of all products.
            Deliveries.Remove(selecteditem);
                //Reset the ListBox.
            deliveryListBox.DataSource = null;
            deliveryListBox.DataSource = Deliveries;
                //Refresh the DataGridView.
            dataGridViewWarehouse.Refresh();
                //Deselect all in DataGridView if list is empty.
            if (Deliveries.Count == 0) { dataGridViewWarehouse.ClearSelection(); }
        }




        /// <summary>
        /// Adds all selected products into a new list then increase stock count for all products in the list with amount.
        /// </summary>
        /// <param name="dataGridViewWarehouse">DataGridView to check which type of product the user selected.</param>
        /// <param name="deliveryListBox">ListBox to get all products to update stock count of.</param>
        /// <param name="amount">The amount in the delivery to increase stock count with.</param>
        private void SeveralDeliveries(DataGridView dataGridViewWarehouse, ListBox deliveryListBox, int amount)
        {
                //Add all products in the ListBox to a list.
            List<object> selectedItems = new List<object>();
            foreach (var item in deliveryListBox.SelectedItems)
            {
                selectedItems.Add(item);
            }

                //Loop through list and add amount to each products stock count.
            for (int i = 0; i < selectedItems.Count; i++)
            {
                if(dataGridViewWarehouse.DataSource == BookSource)
                {
                        //Convert item to specific type of object, here book.
                    Book book = selectedItems[i] as Book;
                        //Add amount to stock count.
                    book.StockCount += amount;
                        //Show confirmation.
                    MessageBox.Show($"Delivery of {book.Name} succeeded.\nNew stock count: {book.StockCount}", "Confirmation.",
                    MessageBoxButtons.OK);
                }
                    //Same as with book.
                else if(dataGridViewWarehouse.DataSource == GameSource)
                {
                    Game game = selectedItems[i] as Game;
                    game.StockCount += amount;
                    MessageBox.Show($"Delivery of {game.Name} succeeded.\nNew stock count: {game.StockCount}", "Confirmation.",
                    MessageBoxButtons.OK);
                }
                    //Same as with book.
                else
                {
                    Movie movie = selectedItems[i] as Movie;
                    movie.StockCount += amount;
                    MessageBox.Show($"Delivery of {movie.Name} succeeded.\nNew stock count: {movie.StockCount}", "Confirmation.",
                    MessageBoxButtons.OK);
                }
                    //Remove the item from list of all products.
                Deliveries.Remove(selectedItems[i]);
                    //Reset the ListBox.
                deliveryListBox.DataSource = null;
                deliveryListBox.DataSource = Deliveries;
                    //Refresh the DataGridView.
                dataGridViewWarehouse.Refresh();
                    //Deselect all in DataGridView if list is empty.
                if (Deliveries.Count == 0) { dataGridViewWarehouse.ClearSelection(); }
            }
        }




        /// <summary>
        /// Displays all products in the ListBox that user has selected in the DataGridView.
        /// </summary>
        /// <param name="dataGridViewWarehouse">DataGridView from which the user selects all products.</param>
        /// <param name="delListBx">ListBox in which all selected products gets displayed.</param>
        public void ShowDeliveryProducts(DataGridView dataGridViewWarehouse, ListBox delListBx)
        {
                //Clear to not have old products before showing new ones.
            Deliveries.Clear();
                //Loop through all selected rows in the DataGridView.
            foreach (DataGridViewRow row in dataGridViewWarehouse.SelectedRows)
            {
                    //If item on row is book, add to a new List.
                if(dataGridViewWarehouse.DataSource == BookSource)
                {
                    Book book = row.DataBoundItem as Book;
                    Deliveries.Add(book);
                }
                    //If item on row is game, add to a new List.
                else if (dataGridViewWarehouse.DataSource == GameSource)
                {
                    Game game = row.DataBoundItem as Game;
                    Deliveries.Add(game);
                }
                    //Else, add movie to a new List.
                else
                {
                    Movie movie = row.DataBoundItem as Movie;
                    Deliveries.Add(movie);
                }
            }
                //Update source to display products.
            delListBx.DataSource = null;
            delListBx.DataSource = Deliveries;
        }




        /// <summary>
        /// Clears the ListBox in which the products to add delivery to are displayed, as well as the list with products.
        /// </summary>
        /// <param name="delListBx">ListBox to clear.</param>
        public void ClearDeliveryListBox(ListBox delListBx)
        {
            Deliveries.Clear();
            delListBx.DataSource = null;
            delListBx.DataSource = Deliveries;
        }




        /// <summary>
        /// Calls for method in Filemanager to save all three BindingLists to the CSV-File.
        /// </summary>
        public void SaveToFile()
        {
            FileManager.SaveData(Books, Games, Movies);
        }
    }
}
