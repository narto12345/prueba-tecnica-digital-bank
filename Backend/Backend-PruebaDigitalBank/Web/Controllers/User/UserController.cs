using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend_PruebaDigitalBank.Web.Controllers.User;

[ApiController]
[Route("/api/users")]
public class UserController : ControllerBase
{
	private readonly IMediator _mediator;

	public UserController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet("{id:int}")]
	public async Task<ActionResult> GetById(int id)
	{
		Business.Commands.User.GetIdResponse result = await _mediator.Send(new Business.Commands.User.GetById()
		{
			Id = id
		});

		if (!result.Success)
		{
			return StatusCode((int)result.StatusCode, new
			{
				Status = result.StatusCode,
				Message = result.ErrorMessage
			});
		}

		return StatusCode((int)result.StatusCode, new
		{
			Status = result.StatusCode,
			Data = result.User
		});
	}

	[HttpGet]
	public async Task<ActionResult> GetAll()
	{
		Business.Commands.User.GetAllResponse result = await _mediator.Send(new Business.Commands.User.GetAll());

		if (!result.Success)
		{
			return StatusCode((int)result.StatusCode, new
			{
				Status = result.StatusCode,
				Message = result.ErrorMessage
			});
		}

		return StatusCode((int)result.StatusCode, new
		{
			Status = result.StatusCode,
			Data = result.User
		});
	}
}