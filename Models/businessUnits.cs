using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace mis4200_team15.Models
{
    public class businessUnits
    {
        [Key]
        public int businessUnitsID { get; set; }
        [Display(Name = "Business Unit")]
        public string Unit { get; set; }
        [Display(Name = "Business Unit")]
        public ICollection<userDetails> userDetails { get; set; }

    }
}