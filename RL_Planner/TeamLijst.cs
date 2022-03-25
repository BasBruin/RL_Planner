using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RL_Planner_DomeinClasses;

namespace RL_Planner
{
    public partial class TeamLijst : Form
    {
        SqlDataReader reader;
        readonly SQL_Connection GetDataBase = new SQL_Connection();
        TeamRepository teamRepository = new TeamRepository();

        public TeamLijst()
        {
            InitializeComponent();
            reader = GetDataBase.loadSQL("SELECT * FROM Gebruiker WHERE ID = 1");
            reader.Read();
            lblProfielNaam.Text = reader.GetString(1);
            Bitmap bitmap = new Bitmap(reader.GetString(6)); ;
            pictureBox1.Image = bitmap;
            //listBox1.Items.Add(teamRepository.GetPlayerTeams().ToString());
            listBox1.Items.AddRange(teamRepository.GetPlayerTeams().ToArray());
        }

        private void ProfielLabel_Click(object sender, EventArgs e)
        {
            FormCommunicator.Profiel.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCommunicator.TeamRegister.Show();
            this.Hide();
        }
    }
}
