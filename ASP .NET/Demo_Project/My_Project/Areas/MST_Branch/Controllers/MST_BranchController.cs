using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using My_Project.Areas.MST_Branch.Models;
using NuGet.Protocol.Plugins;

namespace My_Project.Areas.MST_Branch.Controllers
{
    [Area("MST_Branch")]
    public class MST_BranchController : Controller
    {
        #region Configuration...
        private IConfiguration Configuration;

        public MST_BranchController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region Branch List...
        public IActionResult Index()
        {
            string connectionString = this.Configuration.GetConnectionString("myConnectionString");
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_Branch_SelectAll";
            SqlDataReader data_reader = command.ExecuteReader();
            dataTable.Load(data_reader);
            connection.Close();

            return View("MST_BranchList", dataTable);
        }
        #endregion

        #region Branch Delete...
        public IActionResult MST_BranchDelete(int BranchID)
        {
            try
            {
                string connectionString = this.Configuration.GetConnectionString("myConnectionString");
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PR_Branch_DeleteByPK";
                command.Parameters.AddWithValue("@BranchID", BranchID);
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

        #region Branch Add or Edit...
        public IActionResult MST_BranchAddEdit(int? BranchID)
        {
           if (BranchID != null)
            {
                try
                {
                    string connectionString = this.Configuration.GetConnectionString("myConnectionString");
                    DataTable data_table = new DataTable();
                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PR_Branch_SelectByPK";
                    command.Parameters.AddWithValue("@BranchID", BranchID);
                    SqlDataReader data_reader = command.ExecuteReader();
                    data_table.Load(data_reader);
                    connection.Close();

                    MST_BranchModel model = new MST_BranchModel
                    {
                        BranchID = Convert.ToInt32(data_table.Rows[0]["BranchID"]),
                        BranchName = data_table.Rows[0]["BranchName"].ToString(),
                        BranchCode = data_table.Rows[0]["BranchCode"].ToString(),
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
                MST_BranchModel model = new MST_BranchModel
                {
                    BranchID = BranchID,
                };

                return View(model);
            }
        }
        #endregion

        #region Save Record...
        public IActionResult Save(MST_BranchModel branchModel)
        {
            try
            {
                string connectionString = this.Configuration.GetConnectionString("myConnectionString");
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                if (branchModel.BranchID == null)
                {
                    command.CommandText = "PR_Branch_Insert_Record";
                }
                else
                {
                    command.CommandText = "PR_Branch_UpdateByPK";
                    command.Parameters.AddWithValue("@BranchID", branchModel.BranchID);
                }
                command.Parameters.AddWithValue("@BranchName", branchModel.BranchName);
                command.Parameters.AddWithValue("@BranchCode", branchModel.BranchCode);
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
        public IActionResult MST_BranchSearch(MST_BranchModel branchModel)
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
        }
        #endregion
    }
}
