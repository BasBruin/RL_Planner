using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using RL_Planner_DomeinClasses;


namespace Rl_Planner
{
    public partial class Profiel : Form
    {
        SQL_Connection GetDataBase = new SQL_Connection();
        SqlDataReader reader;

        public Profiel()
        {
            InitializeComponent();
            
            reader = GetDataBase.loadSQL("SELECT * FROM Gebruiker WHERE ID = 1");
            reader.Read();
            txtBoxGameUsername.Text = reader.GetString(4);
            txtBoxNaam.Text = reader.GetString(1);
            txtboxEmail.Text = reader.GetString(5);
            txtBoxAppUsername.Text = reader.GetString(2);
            lblProfielNaam.Text = reader.GetString(1);
            cBox1s.Text = reader.GetString(7);
            cBox2s.Text = reader.GetString(8);
            cBox3s.Text = reader.GetString(9);
            
        }

        private void ApplyLabel_Click(object sender, EventArgs e)
        {
            if(txtBoxNaam.Text != "" && txtBoxAppUsername.Text != "" && txtBoxGameUsername.Text != "")
            {
                Gebruiker gebruiker = new Gebruiker(txtBoxNaam.Text, txtBoxGameUsername.Text, txtBoxAppUsername.Text, txtboxEmail.Text, cBox1s.Text, cBox2s.Text, cBox3s.Text);
                lblProfielNaam.Text = gebruiker.ToString();

                GetDataBase.loadSQL("UPDATE Gebruiker SET Naam = '" + txtBoxNaam.Text + "', UserName ='" + txtBoxAppUsername.Text + "', GameNaam ='" + txtBoxGameUsername.Text + "', Email ='" + txtboxEmail.Text + "',Plaatje = '"+ pictureBox2.Image +"', Rank1s ='" + cBox1s.Text + "', Rank2s ='" + cBox2s.Text + "', Rank3s ='" + cBox3s.Text + "' WHERE ID = 1");
                ChangeProfileLabel.Visible = true;
                ChangeProfilePanel.Visible = true;
                ApplyLabel.Visible = false;
                ApplyPanel.Visible = false;

                foreach (Control c in Controls)
                {
                    if(c.Tag == "ChangeProfile")
                    {
                        c.Enabled = false;
                    }
                }
            }
        }

        private void ChangeProfileLabel_Click(object sender, EventArgs e)
        {
            ChangeProfileLabel.Visible = false;
            ChangeProfilePanel.Visible = false;
            ApplyLabel.Visible = true;
            ApplyPanel.Visible = true;
            foreach (Control c in Controls)
            {
                if (c.Tag == "ChangeProfile")
                {
                    c.Enabled = true;
                }
            }
        }

        private void imBox_AddPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(opnfd.FileName);
            }
        }
    }
}
