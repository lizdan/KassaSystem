using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

/**
 * This class represents a user control for handling product checkout. Provides an
 * interface for adding and removing products to/from a shopping cart, and
 * selling the products in the cart. Allows the user to manage the products
 * available for sale, such as adding new products or modifying existing ones.
 * The class is calling instance methods in "ProductController" to make 
 * changes, add and remove products.
 * 
 * @Author Liza Danielsson.
 */

namespace KassaSystem
{
    public partial class CheckoutControl : UserControl
    {
        private ProductController ProductController;
        private const int BOOKS_ID = 0;
        private const int GAMES_ID = 1;
        private const int MOVIES_ID = 2;


        //Constructor.
        public CheckoutControl(ProductController productController)
        {
            InitializeComponent();

            ProductController = productController;

                //"Removes" highlight of header column when item is selected.
            dataGridViewCheckout.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                dataGridViewCheckout.ColumnHeadersDefaultCellStyle.BackColor;

            CartAmountTxBx.Text = "0:-";
        }

        


        //Executes when user clicks or unclicks RadioButton for books. 
        //Calls for method that loads all books to DataGridView when clicked.
        private void radioBtnBook_CheckedChanged(object sender, EventArgs e)
        {
                //Call method to load the data of books to DataGridView.
            if (radioBtnBook.Checked) { ProductController.LoadDataIntoGridView(dataGridViewCheckout, BOOKS_ID); }

                //Call method to enable or disenable labels and textboxes.
            enableLblsAndTxBxs(true, true, true, true, false, false);

            RemoveStoreBtn.Enabled = false;
            ClearBtn.Enabled = false;
            AddCartBtn.Enabled = false;
            SaveStoreBtn.Enabled = false;
            RemoveCartBtn.Enabled = false;
            VaruNrTxBx.ReadOnly = false;
            dataGridViewCheckout.ClearSelection();
        }




        //Executes when user clicks or unclicks RadioButton for games. 
        //Calls for method that loads all games to DataGridView when clicked.
        private void radioBtnGame_CheckedChanged(object sender, EventArgs e)
        {
                //Call method to load the data of games to DataGridView.
            if (radioBtnGame.Checked) { ProductController.LoadDataIntoGridView(dataGridViewCheckout, GAMES_ID); }

                //Call method to enable or disenable labels and textboxes.
            enableLblsAndTxBxs(false, false, false, false, true, false);

            RemoveStoreBtn.Enabled = false;
            ClearBtn.Enabled = false;
            AddCartBtn.Enabled = false;
            SaveStoreBtn.Enabled = false;
            RemoveCartBtn.Enabled = false;
            VaruNrTxBx.ReadOnly = false;
            dataGridViewCheckout.ClearSelection();
        }




        //Executes when user clicks or unclicks RadioButton for movies. 
        //Calls for method that loads all movies to DataGridView when clicked.
        private void radioBtnMovie_CheckedChanged(object sender, EventArgs e)
        {
                //Call method to load the data of movies to DataGridView.
            if (radioBtnMovie.Checked) { ProductController.LoadDataIntoGridView(dataGridViewCheckout, MOVIES_ID); }

                //Call method to enable or disenable labels and textboxes.
            enableLblsAndTxBxs(false, false, true, false, false, true);

            RemoveStoreBtn.Enabled = false;
            ClearBtn.Enabled = false;
            AddCartBtn.Enabled = false;
            SaveStoreBtn.Enabled=false;
            RemoveCartBtn.Enabled = false;
            VaruNrTxBx.ReadOnly = false;
            dataGridViewCheckout.ClearSelection();
        }




