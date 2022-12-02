using MySqlConnector;

namespace pim_paulista.Database
{
    public class PimConnection
    {
        public MySqlConnection Create()
        {
            //azuredev
            //Faculdade,22
            string connectionString = "server=pim-paulista.mysql.database.azure.com;database=pim;uid=azuredev;pwd=Faculdade,22";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
