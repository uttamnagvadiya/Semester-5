using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace My_Project.Areas.LOC_City.Models
{
    public class LOC_CityModel
    {
        public int? CityID { get; set; }

        public int StateID { get; set; }

        public int CountryID { get; set; }

        [Required]
        [DisplayName("City Name")]
        public string CityName { get; set; } = string.Empty;

        [Required]
        [DisplayName("City Code")]
        public string CityCode { get; set; } = string.Empty;

        [Required]
        [DisplayName("State Name")]
        public string StateName { get; set; } = string.Empty;

        [Required]
        [DisplayName("Country Name")]
        public string CountryName { get; set; } = string.Empty;
    }
}
