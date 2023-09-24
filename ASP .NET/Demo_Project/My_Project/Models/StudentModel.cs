namespace My_Project.Models
{
    public class StudentModel
    {
        public int StudentID { get; set; }

        public int BranchID { get; set; }

        public int CityID { get; set; }

        public int Age { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsActive { get; set; }

        public string StudentName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string MobileNoStudent { get; set; } = string.Empty;

        public string MobileNoFather { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

    }
}
