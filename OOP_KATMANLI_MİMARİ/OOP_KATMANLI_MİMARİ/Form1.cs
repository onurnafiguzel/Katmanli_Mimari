using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENTITYLAYER;
using FACADELAYER;
using BUSINESSLOGICLAYER;


namespace OOP_KATMANLI_MİMARİ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OgrenciListesi();
            KulupListesi();
        }

        void OgrenciListesi()
        {
            List<ENTITYOGRENCI> Ogrlist = BLLOGRENCI.OGRENCILISTESI();
            dataGridView1.DataSource = Ogrlist;
            this.Text = "Öğrenci Listesi";
        }

        void KulupListesi()
        {
            List<ENTITYKULUP> KulupList = BLLKULUP.KULUPLISTESI();
            cmbKulup.DisplayMember = "KULUPAD";
            cmbKulup.ValueMember = "KULUPID";
            cmbKulup.DataSource = KulupList;
            dataGridView1.DataSource = KulupList;
            this.Text = "Kulüp Listesi";
        }

        void NotListesi()
        {
            List<ENTITYNOTLAR> NotList = BLLNOTLAR.LISTELE();
            dataGridView1.DataSource = NotList;
            this.Text = "Not Listesi";
        }


        private void btnKaydet_Click(object sender, EventArgs e)
        {
            ENTITYOGRENCI ent = new ENTITYOGRENCI();
            ent.AD = txtAd.Text;
            ent.SOYAD = txtSoyad.Text;
            ent.FOTOGRAF = txtFotograf.Text;
            ent.KULUPID = Convert.ToInt16(cmbKulup.SelectedValue);
            BLLOGRENCI.EKLE(ent);
            MessageBox.Show("Öğrenci Kaydı Yapıldı");
            OgrenciListesi();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ENTITYOGRENCI ent = new ENTITYOGRENCI();
            ent.AD = txtAd.Text;
            ent.SOYAD = txtSoyad.Text;
            ent.FOTOGRAF = txtFotograf.Text;
            ent.KULUPID = Convert.ToInt16(cmbKulup.SelectedValue);
            ent.ID = Convert.ToInt16(txtId.Text);
            MessageBox.Show("Öğrenci Güncellendi");
            BLLOGRENCI.GUNCELLE(ent);
            OgrenciListesi();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            OgrenciListesi();
        }

        private void BtnNotListele_Click(object sender, EventArgs e)
        {
            NotListesi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Text == "Öğrenci Listesi")
            {
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtFotograf.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                cmbKulup.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            if (this.Text == "Not Listesi")
            {
                txtId.Text = "";
                txtFotograf.Text = "";
                cmbKulup.Text = "";
                txtOGRID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtS1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtS2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtS3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtOrt.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
        }

        private void Guncelle_Click(object sender, EventArgs e)
        {
            ENTITYNOTLAR ent = new ENTITYNOTLAR();
            ent.OGRID = Convert.ToInt16(txtOGRID.Text);
            ent.SINAV1 = Convert.ToInt16(txtS1.Text);
            ent.SINAV2 = Convert.ToInt16(txtS2.Text);
            ent.SINAV3 = Convert.ToInt16(txtS3.Text);
            ent.PROJE = Convert.ToInt16(txtProje.Text);
            ent.ORTALAMA = Convert.ToInt16(txtOrt.Text);
            ent.DURUM = txtDurum.Text;
            BLLNOTLAR.GUNCELLE(ent);
            MessageBox.Show("Notlar Güncellendi");
            NotListesi();
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            int s1, s2, s3, proje;
            double ortalama;
            string durum;

            s1 = Convert.ToInt16(txtS1.Text);
            s2 = Convert.ToInt16(txtS2.Text);
            s3 = Convert.ToInt16(txtS3.Text);
            proje = Convert.ToInt16(txtProje.Text);

            ortalama = (s1 + s2 + s3 + proje) / 4;
            txtOrt.Text = ortalama.ToString();
            if (ortalama >= 50)
            {
                durum = "True";
            }
            else
            {
                durum = "False";
            }
            txtDurum.Text = durum;
        }

        private void BtnKulupListele_Click(object sender, EventArgs e)
        {
            KulupListesi();
        }

        private void btnKulupKaydet_Click(object sender, EventArgs e)
        {
            ENTITYKULUP ent = new ENTITYKULUP();
            ent.KULUPAD = txtKulupAd.Text;
            BLLKULUP.EKLE(ent);
            KulupListesi();
        }

        private void BtnKulupSil_Click(object sender, EventArgs e)
        {
            ENTITYKULUP ent = new ENTITYKULUP();
            ent.KULUPID = Convert.ToInt16(txtKulupId.Text);
            BLLKULUP.SIL(ent.KULUPID);
            KulupListesi();
        }

        private void BtnKulupGuncelle_Click(object sender, EventArgs e)
        {
            ENTITYKULUP ent = new ENTITYKULUP();
            ent.KULUPAD = txtKulupAd.Text;
            ent.KULUPID = Convert.ToInt16(txtKulupId.Text);
            BLLKULUP.GUNCELLE(ent);
            KulupListesi();
        }
    }
}