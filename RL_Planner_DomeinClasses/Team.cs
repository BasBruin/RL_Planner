using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL_Planner_DomeinClasses
{
    public class Team
    {
        private int ID;
        private string Naam;
        private string Beschrijving;

        public Team(int id, string naam, string beschrijving)
        {
            this.ID = id;
            this.Naam = naam;
            this.Beschrijving = beschrijving;
        }
        public void TeamAanmaken()
        {

        }

        public override string? ToString()
        {
            return Naam;
        }
    }
}
