using MediatR;
using System.Net;

namespace Business.Handlers.User;

public class Delete : IRequestHandler<Commands.User.Delete, Commands.User.DeleteResponse>
{
	private readonly Data.DAO.IUserDAO _user;
	public Delete(Data.DAO.IUserDAO user)
	{
		_user = user;
	}

	public async Task<Commands.User.DeleteResponse> Handle(Commands.User.Delete request, CancellationToken cancellationToken)
	{

		try
		{
			return await HandleInternal(request, cancellationToken);
		}
		catch (Exception ex)
		{
			return new Commands.User.DeleteResponse()
			{
				Success = false,
				StatusCode = HttpStatusCode.InternalServerError,
				ErrorMessage = ex.Message
			};
		}

	}

	private async Task<Commands.User.DeleteResponse> HandleInternal(Commands.User.Delete request, CancellationToken cancellationToken)
	{
		int result = await _user.Delete(request.Id);

		if (result == 0)
		{
			return new Commands.User.DeleteResponse()
			{
				Success = false,
				StatusCode = HttpStatusCode.NotFound,
				ErrorMessage = "El usuario no existe"
			};
		}

		return new Commands.User.DeleteResponse()
		{
			Success = true,
			StatusCode = HttpStatusCode.OK
		};
	}
}