        /// <summary>
        /// Enables or disenables labels and textboxes in usercontrol depending on bools sent to method.
        /// </summary>
        /// <param name="a">Bool for author label and textbox.</param>
        /// <param name="g">Bool for genre label and textbox.</param>
        /// <param name="f">Bool for format label and textbox.</param>
        /// <param name="la">Bool for language label and textbox.</param>
        /// <param name="pl">Bool for platform label and textbox.</param>
        /// <param name="le">Bool for length label and textbox.</param>
        private void enableLblsAndTxBxs(bool a, bool g, bool f, bool la, bool pl, bool le)
        {
            VaruNrTxBx.Enabled = true;
            NameTxBx.Enabled = true;
            PriceTxBx.Enabled = true;
            AuthorTxBx.Enabled = a;
            GenreTxBx.Enabled = g;
            FormatTxBx.Enabled = f;
            LanguageTxBx.Enabled = la;
            PlatformTxBx.Enabled = pl;
            LengthTxBx.Enabled = le;

            AuthorLbl.Enabled = a;
            GenreLbl.Enabled = g;
            FormatLbl.Enabled = f;
            LanguageLbl.Enabled = la;
            PlatformLbl.Enabled = pl;
            LengthLbl.Enabled = le;
        }




        //Executes when user changes the text in the TextBox for Name.
        private void NameTxBx_TextChanged(object sender, EventArgs e)
        {
                //Call method to check if to enable buttons.
            enableButtons();
        }




        //Executes when user changes the text in the TextBox for Price.
        private void PriceTxBx_TextChanged(object sender, EventArgs e)
        {
                //Call method to check if to enable buttons.
            enableButtons();
        }




        //Method that enables or disenables buttons depending on user input in TextBoxes for name and price.
        private void enableButtons()
        {
            int priceInput;
                //Regex pattern for price input (allows only posititve numbers).
            string pricePattern = @"^(?!0+$)^[1-9]\d*$";
            Regex regexPrice = new Regex(pricePattern);

                //Regex pattern for name input (input must be at least one letter, and some characters are allowed).
            string namePattern = @"^(?=.*[a-zA-Z])[a-zA-Z0-9\s*!'-]*$";
            Regex regexName = new Regex(namePattern);

                //Try to parse input, if not, input is set to -1 (which will not match regex pattern).
            try { priceInput = int.Parse(PriceTxBx.Text); }
            catch { priceInput = -1; }

                //Check if input in textboxes matches regex patterns, and enable/disenable buttons.
            if(dataGridViewCheckout.SelectedRows.Count > 0)
            {
                if (regexPrice.IsMatch(priceInput.ToString()) && regexName.IsMatch(NameTxBx.Text))
                {
                    SaveStoreBtn.Enabled = true;
                }
                else
                {
                    AddStoreBtn.Enabled = false;
                    SaveStoreBtn.Enabled = false;
                }
            }
            else
            {
                if (regexPrice.IsMatch(priceInput.ToString()) && regexName.IsMatch(NameTxBx.Text))
                {
                    SaveStoreBtn.Enabled = false;
                    AddStoreBtn.Enabled = true;
                }
                else
                {
                    AddStoreBtn.Enabled = false;
                }
            }

                //Enable the Clear button when text in name, price or product number textbox.
            if (!string.IsNullOrEmpty(NameTxBx.Text) || !string.IsNullOrEmpty(PriceTxBx.Text) ||
                !string.IsNullOrEmpty(VaruNrTxBx.Text)) { ClearBtn.Enabled = true; }
            else { ClearBtn.Enabled = false; }
            
        }




