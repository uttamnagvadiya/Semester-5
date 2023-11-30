using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace My_Project.Areas.MST_Branch.Models
{
    public class MST_BranchModel
    {
        public int? BranchID { get; set; }

        [Required]
        [DisplayName("Branch Name")]
        public string BranchName { get; set; } = string.Empty;

        [Required]
        [DisplayName("Branch Code")]
        public string BranchCode { get; set; } = string.Empty;
    }

    public class MST_BranchDropdownModel
    {
        public int BranchID { get; set; }

        public string BranchName { get; set; } = string.Empty;
    }
}
