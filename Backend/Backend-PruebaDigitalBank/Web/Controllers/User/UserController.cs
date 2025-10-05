using MediatR;
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

	[HttpPost]
	public async Task<ActionResult> Create([FromBody] Dto.User.Create create)
	{
		Business.Commands.User.CreateResponse result = await _mediator.Send(new Business.Commands.User.Create()
		{
			NewUser = new Data.Dto.User.Create()
			{
				Name = create.Name!,
				Birthdate = (DateOnly)create.Birthdate!,
				Gender = (char)create.Gender!,
			}
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

	[HttpPut]
	public async Task<ActionResult> Update([FromBody] Dto.User.Update update)
	{
		Business.Commands.User.UpdateResponse result = await _mediator.Send(new Business.Commands.User.Update()
		{
			UpdatedUser = new Data.Models.User()
			{
				Id = (int)update.Id!,
				Name = update.Name!,
				Birthdate = (DateOnly)update.Birthdate!,
				Gender = (char)update.Gender!,
			}
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

	[HttpDelete("{id:int}")]
	public async Task<ActionResult> Delete(int id)
	{
		Business.Commands.User.DeleteResponse result = await _mediator.Send(new Business.Commands.User.Delete()
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

		return StatusCode((int)result.StatusCode);
	}
}