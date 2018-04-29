using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAB3_2
{
    public class UnitOfWork<T> where T : class
    {
        public DbContext Context { get; set; }
        public Repository<T> Repository;

        public UnitOfWork(DbContext context)
        {
            Context = context;
            Repository = new Repository<T>(Context);
        }
        

        public void Complete()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
