using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DoubleTakeInventory;

namespace DoubleTakeInventory
{
    public partial class RegisterLineItemControl : UserControl
    {
        public delegate void ButtonClick(object sender, NewEventArgs newe);
        // public delegate void TextBoxChange(object sender, NewEventArgs newe);
        public delegate void PriceChange(object sender, NewEventArgs newe);
        public delegate void QuantityChange(object sender, NewEventArgs newe);
        public event ButtonClick DeleteClick;
        // public event TextBoxChange TextChange;
        public event PriceChange priceChange;
        public event QuantityChange quantityChange;
        public int UserControlLineItemID { get; set; }
        
        public RegisterLineItemControl()
        {
            InitializeComponent();
        }

        public void SetNewLineItem(int NewQuantity, double NewPrice, double NewExtended)
        {
            txtQuantity.Text = NewQuantity.ToString();
            txtPrice.Text = NewPrice.ToString("c");
            txtExtended.Text = NewExtended.ToString("c");
        }

        public void LoadControl(SoldLineItem li)
        {
            this.lblLineItem.Text = li.LineItemID.ToString();
            this.txtItemID.Text = li.ItemID.ToString();
            this.txtDescription.Text = li.Description;
            this.txtPrice.Text = li.Price.ToString("c");
            this.txtQuantity.Text = li.Quantity.ToString();
            this.txtExtended.Text = li.Extended.ToString("c");
            UserControlLineItemID = int.Parse(li.LineItemID.ToString());
        }

       
        private void txtQuantity_LostFocus(object sender, EventArgs e)
        {
            try
            {
                var d = new NewEventArgs();
                d.LineItemID = UserControlLineItemID;
                d.QuantityChange = txtQuantity.Text;
                d.PriceChange = txtPrice.Text;

                if (this.quantityChange != null)
                {
                    this.quantityChange(sender, d);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Exception at txtQuantity_LostFocus {0}", ex));
            }
            
        }

        private void txtPrice_LostFocus(object sender, EventArgs e)
        {
            try
            {
                var d = new NewEventArgs();
                d.LineItemID = UserControlLineItemID;
                d.PriceChange = txtPrice.Text;
                d.QuantityChange = txtQuantity.Text;

                if (this.priceChange != null)
                {
                    this.priceChange(sender, d);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Exception at txtPrice_LostFocus {0}", ex));
            }
            
        }
        
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var d = new NewEventArgs();
                d.LineItemID = UserControlLineItemID;
                d.PriceChange = txtPrice.Text;
                d.QuantityChange = txtQuantity.Text;
                if (this.DeleteClick != null)
                    this.DeleteClick(this, d);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Exception at cmdDelete_Click {0}", ex));
            }
        }
   }
}