using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace RL_Planner_DomeinClasses
{
    public class Team
    {
        private int ID;
        private string Naam;
        private string Beschrijving;
        private string Plaatje;
        SQL_Connection SQL = new();
        SqlDataReader reader;


        public Team(int id, string naam, string beschrijving)
        {
            this.ID = id;
            this.Naam = naam;
            this.Beschrijving = beschrijving;
        }

        public Team(string naam, string beschrijving, string plaatje)
        {
            this.Naam = naam;
            this.Beschrijving = beschrijving;
            this.Plaatje = plaatje;
        }

        public int TeamAanmaken()
        {
            SQL.loadSQL("INSERT INTO Team(Naam, Beschrijving, Plaatje) VALUES('" + this.Naam + "', '" + this.Beschrijving + "', '" + this.Plaatje + "')");
            reader = SQL.loadSQL("SELECT ID, Naam FROM Team WHERE Naam = '" + this.Naam + "'");
            reader.Read();
            return reader.GetInt32(0);
        }

        public override string? ToString()
        {
            return Naam;
        }
    }
}
