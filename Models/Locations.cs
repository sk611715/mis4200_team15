using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mis4200_team15.Models
{
    public class Locations
    {
        [Key]
        public int locationsID { get; set; }
        [Display(Name ="City")]
        public string city { get; set; }
        [Display(Name ="State")]
        public string state { get; set; }
        public ICollection<userDetails> userDetails { get; set; }
    }
}