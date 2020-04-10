using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


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
        public string fullLocation => city + ", " + state;
        public ICollection<userDetails> userDetails { get; set; }
    }
}