using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using My_Project.Areas.MST_Student.Models;

namespace My_Project.Areas.MST_Student.Controllers
{
    [Area("MST_Student")]
    public class MST_StudentController : Controller
    {
        #region Configuration...
        private IConfiguration Configuration;

        public MST_StudentController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region Student List...
        public IActionResult Index()
        {
            string connectionString = this.Configuration.GetConnectionString("myConnectionString");
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_Student_SelectAll";
            SqlDataReader data_reader = command.ExecuteReader();
            dataTable.Load(data_reader);
            connection.Close();

            return View("MST_StudentList", dataTable);
        }
        #endregion

        #region Student Delete...
        public IActionResult MST_StudentDelete(int StudentID)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }
        }
        #endregion

        // Ahiya thi niche nu karvanu baki che

        #region Student Add or Edit...
        public IActionResult MST_StudentAddEdit(int? StudentID)
        {
            if (StudentID != null)
            {
                try
                {
                    string connectionString = this.Configuration.GetConnectionString("myConnectionString");
                    DataTable data_table = new DataTable();
                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PR_Student_SelectByPK";
                    command.Parameters.AddWithValue("@StudentID", StudentID);
                    SqlDataReader data_reader = command.ExecuteReader();
                    data_table.Load(data_reader);
                    connection.Close();

                    MST_StudentModel model = new MST_StudentModel
                    {
                        StudentID = Convert.ToInt32(data_table.Rows[0]["StudentID"]),
                        BranchID = Convert.ToInt32(data_table.Rows[0]["BranchID"]),
                        StudentName = data_table.Rows[0]["StudentName"].ToString(),
                        BranchName = data_table.Rows[0]["BranchName"].ToString(),
                        Email = data_table.Rows[0]["Email"].ToString(),
                        MobileNoStudent = data_table.Rows[0]["MobileNoStudent"].ToString()
                    };

                    return View(model);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Message : {ex.Message}");
                    return View();
                }
            }
            else
            {
                MST_StudentModel model = new MST_StudentModel
                {
                    StudentID = StudentID,
                };

                return View(model);
            }
        }
        #endregion

        #region Save Record...
        public IActionResult Save(MST_StudentModel studentModel)
        {
            try
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
                command.Parameters.AddWithValue("@BranchID", studentModel.BranchID);
                command.Parameters.AddWithValue("@CityID", studentModel.CityID);
                command.Parameters.AddWithValue("@StudentName", studentModel.StudentName);
                command.Parameters.AddWithValue("@BranchName", studentModel.BranchName);
                command.Parameters.AddWithValue("@Email", studentModel.Email);
                command.Parameters.AddWithValue("@MobileNoStudent", studentModel.MobileNoStudent);
                command.ExecuteNonQuery();
                connection.Close();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message : {ex.Message}");
                return RedirectToAction("Index");
            }
        }
        #endregion

        #region Search Branch...
        /*public IActionResult MST_BranchSearch(MST_BranchModel branchModel)
        {
            string connectionString = this.Configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            DataTable dt = new DataTable();
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_Branch_Search";
            command.Parameters.AddWithValue("@BranchName", branchModel.BranchName);
            command.Parameters.AddWithValue("@BranchCode", branchModel.BranchCode);
            SqlDataReader data_reader = command.ExecuteReader();
            dt.Load(data_reader);
            connection.Close();

            return View("MST_BranchList", dt);
        }*/
        #endregion
    }
}
