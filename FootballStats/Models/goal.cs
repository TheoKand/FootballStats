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
    
    public partial class goal
    {
        public int id { get; set; }
        public int matchId { get; set; }
        public int index { get; set; }
        public Nullable<int> half { get; set; }
        public int teamId { get; set; }
        public int minute { get; set; }
        public int second { get; set; }
        public string score { get; set; }
    
        public virtual fmatch fmatch { get; set; }
        public virtual team team { get; set; }
    }
}
