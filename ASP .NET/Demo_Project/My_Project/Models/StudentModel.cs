using Microsoft.AspNetCore.Mvc;
using My_Project.Areas.LOC_City.Models;
using My_Project.Areas.LOC_Country.Models;
using My_Project.Areas.LOC_State.Models;
using My_Project.Areas.MST_Branch.Models;
using System.ComponentModel.DataAnnotations;

namespace My_Project.Models
{
    public class StudentModel
    {
        public int? StudentID { get; set; }

        [Required]
        public int BranchID { get; set; }

        public int CountryID { get; set; }

        public int StateID { get; set; }

        [Required]
        public int CityID { get; set; }

        public string? Age { get; set; } = string.Empty;

        [Required]
        public DateTime? BirthDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string? IsActive { get; set; }

        [Required]
        public string StudentName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        public string BranchName { get; set; } = string.Empty;

        public string BranchCode { get; set; } = string.Empty;

        [Required]
        public string MobileNoStudent { get; set; } = string.Empty;

        public string? MobileNoFather { get; set; }

        public string? Gender { get; set; }

        public string? Address { get; set; }

        public string CountryName { get; set; } = string.Empty;

        public string CountryCode { get; set; } = string.Empty;

        public string StateName { get; set; } = string.Empty;

        public string StateCode { get; set; } = string.Empty;

        public string CityName { get; set; } = string.Empty;

        public string CityCode { get; set; } = string.Empty;

        public List<LOC_CountryDropdownModel> CountryDropdownList { get; set; }

        public List<LOC_StateDropdownModel> StateDropdownList { get; set; }

        public List<LOC_CityDropdownModel> CityDropdownList { get; set; }

        public List<MST_BranchDropdownModel> BranchDropdownList { get; set; }
    }
}
