using Core.Interfaces;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification() { }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        //Expression for .Where() linq method
        public Expression<Func<T, bool>>? Criteria { get; }

        //Expression for loading related entities
        public List<Expression<Func<T, object>>> Includes { get; } =
            new List<Expression<Func<T, object>>>();

        //How many entities to take for pagination
        public int Take { get; private set; }

        //How many entities to skip for pagination
        public int Skip { get; private set; }
        public bool IsPagingEnabled { get; private set; }

        //Type of ordering
        public Expression<Func<T, object>>? OrderBy { get; private set; }

        public Expression<Func<T, object>>? OrderByDescending { get; private set; }

        public Expression<Func<T, object>>? OrderByAnimal { get; private set; }

        protected void ConfigureOrderBy(string? sort, Expression<Func<T, object>> orderExpression)
        {
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        AddOrderBy(orderExpression);
                        break;
                    case "priceDsc":
                        AddOrderByDescending(orderExpression);
                        break;
                    default:
                        AddOrderBy(orderExpression);
                        break;
                }
            }
        }

        //Overloaded version to specify a default sorting
        protected void ConfigureOrderBy(
            string? sort,
            Expression<Func<T, object>> mainOrderExpression,
            Expression<Func<T, object>> defaultOrderExpression
        )
        {
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        AddOrderBy(mainOrderExpression);
                        break;
                    case "priceDsc":
                        AddOrderByDescending(mainOrderExpression);
                        break;
                    default:
                        AddOrderBy(defaultOrderExpression);
                        break;
                }
            }
            else
            {
                AddOrderBy(defaultOrderExpression);
            }
        }

        private void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        private void AddOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }

        private void AddOrderByAnimal(Expression<Func<T, object>> orderByAnimalExpression)
        {
            OrderByAnimal = orderByAnimalExpression;
        }

        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}
