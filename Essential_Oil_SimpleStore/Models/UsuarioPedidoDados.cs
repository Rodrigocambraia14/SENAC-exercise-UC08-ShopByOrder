using MySqlConnector;
using System.Collections.Generic;


namespace ETAPA3.Models
{
    public  class UsuarioPedidoDados
    {
       private const string SqlConexao = "Database=PEDIDO; Data Source=localhost; User Id=root";

      

        
        public List<UsuarioPedido> ListarUser()
        {
            MySqlConnection Conexao = new MySqlConnection(SqlConexao);
            Conexao.Open();
            string Query = "SELECT * FROM PedidoDados";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            MySqlDataReader Reader = Comando.ExecuteReader();

            List<UsuarioPedido> Lista = new List<UsuarioPedido>();

            while(Reader.Read())
            {
                UsuarioPedido UsuarioEncontrado = new UsuarioPedido();
                UsuarioEncontrado.Nome = Reader.GetString("Nome");
                
                if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    UsuarioEncontrado.Nome = Reader.GetString("Nome");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Email")))
                    UsuarioEncontrado.Email = Reader.GetString("Email");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Produto")))
                    UsuarioEncontrado.Produto = Reader.GetString("Produto");
                
                Lista.Add(UsuarioEncontrado);
            }
            Conexao.Close();

            return Lista;
            
        }
        public void RemoverUser(string Email)
        {
            MySqlConnection Conexao = new MySqlConnection(SqlConexao);
            Conexao.Open();
            string Query = "DELETE FROM PedidoDados WHERE Email=@Email";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Email", Email);
            Comando.ExecuteNonQuery();

            Conexao.Close();
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