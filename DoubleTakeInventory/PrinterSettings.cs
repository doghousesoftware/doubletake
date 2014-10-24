using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using System.Xml;
using Settings = DoubleTakeInventory.Properties.Settings;


namespace DoubleTakeInventory
{
    public partial class PrinterSettings : Form
    {
        public List<string> Printers1 = new List<string>();
        public List<string> Printers2 = new List<string>();
        public List<string> Printers3 = new List<string>();
        public static string strFilename;
        public static string ReportPrinter;
        public static string LabelPrinter;
        public static string RegisterPrinter;
        public PrinterSettings()
        {
            InitializeComponent();
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            strFilename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DoubleTakePrinterAssignments.xml");
            
        }

        private void FetchPrinters()
        {
            foreach (string PrinterName in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                Printers1.Add(PrinterName);
                Printers2.Add(PrinterName);
                Printers3.Add(PrinterName);
            }
            cboLabel.DataSource = Printers1;
            cboRegister.DataSource = Printers2;
            cboReport.DataSource = Printers3;
        }

        private void Save()
        {
            GoWriter();
            FetchPrinters();
            GlobalClass.RegisterPrinter = RegisterPrinter;
            GlobalClass.LabelPrinter = LabelPrinter;
            GlobalClass.ReportPrinter = ReportPrinter;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblLabel.Text = cboLabel.SelectedItem.ToString();
         
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblRegister.Text = cboRegister.SelectedItem.ToString();
           
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblReport.Text = cboReport.SelectedItem.ToString();
           
        }

        public void LoadPrinters()
        {
            if (File.Exists(strFilename) == true)
            {
                GoReader();
            }
            else
            {
                //message we need to write the file for the first time
                MessageBox.Show("First time use - we need to make a file - please wait!", "Printer Settings",MessageBoxButtons.OK,MessageBoxIcon.Information);
                MakeFile();
                MessageBox.Show("Please close this form and load again","Printer Settings",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void PrinterSettings_Load(object sender, EventArgs e)
        {
            FetchPrinters();
            LoadPrinters();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }

        private void GoReader()
        {
            XmlTextReader textReader = new XmlTextReader(strFilename);
            textReader.Read();
            while (textReader.Read())
            {
                XmlNodeType nType = textReader.NodeType;
                switch (textReader.Name)
                {
                    case "RegisterPrinter":
                        lblRegister.Text = textReader.ReadInnerXml().ToString();
                        break;

                    case "ReportPrinter":
                        lblReport.Text = textReader.ReadInnerXml().ToString();
                        break;

                    case "LabelPrinter":
                        lblLabel.Text = textReader.ReadInnerXml().ToString();
                        break;
                }
            }
            textReader.Close();
        }

        private void MakeFile()
        {
            //the xml printer file does not exist so we create it
            Printers printername = new Printers();
            printername.LabelPrinter = "Zebra";
            printername.RegisterPrinter = "Epson";
            printername.ReportPrinter = "Brother";
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Printers));
            System.IO.StreamWriter file = new System.IO.StreamWriter(strFilename);
            writer.Serialize(file, printername);
            file.Close();
        }


        private void GoWriter()
        {
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(strFilename);
            XmlNode node;
            node = myXmlDocument.DocumentElement;
            foreach (XmlNode node1 in node.ChildNodes)
            {
                switch (node1.Name)
                {
                    case "ReportPrinter":
                        node1.InnerText = lblReport.Text;
                        break;

                    case "RegisterPrinter":
                        node1.InnerText = lblRegister.Text;
                        break;

                    case "LabelPrinter":
                        node1.InnerText = lblLabel.Text;
                        break;
                }
            }
            myXmlDocument.Save(strFilename);
        }
    }


    public class Printers
    {
        public string RegisterPrinter;
        public string LabelPrinter;
        public string ReportPrinter;
    }
}
