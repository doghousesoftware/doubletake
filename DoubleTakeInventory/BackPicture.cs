using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DoubleTakeInventory
{
    public partial class BackPicture : Form
    {
        public BackPicture()
        {
            InitializeComponent();
            
        }

        private void BackPicture_Load(object sender, EventArgs e)
        {
            /*
            openFileDialog1.Title = "Select the picture for your background";
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "JPG files (*.jpg)|*.jpb|BMP files (*.bmp)|*.bmp|PNG files (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            DialogResult result = openFileDialog1.ShowDialog();
            Properties.Settings.Default.BackgroundImage = result.ToString();

            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient)
                {
                    ctl.BackgroundImage = Properties.Settings.Default.BackgroundImage;
                    break;
                }
            }
            base.OnLoad(e);

            */
        }
    }
}
