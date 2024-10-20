using BookStore.Models.Domain;
using BookStore.Repositories.Absract;

namespace BookStore.Repositories.Implementation
{
	public class AutherService : IAutherService
	{
		private readonly DatabaseContext context;
		public AutherService(DatabaseContext context)
		{
			this.context = context;
		}
		public bool Add(Auther model)
		{
			try
			{
				context.Auther.Add(model);
				context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public bool Delete(int id)
		{
			try
			{
				var data = FindById(id);
				if (data == null)
					return false;

				context.Auther.Remove(data);
				context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public Auther FindById(int id)
		{
			return context.Auther.Find(id);
		}

		public IEnumerable<Auther> GetAll()
		{
			return context.Auther.ToList();
		}

		public bool Update(Auther model)
		{
			try
			{
				context.Auther.Update(model);
				context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
	}
}
