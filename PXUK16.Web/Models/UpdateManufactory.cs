using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PXUK16.Web.Models
{
    public class UpdateManufactory
    {
        //[Display(Name = "Manufactory Name")]
        //[Required(ErrorMessage = "Manufactory Name is required.")]
        public int ManufactoryId { get; set; }
        [Display(Name = "Manufactory Name")]
        [Required(ErrorMessage = "Manufactory Name is required.")]
        public string Name { get; set; }
    }
}
