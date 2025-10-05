using MediatR;
using System.Net;

namespace Business.Commands.User;

public class Create : IRequest<CreateResponse>
{
	public required Data.Dto.User.Create NewUser { get; set; }
}

public class CreateResponse
{
	public required bool Success { get; set; }
	public required HttpStatusCode StatusCode { get; set; }
	public Data.Models.User? User { get; set; }
	public string? ErrorMessage { get; set; }
}