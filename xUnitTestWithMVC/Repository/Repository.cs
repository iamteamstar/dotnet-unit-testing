using Microsoft.EntityFrameworkCore;
using xUnitTestWithMVC.Models;

namespace xUnitTestWithMVC.Repository
{
	public class Repository<T>:IRepository<T> where T : class
	{
		private readonly DbSet<T> _dbSet;
		private readonly XUnitTestMvcDbContext _context;
		public Repository(XUnitTestMvcDbContext context)
		{
			_context = context;
			_dbSet=_context.Set<T>();
		}

		async Task IRepository<T>.Create(T entity)
		{
			await _dbSet.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public void Delete(T entity)
		{
			 _dbSet.Remove(entity);
			 _context.SaveChanges();
		}

		async Task<IEnumerable<T>> IRepository<T>.GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		async Task<T> IRepository<T>.GetByID(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public void Update(T entity)
		{
			_context.Entry(entity).State = EntityState.Modified;//ef memoryde ne kadar modşfşed olan data varsa db ye yansıtır bundan dolayı await yok aynı şey delete için de geçreli o da entityState yi deleted yapar
			_context.SaveChanges();
		}
	}
}
