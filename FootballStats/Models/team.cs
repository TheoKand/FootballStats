//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GoalsWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class team
    {
        public team()
        {
            this.matchesAsHomeTeam = new HashSet<fmatch>();
            this.matchesAsAwayTeam = new HashSet<fmatch>();
            this.matchesWon = new HashSet<fmatch>();
            this.matchesLost = new HashSet<fmatch>();
            this.goals = new HashSet<goal>();
            this.matchevents = new HashSet<matchevent>();
            this.seasonsAsChampions = new HashSet<season>();
            this.seasontables = new HashSet<seasontable>();
        }
    
        public int id { get; set; }
        public int regionId { get; set; }
        public Nullable<int> domesticTournamentId { get; set; }
        public string name { get; set; }
        public decimal calcDomesticRating { get; set; }
        public decimal calcInternationalRating { get; set; }
        public decimal calcTotalRating { get; set; }
        public decimal calcDomesticHomeAttackPerGame { get; set; }
        public decimal calcDomesticHomeDefencePerGame { get; set; }
        public decimal calcDomesticAwayAttackPerGame { get; set; }
        public decimal calcDomesticAwayDefencePerGame { get; set; }
        public string calcDesc { get; set; }
    
        public virtual ICollection<fmatch> matchesAsHomeTeam { get; set; }
        public virtual ICollection<fmatch> matchesAsAwayTeam { get; set; }
        public virtual ICollection<fmatch> matchesWon { get; set; }
        public virtual ICollection<fmatch> matchesLost { get; set; }
        public virtual ICollection<goal> goals { get; set; }
        public virtual ICollection<matchevent> matchevents { get; set; }
        public virtual region region { get; set; }
        public virtual ICollection<season> seasonsAsChampions { get; set; }
        public virtual ICollection<seasontable> seasontables { get; set; }
        public virtual tournament tournament { get; set; }
    }
}
