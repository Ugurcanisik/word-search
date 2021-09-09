using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string[] dizi = new string[41];
        public string dosyayolu;
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Enabled=false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("aranacak kelimeyi giriniz");
            }
            else
            {
                if(textBox2.Text!="")
                {

                    arama();

                    int k = 0, sayac = 0, sonuc;

                    string ara = textBox1.Text;

                    while (k < 41)
                    {
                        string deneme = dizi[k];

                        sonuc = deneme.IndexOf(ara);

                        if (sonuc != -1)
                        {
                            sayac++;
                        }

                        k++;
                    }

                    MessageBox.Show("Aranan Kelime: " + ara + " " + sayac.ToString() + " Defa Geçmektedir");
                }
                else
                {
                    MessageBox.Show("Dosya Seçiniz");
                }

            }
        }

        void arama()
        {

            FileStream fs = new FileStream(dosyayolu, FileMode.Open, FileAccess.Read);

            StreamReader sw = new StreamReader(fs);

            int sayac = 0;
            string yazi = sw.ReadLine();

            while (yazi != null)
            {

                dizi[sayac] = yazi;
                yazi = sw.ReadLine();
                sayac++;

            }


            sw.Close();
            fs.Close();
        }


        
        private void button2_Click(object sender, EventArgs e)
        {
           
             OpenFileDialog file = new OpenFileDialog();
             file.Filter = "Metin Belgesi |*.txt";

            if (file.ShowDialog() == DialogResult.OK)
                {

                    dosyayolu = file.FileName;
                    string DosyaAdi = file.SafeFileName;
                    textBox2.Text = dosyayolu;
                }
           
           
        }
    }
}
