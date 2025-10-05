using MediatR;
using System.Net;

namespace Business.Handlers.User;

public class Update : IRequestHandler<Commands.User.Update, Commands.User.UpdateResponse>
{
	private readonly Data.DAO.IUserDAO _user;
	public Update(Data.DAO.IUserDAO user)
	{
		_user = user;
	}

	public async Task<Commands.User.UpdateResponse> Handle(Commands.User.Update request, CancellationToken cancellationToken)
	{

		try
		{
			return await HandleInternal(request, cancellationToken);
		}
		catch (Exception ex)
		{
			return new Commands.User.UpdateResponse()
			{
				Success = false,
				StatusCode = HttpStatusCode.InternalServerError,
				ErrorMessage = ex.Message
			};
		}

	}

	private async Task<Commands.User.UpdateResponse> HandleInternal(Commands.User.Update request, CancellationToken cancellationToken)
	{
		Data.Models.User? updatedUser = await _user.Update(request.UpdatedUser);

		if (updatedUser is null)
		{
			return new Commands.User.UpdateResponse()
			{
				Success = false,
				StatusCode = HttpStatusCode.NotFound,
				ErrorMessage = "El usuario no existe"
			};
		}

		return new Commands.User.UpdateResponse()
		{
			Success = true,
			StatusCode = HttpStatusCode.OK,
			User = updatedUser
		};
	}
}