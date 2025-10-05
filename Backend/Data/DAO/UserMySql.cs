using Data.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace Data.DAO;

public class UserMySql : IUserDAO
{

	private readonly string _connectionString;

	public UserMySql(IConfiguration configuration)
	{
		_connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string not found!");
	}

	public async Task<List<User>> GetAll()
	{
		List<User>? users = new();

		using (var conn = new MySqlConnection(_connectionString))
		using (var cmd = new MySqlCommand("sp_users_crud", conn))
		{
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@p_action", "SELECT");
			cmd.Parameters.AddWithValue("@p_id", null);
			cmd.Parameters.AddWithValue("@p_name", null);
			cmd.Parameters.AddWithValue("@p_birthdate", null);
			cmd.Parameters.AddWithValue("@p_gender", null);

			await conn.OpenAsync();


			using (System.Data.Common.DbDataReader reader = await cmd.ExecuteReaderAsync())
			{
				while (await reader.ReadAsync())
				{
					User user = new User
					{
						Id = reader.GetInt32("Id"),
						Name = reader.GetString("Name"),
						Birthdate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("birthdate"))),
						Gender = reader.GetChar(reader.GetOrdinal("gender"))
					};

					users.Add(user);
				}
			}
		}

		return users;
	}

	public async Task<User?> GetById(int id)
	{
		User? user = null;

		using (var conn = new MySqlConnection(_connectionString))
		using (var cmd = new MySqlCommand("sp_users_crud", conn))
		{
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@p_action", "SELECT");
			cmd.Parameters.AddWithValue("@p_id", id);
			cmd.Parameters.AddWithValue("@p_name", null);
			cmd.Parameters.AddWithValue("@p_birthdate", null);
			cmd.Parameters.AddWithValue("@p_gender", null);

			await conn.OpenAsync();

			using (System.Data.Common.DbDataReader reader = await cmd.ExecuteReaderAsync())
			{
				if (await reader.ReadAsync())
				{
					user = new User()
					{
						Id = reader.GetInt32(reader.GetOrdinal("id")),
						Name = reader.GetString(reader.GetOrdinal("name")),
						Birthdate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("birthdate"))),
						Gender = reader.GetChar(reader.GetOrdinal("gender"))
					};
				}
			}
		}

		return user;
	}

	public async Task<int> Insert(Dto.User.Create create)
	{
		int result = 0;

		using (var conn = new MySqlConnection(_connectionString))
		using (var cmd = new MySqlCommand("sp_users_crud", conn))
		{
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@p_action", "INSERT");
			cmd.Parameters.AddWithValue("@p_id", null);
			cmd.Parameters.AddWithValue("@p_name", create.Name);
			cmd.Parameters.AddWithValue("@p_birthdate", create.Birthdate.ToString("yyyy-MM-dd"));
			cmd.Parameters.AddWithValue("@p_gender", create.Gender);

			await conn.OpenAsync();

			using (System.Data.Common.DbDataReader reader = await cmd.ExecuteReaderAsync())
			{
				if (await reader.ReadAsync())
				{
					result = reader.GetInt32(reader.GetOrdinal("new_id"));
				}
			}
		}

		return result;
	}

	public async Task<User?> Update(User user)
	{
		User? updatedUser = null;

		using (var conn = new MySqlConnection(_connectionString))
		using (var cmd = new MySqlCommand("sp_users_crud", conn))
		{
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@p_action", "UPDATE");
			cmd.Parameters.AddWithValue("@p_id", user.Id);
			cmd.Parameters.AddWithValue("@p_name", user.Name);
			cmd.Parameters.AddWithValue("@p_birthdate", user.Birthdate.ToString("yyyy-MM-dd"));
			cmd.Parameters.AddWithValue("@p_gender", user.Gender);

			await conn.OpenAsync();

			using (System.Data.Common.DbDataReader reader = await cmd.ExecuteReaderAsync())
			{
				if (await reader.ReadAsync())
				{
					updatedUser = new User()
					{
						Id = reader.GetInt32(reader.GetOrdinal("id")),
						Name = reader.GetString(reader.GetOrdinal("name")),
						Birthdate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("birthdate"))),
						Gender = reader.GetChar(reader.GetOrdinal("gender"))
					};
				}
			}
		}

		return updatedUser;
	}
	public async Task<int> Delete(int id)
	{

		int result = 0;

		using (var conn = new MySqlConnection(_connectionString))
		using (var cmd = new MySqlCommand("sp_users_crud", conn))
		{
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@p_action", "DELETE");
			cmd.Parameters.AddWithValue("@p_id", id);
			cmd.Parameters.AddWithValue("@p_name", null);
			cmd.Parameters.AddWithValue("@p_birthdate", null);
			cmd.Parameters.AddWithValue("@p_gender", null);

			await conn.OpenAsync();

			using (System.Data.Common.DbDataReader reader = await cmd.ExecuteReaderAsync())
			{
				if (await reader.ReadAsync())
				{
					result = reader.GetInt32(reader.GetOrdinal("deleted_rows"));
				}
			}
		}

		return result;
	}
}