using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forma1Projekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string connection = "server=localhost;database=forma1;user=root;password=;";
        private void Form1_Load(object sender, EventArgs e)
        {
            List<Merkozesek> merkozesek = new List<Merkozesek>();
            string[] sorok = File.ReadAllLines("forma1.txt");
            foreach (string s in sorok)
            {

                string[] adatok = s.Split(';');
                Merkozesek merkozes = new Merkozesek(adatok[0], adatok[1], adatok[2], adatok[3], adatok[4], adatok[5]);
                merkozesek.Add(merkozes);
            }

            foreach (var m in merkozesek) { 
                dataGridView1.Rows.Add(m.helyszin,m.palyatipus,m.rajtszam,m.helyezes,m.gyozelem,m.datum);           
            }
            using(MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM merkozesek";
                using (MySqlCommand cmd = new MySqlCommand(query,conn)) { 
                   int soroksz = Convert.ToInt32(cmd.ExecuteScalar());

                    if (soroksz == 0) {
                        string query1 = "INSERT INTO merkozesek (helyszin,rajtszam,helyezes,gyozelem,datum) VALUES (@helyszin,@rajtszam,@helyezes,@gyozelem,@datum)";
                        foreach (var mer in merkozesek)
                        {
                            using (MySqlCommand cmd1 = new MySqlCommand(query1, conn))
                            {
                           
                                cmd1.Parameters.AddWithValue("@helyszin",mer.helyszin);
                                cmd1.Parameters.AddWithValue("@rajtszam", mer.rajtszam);
                                cmd1.Parameters.AddWithValue("@helyezes", mer.helyezes);
                                cmd1.Parameters.AddWithValue("@gyozelem", mer.gyozelem);
                                cmd1.Parameters.AddWithValue("@datum", mer.datum);
                                cmd1.ExecuteNonQuery();

                            }
                        }
                    }
                
                }
            }

        }
    }
}
