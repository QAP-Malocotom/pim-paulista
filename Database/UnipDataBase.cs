using MySqlConnector;

namespace pim_paulista.Database
{
    public class UnipDataBase
    {
        public void ExecuteInsert(string script, List<MySqlParameter> param)
        {
            PimConnection s = new PimConnection();
            MySqlConnection c = s.Create();

            MySqlCommand c1 = c.CreateCommand();
            c1.CommandText = script;

            if (param != null)
            {
                foreach (MySqlParameter p in param)
                {
                    c1.Parameters.Add(p);
                }
            }

            c1.ExecuteNonQuery();
            c.Close();
        }

        public MySqlDataReader ExecuteSelect(string script, List<MySqlParameter> parameters)
        {
            PimConnection s = new PimConnection();
            MySqlConnection c = s.Create();

            MySqlCommand c1 = c.CreateCommand();
            c1.CommandText = script;

            if (parameters != null)
            {
                foreach (MySqlParameter p in parameters)
                {
                    c1.Parameters.Add(p);
                }
            }

            MySqlDataReader r = c1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            return r;

        }

        public int ExecuteScalar(string script, List<MySqlParameter> parameters)
        {
            PimConnection conn = new PimConnection();
            MySqlConnection connection = conn.Create();

            MySqlCommand command = connection.CreateCommand();
            command.CommandTimeout = 20;

            command.CommandText = script;

            if (parameters != null)
            {
                foreach (MySqlParameter param in parameters)
                {
                    command.Parameters.Add(param);
                }
            }


            command.ExecuteNonQuery();
            connection.Close();



            int id = Convert.ToInt32(command.LastInsertedId);
            return id;
        }
    }
}
