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
    
    public partial class seasontable
    {
        public int id { get; set; }
        public int seasonId { get; set; }
        public int teamId { get; set; }
        public int position { get; set; }
        public string teamName { get; set; }
        public int g { get; set; }
        public int p { get; set; }
        public int w { get; set; }
        public int d { get; set; }
        public int l { get; set; }
        public int gf { get; set; }
        public int ga { get; set; }
    
        public virtual season season { get; set; }
        public virtual team team { get; set; }
    }
}