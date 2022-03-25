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

namespace RL_Planner
{
    public partial class TeamRegister : Form
    {
        SQL_Connection GetDataBase = new SQL_Connection();
        SqlDataReader reader;
        string? path;
        GebruikerRepository GebruikerRepository = new();

        public TeamRegister()
        {
            InitializeComponent();
            reader = GetDataBase.loadSQL("SELECT * FROM Gebruiker WHERE ID = 1");
            reader.Read();
            Bitmap bitmap = new Bitmap(reader.GetString(6));
            pictureBox1.Image = bitmap;

            reader = GebruikerRepository.GetAllGebruikers();
            while (reader.Read())
            {
                Gebruiker g = new(reader.GetInt32(0), reader.GetString(1), reader.GetString(4), reader.GetString(2), reader.GetString(5), reader.GetString(7), reader.GetString(8), reader.GetString(9));
                cBoxLeden.Items.Add(g);
            }
        }

        private void ProfielLabel_Click(object sender, EventArgs e)
        {

        }

        private void imBox_AddPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                picboxTeamPlaatje.Image = new Bitmap(opnfd.FileName);
                path = opnfd.FileName;
            }
        }

        private void btnVoegToe_Click(object sender, EventArgs e)
        {
            if (cBoxLeden.Text != "")
            {
                lBoxTeamLeden.Items.Add(cBoxLeden.Text);
                cBoxLeden.Items.Remove(cBoxLeden.SelectedItem);
            }
        }

        private void btnVerwijder_Click(object sender, EventArgs e)
        {
            if (lBoxTeamLeden.SelectedItem != null)
            {
                cBoxLeden.Items.Add(lBoxTeamLeden.Text);
                lBoxTeamLeden.Items.Remove(lBoxTeamLeden.SelectedItem.ToString());
            }

        }

        private void OpslaanLabel_Click(object sender, EventArgs e)
        {
            Team team = new(txtBoxNaam.Text, txtBoxBeschrijving.Text, path);
            int TeamID = team.TeamAanmaken();
            foreach(Object o in lBoxTeamLeden.Items)
            {
                Gebruiker g = (Gebruiker)o;
                MessageBox.Show($"Test : {TeamID} - {g.ID}");
            }
        }
    }
}
