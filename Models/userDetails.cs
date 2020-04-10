using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mis4200_team15.Models
{
    public class userDetails
    {
      
        [Required]

        public Guid ID { get; set; }

        [Required]
        [EmailAddress]

        [Display(Name = "Email")]

        public string Email { get; set; }

        [Required]

        [Display(Name = "First Name")]

        public string firstName { get; set; }

        [Required]

        [Display(Name = "Last Name")]

        public string lastName { get; set; }

        [Required]

        [Display(Name = "Primary Phone")]

        [Phone]

        public string PhoneNumber { get; set; }

        [Required]

        [Display(Name = "Hire Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? hireDate { get; set; }

        [Required]
        [Display(Name = "Location")]
        public int locationsID { get; set; }
        public virtual Locations Locations { get; set; }
        public string fullLocation { get { return Locations.city + ", " + Locations.state; } }

        [Required]
        [Display(Name = "Business Unit")]
        public int businessUnitsID { get; set; }
        public virtual businessUnits businessUnits { get; set; }

    }
}