using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace kur
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        XElement gelenVeri;
        private void Form1_Load(object sender, EventArgs e)
        {
            gelenVeri =
                XElement.Load("http://www.tcmb.gov.tr/kurlar/today.xml");
            //XElement dolar = gelenVeri.Elements().Where(s => s.Attribute("KOD").Value == "USD").Single();

            foreach (XElement item in gelenVeri.Elements())
            {

                //if (item.Attribute("Kod").Value=="USD")
                //{
                //    MessageBox.Show(item.Element("ForexBuying").Value);
                //}
                comboBox1.Items.Add(item.Attribute("Kod").Value);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (XElement item in gelenVeri.Elements())
            {

                if (item.Attribute("Kod").Value == comboBox1.SelectedItem.ToString())
                {
                    double para = double.Parse(textBox1.Text);
                    double kur = double.Parse(item.Element("ForexBuying").Value.Replace('.',','));
                    double sonuc = para / kur;
                    MessageBox.Show("Bu kadar : "+Math.Round(sonuc,2).ToString());
                }

            }
        }
    }
}