        //Checks that user enters valid product number and valid length if product is movie. Then calls for method to add
        //product to store using input in textboxes. Disenables buttons if product is added.
        private void AddStoreBtn_Click(object sender, EventArgs e)
        {
                //Get an product number, either valid from user, -1 if not valid or 0 if empty.
            int prodNr = checkProdNrInput();
            int length = 0;
                //Stock count -1 since stock count isn't handled by cashier.
            int stockCount = -1;
            bool addSucess;

                //Only focus on product number if not valid input first time.
            if (prodNr == -1 || dataGridViewCheckout.SelectedRows.Count > 0)
            {
                VaruNrTxBx.Focus();
            }
                //Else, add the product.
            else
            {   
                    //If movies in datagrid, check length textbox, get if not empty.
                if (radioBtnMovie.Checked) { if (!string.IsNullOrEmpty(LengthTxBx.Text)) { length = int.Parse(LengthTxBx.Text); } }

                    //Call method to add product.
                addSucess = ProductController.AddProduct(dataGridViewCheckout, prodNr, NameTxBx.Text,
                int.Parse(PriceTxBx.Text), AuthorTxBx.Text, GenreTxBx.Text,
                stockCount, FormatTxBx.Text, LanguageTxBx.Text, PlatformTxBx.Text, length);

                if(addSucess)
                {
                    AddStoreBtn.Enabled = false;
                    SaveStoreBtn.Enabled = false;
                    ClearBtn.Enabled = false;
                    VaruNrTxBx.ReadOnly = false;
                    ClearAllTextBoxes();
                }
            }
                //Remove selection if only one product in view.
            if(dataGridViewCheckout.SelectedRows.Count == 1) { dataGridViewCheckout.ClearSelection(); }
        }




        //Checks if product is selected, and calls method to remove that product.
        //Disenables buttons and clears textboxes if/after removal.
        private void RemoveStoreBtn_Click(object sender, EventArgs e)
        {
            if (dataGridViewCheckout.SelectedRows.Count > 0)
            {
                bool removed = ProductController.RemoveProduct(dataGridViewCheckout);
                if (removed)
                {
                    dataGridViewCheckout.ClearSelection();
                    AddStoreBtn.Enabled = false;
                    RemoveStoreBtn.Enabled = false;
                    SaveStoreBtn.Enabled = false;
                    ClearBtn.Enabled = false;
                    AddCartBtn.Enabled = false;
                }
            }
        }




        //Saves current information in textboxes to the product selected in DataGridView by calling instance method.
        //Resets all buttons after saving is clicked.
        private void SaveStoreBtn_Click(object sender, EventArgs e)
        {
            if (dataGridViewCheckout.SelectedRows.Count > 0)
            {
                    //Delfault value to length if no information from user.
                int length = 0;

                    //If length is entered, save to length.
                if (radioBtnMovie.Checked) { if (!string.IsNullOrEmpty(LengthTxBx.Text)) { length = int.Parse(LengthTxBx.Text); } }

                    //Call instance method to save information to product.
                ProductController.SaveChangesToProduct(dataGridViewCheckout, NameTxBx.Text,
                int.Parse(PriceTxBx.Text), AuthorTxBx.Text, GenreTxBx.Text, FormatTxBx.Text,
                LanguageTxBx.Text, PlatformTxBx.Text, length);
                dataGridViewCheckout.ClearSelection();
                RemoveStoreBtn.Enabled = false;
            }
            ClearBtn.Enabled = false;
            AddStoreBtn.Enabled = false;
            SaveStoreBtn.Enabled = false;
            VaruNrTxBx.ReadOnly = true;
        }




