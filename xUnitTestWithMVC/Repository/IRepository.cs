namespace xUnitTestWithMVC.Repository
{
	public interface IRepository<T> where T : class
	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> GetByID(int id);
		Task Create(T  entity);
		void Update(T entity);
		void Delete(T entity);
	}
}
