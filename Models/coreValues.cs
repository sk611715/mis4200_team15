using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace mis4200_team15.Models
{
    public class coreValues
    {
        [Key]
        public int coreValuesID { get;  set; }
        [Display(Name ="Core Value")]
        public string valueName { get; set; }
        [Display(Name ="Description")]
        public string description { get; set; }
        [Display(Name ="Points")]
        public int points { get; set; }
        public ICollection<UserValues> UserValues { get; set; }
    }
}