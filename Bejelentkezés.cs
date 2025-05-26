using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forma1Projekt
{
    public partial class Bejelentkezés : Form
    {
        public Bejelentkezés()
        {
            InitializeComponent();
        }

        public static string connection = "server=localhost;database=forma1;user=root;password=;";

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
                using (MySqlConnection conn = new MySqlConnection(connection)) { 
                    conn.Open();
                    string query = "SELECT id,nev FROM regisztracio WHERE email=@email AND jelszo=@jelszo";
                    using(MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", textBox1.Text);
                        cmd.Parameters.AddWithValue("@jelszo", textBox2.Text);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                           while(reader.Read())
                            {
                                Session.felazonosito = reader.GetInt32("id");
                                Session.felnev=reader.GetString("nev");

                                MessageBox.Show("Sikeres volt a Bejelentkezés!");
                                Profile profile = new Profile();
                                profile.Show();
                                this.Hide();
                            }
                        }
                    }
                
                }
            }catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
