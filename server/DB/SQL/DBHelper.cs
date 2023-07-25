using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace server.DB.SQL
{
    public partial class DBHelper : IDBHelper
    {
        #region private Attributes
        private string _filePath = Directory.GetCurrentDirectory() + "/MainDB.db";
        private SqlConnection? _conn = null;
        private SqlDataReader? _rdr = null;

        #endregion private Attributes

        #region Public Methods
        public SqlConnection? GetConnection()
        {
            SqlConnection connection;

            try
            {
                connection = new SqlConnection(string.Format("Data Source={0};", this._filePath));
                connection.Open();
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Get Connection is Failed => {ex.Message}");
                return null;
            }

            return connection;

        }

        public SqlCommand Command(string query)
        {
            SqlCommand cmd = new SqlCommand(query, _conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Command has been failed =>{ex.Message}");
            }

            return cmd;

        }
        public async Task CommandAsync(string query)
        {
            using (var command = new SqlCommand(query, _conn))
            {
                try
                {
                    await command.ExecuteNonQueryAsync(); // 비동기로 ExecuteNonQueryAsync() 호출
                }
                catch(Exception ex) 
                {
                    Trace.WriteLine($"Command has been failed =>{ex.Message}");
                }
            }
        }
        public int InsertQuery(string query)
        {
            int result = -1;

            try
            {
                using (var conn = GetConnection())
                {
                    SqlCommand command = new SqlCommand(query, conn);
                    result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return result;
        }
        #endregion Public Methods


        #region Interface Implementation
        public async Task InitializeAsync()
        {
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
            }

            this._conn = new SqlConnection("Data Source=" + _filePath);
            await this._conn.OpenAsync(); // 비동기로 OpenAsync() 호출

            await this.CommandAsync("create table if not exists UserInfo (Email varchar(50) primary key, pwd varchar(20) not null, Gender char(1))");
            await this.CommandAsync("create table if not exists BoardInfo (date varchar(50), Title varchar(20), Contents varchar(200), Email varchar(50))");
        }

        public void insertIntoBoardTable(DateTime date, string title, string contents, string Email)
        {
            string sql = $"INSERT INTO BoardInfo values('{date}','{title}','{contents}','{Email}')";
            Command(sql);
        }


        #endregion Interface Implementation
    }
}
