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

        #region City Add or Edit...
        public IActionResult LOC_CityAddEdit(int? CityID)
        {
            LOC_CityModel cityModel = new LOC_CityModel();

            #region Country List for Dropdowns...
            string connectionString = this.Configuration.GetConnectionString("myConnectionString");
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_Country_SelectAll";
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);

            List<LOC_CountryDropdownModel> countryDropdownModels = new List<LOC_CountryDropdownModel>();
            foreach (DataRow row in dt.Rows)
            {
                LOC_CountryDropdownModel countryModel = new LOC_CountryDropdownModel
                {
                    CountryID = Convert.ToInt32(row["CountryID"]),
                    CountryName = row["CountryName"].ToString(),
                };
                countryDropdownModels.Add(countryModel);
            }

            cityModel.CountryDropdownList = countryDropdownModels;

            #endregion



            if (CityID != null)
            {
                try
                {
                    DataTable data_table = new DataTable();
                    SqlCommand sql_command = connection.CreateCommand();
                    sql_command.CommandType = CommandType.StoredProcedure;
                    sql_command.CommandText = "PR_City_SelectByPK";
                    sql_command.Parameters.AddWithValue("@CityID", CityID);
                    SqlDataReader sql_data_reader = sql_command.ExecuteReader();
                    data_table.Load(sql_data_reader);
                    connection.Close();


                    cityModel.CityID = Convert.ToInt32(data_table.Rows[0]["CityID"]);
                    cityModel.StateID = Convert.ToInt32(data_table.Rows[0]["StateID"]);
                    cityModel.CountryID = Convert.ToInt32(data_table.Rows[0]["CountryID"]);
                    cityModel.CityName = data_table.Rows[0]["CityName"].ToString();
                    cityModel.CityCode = data_table.Rows[0]["CityCode"].ToString();
                    cityModel.StateName = data_table.Rows[0]["StateName"].ToString();
                    cityModel.CountryName = data_table.Rows[0]["CountryName"].ToString();

                    return View(cityModel);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Message : {ex.Message}");
                    return View();
                }
            }
            else
            {
                cityModel.CityID = CityID;

                return View(cityModel);
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
                Console.WriteLine($"Error Message : {ex.Message}");
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


        public IActionResult LOC_StateDropdownListByCountryID(int CountryID)
        {
            //return RedirectToRoute(new { Area = "LOC_Country", controller = "LOC_Country", action = "Index" });

            string connectionString = this.Configuration.GetConnectionString("myConnectionString");
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_State_SelectForDropdown";
            command.Parameters.AddWithValue("@CountryID", CountryID);
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            connection.Close();

            List<LOC_StateDropdownModel> stateDropdownModels = new List<LOC_StateDropdownModel>();
            foreach (DataRow item in dt.Rows)
            {
                LOC_StateDropdownModel model = new LOC_StateDropdownModel
                {
                    StateID = Convert.ToInt32(item["StateID"]),
                    StateName = item["StateName"].ToString(),
                };

                stateDropdownModels.Add(model);
            }

            return Json(stateDropdownModels);
        }
    }
}
