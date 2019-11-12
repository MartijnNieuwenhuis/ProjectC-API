using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Model.Core;
using DAL;

namespace Business.Core
{
    internal class ModelService<T> where T : class, BaseModel
    {
        private const String BEGIN_TRANSACTION_EXCEPTION_MESSAGE =
            "When ids are set manually. It is required to save this in a transaction";

        public ContextService ContextService { get; set; }

        protected String TableName { get; set; }

        public Context Context => this.ContextService.Context;

        public ObjectContext ObjectContext => ((IObjectContextAdapter)this.Context).ObjectContext;

        internal IQueryable<T> Data
        {
            get { return this.Context.Set<T>(); }
        }

        internal ModelService(ContextService contextService)
        {
            this.ContextService = contextService;
            this.TableName = this.Context.GetTableName<T>();
        }

        internal DbContextTransaction BeginTransaction()
        {
            return this.Context.Database.BeginTransaction();
        }

        internal void AddOrUpdate(T entity)
        {
            this.Context.Set<T>()
                .AddOrUpdate(entity);
        }

        internal void AddOrUpdate(IEnumerable<T> entities)
        {
            this.Context.Set<T>()
                .AddOrUpdate(entities.ToArray());
        }

        internal void Delete(T entity)
        {
            this.Context.Set<T>()
                .Remove(entity);
        }

        internal virtual T Get(Guid id)
        {
            return this.Data
                .Where(d => d.Id == id)
                .Single();
        }

        internal virtual void SaveChanges()
        {
            this.ContextService.SaveChanges();
        }
    }
}