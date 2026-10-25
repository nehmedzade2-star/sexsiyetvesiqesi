namespace sexsiyetvesiqesi
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void groupBox2_Enter(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void label10_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();


			openFileDialog.Filter = "Resim Dosyaları|.jpg;.jpeg;.png;.bmp";
			openFileDialog.Title = "Fotoğraf Seçin";

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{

				pictureBox2.Image = Image.FromFile(openFileDialog.FileName);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			textBox1.Clear();
			textBox2.Clear();
			textBox3.Clear();
			textBox4.Clear();
			textBox5.Clear();
			textBox6.Clear();
			textBox7.Clear();
			textBox8.Clear();
			textBox9.Clear();
			textBox10.Clear();
			textBox11.Clear();
			textBox12.Clear();

			label13.Text = "";
			label14.Text = "";
			label15.Text = "";
			label16.Text = "";
			label17.Text = "";
			label18.Text = "";
			label19.Text = "";
			label20.Text = "";
			label21.Text = "";
			label22.Text = "";
			label23.Text = "";

			if (pictureBox2.Image != null)
			{
				Image oldImage = pictureBox2.Image;
				pictureBox2.Image = null;
				oldImage.Dispose();
			}
		}

		private void label13_Click(object sender, EventArgs e)
		{

		}

		private void textBox11_TextChanged(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textBox1.Text) ||
				string.IsNullOrWhiteSpace(textBox2.Text) ||
				string.IsNullOrWhiteSpace(textBox3.Text) ||
				string.IsNullOrWhiteSpace(textBox4.Text) ||
				string.IsNullOrWhiteSpace(textBox5.Text) ||
				string.IsNullOrWhiteSpace(textBox6.Text) ||
				string.IsNullOrWhiteSpace(textBox7.Text) ||
				string.IsNullOrWhiteSpace(textBox8.Text) ||
				string.IsNullOrWhiteSpace(textBox9.Text) ||
				string.IsNullOrWhiteSpace(textBox10.Text) ||
				string.IsNullOrWhiteSpace(textBox11.Text) ||
				string.IsNullOrWhiteSpace(textBox12.Text))
			{
				MessageBox.Show(
					"Bütün xanaları doldurun!",
					"Xəta",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);
				return;
			}


			string fin = textBox2.Text.Trim();

			if (!System.Text.RegularExpressions.Regex.IsMatch(
				fin, @"^[A-Za-z0-9]{7}$"))
			{
				MessageBox.Show("FIN 7 simvoldan ibarət olmalıdır!");
				textBox2.Focus();
				return;
			}

			if (textBox1.Text.Trim().Length < 5)
			{
				MessageBox.Show("Seriya və nömrəni düzgün daxil edin!");
				textBox1.Focus();
				return;
			}


			string ad = textBox3.Text.Trim();
			string soyad = textBox4.Text.Trim();
			string ataAdi = textBox6.Text.Trim();

			string adRegex = @"^[\p{L}\s'-]+$";

			if (!System.Text.RegularExpressions.Regex.IsMatch(ad, adRegex) ||
				!System.Text.RegularExpressions.Regex.IsMatch(soyad, adRegex) ||
				!System.Text.RegularExpressions.Regex.IsMatch(ataAdi, adRegex))
			{
				MessageBox.Show(
					"Ad, soyad və ata adı yalnız hərflərdən ibarət olmalıdır!"
				);
				return;
			}

			string cins = textBox5.Text.Trim().ToUpper();

			if (cins == "K" || cins == "M" || cins == "K/M" || cins == "KİŞİ")
			{
				cins = "K/M";
			}
			else if (cins == "Q" || cins == "F" || cins == "Q/F" || cins == "QADIN")
			{
				cins = "Q/F";
			}
			else
			{
				MessageBox.Show(
					"Cins xanasına K/M və ya Q/F daxil edin!"
				);
				textBox5.Focus();
				return;
			}


			DateTime dogumTarixi;
			DateTime verilmeTarixi;
			DateTime etibarliliqTarixi;

			if (!DateTime.TryParseExact(
				textBox8.Text.Trim(),
				"dd.MM.yyyy",
				System.Globalization.CultureInfo.InvariantCulture,
				System.Globalization.DateTimeStyles.None,
				out dogumTarixi))
			{
				MessageBox.Show(
					"Doğum tarixini dd.MM.yyyy formatında daxil edin!\nMəsələn: 15.06.2000"
				);
				textBox8.Focus();
				return;
			}

			if (!DateTime.TryParseExact(
				textBox9.Text.Trim(),
				"dd.MM.yyyy",
				System.Globalization.CultureInfo.InvariantCulture,
				System.Globalization.DateTimeStyles.None,
				out verilmeTarixi))
			{
				MessageBox.Show(
					"Verilmə tarixini dd.MM.yyyy formatında daxil edin!"
				);
				textBox9.Focus();
				return;
			}

			if (!DateTime.TryParseExact(
				textBox12.Text.Trim(),
				"dd.MM.yyyy",
				System.Globalization.CultureInfo.InvariantCulture,
				System.Globalization.DateTimeStyles.None,
				out etibarliliqTarixi))
			{
				MessageBox.Show(
					"Etibarlılıq tarixini dd.MM.yyyy formatında daxil edin!"
				);
				textBox12.Focus();
				return;
			}

			if (dogumTarixi.Date > DateTime.Today)
			{
				MessageBox.Show("Doğum tarixi gələcək tarix ola bilməz!");
				textBox8.Focus();
				return;
			}

			if (verilmeTarixi.Date < dogumTarixi.Date)
			{
				MessageBox.Show("Verilmə tarixi doğum tarixindən əvvəl ola bilməz!");
				textBox9.Focus();
				return;
			}

			if (etibarliliqTarixi.Date < verilmeTarixi.Date)
			{
				MessageBox.Show("Etibarlılıq tarixi verilmə tarixindən əvvəl ola bilməz!");
				textBox12.Focus();
				return;
			}
			label13.Text = soyad;
			label14.Text = ad;
			label15.Text = ataAdi;
			label16.Text = dogumTarixi.ToString("dd.MM.yyyy");
			label17.Text = textBox7.Text.Trim();
			label18.Text = cins;

			label19.Text = textBox1.Text.Trim();
			label20.Text = fin;
			label21.Text = textBox10.Text.Trim();
			label22.Text = verilmeTarixi.ToString("dd.MM.yyyy");
			label23.Text = etibarliliqTarixi.ToString("dd.MM.yyyy");

			MessageBox.Show(
				"Məlumatlar uğurla yoxlanıldı və vəsiqəyə yerləşdirildi!",
				"Uğurlu",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information
			);
		}
	}
}
