using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestBIT.Data
{
    public static class GetAllData
    {
        #region Fields
        private static DataTable CityTable = new DataTable();
        private static DataTable StreetsTable = new DataTable();
        private static DataTable HouseTable = new DataTable();
        private static DataTable ApartmentTable = new DataTable();
        private static DataSet DataSet = new DataSet();
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private static string sql = "SELECT * FROM Cities; SELECT * FROM Streets; SELECT * FROM Houses; SELECT * FROM Apartments";
        private static SqlConnection Connection = null;
        private static SqlCommand Command = new SqlCommand();
        private static SqlDataAdapter Adapter = new SqlDataAdapter();
        #endregion
        static GetAllData()
        {
            InitializeData();
        }
        private static void InitializeData()
        {
            try
            {
                Connection = new SqlConnection(ConnectionString);
                Command = new SqlCommand(sql, Connection);
                Adapter = new SqlDataAdapter(Command);

                DataSet.Tables.Add(CityTable);
                DataSet.Tables.Add(StreetsTable);
                DataSet.Tables.Add(HouseTable);
                DataSet.Tables.Add(ApartmentTable);

                Connection.Open();

                SqlDataReader DataReader = Command.ExecuteReader();
                DataSet.Load(DataReader, LoadOption.OverwriteChanges, CityTable, StreetsTable, HouseTable, ApartmentTable);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (Connection != null)
                    Connection.Close();
            }
        }
        public static DataTable GetCityTable()
        {
            DataSet.Relations.Add("CityToStreets", CityTable.Columns["ID"], StreetsTable.Columns["city_id"]);
            CityTable.Columns.Add("StreetsCount", typeof(int), "Count(Child.city_id)");
            return CityTable;
        }
        public static DataTable GetStreetTable()
        {
           return StreetsTable;
        }
    }
}
