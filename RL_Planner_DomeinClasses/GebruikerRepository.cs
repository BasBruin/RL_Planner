using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RL_Planner_DomeinClasses
{
    public class GebruikerRepository
    {
        string connString = "Data Source=mssqlstud.fhict.local;Initial Catalog=dbi487790;Persist Security Info=True;User ID=dbi487790;Password=Welkom12";

        // Dit is voor mensen toevoegen aan team.
        public SqlDataReader GetAllGebruikers()
        {
            string query = "SELECT * FROM Gebruiker WHERE ID != 1";
            SqlConnection databaseConnection = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, databaseConnection);
            cmd.CommandTimeout = 60;
            SqlDataReader reader;
            databaseConnection.Open();
            reader = cmd.ExecuteReader();
            return (reader);
        }
    }
}
