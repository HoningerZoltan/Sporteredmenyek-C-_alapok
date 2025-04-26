namespace Sporteredmenyek.Core.Models
{
    public struct TeamsIntValuePair
    {

        public int Home { get; }
        public int Away { get; }
        public TeamsIntValuePair(int home, int away)
        {
            Home = home;
            Away = away;
        }
    }
}
