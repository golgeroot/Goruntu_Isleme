﻿using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections; // Arraylist in kütüphanesi
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Goruntu_Isleme
{
    public partial class Goruntu_Isleme : Form
    {
        public Goruntu_Isleme()
        {
            InitializeComponent();
        }
        OpenFileDialog openFileDialog = new OpenFileDialog();

        public void DosyaAc()
        {
            try
            {
                openFileDialog.DefaultExt = ".jpg";
                openFileDialog.Filter = "Resim Dosyası |*.jpeg|Resim Dosyası |*.png|Tüm Dosyalar |*.*";
                openFileDialog.Title = "~~ Son Resim Bükücü ~~";
                openFileDialog.FilterIndex = 2;
                openFileDialog.Multiselect = true;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.ShowDialog();
                string resimyolu = openFileDialog.FileName;
                pictureBox1.ImageLocation = resimyolu;
            }
            catch (Exception ex)
            {
                MessageBox.Show("System32 Dosyaları siliniyor !", "UYARI! TROJAN 000000X7B ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.ToString(), "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void BDosyaAc_Click(object sender, EventArgs e)
        {
            DosyaAc();
        }
        private void BKaydet_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Jpeg Resmi|*.jpg|Bitmap Resmi|*.bmp|Gif Resmi|*.gif";
            saveFileDialog.Title = "Resmi Kaydet";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                FileStream DosyaAkisi = (FileStream)saveFileDialog.OpenFile();
                switch (saveFileDialog.FilterIndex)
                {
                    case 1:
                        pictureBox2.Image.Save(DosyaAkisi, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 2:
                        pictureBox2.Image.Save(DosyaAkisi, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 3:
                        pictureBox2.Image.Save(DosyaAkisi, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }
                DosyaAkisi.Close();
            }

        }
        private void BResimPixel_Click(object sender, EventArgs e)
        {
            Color OkunanRenk, DonusenRenk;
            int R = 0, G = 0, B = 0;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);

            int ResimGenisligi = GirisResmi.Width; // Giriş resmi golabal tanımlandı. İçeri yüklendi.
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); // Çıkış Resmini oluşturuyor. Boyutları giriş resmi ila aynı olur. Tanımlaaması globalde yapıldı

            int i = 0, j = 0; // Çıkış resminin x ve y si olacak

            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    R = OkunanRenk.R;
                    G = OkunanRenk.G;
                    B = OkunanRenk.B;

                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }
        private void BNegatif_Click(object sender, EventArgs e)
        {
            Color OkunanRenk, DonusenRenk;
            int R = 0, G = 0, B = 0;

            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);

            int ResimGenisligi = GirisResmi.Width; // Giriş Resminin genişliğini aldı
            int ResimYuksekligi = GirisResmi.Height; // Giriş Resminin yüksekliğini aldı

            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); //Cikis resmini oluşturuyor. 

            int i = 0, j = 0; // Çıkış resminin x ve y si olacak
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    R = 255 - OkunanRenk.R;
                    G = 255 - OkunanRenk.G;
                    B = 255 - OkunanRenk.B;

                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }
        private void BGriTon_Click(object sender, EventArgs e)
        {
            GriTon1();
        }
        private void BGriTon2_Click(object sender, EventArgs e)
        {
            Color OkunanRenk, DonusenRenk;

            Bitmap GirisResmi = new Bitmap(pictureBox1.Image);

            int ResimGenisligi = GirisResmi.Width;  // Resmin genilşiğini aldı
            int ResimYuksekligi = GirisResmi.Height; // Resmin Yüksekliğini aldı

            Bitmap CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); // Çıkış resmini oluşturdu. Giriş resmi ile aynı  olur

            int GriDeger = 0;
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    double R = OkunanRenk.R;
                    double G = OkunanRenk.G;
                    double B = OkunanRenk.B;

                    // GriDeger = Convert.ToInt16((R + G + B) / 3);
                    GriDeger = Convert.ToInt16(R * 0.3 + G * 0.6 + B * 0.1);
                    // GriDeger = Convert.ToInt16((R * 0.299) + (G * 0.587) + (B * 0.114));
                    //GriDegeri = 0.299 x R + 0.587 x G + 0.114 x B
                    DonusenRenk = Color.FromArgb(GriDeger, GriDeger, GriDeger);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }
        private void BGriTon3_Click(object sender, EventArgs e)
        {
            Color OkunanRenk, DonusenRenk;

            Bitmap GirisResmi = new Bitmap(pictureBox1.Image);

            int ResimGenisligi = GirisResmi.Width;  // Resmin genilşiğini aldı
            int ResimYuksekligi = GirisResmi.Height; // Resmin Yüksekliğini aldı

            Bitmap CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); // Çıkış resmini oluşturdu. Giriş resmi ile aynı  olur

            int GriDeger = 0;
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    double R = OkunanRenk.R;
                    double G = OkunanRenk.G;
                    double B = OkunanRenk.B;

                    // GriDeger = Convert.ToInt16((R + G + B) / 3);
                    // GriDeger = Convert.ToInt16(R * 0.3 + G * 0.6 + B * 0.1);
                    GriDeger = Convert.ToInt16((R * 0.299) + (G * 0.587) + (B * 0.114));

                    DonusenRenk = Color.FromArgb(GriDeger, GriDeger, GriDeger);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }
        private void BGriTon4_Click(object sender, EventArgs e)
        {
            Color OkunanRenk, DonusenRenk;

            Bitmap GirisResmi = new Bitmap(pictureBox1.Image);

            int ResimGenisligi = GirisResmi.Width;  // Resmin genilşiğini aldı
            int ResimYuksekligi = GirisResmi.Height; // Resmin Yüksekliğini aldı

            Bitmap CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); // Çıkış resmini oluşturdu. Giriş resmi ile aynı  olur

            int GriDeger = 0;
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    double R = OkunanRenk.R;
                    double G = OkunanRenk.G;
                    double B = OkunanRenk.B;

                    // GriDeger = Convert.ToInt16((R + G + B) / 3);
                    // GriDeger = Convert.ToInt16(R * 0.3 + G * 0.6 + B * 0.1);
                    // GriDeger = Convert.ToInt16((R * 0.299) + (G * 0.587) + (B * 0.114));
                    GriDeger = Convert.ToInt16((R * 0.21) + (G * 0.71) + (B * 0.071));
                    DonusenRenk = Color.FromArgb(GriDeger, GriDeger, GriDeger);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }
        private void BGriTon5_Click(object sender, EventArgs e)
        {
            Color OkunanRenk, DonusenRenk;

            Bitmap GirisResmi = new Bitmap(pictureBox1.Image);

            int ResimGenisligi = GirisResmi.Width;  // Resmin genilşiğini aldı
            int ResimYuksekligi = GirisResmi.Height; // Resmin Yüksekliğini aldı

            Bitmap CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); // Çıkış resmini oluşturdu. Giriş resmi ile aynı  olur

            int GriDeger = 0;
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    double R = OkunanRenk.R;
                    double G = OkunanRenk.G;
                    double B = OkunanRenk.B;

                    // GriDeger = Convert.ToInt16((R + G + B) / 3);
                    // GriDeger = Convert.ToInt16(R * 0.3 + G * 0.6 + B * 0.1);
                    // GriDeger = Convert.ToInt16((R * 0.299) + (G * 0.587) + (B * 0.114));
                    //GriDeger = Convert.ToInt16((R * 0.21) + (G * 0.71) + (B * 0.071));
                    GriDeger = Convert.ToInt16((R * 0.3) + (G * 0.6) + (B * 0.1));

                    DonusenRenk = Color.FromArgb(GriDeger, GriDeger, GriDeger);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }
        private void BGriTon6_Click(object sender, EventArgs e)
        {
            Color OkunanRenk, DonusenRenk;

            Bitmap GirisResmi = new Bitmap(pictureBox1.Image);

            int ResimGenisligi = GirisResmi.Width;  // Resmin genilşiğini aldı
            int ResimYuksekligi = GirisResmi.Height; // Resmin Yüksekliğini aldı

            Bitmap CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); // Çıkış resmini oluşturdu. Giriş resmi ile aynı  olur

            int GriDeger = 0;
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    double R = OkunanRenk.R;
                    double G = OkunanRenk.G;
                    double B = OkunanRenk.B;

                    GriDeger = Convert.ToInt16((R + G + B) / 3);
                    // GriDeger = Convert.ToInt16(R * 0.3 + G * 0.6 + B * 0.1);
                    // GriDeger = Convert.ToInt16((R * 0.299) + (G * 0.587) + (B * 0.114));
                    //GriDegeri = 0.299 x R + 0.587 x G + 0.114 x B

                    int GriDegeri = (int)(OkunanRenk.R + OkunanRenk.G + OkunanRenk.B) / 3; //Ortalama Gri-ton formülü
                    DonusenRenk = Color.FromArgb(GriDegeri, GriDegeri, GriDegeri);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Color Renk = ((Bitmap)pictureBox1.Image).GetPixel(e.X, e.Y);
            txtRGB.Text = string.Format("R:{0} G:{1} B:{2}", Renk.R, Renk.G, Renk.B);

        }
        int p1 = 0, p2 = 0, p3 = 0; // Parlaklık değerlerini tutacaklar p1,p2,p3
        int tr1 = 0, tr2 = 0, tr3 = 0; // Trackbar değerlerini tutacaklar tr1,tr2,tr3
        public void GriTon1()
        {
            Color OkunanRenk, DonusenRenk;

            Bitmap GirisResmi = new Bitmap(pictureBox1.Image);

            int ResimGenisligi = GirisResmi.Width;  // Resmin genilşiğini aldı
            int ResimYuksekligi = GirisResmi.Height; // Resmin Yüksekliğini aldı

            Bitmap CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); // Çıkış resmini oluşturdu. Giriş resmi ile aynı  olur

            int GriDeger = 0;
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    double R = OkunanRenk.R;
                    double G = OkunanRenk.G;
                    double B = OkunanRenk.B;

                    GriDeger = Convert.ToInt16((R + G + B) / 3);
                    DonusenRenk = Color.FromArgb(GriDeger, GriDeger, GriDeger);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }
        public Bitmap ResminParlaklikArttir() // Resmin Parlaklığını Arttırır
        {
            int R = 0, G = 0, B = 0;
            Color OkunanRenk, DonusenRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox2.Image);

            int ResimGenisligi = GirisResmi.Width; // Giris Resmi Globale Tanımlandı.
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); // Cikis resmini oluşturuyor. Boyutları giriş resmi ile aynı olur

            int i = 0, j = 0; // Çıkış resminin x ve y si olacak.
            for (int x = 0; x < ResimGenisligi; x++)
            {
                // Olayın beyni burası !!!
                j = 0;
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    // Rengi 50 değer ile açacak
                    R = OkunanRenk.R + p1;
                    G = OkunanRenk.G + p2;
                    B = OkunanRenk.B + p3;

                    //Renkler 255'i geçerse son sınır olan 255 alınacak
                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;

                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(i, j, DonusenRenk);
                    j++;
                }
                i++;
            }
            pictureBox2.Image = CikisResmi;
            return CikisResmi;
        }
        public Bitmap ResminParlaklikAzalt() // Resmin Parlaklığını Azaltır
        {
            int R = 0, G = 0, B = 0;
            Color OkunanRenk, DonusenRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox2.Image);

            int ResimGenisligi = GirisResmi.Width; // Giris Resmi Globale Tanımlandı.
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); // Cikis resmini oluşturuyor. Boyutları giriş resmi ile aynı olur

            int i = 0, j = 0; // Çıkış resminin x ve y si olacak.
            for (int x = 0; x < ResimGenisligi; x++)
            {
                // Olayın beyni burası !!!
                j = 0;
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    // Rengi 50 değer ile açacak
                    R = OkunanRenk.R - p1;
                    G = OkunanRenk.G - p2;
                    B = OkunanRenk.B - p3;

                    //Renkler 255'i geçerse son sınır olan 255 alınacak
                    if (R < 0) R = 0;
                    if (G < 0) G = 0;
                    if (B < 0) B = 0;

                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(i, j, DonusenRenk);
                    j++;
                }
                i++;
            }
            pictureBox2.Image = CikisResmi;
            return CikisResmi;
        }
        public Bitmap ResminParlakliginiArttirTRBAR() // TBar Değeri Kadar Parlaklık Arttır
        {
            int R = 0, G = 0, B = 0;
            Color OkunanRenk, DonusenRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);

            int ResimGenisligi = GirisResmi.Width; // Giris Resmi Globale Tanımlandı.
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); // Cikis resmini oluşturuyor. Boyutları giriş resmi ile aynı olur

            int i = 0, j = 0; // Çıkış resminin x ve y si olacak.
            for (int x = 0; x < ResimGenisligi; x++)
            {
                // Olayın beyni burası !!!
                j = 0;
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    // Rengi 50 değer ile açacak
                    R = OkunanRenk.R + tr1;
                    G = OkunanRenk.G + tr2;
                    B = OkunanRenk.B + tr3;

                    //Renkler 255'i geçerse son sınır olan 255 alınacak
                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;

                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(i, j, DonusenRenk);
                    j++;
                }
                i++;
            }
            pictureBox2.Image = CikisResmi;
            return CikisResmi;
        }
        public Bitmap ResmiEsiklemeYap() // Resim içerisindeki her pikselin renk değeri belli bir eşik değeri ile kıyaslanır.
        {
            int R = 0, G = 0, B = 0;
            Color OkunanRenk, DonusenRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);

            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); // Çıkış resmini oluşturuyor. Boyutları giriş resmi ile aynı olur.

            int EsiklemeDegeri = Convert.ToInt32(TxtEsikleme.Text);

            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    if (OkunanRenk.R >= EsiklemeDegeri)
                        R = 255;
                    else
                        R = 0;

                    if (OkunanRenk.G >= EsiklemeDegeri)
                        G = 255;
                    else
                        G = 0;

                    if (OkunanRenk.B >= EsiklemeDegeri)
                        B = 255;
                    else
                        B = 0;

                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
            return CikisResmi;
        }
        public Bitmap Tasima() // Taşıma
        {
            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);

            double x2 = 0, y2 = 0;

            //Taşıma mesafelerini atıyor
            int Tx = 100;
            int Ty = 60;

            for (int x1 = 0; x1 < (ResimGenisligi); x1++)
            {
                for (int y1 = 0; y1 < (ResimYuksekligi); y1++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x1, y1);

                    x2 = x1 + Tx;
                    y2 = y1 + Ty;

                    if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYuksekligi)
                        CikisResmi.SetPixel((int)x2, (int)y2, OkunanRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
            return CikisResmi;
        }
        public Bitmap Aynalama() // Ayna bakış vs.
        {
            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);

            int ResimGenisligi = GirisResmi.Width;
            int ResimYusekligi = GirisResmi.Height;

            CikisResmi = new Bitmap(ResimGenisligi, ResimYusekligi);

            double Aci = Convert.ToDouble(tAynalama.Text);
            double RadyanAci = Aci * 2 * Math.PI / 360;

            double x2 = 0, y2 = 0;

            //Resim merkezini buluyor. Resmin merkezi etrafında döndürülecek
            int x0 = ResimGenisligi / 2;
            int y0 = ResimYusekligi / 2;

            for (int x1 = 0; x1 < (ResimGenisligi); x1++)
            {
                for (int y1 = 0; y1 < (ResimYusekligi); y1++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x1, y1);

                    //----A-Orta dikey eksen etrafında aynalama ----------------
                    //x2 = Convert.ToInt16(-x1 + 2 * x0); 
                    //y2 = Convert.ToInt16(y1);


                    //----B-Orta yatay eksen etrafında aynalama ----------------
                    //x2 = Convert.ToInt16(x1);
                    //y2 = Convert.ToInt16(-y1 + 2 *y0);

                    //----C-Ortadan geçen 45 açılı çizgi etrafında aynalama----------
                    double Delta = (x1 - x0) * Math.Sin(RadyanAci) - (y1 - y0) * Math.Cos(RadyanAci);
                    x2 = Convert.ToInt16(x1 + 2 * Delta * (-Math.Sin(RadyanAci)));
                    y2 = Convert.ToInt16(y1 + 2 * Delta * (Math.Cos(RadyanAci)));
                    if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYusekligi)
                        CikisResmi.SetPixel((int)x2, (int)y2, OkunanRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
            return CikisResmi;

        }
        public Bitmap Egme_Kaydirma() // Resmin bir kısmını sabit tutup kalanı eğme\kaydırma
        {
            // Aynı resmi birden fazla kez eğmesi için yapılan kontrol if else bloğunda. 
            if (pictureBox2.Image == null)
            {

                Color OkunanRenk;
                Bitmap GirisResmi, CikisResmi;
                GirisResmi = new Bitmap(pictureBox1.Image);
                int ResimGenisligi = GirisResmi.Width;
                int ResimYuksekligi = GirisResmi.Height;
                CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
                //Taşıma mesafelerini atıyor. 
                double EgmeKatsayisi = 0.2;
                double x2 = 0, y2 = 0;
                for (int x1 = 0; x1 < (ResimGenisligi); x1++)
                {
                    for (int y1 = 0; y1 < (ResimYuksekligi); y1++)
                    {
                        OkunanRenk = GirisResmi.GetPixel(x1, y1);
                        // +X ekseni yönünde
                        //x2 = x1 + EgmeKatsayisi * y1;
                        //y2 = y1;
                        // -X ekseni yönünde
                        //x2 = x1 - EgmeKatsayisi * y1;
                        //y2 = y1;
                        // +Y ekseni yönünde
                        //x2 = x1;
                        //y2 = EgmeKatsayisi * x1 + y1;
                        // -Y ekseni yönünde
                        x2 = x1;
                        y2 = -EgmeKatsayisi * x1 + y1;

                        if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYuksekligi)
                            CikisResmi.SetPixel((int)x2, (int)y2, OkunanRenk);
                    }
                }
                pictureBox2.Image = CikisResmi;
                return CikisResmi;
            }
            else
            {

                Color OkunanRenk;
                Bitmap GirisResmi, CikisResmi;
                GirisResmi = new Bitmap(pictureBox2.Image);
                int ResimGenisligi = GirisResmi.Width;
                int ResimYuksekligi = GirisResmi.Height;
                CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
                //Taşıma mesafelerini atıyor. 
                double EgmeKatsayisi = 0.2;
                double x2 = 0, y2 = 0;
                for (int x1 = 0; x1 < (ResimGenisligi); x1++)
                {
                    for (int y1 = 0; y1 < (ResimYuksekligi); y1++)
                    {
                        OkunanRenk = GirisResmi.GetPixel(x1, y1);
                        // +X ekseni yönünde
                        //x2 = x1 + EgmeKatsayisi * y1;
                        //y2 = y1;
                        // -X ekseni yönünde
                        //x2 = x1 - EgmeKatsayisi * y1;
                        //y2 = y1;
                        // +Y ekseni yönünde
                        //x2 = x1;
                        //y2 = EgmeKatsayisi * x1 + y1;
                        // -Y ekseni yönünde
                        x2 = x1;
                        y2 = -EgmeKatsayisi * x1 + y1;

                        if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYuksekligi)
                            CikisResmi.SetPixel((int)x2, (int)y2, OkunanRenk);
                    }
                }
                pictureBox2.Image = CikisResmi;
                return CikisResmi;
            }

        }


        /// <summary>
        ///  Küçültme-Pixel Değiştirme Metodu
        // Giriş resmini X ve Y yönüne birer pixel atlayarak okursak ve okunan değerleri yeni resimde sırayla yerleştirirse
        // 1/2 küçültme sağlamış oluruz. Döngüdeki x ve y artış deeri küçütltme katsayısı olacaktır.
        /// </summary>
        /// <returns></returns>
        public Bitmap Kucultme_DegistirmeMetodu()
        {
            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);


            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);

            int x2 = 0, y2 = 0; // Çıkış resminin x ve y si olacak
            int KucultmeKatSayisi = int.Parse(tKucultOran.Text);

            for (int x1 = 0; x1 < ResimGenisligi; x1 = x1 + KucultmeKatSayisi)
            {
                y2 = 0;
                for (int y1 = 0; y1 < ResimYuksekligi; y1 = y1 + KucultmeKatSayisi)
                {
                    OkunanRenk = GirisResmi.GetPixel(x1, y1);

                    CikisResmi.SetPixel(x2, y2, OkunanRenk);
                    y2++;
                }
                x2++;
            }
            pictureBox2.Image = CikisResmi;
            return CikisResmi;

        }

        /// <summary>
        /// komşu pikseller arasında istatistiksel bir örnekleme yaparak (örneğin
        /// ortalamasını alarak) oluşturulacak pikselin değerini belirler.
        /// </summary>
        /// <returns></returns>
        public Bitmap Kucultme_Interpolasyon()
        {
            Color OkunanRenk,DonusenRenk;
            Bitmap GirisResmi, CikisResmi;
            int R = 0, G = 0, B = 0;

            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;

            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int x2 = 0, y2 = 0; // Çıkış resminin x ve y si olacak
            int KucultmeKatSayisi = 2;

            for (int x1 = 0; x1 < ResimGenisligi; x1 = x1 + KucultmeKatSayisi)
            {
                y2 = 0;
                for (int y1 = 0; y1 < ResimYuksekligi; y1 = y1 + KucultmeKatSayisi)
                {
                    // x ve y de ilerlerken her atlanan pixelleri okuyacak ve ortalama değerini alacak
                    R = 0; G = 0; B = 0;
                    try // resim sınırının dışına çıkıldığında hata vermesin diye
                    {
                        for (int i = 0; i < KucultmeKatSayisi; i++)
                        {
                            for (int j = 0; j < KucultmeKatSayisi; j++)
                            {
                                OkunanRenk = GirisResmi.GetPixel(x1 + i, y1 + j);

                                R = R + OkunanRenk.R;
                                G = G + OkunanRenk.G;
                                B = B + OkunanRenk.B;
                            }
                        }
                    }
                    catch { }
                    // Renk kanallarının ortalamasını alıyor
                    R = R / (KucultmeKatSayisi * KucultmeKatSayisi);
                    G = G / (KucultmeKatSayisi * KucultmeKatSayisi);
                    B =B / (KucultmeKatSayisi * KucultmeKatSayisi);

                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(x2, y2, DonusenRenk);
                    y2++;
                }
                x2++;
            }
            pictureBox2.Image = CikisResmi;
            return CikisResmi;
        }
        private void BParlaklik_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
            {
                pictureBox2.Image = pictureBox1.Image;
            }
            p1 = 50; p2 = 50; p3 = 50;
            ResminParlaklikArttir();
        }
        private void BParlaklik100_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
            {
                pictureBox2.Image = pictureBox1.Image;
            }
            p1 = 100; p2 = 100; p3 = 100;
            ResminParlaklikArttir();
        }
        private void BEksiParlaklik_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
            {
                pictureBox2.Image = pictureBox1.Image;
            }
            p1 = 50; p2 = 50; p3 = 50;
            ResminParlaklikAzalt();
        }
        private void BEksiParlaklik100_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
            {
                pictureBox2.Image = pictureBox1.Image;
            }
            p1 = 100; p2 = 100; p3 = 100;
            ResminParlaklikAzalt();
        }
        private void BEsikleme_Click(object sender, EventArgs e)
        {
            if (TxtEsikleme.Text != "")
            {
                ResmiEsiklemeYap();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void BHistogram_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            ArrayList DiziPiksel = new ArrayList();
            int OrtalamaRenk = 0;
            Color OkunanRenk;
            int R = 0, G = 0, B = 0;
            Bitmap GirisResmi; // Histogram için giriş resmi gri-ton olmalıdır
            GirisResmi = new Bitmap(pictureBox1.Image); // GriTon1 çağırılarak image 1'i gri ton olarak image 2 aktardık ve image 2 dosyasını kullanıyoruz

            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;

            int i = 0; // pixel sayısını tutacak
            for (int x = 0; x < GirisResmi.Width; x++)
            {
                for (int y = 0; y < GirisResmi.Height; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    OrtalamaRenk = (int)(OkunanRenk.R + OkunanRenk.G + OkunanRenk.B) / 3; // Griton resime çevir

                    DiziPiksel.Add(OrtalamaRenk);
                }
            }

            int[] DiziPixselSayilari = new int[256];
            for (int r = 0; r <= 255; r++) //256 renk tonu için donecek
            {
                int PixselSayisi = 0;
                for (int s = 0; s < DiziPiksel.Count; s++) // resimdeki pixel sayısınca donecek
                {
                    if (r == Convert.ToInt16(DiziPiksel[s]))
                        PixselSayisi++;
                }
                DiziPixselSayilari[r] = PixselSayisi;
            }

            //Değerleri listbox'a ekliyor
            int RenkMaksPixelSayisi = 0; //Grafikte y eksenini  ölçeklerken kullanılacak
            for (int k = 0; k <= 255; k++)
            {
                listBox1.Items.Add("Renk: " + k + "= " + DiziPixselSayilari[k]);
                //Maksimum pixel sayısını bulmaya calısıyor
                if (DiziPixselSayilari[k] > RenkMaksPixelSayisi)
                {
                    RenkMaksPixelSayisi = DiziPixselSayilari[k];
                }
            }
            //Grafiği Çiziyor.
            Graphics CizimAlani;
            Pen Kalem1 = new Pen(System.Drawing.Color.Yellow, 1);
            Pen Kalem2 = new Pen(System.Drawing.Color.Red, 1);
            CizimAlani = pictureBox2.CreateGraphics();

            pictureBox2.Refresh();
            int GrafikYuksekligi = 250;
            double OlcekY = RenkMaksPixelSayisi / GrafikYuksekligi;
            double OlcekX = 1.5;
            int X_kaydirma = 10;
            for (int x = 0; x <= 255; x++)
            {
                if (x % 50 == 0)
                    CizimAlani.DrawLine(Kalem2, (int)(X_kaydirma + x * OlcekX),
                   GrafikYuksekligi, (int)(X_kaydirma + x * OlcekX), 0);
                CizimAlani.DrawLine(Kalem1, (int)(X_kaydirma + x * OlcekX), GrafikYuksekligi,
               (int)(X_kaydirma + x * OlcekX), (GrafikYuksekligi - (int)(DiziPixselSayilari[x] / OlcekY)));
                //Dikey kırmızı çizgiler.

            }
            TxtHistogram.Text = "Maks.Piks=" + RenkMaksPixelSayisi.ToString();
        }

        private void BKontras_Click(object sender, EventArgs e)
        {
            Color OkunanRenk, DonusenRenk;
            int R = 0, G = 0, B = 0;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);

            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);

            int X1 = Convert.ToInt16(TxtX1.Text);
            int X2 = Convert.ToInt16(TxtX2.Text);
            int Y1 = Convert.ToInt16(TxtY1.Text);
            int Y2 = Convert.ToInt16(TxtY2.Text);

            int i = 0, j = 0; //Çıkış resminin x ve y si olacak.
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    R = OkunanRenk.R;
                    G = OkunanRenk.G;
                    B = OkunanRenk.B;
                    int Gri = (R + G + B) / 3;
                    //*********** Kontras Formülü***************
                    int X = Gri;
                    int Y = (((X - X1) * (Y2 - Y1)) / (X2 - X1)) + Y1;
                    if (Y > 255) Y = 255;
                    if (Y < 0) Y = 0;
                    DonusenRenk = Color.FromArgb(Y, Y, Y);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Refresh();
            pictureBox2.Image = null;
            pictureBox2.Image = CikisResmi;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) { Tasima(); } else { MessageBox.Show("Resim 1 Değeri Boş olmamalı", "Eksik Bilgi !", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tAynalama.Text != "" && pictureBox1.Image != null) { Aynalama(); } else { MessageBox.Show("Resim 1 ve Aynalama Değeri Boş olmamalı", "Eksik Bilgi !", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void BEgKaydir_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) { Egme_Kaydirma(); } else { MessageBox.Show("Resim 1 Değeri Boş olmamalı", "Eksik Bilgi !", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }
        private void bKucultmeDegistirme_Click(object sender, EventArgs e)
        {
            if (tKucultOran.Text != "" && pictureBox1.Image != null && int.Parse(tKucultOran.Text) >= 1 && int.Parse(tKucultOran.Text) <= 10) { Kucultme_DegistirmeMetodu(); } else { MessageBox.Show("Resim 1 ve 10 / ? Değeri Boş veya Geçersiz olmamalı", "Eksik Bilgi !", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }
        private void bKucultmeInterpolasyon_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) { Kucultme_Interpolasyon(); } else { MessageBox.Show("Resim 1 Değeri Boş olmamalı", "Eksik Bilgi !", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void BSifirla_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            tr2 = Convert.ToInt16(trackBar2.Value);
            ResminParlakliginiArttirTRBAR();
            label2.Text = tr2.ToString();
        }
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            tr3 = Convert.ToInt16(trackBar3.Value);
            ResminParlakliginiArttirTRBAR();
            label3.Text = tr3.ToString();
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            tr1 = Convert.ToInt16(trackBar1.Value);
            ResminParlakliginiArttirTRBAR();
            label1.Text = tr1.ToString();
        }
    }
}
