using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Areas.LOC_Country.Models
{
    public class LOC_CountryModel
    {
        [Required]
        public string CountryName { get; set; } = string.Empty;

        [Required]
        public string CountryCode { get; set; } = string.Empty;
    }
}
