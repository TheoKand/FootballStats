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
    
    public partial class region
    {
        public region()
        {
            this.seasons = new HashSet<season>();
            this.teams = new HashSet<team>();
            this.tournaments = new HashSet<tournament>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<season> seasons { get; set; }
        public virtual ICollection<team> teams { get; set; }
        public virtual ICollection<tournament> tournaments { get; set; }
    }
}
