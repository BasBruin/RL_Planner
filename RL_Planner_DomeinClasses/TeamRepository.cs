using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace RL_Planner_DomeinClasses
{
    public class TeamRepository
    {
        public List<Team> GetPlayerTeams()
        {
            List<Team> teams = new List<Team>();
            string connect = "Data Source=mssqlstud.fhict.local;Initial Catalog=dbi487790;Persist Security Info=True;User ID=dbi487790;Password=Welkom12";
            DataTable dt = new();
            SqlDataAdapter da = new("SELECT t.* FROM Gebruiker g JOIN GebruikerTeam gt ON gt.GebruikerID = g.ID JOIN Team t ON gt.TeamID = t.ID WHERE g.ID = 1", connect);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                teams.Add(new Team(Convert.ToInt32(dr["ID"]), Convert.ToString(dr["Naam"]), Convert.ToString(dr["Beschrijving"])));
            }
            return teams;
        }
    }
}
