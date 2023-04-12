using System;
using System.Windows.Forms;

namespace KassaSystem
{
    /**
     * This is the main class which presents the form for managing the store. The form has controls for checkout and warehouse 
     * operations, and an instance of the class ProductController. It sets the default value of StoreTabControl to -1, 
     * saves the product data to a file when the form is closed, and displays a welcome message when the form is shown. 
     * The StoreTabControl_SelectedIndexChanged method determines which tab is selected and displays a message to the user.
     * 
     * @Author Liza Danielsson.
     */
    public partial class StoreManagementForm : Form
    {
        CheckoutControl checkoutControl;
        WarehouseControl warehouseControl;
        ProductController ProductController;

        //Constructor.
        public StoreManagementForm()
        {
            InitializeComponent();
                //Instance of ProductController to save products to file when closed.
            ProductController = new ProductController();
        }



        //Sets the tabindex of the tabcontrols to -1 (unselected) so user can select view.
        private void StoreManagementForm_Load(object sender, EventArgs e)
        {
            StoreTabControl.SelectedIndex = -1;
        }



        //Calls instance method to save products to file when form is closed.
        private void StoreManagementForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProductController.SaveToFile();
        }



        //Shows welcome message with instructions when form is shown.
        private void StoreManagementForm_Shown(object sender, EventArgs e)
        {
            MessageBox.Show("Choose view to get started by clicking one of the two tabs \"Checkout\" or \"Warehouse\".", 
                "Welcome!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        //Changes the control/view shown to the user when user changes tab.
        private void StoreTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(StoreTabControl.SelectedIndex == 0)
            {
                checkoutControl = new CheckoutControl(ProductController);
                checkoutControl.Dock = DockStyle.Fill;
                CheckoutTab.Controls.Add(checkoutControl);

                MessageBox.Show("Choose one category between books, games or movies to get started.", "Welcome!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(StoreTabControl.SelectedIndex == 1)
            {
                warehouseControl = new WarehouseControl(ProductController);
                warehouseControl.Dock = DockStyle.Fill;
                WarehouseTab.Controls.Add(warehouseControl);

                MessageBox.Show("Choose one category between books, games or movies to get started.", "Welcome!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
