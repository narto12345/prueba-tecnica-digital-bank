using Data.Models;

namespace Data.DAO;

public interface IUserDAO
{
	Task<int> Insert(Dto.User.Create create);
	Task<User?> GetById(int id);
	Task<List<User>> GetAll();
	Task<User?> Update(User user);
	Task<int> Delete(int id);
}
