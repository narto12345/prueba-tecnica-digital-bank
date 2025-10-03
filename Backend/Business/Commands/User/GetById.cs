using MediatR;
using System.Net;

namespace Business.Commands.User;

public class GetById : IRequest<GetIdResponse>
{
	public int Id { get; set; }
}

public class GetIdResponse
{
	public required bool Success { get; set; }
	public required HttpStatusCode StatusCode { get; set; }
	public Data.Models.User? User { get; set; }
	public string? ErrorMessage { get; set; }
}