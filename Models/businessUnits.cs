using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mis4200_team15.Models
{
    public class businessUnits
    {
        [Key]
        public int businessUnitsID { get; set; }
        public string Unit { get; set; }
        [Display(Name = "Business Unit")]
        public ICollection<userDetails> userDetails { get; set; }

    }
}