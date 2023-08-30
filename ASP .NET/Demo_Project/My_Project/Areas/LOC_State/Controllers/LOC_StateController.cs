using Microsoft.AspNetCore.Mvc;
using My_Project.Areas.LOC_Country.Models;
using My_Project.Areas.LOC_State.Models;
using System.Data;
using System.Data.SqlClient;

namespace My_Project.Areas.LOC_State.Controllers
{
    [Area("LOC_State")]
    public class LOC_StateController : Controller
    {
        #region Configuration...
        private IConfiguration Configuration;

        public LOC_StateController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region State List...
        public IActionResult Index()
        {
            string connectionString = this.Configuration.GetConnectionString("myConnectionString");
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_State_SelectAll";
            SqlDataReader data_reader = command.ExecuteReader();
            dataTable.Load(data_reader);
            connection.Close();

            return View("LOC_StateList", dataTable);
        }
        #endregion

        #region State Delete...
        public IActionResult LOC_StateDelete(int StateID)
        {
            try
            {
                string connectionString = this.Configuration.GetConnectionString("myConnectionString");
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PR_State_DeleteByPK";
                command.Parameters.AddWithValue("@StateID", StateID);
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

        #region State Add or Edit...
        public IActionResult LOC_StateAddEdit(int? StateID)
        {
            #region Country List for Dropdown...
            string connectionString = this.Configuration.GetConnectionString("myConnectionString");
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection( connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_Country_SelectForDropdown";
            SqlDataReader data_reader = command.ExecuteReader();
            dataTable.Load(data_reader);
            connection.Close();

            List<LOC_CountryDropdownModel> countryDropdownModelsList = new List<LOC_CountryDropdownModel>();
            foreach (DataRow data in dataTable.Rows)
            {
                LOC_CountryDropdownModel countryModel = new LOC_CountryDropdownModel
                {
                    CountryID = Convert.ToInt32(data["CountryID"]),
                    CountryName = data["CountryName"].ToString(),
                };
                countryDropdownModelsList.Add(countryModel);
            }

            ViewBag.CountryDropdownList = countryDropdownModelsList;
            #endregion

            if (StateID != null)
            {
                try
                {
                    string connection_string = this.Configuration.GetConnectionString("myConnectionString");
                    DataTable data_table = new DataTable();
                    SqlConnection sql_connection = new SqlConnection(connection_string);
                    sql_connection.Open();
                    SqlCommand sql_command = sql_connection.CreateCommand();
                    sql_command.CommandType = CommandType.StoredProcedure;
                    sql_command.CommandText = "PR_State_SelectByPK";
                    sql_command.Parameters.AddWithValue("@StateID", StateID);
                    SqlDataReader sql_data_reader = sql_command.ExecuteReader();
                    data_table.Load(sql_data_reader);
                    sql_connection.Close();

                    LOC_StateModel model = new LOC_StateModel
                    {
                        StateID = Convert.ToInt32(data_table.Rows[0]["StateID"]),
                        CountryID = Convert.ToInt32(data_table.Rows[0]["CountryID"]),
                        StateName = data_table.Rows[0]["StateName"].ToString(),
                        StateCode = data_table.Rows[0]["StateCode"].ToString(),
                    };

                    return View(model);
                }
                catch (Exception ex)
                {
                    return View();
                }
            }
            else
            {
                LOC_StateModel model = new LOC_StateModel
                {
                    StateID = StateID,
                };

                return View(model);
            }
        }
        #endregion

        #region Save Record...
        public IActionResult Save(LOC_StateModel stateModel)
        {
            try
            {
                string connectionString = this.Configuration.GetConnectionString("myConnectionString");
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                if (stateModel.StateID == null)
                {
                    command.CommandText = "PR_State_Insert_Record";
                }
                else
                {
                    command.CommandText = "PR_State_UpdateByPK";
                    command.Parameters.AddWithValue("@StateID", stateModel.StateID); 
                }
                command.Parameters.AddWithValue("@CountryID", stateModel.CountryID);
                command.Parameters.AddWithValue("@StateName", stateModel.StateName);
                command.Parameters.AddWithValue("@StateCode", stateModel.StateCode);
                command.ExecuteNonQuery();
                connection.Close();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
        #endregion

        #region Search State...
        public IActionResult LOC_StateSearch(LOC_StateModel stateModel)
        {
            string connectionString = this.Configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            DataTable dt = new DataTable();
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_State_Search";
            command.Parameters.AddWithValue("@StateName", stateModel.StateName);
            command.Parameters.AddWithValue("@StateCode", stateModel.StateCode);
            SqlDataReader data_reader = command.ExecuteReader();
            dt.Load(data_reader);
            connection.Close();

            return View("LOC_StateList", dt);
        }
        #endregion
    }
}
