using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KassaSystem
{
    public partial class StoreManagementForm : Form
    {
        public StoreManagementForm()
        {
            InitializeComponent();
        }

        private void StoreManagementForm_Load(object sender, EventArgs e)
        {
            CheckoutControl checkoutControl = new CheckoutControl();
            checkoutControl.Dock = DockStyle.Fill;
            CheckoutTab.Controls.Add(checkoutControl);

            WarehouseControl warehouseControl = new WarehouseControl();
            warehouseControl.Dock = DockStyle.Fill;
            WarehouseTab.Controls.Add(warehouseControl);
            
        }
    }
}
