namespace Data.Models;

public class User
{
	public User() { }

	public required int Id { get; set; }
	public required string Name { get; set; }
	public required DateOnly Birthdate { get; set; }
	public required char Gender { get; set; }

	public string BirthdateFormatted => Birthdate.ToString("yyyy-MM-dd");

	public override string? ToString()
	{
		return $"{Id} - {Name} - {BirthdateFormatted} - {Gender}";
	}
}