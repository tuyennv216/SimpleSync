using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleSync
{
	public class Database
	{
		private static Database instance = new Database();
		public static Database i => instance;

		private readonly string connectString;

		public Func<int, SqliteConnection> memConnectShare;
		public SqliteConnection memConnect => new SqliteConnection("Data Source=:memory:");
		public SqliteConnection newConnect => new SqliteConnection(connectString);

		public Func<SqliteConnection, string, Task<int>> RunNonQuery;
		public Func<SqliteConnection, string, Task<object>> RunScalar;
		public Func<SqliteConnection, string, IEnumerable<KeyValuePair<string, object>>, Task<int>> RunNonQueryParams;
		public Func<SqliteConnection, string, IEnumerable<KeyValuePair<string, object>>, Task<object>> RunScalarParams;

		public Func<SqliteConnection, string, Task<SqliteDataReader>> RunReader;
		public Func<SqliteConnection, string, IEnumerable<KeyValuePair<string, object>>, Task<SqliteDataReader>> RunReaderParams;

		private Database()
		{
			connectString = @"Data Source=" + RunningExe.i.Name + ".sqlite.db";
			memConnectShare = i => new SqliteConnection("Data Source=" + RunningExe.i.Name + i + ";Mode=Memory;Cache=Shared");

			// Query
			RunScalar = (connect, query) => RunScalarParams(connect, query, null);
			RunScalarParams = (connect, query, parameters) =>
			{
				var command = connect.CreateCommand();
				command.CommandText = query;
				if (parameters != null)
				{
					foreach (var item in parameters)
					{
						command.Parameters.AddWithValue(item.Key, item.Value);
					}
				}
				return command.ExecuteScalarAsync();
			};

			// Manipulation
			RunNonQuery = (connect, query) => RunNonQueryParams(connect, query, null);
			RunNonQueryParams = (connect, query, parameters) =>
			{
				var command = connect.CreateCommand();
				command.CommandText = query;
				if (parameters != null)
				{
					foreach (var item in parameters)
					{
						command.Parameters.AddWithValue(item.Key, item.Value);
					}
				}
				return command.ExecuteNonQueryAsync();
			};

			// Reader
			RunReader = (connect, query) => RunReaderParams(connect, query, null);
			RunReaderParams = (connect, query, parameters) =>
			{
				var command = connect.CreateCommand();
				command.CommandText = query;
				if (parameters != null)
				{
					foreach (var item in parameters)
					{
						command.Parameters.AddWithValue(item.Key, item.Value);
					}
				}
				return command.ExecuteReaderAsync();
			};
		}
	}
}
