using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DT_SalesRegister
{
    public partial class UserControl1 : UserControl
    {
        public delegate void ButtonClick(object sender, NewEventArgs newe);
        public delegate void TextBoxChange(object sender, NewEventArgs newe);
        public event ButtonClick DeleteClick;
        public event TextBoxChange TextChange;
        public int UserControlLineItemID { get; set; }
        
        public UserControl1()
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
            var d = new NewEventArgs();
            d.LineItemID = UserControlLineItemID;
            d.QuantityChange = txtQuantity.Text;
            d.PriceChange = txtPrice.Text;

            if (this.TextChange != null)
                this.TextChange(sender, d);
        }

        private void txtPrice_LostFocus(object sender, EventArgs e)
        {
            var d = new NewEventArgs();
            d.LineItemID = UserControlLineItemID;
            d.PriceChange = txtPrice.Text;
            d.QuantityChange = txtQuantity.Text;
            
            if (this.TextChange != null)
                this.TextChange(sender, d);
        }

        
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            var d = new NewEventArgs();
            d.LineItemID = UserControlLineItemID;
            d.PriceChange = txtPrice.Text;
            d.QuantityChange = txtQuantity.Text;
            if (this.DeleteClick != null)
                this.DeleteClick(this, d);
        }

       

       
        
   }

   
}
