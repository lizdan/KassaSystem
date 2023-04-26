using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;



/**
 * This class represents a user control for handling the products in stock. Provides an
 * interface for adding deliveries of products to the store. Allows the user to manage the products
 * available in store, such as adding new products or modifying existing ones.
 * The class is calling instance methods in "ProductController" to make 
 * changes, add and remove products.
 * 
 * @Author Liza Danielsson.
 */
namespace KassaSystem
{
    public partial class WarehouseControl : UserControl
    {
        private ProductController ProductController;
        private const int BOOKS_ID = 0;
        private const int GAMES_ID = 1;
        private const int MOVIES_ID = 2;


        //Constructor.
        public WarehouseControl(ProductController productController)
        {
            InitializeComponent();

            ProductController = productController;

                //"Removes" highlight of header column when item is selected.
            dataGridViewWarehouse.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                dataGridViewWarehouse.ColumnHeadersDefaultCellStyle.BackColor;
        }




        //Executes when user clicks or unclicks RadioButton for books. 
        //Calls for method that loads all books to DataGridView when clicked.
        private void radioBtnBook_CheckedChanged(object sender, EventArgs e)
        {
                //Call method to load the data of books to DataGridView.
            if (radioBtnBook.Checked) { ProductController.LoadDataIntoGridView(dataGridViewWarehouse, BOOKS_ID); }

                //Call method to enable or disenable labels and textboxes.
            enableLblsAndTxBxs(true, true, true, true, false, false);

            RemoveStoreBtn.Enabled = false;
            ClearBtn.Enabled = false;
            SaveStoreBtn.Enabled = false;
            VaruNrTxBx.ReadOnly = false;
            StockCntTxBx.ReadOnly = false;
            listBxDel.DataSource = null;
            dataGridViewWarehouse.ClearSelection();
        }




        //Executes when user clicks or unclicks RadioButton for games. 
        //Calls for method that loads all games to DataGridView when clicked.
        private void radioBtnGame_CheckedChanged(object sender, EventArgs e)
        {
                //Call method to load the data of games to DataGridView.
            if (radioBtnGame.Checked) { ProductController.LoadDataIntoGridView(dataGridViewWarehouse, GAMES_ID); }

                //Call method to enable or disenable labels and textboxes.
            enableLblsAndTxBxs(false, false, false, false, true, false);

            RemoveStoreBtn.Enabled = false;
            ClearBtn.Enabled = false;
            SaveStoreBtn.Enabled = false;
            VaruNrTxBx.ReadOnly = false;
            StockCntTxBx.ReadOnly = false;
            dataGridViewWarehouse.ClearSelection();
            listBxDel.DataSource = null;
        }


