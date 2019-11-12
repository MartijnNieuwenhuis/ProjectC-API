using Extensions.LinqHelpers;
using Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Business.Core
{
    public class BaseService<T> where T : class, BaseModel, new()
    {
        private readonly ModelService<T> modelService;

        protected ContextService ContextService
        {
            get
            {
                return this.modelService.ContextService;
            }
        }

        private IQueryable<T> data { get { return this.modelService.Data; } }

        internal BaseService(ModelService<T> modelService)
        {
            this.modelService = modelService;
        }

        internal IQueryable<T> Get(Guid id)
        {
            return (IQueryable<T>)this.data
                 .Where(dto => dto.Id == id);
        }

        private String GetOrderBy(Expression<Func<T, Object>> orderByExpression)
        {
            MemberExpression memberExpr;

            if (orderByExpression.Body.NodeType == ExpressionType.Convert)
            {
                memberExpr = ((UnaryExpression)orderByExpression.Body).Operand as MemberExpression;
            }
            else
            {
                memberExpr = orderByExpression.Body as MemberExpression;
            }

            return memberExpr.Member.Name;
        }

        protected IQueryable<TModel> Get<TModel>(Expression<Func<T, Object>> orderByExpression, LinqExtensions.Order order = LinqExtensions.Order.Asc)
        {
            return (IQueryable<TModel>)this.data
                .OrderByDynamic(this.GetOrderBy(orderByExpression), order);
        }

        protected T Get<TModel>(Guid id)
        {
            return this.Get(id)
                 .Single();
        }

        protected void Save(ref T entity)
        {
            this.modelService.AddOrUpdate(entity);

            this.modelService.SaveChanges();
        }

        protected void Delete(Guid id)
        {
            T entity = this.Get(id)
                .Single();

            this.modelService.Delete(entity);
        }
    }
}