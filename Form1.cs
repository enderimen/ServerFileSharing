using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ServerFileSharing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
          
         /*
         ##Author       :Ender İMEN 
         ##Develop Time :Son Düzenleme Tarihi: 21.04.2017 | Saat: 23.38
         ##NOT          :Çoklu dosya transfer işlemi için gereken kodlar yazılacak.
         */
        string sourcePath = @"C:\Program Files (x86)\Common Files\";//Dosyaların kopyalanacağı dizin
        string kopyalanacakDosya = "", kopyalanacakDosyaIsmi = "", dosyanınKopyalacagiKlasor = "";
        void kopyala()
        {
          openFileDialog1.Title = "Dosya Seçiniz...";

          openFileDialog1.FileName = "";
          this.openFileDialog1.Multiselect = true;
          if (openFileDialog1.ShowDialog() == DialogResult.OK)
          {
            openFileDialog1.InitialDirectory = "C:\\";
            kopyalanacakDosyaIsmi = openFileDialog1.SafeFileName.ToString();
            kopyalanacakDosya = openFileDialog1.FileName.ToString();
            textBox1.Text = kopyalanacakDosya;
          }
          else
          {
            MessageBox.Show("Dosya Seçmediniz...", "Uyarı..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          } 
        }//Kopylama Fonksiyonu
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            toolStripStatusLabel3.Text=DateTime.Now.ToLongDateString();
        } //Gün 

        private void timer1_Tick(object sender, EventArgs e)
        {
          toolStripStatusLabel2.Text = DateTime.Now.Hour.ToString() + ":"+DateTime.Now.Minute.ToString() + ":"+ DateTime.Now.Second.ToString();
        }//Saat 

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
          DialogResult state = MessageBox.Show("Programı kapatmak istediğinizden emin misiniz?","Bilgi",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
          
          if (state == DialogResult.No)
          {
            e.Cancel = true;
          }
          else { e.Cancel = false; }
        }//Çıkış

        private void button2_Click_1(object sender, EventArgs e)
        {
          try
          {
          if (textBox1.Text!="")
	        {
            //Program Files (X86) yoksa Program Files ın içerisine kopyalar. 
            /* if (File.Exists(sourcePath))
             {
               sourcePath = @"C:\Program Files\Common Files\";
             }
            */
            dosyanınKopyalacagiKlasor = sourcePath;

            if (dosyanınKopyalacagiKlasor != "" && kopyalanacakDosya != "")
            {
              if (File.Exists(dosyanınKopyalacagiKlasor + "" + kopyalanacakDosyaIsmi))
              {
                MessageBox.Show("Belirtilen klasörde " + kopyalanacakDosyaIsmi + " isimli dosya zaten mevcut...", "Uyarı..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              }
              else
              {
                File.Copy(kopyalanacakDosya, dosyanınKopyalacagiKlasor + "" + kopyalanacakDosyaIsmi);
                MessageBox.Show("Dosya Kopyalama İşlemi Başarılı", "Dosya Kopyalandı...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
              }
            }
            else if (dosyanınKopyalacagiKlasor == "")
            {
              MessageBox.Show("Dosyanın Kopyalanacağı Klasörü Seçiniz...", "Uyarı..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (kopyalanacakDosya == "")
            {
              MessageBox.Show("Dosya Seçiniz...", "Uyarı..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
          }
          else
          {
            MessageBox.Show("Dosya Seçiniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          }
	        }
          catch (Exception hata)
          {
            MessageBox.Show("Dosya Paylaşım Hatası!\n\n" + hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }   
        }//Dosyanın hedef klasöre taşınması

        private void button1_Click_1(object sender, EventArgs e)
        {
          kopyala();
        }//Kopylama
    }
}

   