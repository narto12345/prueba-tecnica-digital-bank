using Backend_PruebaDigitalBank.Data.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace Backend_PruebaDigitalBank.Data.DAO;

public class UserSQLServer : IUserDAO
{

	private readonly string connectionString;

	public UserSQLServer()
	{
		connectionString = "Server=localhost;Database=prueba_digital_bank;User ID=root;Password=12345;";
	}

	public async Task<List<User>> GetAll()
	{
		throw new NotImplementedException();
	}

	public async Task<User?> GetById(int id)
	{
		User? user = null;

		using (var conn = new MySqlConnection(connectionString))
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

	public async Task<int> Insert(User user)
	{
		throw new NotImplementedException();
	}

	public async Task<int> Update(User user)
	{
		throw new NotImplementedException();
	}
	public async Task<int> Delete(int id)
	{

		throw new NotImplementedException();
	}
}