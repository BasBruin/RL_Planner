namespace RL_Planner_DomeinClasses
{
    public class Gebruiker
    {
        private string Naam;
        private string GameNaam;
        private string PlannerNaam;
        private string Email;
        private string Rank1s;
        private string Rank2s;
        private string Rank3s;

        public Gebruiker(string naam, string gameNaam, string plannerNaam, string email,
            string rank1s, string rank2s, string rank3s)
        {
            Naam = naam;
            GameNaam = gameNaam;
            PlannerNaam = plannerNaam;
            Email = email;
            Rank1s = rank1s;
            Rank2s = rank2s;
            Rank3s = rank3s;
        }

        public override string ToString()
        {
            return Naam;
        }
    }
}