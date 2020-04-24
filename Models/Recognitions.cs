using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mis4200_team15.Models
{
    public class Recognitions
    {
        [Key]
        public int recognitionsID { get; set; }


        [Required]
        [Display(Name = "Name of Employee")]

        public int ID { get; set; }
        public virtual userDetails userDetails { get; set; }
        public string fullUserName { get { return userDetails.lastName + ", " + userDetails.firstName; } }

        [Required]

        [Display(Name = "Date of Value Demonstrated")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? recognitionDate { get; set; }

        [Required]
        [Display(Name = "Core Value")]
        public int coreValuesID { get; set; }
        public virtual coreValues coreValues { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

    }
}