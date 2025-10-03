using MediatR;
using System.Net;

namespace Business.Handlers.User;

public class GetById : IRequestHandler<Commands.User.GetById, Commands.User.GetIdResponse>
{
	private readonly Data.DAO.IUserDAO _user;
	public GetById(Data.DAO.IUserDAO user)
	{
		_user = user;
	}

	public async Task<Commands.User.GetIdResponse> Handle(Commands.User.GetById request, CancellationToken cancellationToken)
	{

		try
		{
			return await HandleInternal(request, cancellationToken);
		}
		catch (Exception ex)
		{
			return new Commands.User.GetIdResponse()
			{
				Success = false,
				StatusCode = HttpStatusCode.InternalServerError,
				ErrorMessage = ex.Message
			};
		}

	}

	private async Task<Commands.User.GetIdResponse> HandleInternal(Commands.User.GetById request, CancellationToken cancellationToken)
	{
		Data.Models.User? userFounded = await _user.GetById(request.Id);

		if (userFounded == null)
		{
			return new Commands.User.GetIdResponse()
			{
				Success = false,
				StatusCode = HttpStatusCode.NotFound,
				ErrorMessage = "El usuario no existe"
			};
		}

		return new Commands.User.GetIdResponse()
		{
			Success = true,
			StatusCode = HttpStatusCode.OK,
			User = userFounded
		};
	}
}