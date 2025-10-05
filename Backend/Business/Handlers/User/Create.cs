using MediatR;
using System.Net;

namespace Business.Handlers.User;

public class Create : IRequestHandler<Commands.User.Create, Commands.User.CreateResponse>
{
	private readonly Data.DAO.IUserDAO _user;
	public Create(Data.DAO.IUserDAO user)
	{
		_user = user;
	}

	public async Task<Commands.User.CreateResponse> Handle(Commands.User.Create request, CancellationToken cancellationToken)
	{

		try
		{
			return await HandleInternal(request, cancellationToken);
		}
		catch (Exception ex)
		{
			return new Commands.User.CreateResponse()
			{
				Success = false,
				StatusCode = HttpStatusCode.InternalServerError,
				ErrorMessage = ex.Message
			};
		}

	}

	private async Task<Commands.User.CreateResponse> HandleInternal(Commands.User.Create request, CancellationToken cancellationToken)
	{
		int userId = await _user.Insert(request.NewUser);

		if (userId == 0)
		{
			return new Commands.User.CreateResponse()
			{
				Success = false,
				StatusCode = HttpStatusCode.InternalServerError,
				ErrorMessage = "El usuario no pudo ser creado"
			};
		}

		return new Commands.User.CreateResponse()
		{
			Success = true,
			StatusCode = HttpStatusCode.Created,
			User = new Data.Models.User()
			{
				Id = userId,
				Name = request.NewUser.Name,
				Birthdate = request.NewUser.Birthdate,
				Gender = request.NewUser.Gender
			}
		};
	}
}