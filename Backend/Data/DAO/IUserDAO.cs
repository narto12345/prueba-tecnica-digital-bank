using Data.Models;

namespace Data.DAO;

public interface IUserDAO
{
	Task<int> Insert(User user);
	Task<User?> GetById(int id);
	Task<List<User>> GetAll();
	Task<int> Update(User user);
	Task<int> Delete(int id);
}