        //Executes when user clicks or unclicks RadioButton for movies.
        //Calls for method that loads all games to DataGridView when clicked.
        private void radioBtnMovie_CheckedChanged(object sender, EventArgs e)
        {
                //Call method to load the data of movies to DataGridView.
            if (radioBtnMovie.Checked) { ProductController.LoadDataIntoGridView(dataGridViewWarehouse, MOVIES_ID); }

                //Call method to enable or disenable labels and textboxes.
            enableLblsAndTxBxs(false, false, true, false, false, true);

            RemoveStoreBtn.Enabled = false;
            ClearBtn.Enabled = false;
            SaveStoreBtn.Enabled = false;
            VaruNrTxBx.ReadOnly = false;
            StockCntTxBx.ReadOnly = false;
            dataGridViewWarehouse.ClearSelection();
            listBxDel.DataSource = null;
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
            StockCntLbl.Enabled = true;
            StockCntTxBx.Enabled = true;
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
            if (dataGridViewWarehouse.SelectedRows.Count >= 1)
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

                //Enable the Clear button when text in name or price textbox.
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
            int stockCount = 0;
            bool addSucess;

                //Only focus on product number if not valid input first time.
            if (prodNr == -1 || dataGridViewWarehouse.SelectedRows.Count > 0)
            {
                VaruNrTxBx.Focus();
            }
                //Else, add the product.
            else
            {
                    //If movies in datagrid, check length textbox, get if not empty.
                if (radioBtnMovie.Checked) { if (!string.IsNullOrEmpty(LengthTxBx.Text)) { length = int.Parse(LengthTxBx.Text); } }
                if (!string.IsNullOrEmpty(StockCntTxBx.Text)) { stockCount = int.Parse(StockCntTxBx.Text); }

                    //Call method to add product.
                addSucess = ProductController.AddProduct(dataGridViewWarehouse, prodNr, NameTxBx.Text,
                int.Parse(PriceTxBx.Text), AuthorTxBx.Text, GenreTxBx.Text,
                stockCount, FormatTxBx.Text, LanguageTxBx.Text, PlatformTxBx.Text, length);

                if(addSucess)
                {
                    AddStoreBtn.Enabled = false;
                    SaveStoreBtn.Enabled = false;
                    ClearBtn.Enabled = false;
                    VaruNrTxBx.ReadOnly = false;
                    StockCntTxBx.ReadOnly = false;
                    ClearAllTextBoxes();
                }
            }
                //Remove selection if only one product in view.
            if (dataGridViewWarehouse.SelectedRows.Count == 1) { dataGridViewWarehouse.ClearSelection(); }
        }




        //Checks if product is selected, and calls method to remove that product.
        //Disenables buttons and clears textboxes if/after removal.
        private void RemoveStoreBtn_Click(object sender, EventArgs e)
        {
            if (dataGridViewWarehouse.SelectedRows.Count > 0)
            {
                bool removed = ProductController.RemoveProduct(dataGridViewWarehouse);
                if (removed)
                {
                    dataGridViewWarehouse.ClearSelection();
                    AddStoreBtn.Enabled = false;
                    RemoveStoreBtn.Enabled = false;
                    SaveStoreBtn.Enabled = false;
                    ClearBtn.Enabled = false;
                }
            }
        }




