namespace My_Project.Areas.MST_Student.Models
{
    public class MST_StudentModel
    {
        public int? StudentID { get; set; }

        public int BranchID { get; set; }

        public int CityID { get; set; }

        public string StudentName { get; set; } = string.Empty;

        public string Email { get; set;} = string.Empty;

        public string MobileNoStudent { get; set; } = string.Empty;

        public string BranchName { get; set; } = string.Empty;
    }
}
