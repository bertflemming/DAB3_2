using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace DAB3_2
{
    public class Repository<T> where T : class
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Create(T t)
        {
            _context.Set<T>().Add(t);
        }

        public T Read(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public DbSet<T> ReadAll()
        {
            return _context.Set<T>();
        }

        public void Update(T t)
        {
            _context.Entry(t).State = EntityState.Modified;
        }

        public void Delete(T t, int id)
        {
            if(_context.Set<T>().Find(id) == null)
                throw new InvalidOperationException();

            _context.Set<T>().Remove(t);
        }
    }
}