        //Saves current information in textboxes to the product selected in DataGridView by calling instance method.
        //Resets all buttons after saving is clicked.
        private void SaveStoreBtn_Click(object sender, EventArgs e)
        {
            if (dataGridViewWarehouse.SelectedRows.Count > 0)
            {
                    //Delfault value to length if no information from user.
                int length = 0;

                    //If length is entered, save to length.
                if (radioBtnMovie.Checked) { if (!string.IsNullOrEmpty(LengthTxBx.Text)) { length = int.Parse(LengthTxBx.Text); } }

                    //Call instance method to save information to product.
                ProductController.SaveChangesToProduct(dataGridViewWarehouse, NameTxBx.Text,
                int.Parse(PriceTxBx.Text), AuthorTxBx.Text, GenreTxBx.Text, FormatTxBx.Text,
                LanguageTxBx.Text, PlatformTxBx.Text, length);
                dataGridViewWarehouse.ClearSelection();
                RemoveStoreBtn.Enabled = false;
            }
            ClearBtn.Enabled = false;
            AddStoreBtn.Enabled = false;
            SaveStoreBtn.Enabled = false;
            VaruNrTxBx.ReadOnly = false;
            StockCntTxBx.ReadOnly = false;
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
                if (prodNr > 0)
                {
                    if (radioBtnBook.Checked)
                    {
                            //Return product number if within range.
                        if (prodNr > 999 && prodNr < 2000) { return prodNr; }
                            //Else, show error and return -1.
                        else
                        { 
                            MessageBox.Show("Product number for books must be between 1000-2000.","Invalid input!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return - 1;
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
                if (dataGridViewWarehouse.SelectedRows.Count > 0)
                {
                    AddStoreBtn.Enabled = false;
                    SaveStoreBtn.Enabled = true;
                }
                    //Else, check if no product selected while name and price is written.
                else if (dataGridViewWarehouse.SelectedRows.Count == 0 && !string.IsNullOrEmpty(NameTxBx.Text)
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
        //Displays the Delivery-ListBox with products, by instance method, if checkbox is checked.
        private void dataGridViewWarehouse_SelectionChanged(object sender, EventArgs e)
        {
                //List to save all properties in.
            List<string> AllInformation = new List<string>();
            ClearAllTextBoxes();

            if (dataGridViewWarehouse.SelectedRows.Count > 0)
            {
                    //Call instance method that returns List with properties as strings.
                AllInformation = ProductController.FillTextBoxesWhenSelected(dataGridViewWarehouse);
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
                StockCntTxBx.Text = AllInformation[9];

                    //Enable/disenable buttons.
                enableButtons();
                RemoveStoreBtn.Enabled = true;
                VaruNrTxBx.ReadOnly = true;
                StockCntTxBx.ReadOnly = true;
            }
                //If delivery section is activeted by user and products are selected.
            if(activateDeliveryChBx.Checked && dataGridViewWarehouse.SelectedRows.Count > 0) 
            {
                    //Call instance method to show products in delivery-ListBox.
                ProductController.ShowDeliveryProducts(dataGridViewWarehouse, listBxDel);
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
            VaruNrTxBx.ReadOnly = false;
            StockCntTxBx.ReadOnly = false;
            dataGridViewWarehouse.ClearSelection();
        }




        //Executes everytime input is changed in textbox for stock count. Checks that input is a positive number only.
        //Enables buttons for adding ans saving if valid input and disenables if unvalidl.
        private void StockCntTxBx_TextChanged(object sender, EventArgs e)
        {
            int stockCnt;

                //Try get stock count from textbox.
            try { stockCnt = int.Parse(StockCntTxBx.Text); }
            catch { stockCnt = -1; }

                //If product selected.
            if (dataGridViewWarehouse.SelectedRows.Count > 0)
            {
                   //If textbox is not empty.
                if (!string.IsNullOrEmpty(StockCntTxBx.Text))
                {
                        //If stock count is valid number, enable.
                    if (stockCnt >= 0)
                    {
                        SaveStoreBtn.Enabled = true;
                        AddStoreBtn.Enabled = true;
                    }
                        //Else disenable.
                    else
                    {
                        SaveStoreBtn.Enabled = false;
                        AddStoreBtn.Enabled = false;
                    }
                }
            }
                //If no product selected.
            else
            {
                if (!string.IsNullOrEmpty(StockCntTxBx.Text))
                {
                    if (stockCnt >= 0)
                    {
                        SaveStoreBtn.Enabled = true;
                        AddStoreBtn.Enabled = true;
                    }
                    else
                    {
                        SaveStoreBtn.Enabled = false;
                        AddStoreBtn.Enabled = false;
                    }
                }

            }
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
            StockCntTxBx.Text = "";
        }




        //Shows messagebox when information icon is clicked. Shows information about valid input to user.
        private void pictureBoxWarehouse_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ProdNr: books(1000-2000), games(2000-3000), movies(3000-4000).\n" +
                "*Name: At least 1 letter, not numbers only.\n*Price: Positive number.\nAuthor: Optional input.\n" +
                "Genre: Optional input.\nFormat: Optional input.\nLanguage: Optional input.\n" +
                "Platform: Optional input.\nLength: Positive number.\nStockCount: Positive number.\n\n* = mandatory. ", 
                "Input instructions", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }




        //Executes every time the checkBox "Activate Delivery" is clicked or unclicked.
        private void activateDeliveryChBx_CheckedChanged(object sender, EventArgs e)
        {
                //When user checks the box.
            if(activateDeliveryChBx.Checked)
            {
                    //Call instance method to clear the ListBox of delivery-products.
                ProductController.ClearDeliveryListBox(listBxDel);
                    //Clear selected items in dataGricView.
                dataGridViewWarehouse.ClearSelection();
                    //Disenable group box for managing products.
                groupBoxManagement.Enabled = false;
                    //Enable group box for deliveries.
                groupBoxDeliveryManagement.Enabled = true;
                    //Set mutliselect to true so user can select multiple products from dataGridView.
                dataGridViewWarehouse.MultiSelect = true;
            }
                //Else, reset view (enable product management, multiselect is false and disenable delivery management).
            else
            {
                groupBoxManagement.Enabled = true;
                groupBoxDeliveryManagement.Enabled = false;
                dataGridViewWarehouse.MultiSelect = false;
            }
        }




        //Executes every time the text changes in the textbox where user enters numbers of products in delivery.
        //Checks that input is a positive number only. Else disenables button to add the delivery.
        private void DeliveryTxBx_TextChanged(object sender, EventArgs e)
        {
            int delInput;
                //Regex pattern for a positive number only.
            string DelPattern = @"^(?!0+$)^[1-9]\d*$";
            Regex regexDel = new Regex(DelPattern);

                //Try to get input, -1 if not possible.
            try { delInput = int.Parse(DeliveryTxBx.Text); }
            catch { delInput = -1; }

                //Enable/disenable button depending on input.
            if (!string.IsNullOrEmpty(DeliveryTxBx.Text) && regexDel.IsMatch(delInput.ToString()) && delInput > 0) { DeliveryBtn.Enabled = true; }
            else { DeliveryBtn.Enabled = false; }
        }




        //Executed when user presses button to add delivery. Calls instance method to add amount (that user enters)
        //to the selected product/products amount in stock count.
        private void DeliveryBtn_Click(object sender, EventArgs e)
        {
                //If one product is selected in listbox or if only one product in listbox.
            if (listBxDel.SelectedItems.Count > 0 || listBxDel.Items.Count == 1)
            {
                    //Call instance method to add the amount to stock count.
                ProductController.AddDelivery(dataGridViewWarehouse, listBxDel, int.Parse(DeliveryTxBx.Text));
                DeliveryTxBx.Text = "";
                selectAllTxBx.Checked = false;
            }
        }



        //Executes when checkBox to select all products in ListBox is clicked.
        //Selects all deliver-products in listBox if checked and unselects if unchecked.
        private void selectAllTxBx_CheckedChanged(object sender, EventArgs e)
        {
                //If checked.
            if(selectAllTxBx.Checked)
            {
                    //Set ListBox to multiselect.
                listBxDel.SelectionMode = SelectionMode.MultiExtended;
                    //Loop trough all items in listbox and select each one.
                for (int i = 0; i < listBxDel.Items.Count; i++)
                {
                    listBxDel.SetSelected(i, true);
                }
            }
            //Else, clear all selected products and set Listbox to oneslection.
            else 
            {
                listBxDel.ClearSelected();
                listBxDel.SelectionMode = SelectionMode.One;
            }
        }



        //Executes when user presses button to clear the Listbox of delivery-products.
        //Empties the listbox, and textbox of delivery amount. Unselects all products in dataGridView.
        private void delivClearBtn_Click(object sender, EventArgs e)
        {
            ProductController.ClearDeliveryListBox(listBxDel);
            dataGridViewWarehouse.ClearSelection();
            DeliveryTxBx.Text = "";
            selectAllTxBx.Checked = false;
        }



        //Changes the color of empty cells in DataGridView when DataGridView is getting new information.
        private void dataGridViewWarehouse_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
                //If cell is empty and isn't the header.
            if (string.IsNullOrEmpty(e.Value?.ToString()) && e.ColumnIndex != -1)
            {
                    // Set the background color of the cell to grey.
                e.CellStyle.BackColor = Color.LightGray;
            }
        }

        private void syncBtnWareView_Click(object sender, EventArgs e)
        {
            ProductController.SyncWithHeadWarehouse();
            dataGridViewWarehouse.Refresh();
        }
    }
}
