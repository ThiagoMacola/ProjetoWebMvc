using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Util
{
    public class ConnectionDB : IDisposable
    {
        private static SqlConnection _conn;

        public ConnectionDB() // ABRIU CONEXÃO
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexaoSQLServer"].ConnectionString); 
            _conn.Open();
        }

        public bool ExecQuery(string query) // INSTANCIANDO AÇÃO NO BANCO DE DADOS
        {
            var cmd = new SqlCommand // AÇÃO DENTRO DO BANCO
            {
                CommandText = query,
                CommandType = CommandType.Text,
                Connection = _conn
            };
            return (cmd.ExecuteNonQuery() == 1) ? true : false;

        }

        public SqlDataReader ExecQueryReturn(string query)
        {
            var cmd = new SqlCommand(query, _conn);
            return cmd.ExecuteReader();
        }	


        public void Dispose()
        {
            if (_conn.State == ConnectionState.Open)
            {
                _conn.Close();
                _conn.Dispose();
            }
        }
    }
}