using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PXUK16.Web.Models
{
    public class DeleteManufactory
    {
        [Display(Name = "Manufactory ID")]
        [Required(ErrorMessage = "Manufactory ID is required.")]
        public int ManufactoryId { get; set; }
    }
}
