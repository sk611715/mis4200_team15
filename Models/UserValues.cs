using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mis4200_team15.Models
{
    public class UserValues
    {
        [Key]
        public int userValueID { get; set; }
        public int ID { get; set; }
        public virtual userDetails UserDetails { get; set; }
        public int valueID { get; set; }
        public virtual coreValues coreValues { get; set; }
        [Display(Name ="Date Assigned")]
        public DateTime dateAssigned { get; set; }
    }
}