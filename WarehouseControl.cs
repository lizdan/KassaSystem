using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KassaSystem
{
    public partial class WarehouseControl : UserControl
    {
        private ProductController ProductController;
        private BindingSource BookSource;
        private BindingSource GameSource;
        private BindingSource MovieSource;

        public WarehouseControl()
        {
            InitializeComponent();

            ProductController = new ProductController();
            BookSource = ProductController.getBookSource();
            GameSource = ProductController.getGameSource();
            MovieSource = ProductController.getMovieSource();

            dataGridViewWarehouse.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                dataGridViewWarehouse.ColumnHeadersDefaultCellStyle.BackColor;
        }

        private void radioBtnBook_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnBook.Checked) { dataGridViewWarehouse.DataSource = BookSource; }
            dataGridViewWarehouse.ClearSelection();
            enableLblsAndTxBxs(true, true, true, true, false, false);
            RemoveStoreBtn.Enabled = false;
        }

        private void radioBtnGame_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnGame.Checked) { dataGridViewWarehouse.DataSource = GameSource; }
            dataGridViewWarehouse.ClearSelection();
            enableLblsAndTxBxs(false, false, false, false, true, false);
            RemoveStoreBtn.Enabled = false;
        }

        private void radioBtnMovie_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnMovie.Checked) { dataGridViewWarehouse.DataSource = MovieSource; }
            dataGridViewWarehouse.ClearSelection();
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
            StockCntLbl.Enabled = true;
            StockCntTxBx.Enabled = true;
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
            if (dataGridViewWarehouse.SelectedRows.Count > 0)
            {
                if (radioBtnBook.Checked) { ProductController.RemoveProduct<Book>(dataGridViewWarehouse, b => b.getStockCount()); }
                if (radioBtnGame.Checked) { ProductController.RemoveProduct<Game>(dataGridViewWarehouse, b => b.getStockCount()); }
                if (radioBtnMovie.Checked) { ProductController.RemoveProduct<Movie>(dataGridViewWarehouse, b => b.getStockCount()); }
            }
        }

        private void AddStoreBtn_Click(object sender, EventArgs e)
        {
            int prodNr = checkProdNrInput();
            int length = checkLengthInput();

            if (radioBtnMovie.Checked && length > 0)
            {
                ProductController.AddProduct(dataGridViewWarehouse, prodNr, NameTxBx.Text,
                int.Parse(PriceTxBx.Text), AuthorTxBx.Text, GenreTxBx.Text,
                0, FormatTxBx.Text, LanguageTxBx.Text, PlatformTxBx.Text, length);
            }
            else
            {
                ProductController.AddProduct(dataGridViewWarehouse, prodNr, NameTxBx.Text,
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

        private void VaruNrTxBx_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void LengthTxBx_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(LengthTxBx.Text, out int value))
            {
                if (value < 0) { AddStoreBtn.Enabled = false; }
                else { AddStoreBtn.Enabled = true; }
            }
            else { AddStoreBtn.Enabled = false; }
        }

        private void dataGridViewWarehouse_SelectionChanged(object sender, EventArgs e)
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


            if (dataGridViewWarehouse.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewWarehouse.SelectedRows[0];
                if (selectedRow.DataBoundItem is Book book)
                {
                    VaruNrTxBx.Text = book.Id.ToString();
                    NameTxBx.Text = book.Name;
                    PriceTxBx.Text = book.Price.ToString();
                    AuthorTxBx.Text = book.Author;
                    GenreTxBx.Text = book.Genre;
                    FormatTxBx.Text = book.Format;
                    LanguageTxBx.Text = book.Language;
                    StockCntTxBx.Text = book.StockCount.ToString();
                }
                else if (selectedRow.DataBoundItem is Game game)
                {
                    VaruNrTxBx.Text = game.Id.ToString();
                    NameTxBx.Text = game.Name;
                    PriceTxBx.Text = game.Price.ToString();
                    PlatformTxBx.Text = game.Platform;
                    StockCntTxBx.Text = game.StockCount.ToString();
                }
                else if (selectedRow.DataBoundItem is Movie movie)
                {
                    VaruNrTxBx.Text = movie.Id.ToString();
                    NameTxBx.Text = movie.Name;
                    PriceTxBx.Text = movie.Price.ToString();
                    FormatTxBx.Text = movie.Format;
                    string[] lengthMin = movie.Length.Split();
                    LengthTxBx.Text = lengthMin[0];
                    StockCntTxBx.Text = movie.StockCount.ToString();
                }
                enableButtons();
                ClearBtn.Enabled = true;
                RemoveStoreBtn.Enabled = true;
                SaveStoreBtn.Enabled = true;
            }
        }

        private void SaveStoreBtn_Click(object sender, EventArgs e)
        {
            int stockCount = 0;
            int length = 0;
            int VaruNr;

            if (dataGridViewWarehouse.SelectedRows.Count > 0)
            {

                if (!string.IsNullOrEmpty(LengthTxBx.Text)) { length = int.Parse(LengthTxBx.Text); }
               
                ProductController.SaveChangesToProduct(dataGridViewWarehouse, NameTxBx.Text,
                    int.Parse(PriceTxBx.Text), AuthorTxBx.Text, GenreTxBx.Text, FormatTxBx.Text,
                    LanguageTxBx.Text, PlatformTxBx.Text, length, stockCount);
            }
            dataGridViewWarehouse.ClearSelection();
            RemoveStoreBtn.Enabled = false;
            
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
            StockCntTxBx.Text = "";
            SaveStoreBtn.Enabled = false;
            dataGridViewWarehouse.ClearSelection();
            RemoveStoreBtn.Enabled = false;
        }

        private void DeliveryTxBx_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(DeliveryTxBx.Text) || int.Parse(DeliveryTxBx.Text) < 0) { DeliveryBtn.Enabled = false; }
            else { DeliveryBtn.Enabled = true; }
        }

        private void DeliveryBtn_Click(object sender, EventArgs e)
        {
            ProductController.AddDelivery(dataGridViewWarehouse, int.Parse(DeliveryTxBx.Text));
            DeliveryTxBx.Text = "";
        }
    }
}
