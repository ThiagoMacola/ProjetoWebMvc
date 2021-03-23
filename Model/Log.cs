using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Log
	{
		public const String INSERT = "INSERT INTO TB_LOG (data, descricao) VALUES (GETDATE(), '{0}' )";
		public const String SELECT = "SELECT data, descricao FROM TB_LOG";
		public DateTime Data { get; set; }
		public string Descricao { get; set; }


	}
}
