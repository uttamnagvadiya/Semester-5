using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace My_Project.Areas.LOC_State.Models
{
    public class LOC_StateModel
    {
        public int? StateID { get; set; }

        public int CountryID { get; set; }

        [Required]
        [DisplayName("State Name")]
        public string StateName { get; set; } = string.Empty;

        [Required]
        [DisplayName("State Code")]
        public string StateCode { get; set; } = string.Empty;
    }

    public class LOC_StateDropdownModel
    {
        public int StateID { get; set; }

        public string StateName { get; set; } = string.Empty;
    }
}