        /// <summary>
        /// Checks that product number entered by user is valid for specific type of product.
        /// Books(1000-2000), games(2000-3000) and movies(3000-4000).
        /// </summary>
        /// <returns>Int: Product number to send to method that adds new product. 0 if textbox was empty, -1
        /// if input was not valid.</returns>
        private int checkProdNrInput()
        {
            int prodNr = 0;

                //If not empty.
            if (!string.IsNullOrEmpty(VaruNrTxBx.Text))
            {
                    //Try get product number.
                try { prodNr = int.Parse(VaruNrTxBx.Text); }
                catch { prodNr = 0; }

                    //If product number was set to 0 or more, check that it is within range depending on type of product.
                if (prodNr >= 0)
                {
                    if (radioBtnBook.Checked)
                    {
                            //Return product number if within range.
                        if (prodNr >=1000 && prodNr < 2000) { return prodNr; }
                            //Else, show error and return -1.
                        else 
                        { 
                            MessageBox.Show("Product number for books must be between 1000-2000.","Invalid input!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return -1;
                        }
                    }
                    else if (radioBtnGame.Checked)
                    {
                        if (prodNr >= 2000 && prodNr < 3000) { return prodNr; }
                        else
                        { 
                            MessageBox.Show("Product number for games must be between 2000-3000.","Invalid input!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return -1;
                        }
                    }
                    else
                    {
                        if (prodNr >= 3000 && prodNr < 4000) { return prodNr; }
                        else 
                        { 
                            MessageBox.Show("Product number for movies must be between 3000-4000.","Invalid input!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return -1;
                        }
                    }
                }
            }
                //Return 0 if textbox was empty.
            return prodNr;
        }




        //Executes when text changes in TextBox for Lenght. Checks that length is a positive number and nothing else.
        //Disenables buttons for saving and adding if not valid.
        private void LengthTxBx_TextChanged(object sender, EventArgs e)
        {
            int length;

                //Try get length from textbox, else set to -1.
            try { length = int.Parse(LengthTxBx.Text); }
            catch { length = -1; }

                //If length is valid or textbox empty.
            if (length >= 0 || string.IsNullOrEmpty(LengthTxBx.Text))
            {
                    //Check if product selected.
                if (dataGridViewCheckout.SelectedRows.Count > 0)
                {
                    AddStoreBtn.Enabled = false;
                    SaveStoreBtn.Enabled = true;
                }
                    //Else, check if no product selected while name and price is written.
                else if(dataGridViewCheckout.SelectedRows.Count == 0 && !string.IsNullOrEmpty(NameTxBx.Text)
                    && !string.IsNullOrEmpty(PriceTxBx.Text))
                {
                    AddStoreBtn.Enabled = true;
                    SaveStoreBtn.Enabled = false;
                }
            }
                //Else, both Add and Save buttons disenabled.
            else
            {
                SaveStoreBtn.Enabled = false;
                AddStoreBtn.Enabled = false;
            }
        }




        //Executes every time user selects a new product in the DataGridView.
        //Clears all textboxes and then calls instance method to fill them with new information about the selected product.
        private void dataGridViewCheckout_SelectionChanged(object sender, EventArgs e)
        {
                //List to save all properties in.
            List<string> AllInformation = new List<string>();
            ClearAllTextBoxes();

            if(dataGridViewCheckout.SelectedRows.Count > 0)
            {
                    //Call instance method that returns List with properties as strings.
                AllInformation = ProductController.FillTextBoxesWhenSelected(dataGridViewCheckout);
                    //Show each property in list in each textbox.
                VaruNrTxBx.Text = AllInformation[0];
                NameTxBx.Text = AllInformation[1];
                PriceTxBx.Text = AllInformation[2];
                AuthorTxBx.Text = AllInformation[3];
                GenreTxBx.Text = AllInformation[4];
                FormatTxBx.Text = AllInformation[5];
                LanguageTxBx.Text = AllInformation[6];
                PlatformTxBx.Text = AllInformation[7];
                LengthTxBx.Text = AllInformation[8];

                    //Enable/disenable buttons.
                enableButtons();
                RemoveStoreBtn.Enabled = true;
                AddCartBtn.Enabled = true;
                VaruNrTxBx.ReadOnly = true;
            }
        }

       


        //Calls method to clear all textboxes. Disenables all buttons and unselects all items in DataGridView.
        private void ClearBtn_Click(object sender, EventArgs e)
        {
                //Call method to clear all textboxes.
            ClearAllTextBoxes();

            SaveStoreBtn.Enabled = false;
            ClearBtn.Enabled = false;
            RemoveStoreBtn.Enabled = false;
            AddStoreBtn.Enabled = false;
            AddCartBtn.Enabled = false;
            RemoveCartBtn.Enabled = false;
            VaruNrTxBx.ReadOnly = false;
            dataGridViewCheckout.ClearSelection();
        }




        //Get the selected item from DataGridView and calls instance method to add it to the cart.
        //Updates the textbox with cart amount trough instance method.
        //Enables/disenables buttons.
        private void AddCartBtn_Click(object sender, EventArgs e)
        {
            if (dataGridViewCheckout.SelectedRows.Count > 0)
            {
                    //Call method to add item to cart.
                ProductController.AddToCart(dataGridViewCheckout, CartListBox);

                    //Call method to update the amount of cost of products in cart.
                CartAmountTxBx.Text = ProductController.CalculateTotalAmount().ToString() + ":-";
              
                RemoveCartBtn.Enabled = true;
                CartAmountTxBx.Enabled = true;
                SellCartBtn.Enabled = true;
                AddStoreBtn.Enabled = false;
                CartListBox.ClearSelected();
            }
        }




        //Get the selected item in cart and calls instance method to remove it from the cart.
        //Updates the textbox with cart amount trough instance method.
        //Enables/disenables buttons.
        private void RemoveCartBtn_Click(object sender, EventArgs e)
        {
            if(CartListBox.SelectedItems.Count > 0)
            {
                    //Call method to remove item in cart from cart.
                ProductController.RemoveFromCart(CartListBox);

                    //Call method to update the total amount/cost of all products in cart.
                CartAmountTxBx.Text = ProductController.CalculateTotalAmount().ToString() + ":-";

                    //Unselect all items cart.
                CartListBox.ClearSelected();
                    //Update DataGridView to update stock count.
                dataGridViewCheckout.Refresh();
            }

                //Enable/disenable buttons.
            if(CartListBox.Items.Count == 0)
            {
                SellCartBtn.Enabled = false;
                RemoveCartBtn.Enabled = false;
            }
            else
            {
                SellCartBtn.Enabled = true;
                RemoveCartBtn.Enabled = true;
            }
            AddStoreBtn.Enabled = false;
        }




        //Calls instance method to sell all products in cart.
        //Resets textbox, buttons and DataGridView.
        private void SellCartBtn_Click(object sender, EventArgs e)
        {
                //Call instance method to sell products.
            ProductController.SellProducts(CartListBox);

            CartAmountTxBx.Text = "0:-";
            SellCartBtn.Enabled = false;
            RemoveCartBtn.Enabled = false;
            RemoveStoreBtn.Enabled = false;
            dataGridViewCheckout.ClearSelection();
        }




        //Clears all textboxes.
        private void ClearAllTextBoxes()
        {
            VaruNrTxBx.Text = "";
            NameTxBx.Text = "";
            PriceTxBx.Text = "";
            AuthorTxBx.Text = "";
            GenreTxBx.Text = "";
            FormatTxBx.Text = "";
            PlatformTxBx.Text = "";
            LanguageTxBx.Text = "";
            LengthTxBx.Text = "";
        }




        //Shows messagebox when information icon is clicked. Shows information about valid input to user.
        private void pictureBoxCheckout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ProdNr: books(1000-2000), games(2000-3000), movies(3000-4000).\n" +
                "*Name: At least 1 letter, not numbers only.\n*Price: Positive number.\nAuthor: Optional input.\n" +
                "Genre: Optional input.\nFormat: Optional input.\nLanguage: Optional input.\n" +
                "Platform: Optional input.\nLength: Positive number.\n\n* = mandatory. ",
                "Input instructions", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }




        //Changes the color of empty cells in DataGridView when DataGridView is getting new information.
        private void dataGridViewCheckout_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
                //If cell is empty and isn't the header.
            if (string.IsNullOrEmpty(e.Value?.ToString()) && e.ColumnIndex != -1)
            {
                    //Set the background color of the cell to lihtgrey.
                e.CellStyle.BackColor = Color.LightGray;
            }
        }



        //Calls instance method to synchronize price and stock count with the main warehouse from an open API.
        private void SyncBtnCheckView_Click(object sender, EventArgs e)
        {
            ProductController.SyncWithHeadWarehouse();
            dataGridViewCheckout.Refresh();
        }
    }
}
