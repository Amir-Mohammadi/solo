using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using Microsoft.Extensions.Logging;

namespace Solo.Base.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class 
    {

        protected AppDbContext dbContext;
        internal DbSet<TEntity> dbSet;
        public readonly ILogger _logger;
        public Repository(AppDbContext context , ILogger logger)
        {
            this.dbContext = context;
            this.dbSet = context.Set<TEntity>();
            _logger = logger;
        }

        public virtual async Task<bool> Add(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }
        // private readonly AppDbContext dbContext;
        // private DbSet<TEntity> Entities { get; }
        // public Repository(AppDbContext dbContext)
        // {
        //     this.dbContext = dbContext;
        //     Entities = this.dbContext.Set<TEntity>();
        // }
        // public virtual void Add(TEntity entity, bool saveNow = true)
        // {
        //     Entities.Add(entity);
        //     if (saveNow)
        //         dbContext.SaveChanges();
        // }

    }
}

