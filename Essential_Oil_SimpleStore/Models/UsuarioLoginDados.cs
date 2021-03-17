using MySqlConnector;

namespace ETAPA3.Models
{
    public class UsuarioLoginDados
    {
        private const string SqlConexao = "Database=PEDIDO; Data Source=localhost; User Id=root";
         public UsuarioLogin TesteLogin(UsuarioLogin usuario)
        {
            MySqlConnection Conexao = new MySqlConnection(SqlConexao);
            Conexao.Open();
            string Query = "SELECT * FROM Usuario WHERE Login = @Login AND Senha = @Senha";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Login", usuario.Login);
            Comando.Parameters.AddWithValue("@Senha", usuario.Senha);
            MySqlDataReader Reader = Comando.ExecuteReader();

            UsuarioLogin UsuarioEncontrado = null;

            if(Reader.Read())
            {
                UsuarioEncontrado = new UsuarioLogin();
                UsuarioEncontrado.Login = Reader.GetString("Login");
                
                if(!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                    UsuarioEncontrado.Login = Reader.GetString("Login");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                    UsuarioEncontrado.Senha = Reader.GetString("Senha");
            }
            Conexao.Close();

            return UsuarioEncontrado;
        }
     
        public void InserirUser(UsuarioPedido usuario)
        {
            MySqlConnection Conexao = new MySqlConnection(SqlConexao);
            Conexao.Open();
            string Query = "INSERT INTO PedidoDados (Nome, Email, Produto) VALUES (@Nome, @Email, @Produto)";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Nome", usuario.Nome);
            Comando.Parameters.AddWithValue("@Email", usuario.Email);
            Comando.Parameters.AddWithValue("@Produto", usuario.Produto);
            Comando.ExecuteNonQuery();

            Conexao.Close();
        }
    }
} 