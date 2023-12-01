using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ApiEntityDapper.Infra
{
	public class ApiDapperContext : IDisposable
	{
		public IDbConnection Connection {get;}

		public ApiDapperContext(IConfiguration configuration)
		{
			Connection = new SqlConnection(configuration.GetSection("DatabaseSetting:ConnectionString").Value);

			Connection.Open();
		}

		public void Dispose() => Connection?.Dispose();
    }
}

