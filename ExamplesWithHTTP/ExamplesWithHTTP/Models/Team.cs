using System;


namespace ExamplesWithHTTP.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime FoudationYer { get; set; }
        public string Division { get; set; }
        public string Conference { get; set; }
        public string ImageUrl { get; set; }
    }
}
