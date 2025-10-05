namespace Data.Dto.User;

public class Create
{
	public required string Name { get; set; }
	public required DateOnly Birthdate { get; set; }
	public required char Gender { get; set; }
}