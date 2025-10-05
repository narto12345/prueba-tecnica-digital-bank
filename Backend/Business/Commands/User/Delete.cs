using MediatR;
using System.Net;

namespace Business.Commands.User;

public class Delete : IRequest<DeleteResponse>
{
	public int Id { get; set; }
}

public class DeleteResponse
{
	public required bool Success { get; set; }
	public required HttpStatusCode StatusCode { get; set; }
	public string? ErrorMessage { get; set; }
}