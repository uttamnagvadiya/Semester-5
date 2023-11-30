using Microsoft.AspNetCore.Mvc;
using My_Project.Areas.LOC_City.Models;
using My_Project.Areas.LOC_Country.Models;
using My_Project.Areas.LOC_State.Models;
using My_Project.Areas.MST_Branch.Models;
using My_Project.Models;
using System.Data;
using System.Data.SqlClient;

namespace My_Project.Controllers
{
    public class HomeController : Controller
    {
        #region Configuration...
        private readonly IConfiguration Configuration;
        public HomeController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        #endregion

        #region Student List...
        public IActionResult Index()
        {
            try
            {
                string connectionString = this.Configuration.GetConnectionString("myConnectionString");
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "PR_Student_SelectAll";
                SqlDataReader reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                connection.Close();

                return View(dataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }
        #endregion

        #region Student Profile Details...
        public IActionResult StudentProfileDetails(int StudentID)
        {
            try
            {
                string connectionString = this.Configuration.GetConnectionString("myConnectionString");
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PR_Student_SelectByPK";
                command.Parameters.AddWithValue("@StudentID", StudentID);
                SqlDataReader reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                connection.Close();

                return View(dataTable.Rows[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }
        #endregion

        #region Student Add or Edit...
        public IActionResult StudentAddEdit(int? StudentID)
        {
            StudentModel studentModel = new StudentModel();

            string connectionString = this.Configuration.GetConnectionString("myConnectionString");
            DataTable cityTable = new DataTable();
            DataTable branchTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_City_SelectForDropdown";
            SqlDataReader city_reader = command.ExecuteReader();
            cityTable.Load(city_reader);
            command.CommandText = "PR_Branch_SelectForDropdown";
            SqlDataReader branch_reader = command.ExecuteReader();
            branchTable.Load(branch_reader);

            List<LOC_CityDropdownModel> cityDropdown = new List<LOC_CityDropdownModel>();
            foreach (DataRow item in cityTable.Rows)
            {
                LOC_CityDropdownModel cityDropdownModel = new LOC_CityDropdownModel
                {
                    CityID = Convert.ToInt32(item["CityID"].ToString()),
                    CityName = item["CityName"].ToString(),
                };
                cityDropdown.Add(cityDropdownModel);
            }

            List<MST_BranchDropdownModel> branchDropdown = new List<MST_BranchDropdownModel>();
            foreach (DataRow item in branchTable.Rows)
            {
                MST_BranchDropdownModel branchDropdownModel = new MST_BranchDropdownModel
                {
                    BranchID = Convert.ToInt32(item["BranchID"].ToString()),
                    BranchName = item["BranchName"].ToString(),
                };
                branchDropdown.Add(branchDropdownModel);
            }

            studentModel.CityDropdownList = cityDropdown;
            studentModel.BranchDropdownList = branchDropdown;

            if (StudentID != null)
            {
                try
                {
                    DataTable studentTable = new DataTable();
                    command.CommandText = "PR_Student_SelectByPK";
                    command.Parameters.AddWithValue("@StudentID", StudentID);
                    SqlDataReader student_reader = command.ExecuteReader();
                    studentTable.Load(student_reader);
                    connection.Close();

                    studentModel.StudentID = Convert.ToInt32(studentTable.Rows[0]["StudentID"].ToString());
                    studentModel.BranchID = Convert.ToInt32(studentTable.Rows[0]["BranchID"].ToString());
                    studentModel.CountryID = Convert.ToInt32(studentTable.Rows[0]["CountryID"].ToString());
                    studentModel.StateID = Convert.ToInt32(studentTable.Rows[0]["StateID"].ToString());
                    studentModel.CityID = Convert.ToInt32(studentTable.Rows[0]["CityID"].ToString());
                    studentModel.Age = studentTable.Rows[0]["Age"].ToString();
                    studentModel.IsActive = studentTable.Rows[0]["IsActive"].ToString();
                    studentModel.BirthDate = Convert.ToDateTime(studentTable.Rows[0]["BirthDate"].ToString());
                    studentModel.StudentName = studentTable.Rows[0]["StudentName"].ToString();
                    studentModel.Email = studentTable.Rows[0]["Email"].ToString();
                    studentModel.BranchName = studentTable.Rows[0]["BranchName"].ToString();
                    studentModel.MobileNoStudent = studentTable.Rows[0]["MobileNoStudent"].ToString();
                    studentModel.MobileNoFather = studentTable.Rows[0]["MobileNoFather"].ToString();
                    studentModel.CountryName = studentTable.Rows[0]["CountryName"].ToString();
                    studentModel.StateName = studentTable.Rows[0]["StateName"].ToString();
                    studentModel.CityName = studentTable.Rows[0]["CityName"].ToString();
                    studentModel.Gender = studentTable.Rows[0]["Gender"].ToString();
                    studentModel.Address = studentTable.Rows[0]["Address"].ToString();

                    return View(studentModel);

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Message : {ex.Message}");
                    return View();
                }
            }
            else
            {
                connection.Close();
                studentModel.StudentID = StudentID;
                return View(studentModel);
            }
        }
        #endregion

        #region Save Record...
        public IActionResult Save(StudentModel studentModel)
        {
            string connectionString = this.Configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            if (studentModel.StudentID == null)
            {
                command.CommandText = "PR_Student_Insert_Record";
            }
            else
            {
                command.CommandText = "PR_Student_UpdateByPK";
                command.Parameters.AddWithValue("@StudentID", studentModel.StudentID);
            }
            command.Parameters.AddWithValue("@StudentName", studentModel.StudentName);
            command.Parameters.AddWithValue("@Email", studentModel.Email);
            command.Parameters.AddWithValue("@MobileNoStudent", studentModel.MobileNoStudent);
            command.Parameters.AddWithValue("@MobileNoFather", studentModel.MobileNoFather);
            command.Parameters.AddWithValue("@Gender", studentModel.Gender);
            command.Parameters.AddWithValue("@BirthDate", studentModel.BirthDate);
            command.Parameters.AddWithValue("@BranchID", studentModel.BranchID);
            command.Parameters.AddWithValue("@CityID", studentModel.CityID);
            command.Parameters.AddWithValue("@Age", Convert.ToInt32(studentModel.Age));
            command.Parameters.AddWithValue("@IsActive", Convert.ToBoolean(studentModel.IsActive));
            command.Parameters.AddWithValue("@Address", studentModel.Address);
            command.ExecuteNonQuery();
            connection.Close();

            return RedirectToAction("Index");
        }
        #endregion

        #region Student Delete...
        public IActionResult StudentDelete(int StudentID)
        {
            string connectionString = this.Configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_Student_DeleteByPK";
            command.Parameters.AddWithValue("@StudentID", StudentID);
            command.ExecuteNonQuery();
            connection.Close();

            return RedirectToAction("Index");
        }
        #endregion

        #region Student Search...
        public IActionResult StudentSearch(StudentModel studentModel)
        {
            string connectionString = this.Configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            DataTable dt = new DataTable();
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_Student_Search";
            command.Parameters.AddWithValue("@StudentName", studentModel.StudentName);
            command.Parameters.AddWithValue("@BranchName", studentModel.BranchName);
            command.Parameters.AddWithValue("@CityName", studentModel.CityName);
            SqlDataReader data_reader = command.ExecuteReader();
            dt.Load(data_reader);
            connection.Close();

            return View("Index", dt);
        }
        #endregion

    }
}

