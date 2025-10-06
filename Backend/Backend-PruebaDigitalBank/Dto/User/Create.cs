using System.ComponentModel.DataAnnotations;

namespace Backend_PruebaDigitalBank.Dto.User
{
	public class Create
	{
		[Required(ErrorMessage = "El campo {0} es requerido")]
		[StringLength(100, ErrorMessage = "El campo {0} no puede superar los {1} caracteres")]
		public string? Name { get; set; }

		[Required(ErrorMessage = "El campo {0} es requerido")]
		public DateOnly? Birthdate { get; set; }

		[Required(ErrorMessage = "El campo {0} es requerido")]
		public char? Gender { get; set; }
	}
}
