using MediatR;
using System.Net;

namespace Business.Handlers.User;

public class GetAll : IRequestHandler<Commands.User.GetAll, Commands.User.GetAllResponse>
{
	private readonly Data.DAO.IUserDAO _user;
	public GetAll(Data.DAO.IUserDAO user)
	{
		_user = user;
	}

	public async Task<Commands.User.GetAllResponse> Handle(Commands.User.GetAll request, CancellationToken cancellationToken)
	{

		try
		{
			return await HandleInternal(request, cancellationToken);
		}
		catch (Exception ex)
		{
			return new Commands.User.GetAllResponse()
			{
				Success = false,
				StatusCode = HttpStatusCode.InternalServerError,
				ErrorMessage = ex.Message
			};
		}

	}

	private async Task<Commands.User.GetAllResponse> HandleInternal(Commands.User.GetAll request, CancellationToken cancellationToken)
	{
		List<Data.Models.User> usersFound = await _user.GetAll();

		return new Commands.User.GetAllResponse()
		{
			Success = true,
			StatusCode = HttpStatusCode.OK,
			User = usersFound.ToArray(),
		};
	}
}