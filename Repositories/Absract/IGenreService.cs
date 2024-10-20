using BookStore.Models.Domain;

namespace BookStore.Repositories.Absract
{
    public interface IGenreService
    {
        bool Add(Genre model);

        bool Update(Genre model);
        bool Delete(int id);

        Genre FindById(int id);

        IEnumerable<Genre> GetAll();

    }
}
