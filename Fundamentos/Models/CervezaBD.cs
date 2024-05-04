using MySql.Data.MySqlClient;

namespace Fundamentos.Models
{
    internal class CervezaBD
    {
        private readonly string connectionString = "server=localhost;port=3306;user=root;password=admin;database=cervezas";
        public List<Cerveza> Get()
        {
            List<Cerveza> cervezas = [];
            string query = "select nombre, marca, alcohol, cantidad from cerveza;";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int cantidad = reader.GetInt32(3);
                        string nombre = reader.GetString(0);
                        Cerveza cerveza = new(cantidad, nombre)
                        {
                            Alcohol = reader.GetInt32(2),
                            Marca = reader.GetString(1)
                        };
                        cervezas.Add(cerveza);
                    }
                }
                connection.Close();
            }
            return cervezas;
        }
        public void Add(Cerveza cerveza)
        {
            string query = "INSERT INTO cerveza (nombre, marca, alcohol, cantidad) " +
                "VALUES (@nombre, @marca, @alcohol, @cantidad);";
            using var connection = new MySqlConnection(connectionString);
            var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@nombre", cerveza.Nombre);
            command.Parameters.AddWithValue("@marca", cerveza.Marca);
            command.Parameters.AddWithValue("@alcohol", cerveza.Alcohol);
            command.Parameters.AddWithValue("@cantidad", cerveza.Cantidad);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Edit(Cerveza cerveza, int id)
        {
            string query = "UPDATE cerveza SET " +
                "nombre = @nombre, marca = @marca, alcohol = @alcohol, cantidad = @cantidad " + 
                "WHERE id = @id";
            using var connection = new MySqlConnection(connectionString);
            var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@nombre", cerveza.Nombre);
            command.Parameters.AddWithValue("@marca", cerveza.Marca);
            command.Parameters.AddWithValue("@alcohol", cerveza.Alcohol);
            command.Parameters.AddWithValue("@cantidad", cerveza.Cantidad);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(int id)
        {
            string query = "DELETE FROM cerveza " +
                "WHERE id = @id";
            using var connection = new MySqlConnection(connectionString);
            var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
