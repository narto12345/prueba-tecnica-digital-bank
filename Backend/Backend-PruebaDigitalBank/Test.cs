using Data.DAO;
using Data.Models;

namespace Backend_PruebaDigitalBank;

public class Test : BackgroundService
{
	private readonly IUserDAO _userDAO;
	public Test(IUserDAO userDAO)
	{
		_userDAO = userDAO;
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		User? userFounded = await _userDAO.GetById(4);

		Console.WriteLine(userFounded);
	}
}