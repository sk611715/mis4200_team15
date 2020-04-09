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

        [EmailAddress]

        [Display(Name = "Email")]

        public string Email { get; set; }

        [Required]

        [Display(Name = "First Name")]

        public string firstName { get; set; }

        [Required]

        [Display(Name = "Last Name")]

        public string lastName { get; set; }

        [Display(Name = "Primary Phone")]

        [Phone]

        public string PhoneNumber { get; set; }

        [Display(Name = "Office")]

        public string Office { get; set; }

        [Display(Name = "Current position")]

        public string Position { get; set; }

        [Display(Name = "Hire Date")]

        public DateTime? hireDate { get; set; }

        [Display(Name = "Location")]
        [Required(ErrorMessage = "Location is required")]
        public int locationsID { get; set; }
        public virtual Locations Locations { get; set; }
        public string fullLocation { get { return Locations.city + ", " + Locations.state; } }

        [Display(Name = "Business Unit")]
        [Required(ErrorMessage = "Business Unit is required")]
        public int businessUnitsID { get; set; }
        public virtual businessUnits businessUnits { get; set; }

    }
}