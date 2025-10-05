using System.ComponentModel.DataAnnotations;

namespace Backend_PruebaDigitalBank.Dto.User;

public class Update
{

	[Required(ErrorMessage = "El campo {0} es requerido")]
	public int? Id { get; set; }

	[Required(ErrorMessage = "El campo {0} es requerido")]
	public string? Name { get; set; }

	[Required(ErrorMessage = "El campo {0} es requerido")]
	public DateOnly? Birthdate { get; set; }

	[Required(ErrorMessage = "El campo {0} es requerido")]
	public char? Gender { get; set; }
}