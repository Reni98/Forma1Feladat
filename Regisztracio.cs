using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forma1Projekt
{
    public partial class Regisztracio : Form
    {
        public Regisztracio()
        {
            InitializeComponent();
        }
        public static string connection = "server=localhost;database=forma1;user=root;password=;";

        byte[] profilkepBytes;
        private void button2_Click(object sender, EventArgs e)
        {
            try {
                using (MySqlConnection conn = new MySqlConnection(connection)) { 
                    conn.Open();
                    string query = "INSERT INTO regisztracio (nev,email,jelszo,profilkep,szdatum) VALUES (@nev,@email,@jelszo,@profilkep,@szdatum)";
                    using(MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nev",textBox1.Text);
                        cmd.Parameters.AddWithValue("@email", textBox2.Text);
                        cmd.Parameters.AddWithValue("@jelszo", textBox3.Text);                        
                        cmd.Parameters.Add("@profilkep", MySqlDbType.Blob).Value = profilkepBytes;                       
                        cmd.Parameters.AddWithValue("@szdatum",dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Sikeres regisztráció!");
                        Bejelentkezés b = new Bejelentkezés();
                        b.Show();
                        this.Hide();


                    }
                }
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Kép fájlok|*.jpg;*.jpeg;*.png";

            if(op.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(op.FileName);
                profilkepBytes=File.ReadAllBytes(op.FileName);

            }
        }
    }
}
