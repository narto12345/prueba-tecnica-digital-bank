using Backend_PruebaDigitalBank.Data.DAO;
using Backend_PruebaDigitalBank.Data.Models;

namespace Backend_PruebaDigitalBank
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			// Dependency Injection
			builder.Services.AddSingleton<IUserDAO, UserSQLServer>();

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthorization();

			app.MapControllers();

			app.Run();

			//IUserDAO userDAO = new UserSQLServer();

			//User? userFounded = await userDAO.GetById(4);

			//Console.WriteLine(userFounded);
		}
	}
}
