using BookStore.Models.Domain;

namespace BookStore.Repositories.Absract
{
	public interface IAutherService
	{
		bool Add(Auther model);

		bool Update(Auther model);
		bool Delete(int id);

		Auther FindById(int id);

		IEnumerable<Auther> GetAll();
	}
}
