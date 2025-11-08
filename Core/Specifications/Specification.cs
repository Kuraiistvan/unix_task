using System.Linq.Expressions;
using Core.Interfaces;

namespace Core.Specifications;

public class Specification<T>(Expression<Func<T, bool>>? criteria) : ISpecification<T>
{
    protected Specification() : this(null) { }

    public Expression<Func<T, bool>>? Criteria => criteria;

    public Expression<Func<T, object>>? OrderBy { get; private set; }

    public Expression<Func<T, object>>? OrderByDesc { get; private set; }

    public Expression<Func<T, bool>>? PriceBetween { get; private set; }

    public int Take { get; private set; }

    public int Skip { get; private set; }

    public bool IsPagingEnabled { get; private set; }

    protected void AddOrderBy(Expression<Func<T, object>>? expression)
    {
        OrderBy = expression;
    }

    protected void AddOrderByDesc(Expression<Func<T, object>>? expression)
    {
        OrderByDesc = expression;
    }

    protected void AddPriceBetween(Expression<Func<T, bool>>? expression)
    {
        PriceBetween = expression;
    }

    public void ApplyPaging(int skip, int take)
    {
        Take = take;
        Skip = skip;
        IsPagingEnabled = true;
    }

    public IQueryable<T> ApplyCriteria(IQueryable<T> query)
    {
        if (Criteria != null)
            query = query.Where(Criteria);

        return query;
    }
}