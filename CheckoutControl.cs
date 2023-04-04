using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace KassaSystem
{
    public partial class CheckoutControl : UserControl
    {
        private BindingSource BookSource;
        private BindingSource GameSource;
        private BindingSource MovieSource;
        private BindingSource CartSource;

        private ProductController ProductController;

        public CheckoutControl()
        {
            InitializeComponent();

            ProductController = new ProductController();
            BookSource = ProductController.getBookSource();
            GameSource = ProductController.getGameSource();
            MovieSource = ProductController.getMovieSource();

            CartSource = ProductController.getCartSource();
            CartListBox.DataSource = CartSource;

            dataGridViewCheckout.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                dataGridViewCheckout.ColumnHeadersDefaultCellStyle.BackColor;

            CartAmountTxBx.Text = "0:-";
        }

        private void radioBtnGame_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnGame.Checked) { dataGridViewCheckout.DataSource = GameSource; }
            dataGridViewCheckout.ClearSelection();
            enableLblsAndTxBxs(false, false, false, false, true, false);
            RemoveStoreBtn.Enabled = false;
        }

        private void radioBtnBook_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnBook.Checked) { dataGridViewCheckout.DataSource = BookSource; }
            dataGridViewCheckout.ClearSelection();
            enableLblsAndTxBxs(true, true, true, true, false, false);
            RemoveStoreBtn.Enabled = false;
        }

        private void radioBtnMovie_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnMovie.Checked) { dataGridViewCheckout.DataSource = MovieSource; }
            dataGridViewCheckout.ClearSelection();
            enableLblsAndTxBxs(false, false, true, false, false, true);
            RemoveStoreBtn.Enabled = false;
        }

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

        private void NameTxBx_TextChanged(object sender, EventArgs e)
        {
            enableButtons();
        }

        private void PriceTxBx_TextChanged(object sender, EventArgs e)
        {
            enableButtons();
        }

        private void enableButtons()
        {
            string pricePattern = @"^(?!0+$)^[1-9]\d*$";
            Regex regexPrice = new Regex(pricePattern);

            //FUNKAR EJ. KOLLA DETTA.
            string namePattern = @"^(?=.*[a-zA-Z])[a-zA-Z0-9\s]*$";
            Regex regexName = new Regex(namePattern);

            if (regexPrice.IsMatch(PriceTxBx.Text) && regexName.IsMatch(NameTxBx.Text))
            {
                AddStoreBtn.Enabled = true;
                SaveStoreBtn.Enabled = true;
            }
            else 
            { 
                AddStoreBtn.Enabled = false;
                SaveStoreBtn.Enabled = false;
            }
        }

        private void RemoveStoreBtn_Click(object sender, EventArgs e)
        {
            if(dataGridViewCheckout.SelectedRows.Count > 0)
            {
                if (radioBtnBook.Checked) { ProductController.RemoveProduct<Book>(dataGridViewCheckout, b => b.getStockCount()); }
                if (radioBtnGame.Checked) { ProductController.RemoveProduct<Game>(dataGridViewCheckout, b => b.getStockCount()); }
                if (radioBtnMovie.Checked) { ProductController.RemoveProduct<Movie>(dataGridViewCheckout, b => b.getStockCount()); }
            } 
        }

        private void AddStoreBtn_Click(object sender, EventArgs e)
        {
            int prodNr = checkProdNrInput();
            int length = checkLengthInput();

            if(radioBtnMovie.Checked && length > 0)
            {
                ProductController.AddProduct(dataGridViewCheckout, prodNr, NameTxBx.Text,
                int.Parse(PriceTxBx.Text), AuthorTxBx.Text, GenreTxBx.Text,
                0, FormatTxBx.Text, LanguageTxBx.Text, PlatformTxBx.Text, length);
            }
            else
            {
                ProductController.AddProduct(dataGridViewCheckout, prodNr, NameTxBx.Text,
                int.Parse(PriceTxBx.Text), AuthorTxBx.Text, GenreTxBx.Text,
                0, FormatTxBx.Text, LanguageTxBx.Text, PlatformTxBx.Text, length);
            }
        }

        private int checkProdNrInput()
        {
            int prodNr = 0;

            if (!string.IsNullOrEmpty(VaruNrTxBx.Text))
            {
                try { prodNr = int.Parse(VaruNrTxBx.Text); }
                catch { prodNr = 0; }

                if (prodNr > 0)
                {
                    if (radioBtnBook.Checked)
                    {
                        if (prodNr >= 1000 && prodNr < 2000)
                        {
                            return prodNr;
                        }
                        else { MessageBox.Show("Product number for books must be between 1000-2000."); }
                    }
                    else if (radioBtnGame.Checked)
                    {
                        if (prodNr >= 2000 && prodNr < 3000)
                        {
                            return prodNr;
                        }
                        else { MessageBox.Show("Product number for games must be between 2000-3000."); }
                    }
                    else
                    {
                        if (prodNr >= 3000 && prodNr < 4000)
                        {
                            return prodNr;
                        }
                        else { MessageBox.Show("Product number for movies must be between 3000-4000."); }
                    }
                }
            }
            return prodNr;
        }

        private int checkLengthInput()
        {
            int length = 0;

            if (!string.IsNullOrEmpty(LengthTxBx.Text))
            {
                try { length = int.Parse(LengthTxBx.Text); }
                catch { length = 0; }

                if (length > 0) { return length; }
                else { MessageBox.Show("Length for a movie must me a positive number, and number only."); }
            }
            return length;
        }

        private void LengthTxBx_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewCheckout_SelectionChanged(object sender, EventArgs e)
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

            
            if (dataGridViewCheckout.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewCheckout.SelectedRows[0];
                if (selectedRow.DataBoundItem is Book book)
                {
                    VaruNrTxBx.Text = book.Id.ToString();
                    NameTxBx.Text = book.Name;
                    PriceTxBx.Text = book.Price.ToString();
                    AuthorTxBx.Text = book.Author;
                    GenreTxBx.Text = book.Genre;
                    FormatTxBx.Text = book.Format;
                    LanguageTxBx.Text = book.Language;
                }
                else if (selectedRow.DataBoundItem is Game game)
                {
                    VaruNrTxBx.Text = game.Id.ToString();
                    NameTxBx.Text = game.Name;
                    PriceTxBx.Text = game.Price.ToString();
                    PlatformTxBx.Text = game.Platform;
                }
                else if (selectedRow.DataBoundItem is Movie movie)
                {
                    VaruNrTxBx.Text = movie.Id.ToString();
                    NameTxBx.Text = movie.Name;
                    PriceTxBx.Text = movie.Price.ToString();
                    FormatTxBx.Text = movie.Format;
                    string[] lengthMin = movie.Length.Split();
                    LengthTxBx.Text = lengthMin[0];
                }
                enableButtons();
                ClearBtn.Enabled = true;
                RemoveStoreBtn.Enabled = true;
                SaveStoreBtn.Enabled = true;
                AddCartBtn.Enabled = true;
            }
        }

        private void SaveStoreBtn_Click(object sender, EventArgs e)
        {
            int stockCount = 0;
            int length = 0;

            if (dataGridViewCheckout.SelectedRows.Count > 0)
            {
                if(!string.IsNullOrEmpty(LengthTxBx.Text)) 
                { 
                    try { length = int.Parse(LengthTxBx.Text); } 
                    catch {MessageBox.Show("You entered an invalid " +
                        "length of the movie. Please try again."); }
                }

                ProductController.SaveChangesToProduct(dataGridViewCheckout, NameTxBx.Text,
                int.Parse(PriceTxBx.Text), AuthorTxBx.Text, GenreTxBx.Text, FormatTxBx.Text,
                LanguageTxBx.Text, PlatformTxBx.Text, length, stockCount);
            }
            dataGridViewCheckout.ClearSelection();
            RemoveStoreBtn.Enabled = false;
            AddCartBtn.Enabled = false;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
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
            SaveStoreBtn.Enabled = false;
            dataGridViewCheckout.ClearSelection();
            RemoveStoreBtn.Enabled = false;
        }

        private void AddCartBtn_Click(object sender, EventArgs e)
        {
            if (dataGridViewCheckout.SelectedRows.Count > 0)
            {
                RemoveCartBtn.Enabled = true;
                CartAmountTxBx.Enabled = true;
                SellCartBtn.Enabled = true;
                ProductController.AddToCart(dataGridViewCheckout);
                CartListBox.DataSource = null;
                CartListBox.DataSource = CartSource;
                CartAmountTxBx.Text = ProductController.CalculateTotalAmount().ToString() + ":-";
                CartListBox.ClearSelected();
            }
        }

        private void RemoveCartBtn_Click(object sender, EventArgs e)
        {
            if(dataGridViewCheckout.SelectedRows.Count > 0)
            {
                ProductController.RemoveFromCart(CartListBox);
                CartListBox.DataSource = null;
                CartListBox.DataSource = CartSource;

                CartAmountTxBx.Text = ProductController.CalculateTotalAmount().ToString() + ":-";
                CartListBox.ClearSelected();
                dataGridViewCheckout.Refresh();
            }
            if(CartListBox.SelectedItems.Count == 0)
            {
                SellCartBtn.Enabled = false;
            }
           
        }

        private void SellCartBtn_Click(object sender, EventArgs e)
        {
            ProductController.SellProducts();
            CartListBox.DataSource = null;
            CartAmountTxBx.Text = "0:-";
        }
    }
}
