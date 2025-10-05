using MediatR;

namespace Backend_PruebaDigitalBank
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			// Mediator Configuration
			builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(System.Reflection.Assembly.GetExecutingAssembly()));

			// Dependency Injection
			builder.Services.AddSingleton<Data.DAO.IUserDAO, Data.DAO.UserMySql>();

			// Handlers
			builder.Services.AddSingleton<IRequestHandler<Business.Commands.User.GetById, Business.Commands.User.GetIdResponse>, Business.Handlers.User.GetById>();
			builder.Services.AddSingleton<IRequestHandler<Business.Commands.User.GetAll, Business.Commands.User.GetAllResponse>, Business.Handlers.User.GetAll>();
			builder.Services.AddSingleton<IRequestHandler<Business.Commands.User.Create, Business.Commands.User.CreateResponse>, Business.Handlers.User.Create>();

			// Test
			builder.Services.AddHostedService<Test>();

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
