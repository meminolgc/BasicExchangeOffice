using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Doviz_Ofisi
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
			var xmldosya = new XmlDocument();	
			xmldosya.Load(bugun);

			string dolarAlis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerText;
			LblDolarAlis.Text = dolarAlis;

			string dolarSatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerText;
			LblDolarSatis.Text = dolarSatis;

			string euroAlis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerText;
			LblEuroAlis.Text = euroAlis;

			string euroSatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerText;
			LblEuroSatis.Text = euroSatis;


		}

		private void BtnDolarAl_Click(object sender, EventArgs e)
		{
			TxtKur.Text = LblDolarAlis.Text;
		}

		private void BtnDolarSat_Click(object sender, EventArgs e)
		{
			TxtKur.Text = LblDolarSatis.Text;
		}

		private void BtnEuroAl_Click(object sender, EventArgs e)
		{
			TxtKur.Text = LblEuroAlis.Text;
		}

		private void BtnEuroSat_Click(object sender, EventArgs e)
		{
			TxtKur.Text = LblEuroSatis.Text;
		}

		private void BtnSatisYap_Click(object sender, EventArgs e)
		{
			double kur, miktar, tutar;
			kur = Convert.ToDouble(TxtKur.Text);
			miktar = Convert.ToDouble(TxtMiktar.Text);
			tutar = kur * miktar;	
			TxtTutar.Text = tutar.ToString();
		}

		private void TxtKur_TextChanged(object sender, EventArgs e)
		{
			TxtKur.Text = TxtKur.Text.Replace(".", ",");
		}

		private void BtnSatisYap2_Click(object sender, EventArgs e)
		{
			double kur = Convert.ToDouble(TxtKur.Text);
			int miktar = Convert.ToInt32(TxtMiktar.Text);
			int tutar = Convert.ToInt32(miktar / kur);
			TxtTutar.Text = tutar.ToString();
			int kalan;
			kalan = Convert.ToInt32(miktar % kur);
			TxtKalan.Text = kalan.ToString();
		}
	}
}
