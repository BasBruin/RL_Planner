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

namespace RL_Planner
{
    public partial class TeamRegister : Form
    {
        SQL_Connection GetDataBase = new SQL_Connection();
        SqlDataReader reader;

        public TeamRegister()
        {
            InitializeComponent();
            reader = GetDataBase.loadSQL("SELECT * FROM Gebruiker WHERE ID = 1");
            reader.Read();
            Bitmap bitmap = new Bitmap(reader.GetString(6)); ;
            pictureBox1.Image = bitmap;
        }

        private void ProfielLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
