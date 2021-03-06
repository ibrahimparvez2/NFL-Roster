//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NFLPlayers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Player
    {
        

        public int id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Team Name is required")]
        public string Team { get; set; }
        [Required(ErrorMessage = "Position is required")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Years Pro is required")]
        public Nullable<int> YearsPro { get; set; }
        public string ProfilePic { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<int> Height { get; set; }
        public Nullable<int> Weight { get; set; }
        public Nullable<int> Touchdowns { get; set; }
        public Nullable<int> Yards { get; set; }
        public Nullable<bool> Status { get; set; }
        public string Description { get; set; }
    }
}
