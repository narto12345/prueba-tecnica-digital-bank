using MediatR;
using System.Net;

namespace Business.Commands.User;

public class Update : IRequest<UpdateResponse>
{
	public required Data.Models.User UpdatedUser { get; set; }
}

public class UpdateResponse
{
	public required bool Success { get; set; }
	public required HttpStatusCode StatusCode { get; set; }
	public Data.Models.User? User { get; set; }
	public string? ErrorMessage { get; set; }
}