using Microsoft.AspNetCore.Mvc;
using My_Project.Areas.LOC_City.Models;
using My_Project.Areas.LOC_Country.Models;
using My_Project.Areas.LOC_State.Models;
using System.Data;
using System.Data.SqlClient;
using My_Project.Areas.LOC_Country.Controllers;


namespace My_Project.Areas.LOC_City.Controllers
{
    [Area("LOC_City")]
    public class LOC_CityController : Controller
    {
        #region Configuration...
        private IConfiguration Configuration;
        public LOC_CityController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region City List...
        public IActionResult Index()
        {
            string connectionString = this.Configuration.GetConnectionString("myConnectionString");
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_City_SelectAll";
            SqlDataReader data_reader = command.ExecuteReader();
            dataTable.Load(data_reader);
            connection.Close();

            return View("LOC_CityList", dataTable);
        }
        #endregion

        #region City Delete...
        public IActionResult LOC_CityDelete(int CityID)
        {
            try
            {
                string connectionString = this.Configuration.GetConnectionString("myConnectionString");
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PR_City_DeleteByPK";
                command.Parameters.AddWithValue("@CityID", CityID);
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

        public IActionResult DropDown()
        {
           return RedirectToRoute(new { Area="LOC_Country", controller = "LOC_Country", action = "Index" });
        }
        #region City Add or Edit...
        public IActionResult LOC_CityAddEdit(int? CityID)
        {
            #region Country & State List for Dropdowns...
            string connectionString = this.Configuration.GetConnectionString("myConnectionString");
            DataTable countryDataTable = new DataTable();
            DataTable stateDataTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_Country_SelectForDropdown";
            SqlDataReader data_reader1 = command.ExecuteReader();
            countryDataTable.Load(data_reader1);
            command.CommandText = "PR_State_SelectForDropdown";
            SqlDataReader data_reader2 = command.ExecuteReader();
            stateDataTable.Load(data_reader2);
            connection.Close();

            List<LOC_CountryDropdownModel> countryDropdownModelsList = new List<LOC_CountryDropdownModel>();
            foreach (DataRow data in countryDataTable.Rows)
            {
                LOC_CountryDropdownModel countryModel = new LOC_CountryDropdownModel
                {
                    CountryID = Convert.ToInt32(data["CountryID"]),
                    CountryName = data["CountryName"].ToString(),
                };
                countryDropdownModelsList.Add(countryModel);
            }

            List<LOC_StateDropdownModel> stateDropdownModelsList = new List<LOC_StateDropdownModel>();
            foreach (DataRow data in stateDataTable.Rows)
            {
                LOC_StateDropdownModel stateModel = new LOC_StateDropdownModel
                {
                    StateID = Convert.ToInt32(data["StateID"]),
                    StateName = data["StateName"].ToString(),
                };
                stateDropdownModelsList.Add(stateModel);
            }

            ViewBag.CountryDropdownList = countryDropdownModelsList;
            ViewBag.StateDropdownList = stateDropdownModelsList;
            #endregion

            if (CityID != null)
            {
                try
                {
                    string connection_string = this.Configuration.GetConnectionString("myConnectionString");
                    DataTable data_table = new DataTable();
                    SqlConnection sql_connection = new SqlConnection(connection_string);
                    sql_connection.Open();
                    SqlCommand sql_command = sql_connection.CreateCommand();
                    sql_command.CommandType = CommandType.StoredProcedure;
                    sql_command.CommandText = "PR_City_SelectByPK";
                    sql_command.Parameters.AddWithValue("@CityID", CityID);
                    SqlDataReader sql_data_reader = sql_command.ExecuteReader();
                    data_table.Load(sql_data_reader);
                    sql_connection.Close();

                    LOC_CityModel model = new LOC_CityModel
                    {
                        CityID = Convert.ToInt32(data_table.Rows[0]["CityID"]),
                        StateID = Convert.ToInt32(data_table.Rows[0]["StateID"]),
                        CountryID = Convert.ToInt32(data_table.Rows[0]["CountryID"]),
                        CityName = data_table.Rows[0]["CityName"].ToString(),
                        CityCode = data_table.Rows[0]["CityCode"].ToString(),
                        StateName = data_table.Rows[0]["StateName"].ToString(),
                        CountryName = data_table.Rows[0]["CountryName"].ToString(),
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
                LOC_CityModel model = new LOC_CityModel
                {
                    CityID = CityID
                };

                return View(model);
            }
        }
        #endregion

        #region Save Record...
        public IActionResult Save(LOC_CityModel cityModel)
        {
            try
            {
                string connectionString = this.Configuration.GetConnectionString("myConnectionString");
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                if (cityModel.CityID == null)
                {
                    command.CommandText = "PR_City_Insert_Record";
                }
                else
                {
                    command.CommandText = "PR_City_UpdateByPK";
                    command.Parameters.AddWithValue("@CityID", cityModel.CityID);
                }
                command.Parameters.AddWithValue("@StateID", cityModel.StateID);
                command.Parameters.AddWithValue("@CountryID", cityModel.CountryID);
                command.Parameters.AddWithValue("@CityName", cityModel.CityName);
                command.Parameters.AddWithValue("@CityCode", cityModel.CityCode);
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

        #region Search City...
        public IActionResult LOC_CitySearch(LOC_CityModel cityModel)
        {
            string connectionString = this.Configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            DataTable dt = new DataTable();
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_City_Search";
            command.Parameters.AddWithValue("@CityName", cityModel.CityName);
            command.Parameters.AddWithValue("@CityCode", cityModel.CityCode);
            SqlDataReader data_reader = command.ExecuteReader();
            dt.Load(data_reader);
            connection.Close();

            return View("LOC_CityList", dt);
        }
        #endregion
    }
}
