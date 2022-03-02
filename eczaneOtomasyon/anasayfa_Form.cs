using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Xml;
using System.Xml.Linq;
using System.Diagnostics;

namespace eczaneOtomasyon
{
    public partial class anasayfa_Form : Form
    {
        //private const string api = "f1aac7ca90a81bea265b3ca3abc7774b";
        private const string bagKars = "https://api.openweathermap.org/data/2.5/weather?q=Kars&mode=xml&units=metric&appid=f1aac7ca90a81bea265b3ca3abc7774b";
        private const string bagIstanbul = "https://api.openweathermap.org/data/2.5/weather?q=Istanbul&mode=xml&units=metric&appid=f1aac7ca90a81bea265b3ca3abc7774b";
        private const string bagKocaeli = "https://api.openweathermap.org/data/2.5/weather?q=izmit&mode=xml&units=metric&appid=f1aac7ca90a81bea265b3ca3abc7774b";
        public string userid;
        string d = null;
        MySqlConnection connection;
        MySqlCommand command;
        MySqlDataAdapter data_A;//kamyon
        DataTable data_T;
        DataSet data_S;//havuz

        //--------------------PERSONEL-----------------------------
        void personelFilltxt()
        {
            connect();

            txt_anasayfa_personelid.Text = dg_anasayfa_personel.CurrentRow.Cells[0].Value.ToString();
            txt_anasayfa_ad.Text = dg_anasayfa_personel.CurrentRow.Cells[1].Value.ToString();
            txt_anasayfa_soyad.Text = dg_anasayfa_personel.CurrentRow.Cells[2].Value.ToString();
            cmb_anasayfa_unvan.Text = dg_anasayfa_personel.CurrentRow.Cells[3].Value.ToString();
            txt_anasayfa_eposta.Text = dg_anasayfa_personel.CurrentRow.Cells[4].Value.ToString();
            txt_anasayfa_telno.Text = dg_anasayfa_personel.CurrentRow.Cells[5].Value.ToString();
            txt_anasayfa_eczaneid.Text = dg_anasayfa_personel.CurrentRow.Cells[6].Value.ToString();

            command = new MySqlCommand("select sifre from personel where pID='" + txt_anasayfa_personelid.Text + "'", connection);
            data_A = new MySqlDataAdapter(command);
            data_T = new DataTable();
            data_A.Fill(data_T);
            try
            {
                string a = data_T.Rows[0]["sifre"].ToString();
                txt_anasayfa_sifre.Text = a;
            }
            catch (Exception)
            {

            }

        }
        void personelFill(bool control)
        {
            connect();
            string d = null;
            if (cmb_arama_kriteri.SelectedIndex == 0)
            {
                d = "pAdi";
            }
            else
            {
                d = "pID";
            }

            if (control == true)
                command = new MySqlCommand("select pID as Personel_ID , pAdi as Personel_Adı,pSoyadi as Personel_Soyadı,pUnvanı as Personel_Unvanı,ePosta as Personel_EPosta,telNo as Personel_TelNO,eID as Eczane_ID from personel", connection);

            else
            {
                if (d == "pID")
                {
                    command = new MySqlCommand("select * from personel where " + d + " ='" + txt_anasayfa_aramaanahtari.Text + "'", connection);

                }
                else
                {
                    command = new MySqlCommand("select * from personel where " + d + " like '%" + txt_anasayfa_aramaanahtari.Text + "%'", connection);
                }

            }

            data_A = new MySqlDataAdapter(command);
            data_S = new DataSet();
            data_A.Fill(data_S, "personel");

            dg_anasayfa_personel.DataSource = data_S.Tables["personel"];
            dg_anasayfa_personel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cmb_arama_kriteri.Enabled = true;

            connection.Close();
        }
        void personelUpdate()
        {
            connect();
            command = new MySqlCommand("update personel set pAdi='" + txt_anasayfa_ad.Text + "',pSoyadi='" + txt_anasayfa_soyad.Text + "',pUnvanı='" + cmb_anasayfa_unvan.SelectedItem + "',eID='" + txt_anasayfa_eczaneid.Text + "',sifre='" + txt_anasayfa_sifre.Text + "',telNo='" + txt_anasayfa_telno.Text + "',ePosta='" + txt_anasayfa_eposta.Text + "'where pID=" + txt_anasayfa_personelid.Text, connection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message);
            }
            personelFill(true);
            connection.Close();

        }
        void personelDelete()
        {
            connect();
            command = new MySqlCommand("delete from personel where pID=" + txt_anasayfa_personelid.Text, connection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }
        void personelClearintxt()
        {
            txt_anasayfa_ad.Clear();
            txt_anasayfa_eczaneid.Clear();
            txt_anasayfa_eposta.Clear();
            txt_anasayfa_personelid.Clear();
            txt_anasayfa_sifre.Clear();
            txt_anasayfa_soyad.Clear();
            txt_anasayfa_telno.Clear();
            txt_anasayfa_aramaanahtari.Clear();
            cmb_anasayfa_unvan.Text = "";
            cmb_arama_kriteri.Text = "";
        }

        //---------------------------------------------------------

        //---------------------ANASAYFA---------------------------

        void anasayfaFill(bool control)
        {
            connect();

            if (control == true)
                command = new MySqlCommand("select satinalinanlarID as SatınalınanlarID, hAdi as Hasta_Adı, hSoyadi as Hasta_Soyadı, hAdres as Hasta_Adresi, hastalar.hTcNo as Hasta_TC_No,hastalar.hTelNo as Hasta_Tel_No, ilacAdi as İlaç_Adı, ilacbilgi.ilacKodu as İlaç_Kodu, ilacTip as İlaç_Tİpi, ilacFiyati as İlaç_Fiyatı,satinalinanlar.durum as Durum,satinalinanlar.date as Tarih  from meeeczaneotomasyonu.satinalinanlar, meeeczaneotomasyonu.ilacbilgi, meeeczaneotomasyonu.hastalar where satinalinanlar.hTcNo = hastalar.hTcNo and ilacbilgi.ilacKodu = satinalinanlar.ilacKodu order by satinalinanlarID", connection);
            else
            {
                if (d == "hTcNo")
                {
                    command = new MySqlCommand("select satinalinanlarID, hAdi, hSoyadi, hAdres, hastalar.hTcNo,hastalar.hTelNo, ilacAdi, ilacbilgi.ilacKodu, ilacTip, ilacFiyati,satinalinanlar.durum,satinalinanlar.date  from meeeczaneotomasyonu.satinalinanlar, meeeczaneotomasyonu.ilacbilgi, meeeczaneotomasyonu.hastalar where satinalinanlar.hTcNo = hastalar.hTcNo and ilacbilgi.ilacKodu = satinalinanlar.ilacKodu and satinalinanlar." + d + " like '%" + txt_ana_ana_aramaanahtari.Text + "%' ", connection);

                }
                else if (d == "satinalinanlarID")
                {
                    command = new MySqlCommand("select satinalinanlarID, hAdi, hSoyadi, hAdres, hastalar.hTcNo,hastalar.hTelNo, ilacAdi, ilacbilgi.ilacKodu, ilacTip, ilacFiyati,satinalinanlar.durum,satinalinanlar.date  from meeeczaneotomasyonu.satinalinanlar, meeeczaneotomasyonu.ilacbilgi, meeeczaneotomasyonu.hastalar where satinalinanlar.hTcNo = hastalar.hTcNo and ilacbilgi.ilacKodu = satinalinanlar.ilacKodu and satinalinanlar." + d + " = '" + txt_ana_ana_aramaanahtari.Text + "' ", connection);

                }
                else
                {
                    command = new MySqlCommand("select satinalinanlarID, hAdi, hSoyadi, hAdres, hastalar.hTcNo,hastalar.hTelNo, ilacAdi, ilacbilgi.ilacKodu, ilacTip, ilacFiyati,satinalinanlar.durum,satinalinanlar.date  from meeeczaneotomasyonu.satinalinanlar, meeeczaneotomasyonu.ilacbilgi, meeeczaneotomasyonu.hastalar where satinalinanlar.hTcNo = hastalar.hTcNo and ilacbilgi.ilacKodu = satinalinanlar.ilacKodu and satinalinanlar." + d + " like '%" + dateTimePicker1.Text.ToString() + "%' ", connection);

                }

            }

            data_A = new MySqlDataAdapter(command);
            data_S = new DataSet();
            data_A.Fill(data_S, "satinalinanlar");

            dg_anasayfa_anasayfa.DataSource = data_S.Tables["satinalinanlar"];
            dg_anasayfa_anasayfa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cmb_ana_ana_aramaanahtari.Enabled = true;

            connection.Close();



        }
        void anasayfaSatisAdd()
        {
            connect();
            command = new MySqlCommand("select ilacAdet  from stok where ilacKodu='" + txt_ana_ana_ilckodu.Text + "'", connection);
            data_A = new MySqlDataAdapter(command);
            data_T = new DataTable();
            data_A.Fill(data_T);
            string a = data_T.Rows[0]["ilacAdet"].ToString();
            int b;
            b = Convert.ToInt32(a);


            string ansayfa_satinalinanlar_ekle_sorgu = null;
            if (radio_ana_ana_satis.Checked == true)
            {
                if (b > 0)
                {
                    ansayfa_satinalinanlar_ekle_sorgu = "insert into satinalinanlar(hTcNo,ilacKodu,eID,durum,date) values ('" + txt_ana_ana_hastatcno.Text + "','" + txt_ana_ana_ilckodu.Text + "','" + 1 + "','Satış','" + DateTime.Now.ToString() + "')";

                    MySqlCommand kmt = new MySqlCommand("update stok set ilacAdet=ilacAdet-1 where ilacKodu=" + txt_ana_ana_ilckodu.Text, connection); ;
                    kmt.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Bu ilaç stoklarda bulunmamaktadır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                ansayfa_satinalinanlar_ekle_sorgu = "insert into satinalinanlar(hTcNo,ilacKodu,eID,durum,date) values ('" + txt_ana_ana_hastatcno.Text + "','" + txt_ana_ana_ilckodu.Text + "','" + 1 + "','İade','" + DateTime.Now.ToString() + "')";
                MySqlCommand kmt = new MySqlCommand("update stok set ilacAdet=ilacAdet+1 where ilacKodu=" + txt_ana_ana_ilckodu.Text, connection); ;
                kmt.ExecuteNonQuery();
            }


            try
            {
                string anasayfa_hasta_ekle_sorgu = "insert into hastalar(hTcNo,hAdi,hSoyadi,hAdres,hTelno) values ('" + txt_ana_ana_hastatcno.Text + "','" + txt_ana_ana_hastaadi.Text + "','" + txt_ana_ana_hastasoyadi.Text + "','" + txt_ana_ana_hastaadres.Text + "','" + txt_ana_ana_hastatelno.Text + "')";
                MySqlCommand komut = new MySqlCommand(anasayfa_hasta_ekle_sorgu, connection);
                komut.ExecuteNonQuery();

                command = new MySqlCommand(ansayfa_satinalinanlar_ekle_sorgu, connection);
                command.ExecuteNonQuery();//property
                MessageBox.Show("Kayıt Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                anasayfaFill(true);
            }
            catch (Exception)
            {
                try
                {
                    command = new MySqlCommand(ansayfa_satinalinanlar_ekle_sorgu, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    anasayfaFill(true);
                }
                catch (Exception)
                {                   
                }
                
            }
            connection.Close();



        }
        void anasayfaFillTxt(DataGridViewCellEventArgs e)
        {
            connect();

            try
            {
                txt_ana_ana_satiskodu.Text = dg_anasayfa_anasayfa.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                txt_ana_ana_hastaadi.Text = dg_anasayfa_anasayfa.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                txt_ana_ana_hastasoyadi.Text = dg_anasayfa_anasayfa.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                txt_ana_ana_hastaadres.Text = dg_anasayfa_anasayfa.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                txt_ana_ana_hastatcno.Text = dg_anasayfa_anasayfa.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                txt_ana_ana_hastatelno.Text = dg_anasayfa_anasayfa.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                txt_ana_ana_ilcadi.Text = dg_anasayfa_anasayfa.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
                txt_ana_ana_ilckodu.Text = dg_anasayfa_anasayfa.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
                txt_ana_ana_ilctipi.Text = dg_anasayfa_anasayfa.Rows[e.RowIndex].Cells[8].FormattedValue.ToString();
                txt_ana_ana_ilcfiyati.Text = dg_anasayfa_anasayfa.Rows[e.RowIndex].Cells[9].FormattedValue.ToString();
                txt_ana_ana_date.Text = dg_anasayfa_anasayfa.Rows[e.RowIndex].Cells[11].FormattedValue.ToString();


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            connection.Close();

        }
        void anasayfatxtclear()
        {
            txt_ana_ana_aramaanahtari.Clear();
            txt_ana_ana_date.Clear();
            txt_ana_ana_hastaadi.Clear();
            txt_ana_ana_hastaadres.Clear();
            txt_ana_ana_hastasoyadi.Clear();
            txt_ana_ana_hastatcno.Clear();
            txt_ana_ana_hastatelno.Clear();
            txt_ana_ana_ilcadi.Clear();
            txt_ana_ana_ilcfiyati.Clear();
            txt_ana_ana_ilckodu.Clear();
            txt_ana_ana_ilctipi.Clear();
            txt_ana_ana_satiskodu.Clear();
            cmb_ana_ana_aramaanahtari.SelectedItem = null;
        }

        //------------------------------------------------

        //--------------------STOK----------------------------

        void stokFill(bool control)
        {
            string d = null;
            if (cmb_stok_aramakriteri.SelectedIndex == 0)
            {
                d = "fID";
            }
            else
            {
                d = "İlacKodu";
            }
            connect();

            if (control == true)
                command = new MySqlCommand("select ilacbilgi.ilacKodu as İlaç_Kodu ,ilacAdi as İlaç_adı,ilacAdet as İlaç_Adet,ilacfirma.fID as Firma_ID,fAdi as Firma_Adı,fTelNo as Firma_Tel_No,fAdres as Firma_Adres from meeeczaneotomasyonu.ilacfirma ,meeeczaneotomasyonu.ilacbilgi,meeeczaneotomasyonu.stok where stok.fID=ilacfirma.fID and ilacbilgi.ilacKodu=stok.ilacKodu", connection);
            else
            {
                command = new MySqlCommand("select ilacbilgi.ilacKodu, ilacAdi, ilacAdet, ilacfirma.fID, fAdi, fTelNo, fAdres from meeeczaneotomasyonu.ilacfirma , meeeczaneotomasyonu.ilacbilgi, meeeczaneotomasyonu.stok where stok.fID = ilacfirma.fID and ilacbilgi.ilacKodu = stok.ilacKodu and  stok." + d + "  like '%" + txt_stok_aramaanahtari.Text + "%' ", connection);
            }

            data_A = new MySqlDataAdapter(command);
            data_S = new DataSet();
            data_A.Fill(data_S, "ilacfirma");

            dg_anasayfa_stok.DataSource = data_S.Tables["ilacfirma"];
            dg_anasayfa_stok.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            connection.Close();
        }
        void stokAdd()
        {
            connect();
            try
            {


                string stok_ilac_ekle_sorgu = "insert into stok(ilacKodu,ilacAdet,fID) values ('" + txt_stok_ilacid.Text + "','" + txt_stok_mevmik.Text + "','" + txt_stok_firmaid.Text + "')";
                MySqlCommand komut = new MySqlCommand(stok_ilac_ekle_sorgu, connection);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                stokFill(true);
            }
            catch (Exception  M)
            {
                MessageBox.Show("Daha önce girdiğiniz bir ilaç bilgisi veya tanımlamadığınız ilaç / firma bulunmaktadır.\n\n-Günceleme yapmak\n-İlaç veya firma eklemek\n\nSorunu çözebilir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            connection.Close();
        }
        void stokUpdate()
        {
            connect();
            command = new MySqlCommand("update stok set ilacKodu='" + txt_stok_ilacid.Text + "',ilacAdet='" + txt_stok_mevmik.Text + "',fID='" + txt_stok_firmaid.Text + "'where ilacKodu=" + txt_stok_ilacid.Text, connection); ;
            try
            {
                command.ExecuteNonQuery();
                stokFill(true);
                MessageBox.Show("Güncelleme Başarılı", "Bigi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception a)
            {

                MessageBox.Show("Güncelleme Yapılamadı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            connection.Close();
        }
        void stokFilltxt(DataGridViewCellEventArgs e)
        {
            connect();
            try
            {
                txt_stok_ilacid.Text = dg_anasayfa_stok.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                txt_Stok_ilacadi.Text = dg_anasayfa_stok.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                txt_stok_mevmik.Text = dg_anasayfa_stok.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                txt_stok_firmaid.Text = dg_anasayfa_stok.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                txt_stok_firmaadi.Text = dg_anasayfa_stok.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                txt_stok_firmatelno.Text = dg_anasayfa_stok.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                txt_stok_firmaadresi.Text = dg_anasayfa_stok.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            connection.Close();
        }
        void stokDelete()
        {
            connect();
            command = new MySqlCommand("delete from stok where ilacKodu=" + txt_stok_ilacid.Text, connection);
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Silme başarılı", "Bigi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                stokFill(true);
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }
        void stokClearinText()
        {
            txt_stok_ilacid.Clear();
            txt_Stok_ilacadi.Clear();
            txt_stok_mevmik.Clear();
            txt_stok_firmatelno.Clear();
            txt_stok_firmaid.Clear();
            txt_stok_firmaadresi.Clear();
            txt_stok_firmaadi.Clear();
            txt_stok_aramaanahtari.Clear();

            btn_ana_stok_ara.Enabled = false;


        }

        //----------------------------------------------------

        //-------------------FİRMA BİLGİ---------------------------------

        void firmaFill(bool control)
        {
            string d = null;
            if (cmb_firma_aramakriteri.SelectedIndex == 0)
            {
                d = "fID";
            }
            else
            {
                d = "fAdi";
            }
            connect();

            //select ilacbilgi.ilacKodu ,ilacAdi,ilacAdet,ilacfirma.fID,fAdi,fTelNo,fTelNo,fAdres from meeeczaneotomasyonu.ilacfirma ,meeeczaneotomasyonu.ilacbilgi,meeeczaneotomasyonu.stok where stok.fID=ilacfirma.fID and ilacbilgi.ilacKodu=stok.ilacKodu

            if (control == true)
                command = new MySqlCommand("select * from ilacfirma", connection);
            else
            {
                command = new MySqlCommand("select * from ilacfirma where  " + d + "  like '%" + txt_firmabilgi_aramaanahtari.Text + "%' ", connection);
            }

            data_A = new MySqlDataAdapter(command);
            data_S = new DataSet();
            data_A.Fill(data_S, "ilacfirma");

            dg_anasayfa_firmabilgi.DataSource = data_S.Tables["ilacfirma"];
            dg_anasayfa_firmabilgi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            connection.Close();
        }
        void firmaFillText()
        {
            txt_firma_firmaid.Text = dg_anasayfa_firmabilgi.CurrentRow.Cells[0].Value.ToString();
            txt_firma_firmaadi.Text = dg_anasayfa_firmabilgi.CurrentRow.Cells[1].Value.ToString();
            txt_firma_firmatelno.Text = dg_anasayfa_firmabilgi.CurrentRow.Cells[2].Value.ToString();
            txt_firma_firmaadres.Text = dg_anasayfa_firmabilgi.CurrentRow.Cells[3].Value.ToString();
        }
        void firmaAdd()
        {
            connect();
            try
            {
                MySqlCommand komut = new MySqlCommand("insert into ilacfirma(fID,fAdi,fTelNo,fAdres) values ('" + txt_firma_firmaid.Text + "','" + txt_stok_firmaadi.Text + "','" + txt_stok_firmatelno.Text + "','" + txt_firma_firmaadres.Text + "')", connection);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                firmaFill(true);
            }
            catch (Exception)
            {
                MessageBox.Show("Daha önce girdiğiniz bir ilaç bilgisi veya tanımlamadığınız ilaç / firma bulunmaktadır.\n\n-Günceleme yapmak\n-İlaç veya firma eklemek\n\nSorunu çözebilir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            connection.Close();
        }
        void firmaDelete()
        {
            connect();
            command = new MySqlCommand("delete from ilacfirma where fID=" + txt_firma_firmaid.Text, connection);
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Silme başarılı", "Bigi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                firmaFill(true);
            }
            catch (Exception)
            {
                MessageBox.Show("Daha önce satmış olduğunuz veya elinizde bulunan ilaçların firma bilgilerini silemezsiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }
        void firmaUpdate()
        {
            connect();
            command = new MySqlCommand("update ilacfirma set fAdi='" + txt_firma_firmaadi.Text + "',fTelNo='" + txt_firma_firmatelno.Text + "',fAdres='" + txt_stok_firmaadresi.Text + "'where fID=" + txt_firma_firmaid.Text, connection); ;
            try
            {
                command.ExecuteNonQuery();
                firmaFill(true);
                MessageBox.Show("Güncelleme Başarılı", "Bigi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception a)
            {

                MessageBox.Show("Güncelleme Yapılamadı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            connection.Close();
        }
        void firmaTextClear()
        {
            txt_firma_firmaid.Clear();
            txt_firma_firmaadi.Clear();
            txt_firma_firmatelno.Clear();
            txt_firma_firmaadres.Clear();
            txt_firmabilgi_aramaanahtari.Clear();
            cmb_firma_aramakriteri.Text = "";
            btn_firmabilgi_ara.Enabled = false;
        }
        //----------------------------------------------------

        //----------------------İLAÇ BİLGİ-------------------------------

        void ilacFill(bool control)
        {
            connect();
            string d = null;
            if (cmb_ilc_arama.SelectedIndex == 0)
            {
                d = "ilacKodu";
            }
            else
            {
                d = "İlacAdi";
            }

            if (control == true)
                command = new MySqlCommand("select * from ilacbilgi", connection);
            else
            {
                command = new MySqlCommand("select * from ilacbilgi where ilacbilgi." + d + "  like '%" + txt_ana_ilc_aramaanahtari.Text + "%' ", connection);
            }


            data_A = new MySqlDataAdapter(command);
            data_S = new DataSet();
            data_A.Fill(data_S, "ilacbilgi");

            dg_anasayfa_ilc.DataSource = data_S.Tables["ilacbilgi"];
            dg_anasayfa_ilc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            connection.Close();
        }
        void ilacFillText(DataGridViewCellEventArgs e)
        {
            connect();
            try
            {
                txt_ana_ilc_ilckodu.Text = dg_anasayfa_ilc.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                txt_ana_ilc_ilacadi.Text = dg_anasayfa_ilc.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                txt_ana_ilc_ilacfiyati.Text = dg_anasayfa_ilc.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                txt_ana_ilc_ilactipi.Text = dg_anasayfa_ilc.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            connection.Close();
        }
        void ilacAdd()
        {
            connect();

            try
            {
                string ilc_ilacekle_sorgu = "insert into ilacbilgi(ilacKodu,ilacAdi,ilacFiyati,ilacTip) values ('" + txt_ana_ilc_ilckodu.Text + "','" + txt_ana_ilc_ilacadi.Text + "','" + txt_ana_ilc_ilacfiyati.Text + "','" + txt_ana_ilc_ilactipi.Text + "')";
                MySqlCommand komut = new MySqlCommand(ilc_ilacekle_sorgu, connection);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ilacFill(true);
            }
            catch (Exception e)
            {
                MessageBox.Show("Daha önce girdiğiniz bir ilaç bilgisi bulunmaktadır.\n\n-Günceleme yapmak sorunu çözebilir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            connection.Close();

        }
        void ilacDelete()
        {
            connect();
            command = new MySqlCommand("delete from ilacbilgi where ilacKodu=" + txt_ana_ilc_ilckodu.Text, connection);
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Silme başarılı", "Bigi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ilacFill(true);
            }
            catch (Exception)
            {
                MessageBox.Show("Daha önce satışmış bir ilaç bilgisini veya hala stoğunuzda bulunan bir ilaç bilgisni silmeye çalıştınız.\n\n-Daha önce satılmış bir ilacın bilgilerini silemezsiniz.\n\n-Önce silmeye çalıştığınız ilacın stok bilgilerini silmeniz sorunu çözebilir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //  MessageBox.Show(ee.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }
        void ilacUpdate()
        {
            connect();
            command = new MySqlCommand("update ilacbilgi set ilacKodu='" + txt_ana_ilc_ilckodu.Text + "',ilacAdi='" + txt_ana_ilc_ilacadi.Text + "',ilacFiyati='" + txt_ana_ilc_ilacfiyati.Text + "',ilacTip='" + txt_ana_ilc_ilactipi.Text + "'where ilacKodu=" + txt_ana_ilc_ilckodu.Text, connection); ;

            try
            {
                command.ExecuteNonQuery();
                ilacFill(true);
                MessageBox.Show("Güncelleme Başarılı", "Bigi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception a)
            {
                MessageBox.Show("Güncelleme Yapılamadı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            connection.Close();
        }
        void ilacclearintxt()
        {
            txt_ana_ilc_ilckodu.Clear();
            txt_ana_ilc_ilactipi.Clear();
            txt_ana_ilc_ilacadi.Clear();
            txt_ana_ilc_ilacfiyati.Clear();
            txt_ana_ilc_aramaanahtari.Clear();
            cmb_ilc_arama.Text = "";
            brn_ana_ilc_ara.Enabled = false;
            txt_ana_ilc_aramaanahtari.Visible = false;
            label31.Visible = false;
        }

        //----------------------------------------------------------------

        //--------------------MAİN----------------------------------------

        void connect()
        {
            connection = new MySqlConnection("Server = localhost; Database = meeeczaneotomasyonu; Uid = root; Pwd = '166455';");
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();


            }
        }
        bool userControl()
        {
            connect();
            command = new MySqlCommand("select pUnvanı from personel where pID='" + this.userid + "'", connection);
            data_A = new MySqlDataAdapter(command);
            data_T = new DataTable();
            data_A.Fill(data_T);
            string a = data_T.Rows[0]["pUnvanı"].ToString();

            if (a == "Müdür" || a == "müdür")
            {
                connection.Close();
                label7.Visible = true;
                txt_anasayfa_sifre.Visible = true;
                chk_anasayfa_sifre.Visible = true;
                return true;

            }
            else
            {
                MessageBox.Show("Yetkiniz yok", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
                return false;
            }


        }
        bool anasayfauserControl()
        {
            connect();
            command = new MySqlCommand("select pUnvanı from personel where pID='" + this.userid + "'", connection);
            data_A = new MySqlDataAdapter(command);
            data_T = new DataTable();
            data_A.Fill(data_T);
            string a = data_T.Rows[0]["pUnvanı"].ToString();

            if (a == "Müdür" || a == "müdür")
            {
                connection.Close();
                label7.Visible = true;
                txt_anasayfa_sifre.Visible = true;
                chk_anasayfa_sifre.Visible = true;
                return true;
            }
            else
            {
                return true;
            }
        }
        void getweather()
        {
            try
            {
                XDocument hava = new XDocument();                 //https://openweathermap.org
                if (cmb_anasayfa_sehirler.SelectedIndex == 0)
                {
                    hava = XDocument.Load(bagIstanbul);
                    var sicaklik = hava.Descendants("temperature").ElementAt(0).Attribute("value").Value; //Youtubeden bir videodan alınma.
                    lbl_anasayfa_derece.Text = "";
                    lbl_anasayfa_derece.Text = sicaklik.ToString() + "°";//alt+0176

                    var durum = hava.Descendants("clouds").ElementAt(0).Attribute("name").Value; //Youtubeden bir videodan alınma.

                    //label14.Text = durum.ToString();

                    if (durum.Contains("clear sky") == true)
                    {
                        pcb_anasayfa_weather.Image = Properties.Resources._01d_1x;
                        lbl_anasayfa_weather.Text = "Açık";
                    }
                    else if (durum.Contains("few clouds") == true)
                    {
                        pcb_anasayfa_weather.Image = Properties.Resources._02d_2x;
                        lbl_anasayfa_weather.Text = "Az Bulutlu";
                    }
                    else if (durum.Contains("scattered clouds") == true)
                    {
                        pcb_anasayfa_weather.Image = Properties.Resources._03d_2x;
                        lbl_anasayfa_weather.Text = "Bulutlu";
                    }
                    else if (durum.Contains("broken clouds") == true)
                    {
                        pcb_anasayfa_weather.Image = Properties.Resources._04d_2x;
                        lbl_anasayfa_weather.Text = "Parçalı Bulutlu";
                    }
                    else if (durum.Contains("shower rain") == true)
                    {
                        pcb_anasayfa_weather.Image = Properties.Resources._09d_2x;
                        lbl_anasayfa_weather.Text = "Sağanak Yağmurlu";
                    }
                    else if (durum.Contains("rain") == true)
                    {
                        pcb_anasayfa_weather.Image = Properties.Resources._10d_2x;
                        lbl_anasayfa_weather.Text = "Yağmurlu";
                    }
                    else if (durum.Contains("thunderstorm") == true)
                    {
                        pcb_anasayfa_weather.Image = Properties.Resources._11d_2x;
                        lbl_anasayfa_weather.Text = "Gökgürültülü Sağanak Yağışlı";
                    }
                    else if (durum.Contains("snow") == true)
                    {
                        pcb_anasayfa_weather.Image = Properties.Resources._13d_2x;
                        lbl_anasayfa_weather.Text = "Kar Yağışlı";
                    }
                }
                else if (cmb_anasayfa_sehirler.SelectedIndex == 1)
                {
                    hava = XDocument.Load(bagKocaeli);
                    var sicaklik = hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                    lbl_anasayfa_derece.Text = "";
                    lbl_anasayfa_derece.Text = sicaklik.ToString() + "°";//alt+0176

                    var durum = hava.Descendants("clouds").ElementAt(0).Attribute("name").Value;

                    //label14.Text = durum.ToString();

                    if (durum.Contains("clear sky") == true)
                    {
                        pcb_anasayfa_weather.Image = Properties.Resources._01d_1x;
                        lbl_anasayfa_weather.Text = "Açık";
                    }
                    else if (durum.Contains("few clouds") == true)
                    {
                        pcb_anasayfa_weather.Image = Properties.Resources._02d_2x;
                        lbl_anasayfa_weather.Text = "Az Bulutlu";
                    }
                    else if (durum.Contains("scattered clouds") == true)
                    {
                        pcb_anasayfa_weather.Image = Properties.Resources._03d_2x;
                        lbl_anasayfa_weather.Text = "Bulutlu";
                    }
                    else if (durum.Contains("broken clouds") == true)
                    {
                        pcb_anasayfa_weather.Image = Properties.Resources._04d_2x;
                        lbl_anasayfa_weather.Text = "Parçalı Bulutlu";
                    }
                    else if (durum.Contains("shower rain") == true)
                    {
                        pcb_anasayfa_weather.Image = Properties.Resources._09d_2x;
                        lbl_anasayfa_weather.Text = "Sağanak Yağmurlu";
                    }
                    else if (durum.Contains("rain") == true)
                    {
                        pcb_anasayfa_weather.Image = Properties.Resources._10d_2x;
                        lbl_anasayfa_weather.Text = "Yağmurlu";
                    }
                    else if (durum.Contains("thunderstorm") == true)
                    {
                        pcb_anasayfa_weather.Image = Properties.Resources._11d_2x;
                        lbl_anasayfa_weather.Text = "Gökgürültülü Sağanak Yağışlı";
                    }
                    else if (durum.Contains("snow") == true)
                    {
                        pcb_anasayfa_weather.Image = Properties.Resources._13d_2x;
                        lbl_anasayfa_weather.Text = "Kar Yağışlı";
                    }
                }
                else if (cmb_anasayfa_sehirler.SelectedIndex == 2)
                {
                    hava = XDocument.Load(bagKars);
                    var sicaklik = hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                    lbl_anasayfa_derece.Text = "";
                    lbl_anasayfa_derece.Text = sicaklik.ToString() + "°";//alt+0176

                    var durum = hava.Descendants("clouds").ElementAt(0).Attribute("name").Value;

                    //label14.Text = durum.ToString();

                    if (durum.Contains("clear sky") == true)
                    {
                        pcb_anasayfa_weather.Image = Properties.Resources._01d_1x;
                        lbl_anasayfa_weather.Text = "Açık";
                    }
                    else if (durum.Contains("few clouds") == true)
                    {
                        pcb_anasayfa_weather.Image = Properties.Resources._02d_2x;
                        lbl_anasayfa_weather.Text = "Az Bulutlu";
                    }
                    else if (durum.Contains("scattered clouds") == true)
                    {
                        pcb_anasayfa_weather.Image = Properties.Resources._03d_2x;
                        lbl_anasayfa_weather.Text = "Bulutlu";
                    }
                    else if (durum.Contains("broken clouds") == true)
                    {
                        pcb_anasayfa_weather.Image = Properties.Resources._04d_2x;
                        lbl_anasayfa_weather.Text = "Parçalı Bulutlu";
                    }
                    else if (durum.Contains("shower rain") == true)
                    {
                        pcb_anasayfa_weather.Image = Properties.Resources._09d_2x;
                        lbl_anasayfa_weather.Text = "Sağanak Yağmurlu";
                    }
                    else if (durum.Contains("rain") == true)
                    {
                        pcb_anasayfa_weather.Image = Properties.Resources._10d_2x;
                        lbl_anasayfa_weather.Text = "Yağmurlu";
                    }
                    else if (durum.Contains("thunderstorm") == true)
                    {
                        pcb_anasayfa_weather.Image = Properties.Resources._11d_2x;
                        lbl_anasayfa_weather.Text = "Gökgürültülü Sağanak Yağışlı";
                    }
                    else if (durum.Contains("snow") == true)
                    {
                        pcb_anasayfa_weather.Image = Properties.Resources._13d_2x;
                        lbl_anasayfa_weather.Text = "Kar Yağışlı";
                    }
                }

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message,"Dikkat",MessageBoxButtons.OK,MessageBoxIcon.Error); ;
            }




        }

        //-----------------------------------------------------
        public anasayfa_Form()
        {
            InitializeComponent();
        }

        private void anasayfa_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void btn_anasayfa_Click(object sender, EventArgs e)
        {
            anasayfaFill(true);
            tabControl1.SelectedTab = tabPage1;
        }
        private void btn_stok_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            stokFill(true);
        }

        private void btn_personel_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            personelFill(true);
        }

        private void btn_recete_Click(object sender, EventArgs e)
        {
            ilacFill(true);
            tabControl1.SelectedTab = tabPage4;
        }
        private void dg_anasayfa_personel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            personelFilltxt();
        }

        private void btn_anasayfa_oturumkapa_Click(object sender, EventArgs e)
        {
            giris_Form kayitForm = new giris_Form();
            kayitForm.Show();
            this.Hide();
        }

        private void btn_anasayfa_yenile_Click(object sender, EventArgs e)
        {
            cmb_arama_kriteri.SelectedItem = null;
            txt_anasayfa_aramaanahtari.Visible = false;
            label12.Visible = false;
            personelFill(true);
            personelClearintxt();
            btn_anasayfa_ara.Enabled = false;

        }



        private void tmr_anasayfa_Tick(object sender, EventArgs e)
        {
            connect();

            if (connection.State == ConnectionState.Closed)
            {
                btn_anasayfa_baglantikontrol.BackColor = Color.Red;
            }
            else
            {
                btn_anasayfa_baglantikontrol.BackColor = Color.GreenYellow;
            }

            lbl_anasayfa_saat.Text = DateTime.Now.ToLongTimeString();
            lbl_anasayfa_tarih.Text = DateTime.Now.ToLongDateString();
            connection.Close();
        }

        private void anasayfa_Form_Load(object sender, EventArgs e)
        {
            tmr_anasayfa.Interval = 100;
            tmr_anasayfa.Enabled = true;
            cmb_anasayfa_sehirler.SelectedIndex = 0;
            this.userid = giris_Form.userid;
            anasayfaFill(true);
            anasayfauserControl();
            getweather();
        }

        private void cmb_arama_kriteri_TextChanged(object sender, EventArgs e)
        {

            btn_anasayfa_ara.Enabled = true;
            txt_anasayfa_aramaanahtari.Visible = true;
            label12.Visible = true;
            personelFill(false);
        }

        private void btn_anasayfa_ara_Click(object sender, EventArgs e)
        {
            personelFill(false);
        }

        private void btn_anasayfa_guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (userControl() == true)
                {
                    personelUpdate();
                    MessageBox.Show("Güncelleme başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Güncelleme yapılamadı.", "Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void btn_anasayfa_sil_Click(object sender, EventArgs e)
        {
            try
            {
                if (userControl() == true)
                {
                    personelDelete();
                    personelFill(true);
                    MessageBox.Show("Silme işlemi başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Silme işlemi yapılamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btn_ana_stok_mevmik_Click(object sender, EventArgs e)
        {
            cmb_stok_aramakriteri.SelectedItem = null;
            stokFill(true);
            stokClearinText();
            txt_stok_aramaanahtari.Visible = false;
            label20.Visible = false;


        }

        private void btn_ana_stok_yeniilac_Click(object sender, EventArgs e)
        {
            stokAdd();
        }

        private void btn_ana_stok_guncelle_Click(object sender, EventArgs e)
        {
            stokUpdate();
        }

        private void dg_anasayfa_stok_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            stokFilltxt(e);
        }

        private void btn_ana_stok_sil_Click(object sender, EventArgs e)
        {
            stokDelete();
        }

        private void btn_ana_stok_ara_Click(object sender, EventArgs e)
        {
            stokFill(false);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_anasayfa_sifre.Checked)
            {
                txt_anasayfa_sifre.PasswordChar = '\0';
            }
            else
            {
                txt_anasayfa_sifre.PasswordChar = '*';

            }
        }
        private void cmb_anasayfa_sehirler_TextChanged(object sender, EventArgs e)
        {
            lbl_anasayfa_weather.Text = "";
            getweather();
        }

        private void btn_anasayfa_firmabilgi_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = tabPage5;
            firmaFill(true);
        }

        private void dg_anasayfa_firmabilgi_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            firmaFillText();
        }

        private void btn_firmabilgi_yenile_Click(object sender, EventArgs e)
        {
            txt_firmabilgi_aramaanahtari.Visible = false;
            label25.Visible = false;
            btn_firmabilgi_ara.Enabled = false;
            cmb_firma_aramakriteri.SelectedItem = null;
            firmaFill(true);
            firmaTextClear();
        }

        private void btn_firmabilgi_ekle_Click(object sender, EventArgs e)
        {
            firmaAdd();
        }

        private void btn_firmabilgi_sil_Click(object sender, EventArgs e)
        {
            firmaDelete();
        }

        private void btn_firmabilgi_ara_Click(object sender, EventArgs e)
        {
            firmaFill(false);
        }

        private void dg_anasayfa_ilc_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ilacFillText(e);
        }

        private void btn_ana_ilc_kyt_Click(object sender, EventArgs e)
        {
            ilacAdd();
        }

        private void btn_ana_ilc_yenile_Click(object sender, EventArgs e)
        {
            brn_ana_ilc_ara.Enabled = false;
            cmb_ilc_arama.SelectedItem = null;
            ilacFill(true);
            ilacclearintxt();
        }

        private void btn_ana_ilc_sil_Click(object sender, EventArgs e)
        {
            ilacDelete();
        }

        private void btn_ana_ilc_guncelle_Click(object sender, EventArgs e)
        {
            ilacUpdate();
        }

        private void brn_ana_ilc_ara_Click(object sender, EventArgs e)
        {
            ilacFill(false);
        }

        private void dg_anasayfa_anasayfa_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            anasayfaFillTxt(e);
        }

        private void btn_ana_ana_satisekle_Click(object sender, EventArgs e)
        {
            anasayfaSatisAdd();
        }

        private void radio_ana_ana_satis_CheckedChanged(object sender, EventArgs e)
        {
            btn_ana_ana_satisekle.Text = "Satış Ekle";
        }

        private void radio_ana_ana_iade_CheckedChanged(object sender, EventArgs e)
        {
            btn_ana_ana_satisekle.Text = "Satış İade";
        }

        private void btn_ana_ana_ara_Click(object sender, EventArgs e)
        {
            anasayfaFill(false);
        }

        private void cmb_stok_aramakriteri_TextChanged(object sender, EventArgs e)
        {
            btn_ana_stok_ara.Enabled = true;
            txt_stok_aramaanahtari.Visible = true;
            label20.Visible = true;
            stokFill(false);

        }

        private void cmb_ilc_arama_TextChanged(object sender, EventArgs e)
        {
            txt_ana_ilc_aramaanahtari.Visible = true;
            label31.Visible = true;
            brn_ana_ilc_ara.Enabled = true;
            ilacFill(false);

        }

        private void cmb_firma_aramakriteri_TextChanged(object sender, EventArgs e)
        {
            txt_firmabilgi_aramaanahtari.Visible = true;
            label25.Visible = true;
            btn_firmabilgi_ara.Enabled = true;
            firmaFill(false);

        }

        private void btn_ana_ana_yenile_Click(object sender, EventArgs e)
        {
            cmb_ana_ana_aramaanahtari.SelectedItem = null;
            dateTimePicker1.Visible = false;
            txt_ana_ana_aramaanahtari.Visible = false;
            label43.Visible = false;
            anasayfaFill(true);
            anasayfatxtclear();
        }

        private void cmb_ana_ana_aramaanahtari_TextChanged(object sender, EventArgs e)
        {
            if (cmb_ana_ana_aramaanahtari.SelectedIndex == 0)
            {
                txt_ana_ana_aramaanahtari.Visible = true;
                dateTimePicker1.Visible = false;
                label43.Visible = true;
                d = "hTcNo";
            }
            else if (cmb_ana_ana_aramaanahtari.SelectedIndex == 1)
            {
                txt_ana_ana_aramaanahtari.Visible = true;
                dateTimePicker1.Visible = false;
                label43.Visible = true;
                d = "satinalinanlarID";

            }
            else if (cmb_ana_ana_aramaanahtari.SelectedIndex == 2)
            {
                dateTimePicker1.Visible = true;
                txt_ana_ana_aramaanahtari.Visible = false;
                label43.Visible = true;
                d = "date";

            }
        }

        private void dg_anasayfa_anasayfa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_ana_ana_satiskodu_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
