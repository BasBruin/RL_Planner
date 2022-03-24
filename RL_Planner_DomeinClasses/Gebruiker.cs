using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL_Planner_DomeinClasses
{
    public class Gebruiker
    {
        private int ID;
        private string Naam;
        private string GameNaam;
        private string PlannerNaam;
        private string Email;
        private string Rank1s;
        private string Rank2s;
        private string Rank3s;

        public Gebruiker(int ID, string naam, string gameNaam, string plannerNaam, string email,
            string rank1s, string rank2s, string rank3s)
        {
            this.ID = ID;
            this.Naam = naam;
            this.GameNaam = gameNaam;
            this.PlannerNaam = plannerNaam;
            this.Email = email;
            this.Rank1s = rank1s;
            this.Rank2s = rank2s;
            this.Rank3s = rank3s;
        }

        public override string ToString()
        {
            return Naam;
        }
    }
}